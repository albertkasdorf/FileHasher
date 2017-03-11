using FileHasher.Logic;
using FileHasher.ObjectModel;
using FileHasher.Properties;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileHasher
{
	public partial class MainForm : Form
	{
		public MainForm( )
		{
			InitializeComponent( );
			InitializeBinding( );

			cancellationTokenSource = new CancellationTokenSource( );
			workerTask = Task.Factory.StartNew( ( ) => { } );
			uiScheduler = TaskScheduler.FromCurrentSynchronizationContext( );

			var progress = new Progress<UIProgress>( );
			progress.ProgressChanged += Progress_ProgressChanged;

			this.progress= progress as IProgress<UIProgress>;
		}

		private Database database;
		private CancellationTokenSource cancellationTokenSource;
		private Task workerTask;
		private TaskScheduler uiScheduler;
		private IProgress<UIProgress> progress;

		private void InitializeBinding( )
		{
			txbDirectories.DataBindings.Add(
				"Lines", Settings.Default, "MainForm_Directories", false,
				DataSourceUpdateMode.OnPropertyChanged );
		}

		private void MainForm_Load( Object sender, EventArgs e )
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

			SetTitleWithVersion( );
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
				txbDirectories.Text += Environment.NewLine;
				txbDirectories.Text += fbd.SelectedPath;
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
				var fileCount = 0;
				var filesProcessed = 0;

				foreach( var startPath in Settings.Default.MainForm_Directories )
				{
					if( string.IsNullOrEmpty( startPath ) )
						continue;

					var startId = database.ItemIdGet( startPath );
					stack.Push( new Tuple<Int64, String>( startId, startPath ) );
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

		private void UIEnable( )
		{
			txbDirectories.Enabled = true;
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
			txbDirectories.Enabled = false;
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

		private void SetTitleWithVersion( )
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
	}
}
