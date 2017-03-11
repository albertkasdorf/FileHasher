using FileHasher.ObjectModel;
using FileHasher.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileHasher
{
	public partial class ResultForm : Form
	{
		//----------------------------------------------------------------------
		// Constructors
		//----------------------------------------------------------------------

		public ResultForm( List<ResultSet> resultSets )
		{
			InitializeComponent( );

			DataTableInitialize( );
			DataGridViewsInitialize( );

			this.uiSchedular = TaskScheduler.FromCurrentSynchronizationContext( );
			this.resultSets = resultSets;
			this.workerTask = new Task( ( ) => { } );
		}


		//----------------------------------------------------------------------
		// Members
		//----------------------------------------------------------------------

		private const String TableName_Changed = "Changed";
		private const String TableName_Faulted = "Faulted";
		private const String TableName_Added = "Added";
		private const String TableName_Deleted = "Deleted";
		private const String TableName_ExaminedPaths = "ExaminedPaths";

		private const String ColumnName_Type = "Type";
		private const String ColumnName_Name = "Name";
		private const String ColumnName_Path = "Path";
		private const String ColumnName_Exception = "Exception";

		private readonly TaskScheduler uiSchedular;
		private List<ResultSet> resultSets;
		private Task workerTask;

		private DataTable dtChanged;
		private DataTable dtFaulted;
		private DataTable dtAdded;
		private DataTable dtDeleted;
		private DataTable dtExaminedPaths;


		//----------------------------------------------------------------------
		// Methods ( event )
		//----------------------------------------------------------------------

		private void ResultForm_FormClosing(
			Object sender, FormClosingEventArgs e )
		{
			e.Cancel = !workerTask.IsCompleted;
		}

		private void ResultForm_Load( Object sender, EventArgs e )
		{
			tlpResult.Enabled = false;
			TabPageNamesUpdate( );

			workerTask = Task.Factory.StartNew(
				ResultSetProcess,
				CancellationToken.None,
				TaskCreationOptions.LongRunning,
				TaskScheduler.Default );

			workerTask.ContinueWith( ( _ ) =>
			{
				dgvChanged.DataSource = dtChanged;
				dgvFaulted.DataSource = dtFaulted;
				dgvAdded.DataSource = dtAdded;
				dgvDeleted.DataSource = dtDeleted;
				dgvExaminedPaths.DataSource = dtExaminedPaths;

				TabPageNamesUpdate( );

				pbProgress.Visible = false;
				tlpResult.Enabled = true;
			}, CancellationToken.None, TaskContinuationOptions.None, uiSchedular );
		}

		private void DataGridView_CellFormatting(
			Object sender, DataGridViewCellFormattingEventArgs e )
		{
			if( e.DesiredType != typeof( Image ) )
				return;

			var uiType = (UIType)e.Value;
			switch( uiType )
			{
			case UIType.AddedFile: e.Value = Resources.AddFile_16x; break;
			case UIType.AddedFolder: e.Value = Resources.AddFolder_16x; break;
			case UIType.ChangedFile: e.Value = Resources.EditPage_16x; break;
			case UIType.DeletedFile: e.Value = Resources.NoResults_16x; break;
			case UIType.DeletedFolder: e.Value = Resources.DeleteFolder_16x; break;
			case UIType.ExaminedFolder: e.Value = Resources.FindinFiles_16x; break;
			case UIType.FaultedFile: e.Value = Resources.FileError_16x; break;
			case UIType.FaultedFolder: e.Value = Resources.FolderError_16x; break;
			default:
				break;
			}
		}


		//----------------------------------------------------------------------
		// Methods ( private )
		//----------------------------------------------------------------------

		private void DataTableInitialize( )
		{
			dtChanged = DataTableCreate( TableName_Changed, new DataColumn[]
			{
				new DataColumn( ColumnName_Type, typeof( UIType ) ),
				new DataColumn( ColumnName_Name, typeof( String ) ),
				new DataColumn( ColumnName_Path, typeof( String ) ),
			} );

			dtFaulted = DataTableCreate( TableName_Faulted, new DataColumn[] {
				new DataColumn( ColumnName_Type, typeof( UIType ) ),
				new DataColumn( ColumnName_Name, typeof( String ) ),
				new DataColumn( ColumnName_Path, typeof( String ) ),
				new DataColumn( ColumnName_Exception, typeof( String ) ),
			} );

			dtAdded = DataTableCreate( TableName_Added, new DataColumn[] {
				new DataColumn( ColumnName_Type, typeof( UIType ) ),
				new DataColumn( ColumnName_Name, typeof( String ) ),
				new DataColumn( ColumnName_Path, typeof( String ) ),
			} );

			dtDeleted = DataTableCreate( TableName_Deleted, new DataColumn[] {
				new DataColumn( ColumnName_Type, typeof( UIType ) ),
				new DataColumn( ColumnName_Name, typeof( String ) ),
				new DataColumn( ColumnName_Path, typeof( String ) ),
			} );

			dtExaminedPaths = DataTableCreate(
				TableName_ExaminedPaths,
				new DataColumn[] {
					new DataColumn( ColumnName_Type, typeof( UIType ) ),
					new DataColumn( ColumnName_Path, typeof( String ) ),
				} );
		}

		private void DataGridViewsInitialize( )
		{
			DataGridViewConfigure( dgvChanged, new DataGridViewColumn[] {
				TypeDataGridViewColumnCreate( ),
				NameDataGridViewColumnCreate( ),
				PathDataGridViewColumnCreate( ),
			} );

			DataGridViewConfigure( dgvFaulted, new DataGridViewColumn[] {
				TypeDataGridViewColumnCreate( ),
				NameDataGridViewColumnCreate( ),
				PathDataGridViewColumnCreate( ),
				ExceptionDataGridViewColumnCreate( ),
			} );

			DataGridViewConfigure( dgvAdded, new DataGridViewColumn[] {
				TypeDataGridViewColumnCreate( ),
				NameDataGridViewColumnCreate( ),
				PathDataGridViewColumnCreate( ),
			});

			DataGridViewConfigure( dgvDeleted, new DataGridViewColumn[] {
				TypeDataGridViewColumnCreate( ),
				NameDataGridViewColumnCreate( ),
				PathDataGridViewColumnCreate( ),
			} );

			DataGridViewConfigure( dgvExaminedPaths, new DataGridViewColumn[] {
				TypeDataGridViewColumnCreate( ),
				PathDataGridViewColumnCreate( ),
			} );
		}

		private void DataGridViewConfigure(
			DataGridView dgv, DataGridViewColumn[] columns )
		{
			dgv.AutoGenerateColumns = false;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.MultiSelect = false;
			dgv.ReadOnly = true;
			dgv.RowHeadersVisible = false;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.Columns.AddRange( columns );
		}

		private DataTable DataTableCreate( String tableName, DataColumn[] columns )
		{
			var dt = new DataTable( tableName );
			{
				dt.Columns.AddRange( columns );
			}
			return dt;
		}

		private DataGridViewColumn TypeDataGridViewColumnCreate( )
		{
			return new DataGridViewImageColumn( false )
			{
				DataPropertyName = ColumnName_Type,
				HeaderText = string.Empty,
				AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
				Resizable = DataGridViewTriState.False,
			};
		}

		private DataGridViewColumn NameDataGridViewColumnCreate( )
		{
			return new DataGridViewTextBoxColumn( )
			{
				DataPropertyName = ColumnName_Name,
				HeaderText = ColumnName_Name,
				Width = 200,
			};
		}

		private DataGridViewColumn PathDataGridViewColumnCreate( )
		{
			return new DataGridViewTextBoxColumn( )
			{
				DataPropertyName = ColumnName_Path,
				HeaderText = ColumnName_Path,
				Width = 400,
			};
		}

		private DataGridViewColumn ExceptionDataGridViewColumnCreate( )
		{
			return new DataGridViewTextBoxColumn( )
			{
				DataPropertyName = ColumnName_Exception,
				HeaderText = ColumnName_Exception,
				Width = 200,
			};
		}

		private void TabPageNamesUpdate( )
		{
			TabPageNameChange(
					tpChanged, Resources.ResultForm_TabNameChanged, dtChanged );
			TabPageNameChange(
				tpFaulted, Resources.ResultForm_TabNameFaulted, dtFaulted );
			TabPageNameChange(
				tpAdded, Resources.ResultForm_TabNameAdded, dtAdded );
			TabPageNameChange(
				tpDeleted, Resources.ResultForm_TabNameDeleted, dtDeleted );
			TabPageNameChange(
				tpExaminedPaths,
				Resources.ResultForm_TabNameExaminedPaths,
				dtExaminedPaths );
		}

		private void TabPageNameChange(
			TabPage tabPage, String name, DataTable dataTable )
		{
			tabPage.Text = String.Format(
				Resources.ResultForm_TabNameFormat, name, dataTable.Rows.Count );
		}

		private void ResultSetProcess( )
		{
			foreach( var resultSet in resultSets )
			{
				dtExaminedPaths.Rows.Add(
					UIType.ExaminedFolder, resultSet.Path );

				if( resultSet.Exception == null )
				{
					foreach( var changed in resultSet.Changed )
					{
						dtChanged.Rows.Add(
							UIType.ChangedFile, changed.Name, resultSet.Path );
					}

					foreach( var faulted in resultSet.Faulted )
					{
						dtFaulted.Rows.Add(
							UIType.FaultedFile,
							faulted.Name,
							resultSet.Path,
							faulted.Exception.Message );
					}

					foreach( var deleted in resultSet.Deleted )
					{
						dtDeleted.Rows.Add(
							deleted.Type == FSType.File ? UIType.DeletedFile : UIType.DeletedFolder,
							deleted.Name,
							resultSet.Path );
					}

					foreach( var added in resultSet.Added )
					{
						dtAdded.Rows.Add(
							added.Type == FSType.File ? UIType.AddedFile : UIType.AddedFolder,
							added.Name,
							resultSet.Path );
					}
				}
				else
				{
					dtFaulted.Rows.Add(
						UIType.FaultedFolder,
						string.Empty,
						resultSet.Path,
						resultSet.Exception.Message );
				}
			}

			dtChanged.AcceptChanges( );
			dtFaulted.AcceptChanges( );
			dtAdded.AcceptChanges( );
			dtDeleted.AcceptChanges( );
			dtExaminedPaths.AcceptChanges( );
		}
	}
}
