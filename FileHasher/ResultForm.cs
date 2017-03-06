using FileHasher.Logic;
using FileHasher.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileHasher
{
	public partial class ResultForm : Form
	{
		public ResultForm( List<ResultSet> resultSets )
		{
			InitializeComponent( );

			this.uiSchedular = TaskScheduler.FromCurrentSynchronizationContext( );
			this.resultSets = resultSets;
			this.workerTask = new Task( ( ) => { } );
		}

		private readonly TaskScheduler uiSchedular;
		private List<ResultSet> resultSets;
		private Task workerTask;

		private void ResultForm_FormClosing( Object sender, FormClosingEventArgs e )
		{
			e.Cancel = !workerTask.IsCompleted;
		}

		private void ResultForm_Load( Object sender, EventArgs e )
		{
			tlpResultForm.Enabled = false;

			workerTask = Task.Factory.StartNew( ( ) =>
			{
				Int32 changedCounter = 0, faultedCounter = 0;
				Int32 addedCounter = 0, deletedCounter = 0;

				foreach( var resultSet in resultSets )
				{
					//Thread.Sleep( 1000 );
					if( resultSet.Exception == null )
					{
						var count =
							resultSet.Added.Count( ) +
							resultSet.Changed.Count( ) +
							resultSet.Deleted.Count( ) +
							resultSet.Faulted.Count( );
						//if( count != 0 )
						{
							AppendPath( resultSet.Path );
						}

						foreach( var changed in resultSet.Changed )
						{
							AppendChanged( changed.Name );
							changedCounter++;
						}

						foreach( var faulted in resultSet.Faulted )
						{
							AppendFaultedFile( faulted.Name, faulted.Exception.Message );
							faultedCounter++;
						}

						foreach( var deleted in resultSet.Deleted )
						{
							AppendDeleted( deleted.Name );
							deletedCounter++;
						}

						foreach( var added in resultSet.Added )
						{
							AppendAdded( added.Name );
							addedCounter++;
						}

						if( count != 0 )
						{
							AppendNewLine( );
						}
					}
					else
					{
						AppendPath( resultSet.Path );
						AppendFaultedDirectory( resultSet.Exception.Message );

						faultedCounter++;
					}
				}

				CounterUpdate(
					changedCounter, faultedCounter, addedCounter, deletedCounter );

			}, CancellationToken.None, TaskCreationOptions.LongRunning,
			TaskScheduler.Default );

			workerTask.ContinueWith( ( _ ) =>
			{
				pbProgress.Visible = false;
				rtbResults.Select( 0, 0 );

				tlpResultForm.Enabled = true;
			}, CancellationToken.None, TaskContinuationOptions.None, uiSchedular );
		}

		private void AppendNewLine( )
		{
			RunOnUI( ( ) => { rtbResults.AppendText( Environment.NewLine ); } );
		}

		private void AppendFaultedDirectory( String message )
		{
			RunOnUI( ( ) =>
			{
				rtbResults.SelectionColor = Color.Red;
				rtbResults.AppendText( string.Format( "! {0}", message ) );
				rtbResults.AppendText( Environment.NewLine );
				rtbResults.AppendText( Environment.NewLine );
			} );
		}

		private void AppendPath( String path )
		{
			RunOnUI( ( ) =>
			{
				rtbResults.SelectionColor = SystemColors.WindowText;
				rtbResults.AppendText( string.Format( "{0}:", path ) );
				rtbResults.AppendText( Environment.NewLine );
			} );
		}

		private void AppendAdded( String name )
		{
			RunOnUI( ( ) =>
			{
				rtbResults.SelectionColor = SystemColors.WindowText;
				rtbResults.AppendText( string.Format( "+ {0}", name ) );
				rtbResults.AppendText( Environment.NewLine );
			} );
		}

		private void AppendDeleted( String name )
		{
			RunOnUI( ( ) =>
			{
				rtbResults.SelectionColor = SystemColors.WindowText;
				rtbResults.AppendText( string.Format( "- {0}", name ) );
				rtbResults.AppendText( Environment.NewLine );
			} );
		}

		private void AppendFaultedFile( String name, String message )
		{
			RunOnUI( ( ) =>
			{
				rtbResults.SelectionColor = Color.Red;
				rtbResults.AppendText( string.Format( "! {0}, {1}", name, message ) );
				rtbResults.AppendText( Environment.NewLine );
			} );
		}

		private void CounterUpdate(
			Int32 changed, Int32 faulted, Int32 added, Int32 deleted )
		{
			RunOnUI( ( ) =>
			{
				txbChanged.Text = changed.ToString( );
				txbFaulted.Text = faulted.ToString( );
				txbAdded.Text = added.ToString( );
				txbDeleted.Text = deleted.ToString( );
			} );
		}

		private void AppendChanged( String name )
		{
			RunOnUI( ( ) =>
			{
				rtbResults.SelectionColor = Color.Red;
				rtbResults.AppendText( string.Format( "§ {0}", name ) );
				rtbResults.AppendText( Environment.NewLine );
			} );
		}

		private void RunOnUI( Action action )
		{
			Task.Factory.StartNew(
				action, CancellationToken.None, TaskCreationOptions.None,
				uiSchedular );
		}
	}
}
