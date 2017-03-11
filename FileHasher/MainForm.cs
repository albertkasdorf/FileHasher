using FileHasher.Logic;
using FileHasher.ObjectModel;
using FileHasher.Properties;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileHasher
{
	public partial class MainForm : Form
	{
		//----------------------------------------------------------------------
		// Constructors
		//----------------------------------------------------------------------

		public MainForm( )
		{
			InitializeComponent( );

			cancellationTokenSource = new CancellationTokenSource( );
			workerTask = Task.Factory.StartNew( ( ) => { } );
			uiScheduler = TaskScheduler.FromCurrentSynchronizationContext( );

			ProgressInitialize( );
		}


		//----------------------------------------------------------------------
		// Members
		//----------------------------------------------------------------------

		private Database database;
		private CancellationTokenSource cancellationTokenSource;
		private Task workerTask;
		private TaskScheduler uiScheduler;
		private IProgress<UIProgress> progress;


		//----------------------------------------------------------------------
		// Methods ( event )
		//----------------------------------------------------------------------

		private void MainForm_Load( Object sender, EventArgs e )
		{
			TitleWithVersionSet( );
			UserSettingsLoad( );
			DatabaseInitialize( );
		}

		private void MainForm_FormClosing( Object sender, FormClosingEventArgs e )
		{
			e.Cancel = !workerTask.IsCompleted;
			if( e.Cancel )
			{
				MessageBox.Show(
					this,
					Resources.MainForm_CanNotCloseTaskIsRunning,
					Resources.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information );
			}
		}

		private void MainForm_FormClosed( Object sender, FormClosedEventArgs e )
		{
			database.Close( );
			database.Dispose( );

			UserSettingsSave( );
		}

		private void btnDirectories_Click( Object sender, EventArgs e )
		{
			var fbd = new FolderBrowserDialog( )
			{
				ShowNewFolderButton = false,
				Description = string.Empty,
			};
			var dialogResult = fbd.ShowDialog( this );
			if( dialogResult == DialogResult.OK )
			{
				dgvDirectories.Rows.Add( fbd.SelectedPath );
			}
		}

		private void btnStart_Click( Object sender, EventArgs e )
		{
			var results = new List<ResultSet>( );

			UIDisable( );

			cancellationTokenSource = new CancellationTokenSource( );
			workerTask = Task.Factory.StartNew( ( ) =>
			{
				var stack = new Stack<Tuple<Int64, String>>( );
				var searchPaths = UIDirectoriesGet()
					.Where( x => Directory.Exists( x ) )
					.Reverse( )
					.ToList( );
				var fileCount = 0;
				var filesProcessed = 0;

				foreach( var searchPath in searchPaths )
				{
					var id = database.ItemIdGet( searchPath );
					stack.Push( new Tuple<Int64, String>( id, searchPath ) );
				}

				progress.Report(
					new UIProgress( Resources.MainForm_DetermineNumberOfFiles ) );

				fileCount = FileCountDetermine(
					stack.ToList( ).Select( x => x.Item2 ).ToList( ),
					cancellationTokenSource.Token );

				while( stack.Count > 0 )
				{
					var data = stack.Pop( );

					progress.Report(
						new UIProgress( data.Item2, fileCount, filesProcessed ) );

					try
					{
						var dbItems = database.ItemsGet( data.Item1 );
						var fsItems = FileSystem.ItemsGet(
							data.Item2, cancellationTokenSource.Token );

						filesProcessed += fsItems.Count( );

						var fsItemSet = FSItemSetCreator.Create(
							dbItems, fsItems, data.Item2 );

						results.Add( new ResultSet( fsItemSet ) );

						database.Insert( fsItemSet.Added, data.Item1 );
						database.Update( fsItemSet.Changed, data.Item1 );
						database.Delete( fsItemSet.Deleted, data.Item1 );

						var fsDirectoryItems = fsItems
							.Where( fsItem => fsItem.Type == FSType.Directory )
							.Reverse( );
						foreach( var fsDirectoryItem in fsDirectoryItems )
						{
							var nextId = database.ItemIdGet(
								data.Item1, fsDirectoryItem.Name );
							var nextPath = Path.Combine(
								data.Item2, fsDirectoryItem.Name );

							stack.Push( new Tuple<Int64, String>(
								nextId.Value, nextPath ) );
						}
					}
					catch( OperationCanceledException )
					{
						throw;
					}
					catch( Exception ex )
					{
						results.Add( new ResultSet( data.Item2, ex ) );
					}
				}
			}, cancellationTokenSource.Token, TaskCreationOptions.LongRunning,
			TaskScheduler.Default );

			workerTask.ContinueWith( ( _ ) =>
			{
				UIEnable( );

				var resultForm = new ResultForm( results );
				resultForm.ShowDialog( this );
			}, CancellationToken.None, TaskContinuationOptions.None, uiScheduler );
		}

		private void btnCancel_Click( Object sender, EventArgs e )
		{
			cancellationTokenSource.Cancel( );
		}

		private void Progress_ProgressChanged( Object sender, UIProgress e )
		{
			tsslPath.Text = e.Message;
			tspbProgress.Style = e.Style;

			if( TaskbarManager.IsPlatformSupported )
			{
				TaskbarManager.Instance.SetProgressState(
					Mapping.ToTaskbarProgressBarState( e.Style ) );
			}

			if( e.Style == ProgressBarStyle.Continuous )
			{
				tspbProgress.Value = e.Progress;

				if( TaskbarManager.IsPlatformSupported )
				{
					TaskbarManager.Instance.SetProgressValue(
						e.FilesProcessed, e.FileCount );
				}
			}
		}

		private void dgvDirectories_CellValidating(
			Object sender, DataGridViewCellValidatingEventArgs e )
		{
			var dgv = sender as DataGridView;
			var path = e.FormattedValue as string;

			dgv.Rows[e.RowIndex].ErrorText = string.Empty;

			// Don't try to validate the 'new row' until finished editing since
			// there is not any point in validating its initial value.
			if( dgv.Rows[e.RowIndex].IsNewRow )
				return;

			e.Cancel = !Directory.Exists( path );
			if( e.Cancel )
			{
				dgv.Rows[e.RowIndex].ErrorText = Resources.MainForm_EnterValidPath;
			}
		}


		//----------------------------------------------------------------------
		// Methods ( private )
		//----------------------------------------------------------------------

		private void UIEnable( )
		{
			dgvDirectories.Enabled = true;
			btnDirectories.Enabled = true;
			btnStart.Enabled = true;
			btnCancel.Enabled = false;

			tspbProgress.Visible = false;
			tsslPath.Visible = false;

			if( TaskbarManager.IsPlatformSupported )
			{
				TaskbarManager.Instance.SetProgressState(
					TaskbarProgressBarState.NoProgress );
			}
		}

		private void UIDisable( )
		{
			dgvDirectories.Enabled = false;
			btnDirectories.Enabled = false;
			btnStart.Enabled = false;
			btnCancel.Enabled = true;

			tspbProgress.Visible = true;
			tspbProgress.Style = ProgressBarStyle.Marquee;
			tspbProgress.Value = 0;

			tsslPath.Visible = true;
			tsslPath.Text = string.Empty;

			if( TaskbarManager.IsPlatformSupported )
			{
				TaskbarManager.Instance.SetProgressState(
					Mapping.ToTaskbarProgressBarState( ProgressBarStyle.Marquee ) );
			}
		}

		private void TitleWithVersionSet( )
		{
			var assembly = Assembly.GetExecutingAssembly( );
			var fvi = FileVersionInfo.GetVersionInfo( assembly.Location );
			this.Text = string.Format(
				Resources.MainForm_TitleFormat,
				Resources.MainForm_Title,
				fvi.FileVersion );
		}

		private Int32 FileCountDetermine(
			List<string> paths, CancellationToken cancellationToken )
		{
			var fileCount = 0;

			foreach( var path in paths )
			{
				fileCount += FileCountDetermine( path, cancellationToken );
			}

			return fileCount;
		}

		private Int32 FileCountDetermine(
			string path, CancellationToken cancellationToken )
		{
			var fileCount = 0;

			cancellationToken.ThrowIfCancellationRequested( );

			try
			{
				var directories = Directory.EnumerateDirectories( path );
				foreach( var directory in directories )
				{
					fileCount += FileCountDetermine( directory, cancellationToken );
				}
			}
			catch( Exception ) { }

			cancellationToken.ThrowIfCancellationRequested( );

			try
			{
				fileCount += Directory.EnumerateFiles( path ).Count( );
			}
			catch( Exception ) { }

			return fileCount;
		}

		private void UserSettingsLoad( )
		{
			foreach( var directory in Settings.Default.MainForm_Directories )
			{
				dgvDirectories.Rows.Add( directory );
			}
		}

		private void UserSettingsSave( )
		{
			Settings.Default.MainForm_Directories = UIDirectoriesGet( ).ToArray( );
			Settings.Default.Save( );
		}

		private List<String> UIDirectoriesGet( )
		{
			return dgvDirectories
				.Rows
				.Cast<DataGridViewRow>()
				.Where( x => !x.IsNewRow )
				.Select( x => x.Cells[dgvtbcPath.Index].Value as string )
				.ToList( );
		}

		private void ProgressInitialize( )
		{
			var progress = new Progress<UIProgress>( );
			progress.ProgressChanged += Progress_ProgressChanged;

			this.progress = progress as IProgress<UIProgress>;
		}

		private void DatabaseInitialize( )
		{
			var appName = "FileHasher";
			var appDataPath = Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData );

			var databaseName = "FileHasher.sqlite";
			var databasePath = Path.Combine( appDataPath, appName );
			var databaseFilePath = Path.Combine(
				appDataPath, appName, databaseName );

			if( !Directory.Exists( databasePath ) )
			{
				Directory.CreateDirectory( databasePath );
			}

			database = new Database( );
			database.Open( databaseFilePath );
		}
	}
}
