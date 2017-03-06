using FileHasher.ObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHasher.Logic
{
	public class Database : IDisposable
	{
		public Database( )
		{
			connection = new SQLiteConnection( );
		}

		private static readonly string FileSystemID = "@id";
		private static readonly string FileSystemPID = "@pid";
		private static readonly string FileSystemName = "@name";
		private static readonly string FileSystemHash = "@hash";

		private SQLiteConnection connection;

		public void Open( String path )
		{
			var formatString = "Data Source={0}; Version=3;";
			var connectionString = String.Format( formatString, path );

			connection = new SQLiteConnection( connectionString );
			connection.Open( );
		}

		public void Close( )
		{
			connection.Close( );
		}

		/// <summary>
		/// Bestimmt die id von dem Startpfad, ggf. werden die entsprechenden
		/// Einträge in der Datenbank erstellt.
		/// </summary>
		public Int64 ItemIdGet( String path )
		{
			var stack = new Stack<String>( );

			do
			{
				var directoryName = Path.GetFileName( path );
				if( String.IsNullOrEmpty( directoryName ) )
					directoryName = Path.GetPathRoot( path );
				stack.Push( directoryName );

				path = Path.GetDirectoryName( path );
			}
			while( !String.IsNullOrEmpty( path ) );

			using( var cmd = CreateCommand( ) )
			{
				Int64? id = null;
				Int64? pid = null;

				cmd.CommandText = "insert into tblFileSystem (pid,name,hash) values (@pid,@name,@hash);";

				while( stack.Count != 0 )
				{
					var name = stack.Pop( ).ToLower( );

					id = ItemIdGet( pid, name );
					if( id.HasValue )
					{
						pid = id;
					}

					if( id.HasValue == false )
					{
						cmd.Parameters[FileSystemPID].Value =
							pid.HasValue ? (object)pid.Value : DBNull.Value;
						cmd.Parameters[FileSystemName].Value = name;

						var result = cmd.ExecuteNonQuery( );
						Debug.Assert( result == 1 );

						pid = id = cmd.Connection.LastInsertRowId;
					}
				}

				return Convert.ToInt64( pid.Value );
			}
		}

		/// <summary>
		/// Bestimmen der Item-Id anhand des Namens und der Pid.
		/// </summary>
		public Int64? ItemIdGet( Int64? pid, String name )
		{
			Int64? result = null;

			using( var cmd = CreateCommand( ) )
			{
				cmd.CommandText = "select id from tblFileSystem where pid is @pid and name=@name;";
				cmd.Parameters[FileSystemPID].Value = pid.HasValue ? (object)pid.Value : DBNull.Value;
				cmd.Parameters[FileSystemName].Value = name;

				using( var reader = cmd.ExecuteReader( ) )
				{
					while( reader.Read( ) )
					{
						result = reader.GetInt64( 0 );
						break;
					}
				}
			}

			return result;
		}

		/// <summary>
		/// Gibt eine Liste von Verzeichnis- und Dateinamen zurück die zu der
		/// pid passen.
		/// </summary>
		public IEnumerable<FSItem> ItemsGet( Int64 pid )
		{
			var result = new List<FSItem>( );

			using( var cmd = CreateCommand( ) )
			{
				cmd.CommandText = "select name, hash from tblFileSystem where pid is @pid;";
				cmd.Parameters[FileSystemPID].Value = pid;

				using( var reader = cmd.ExecuteReader( ) )
				{
					while( reader.Read( ) )
					{
						var name = reader.GetString( 0 );
						var hashObj = reader.GetValue( 1 );
						var hash = (hashObj == DBNull.Value) ? null : Convert.ToString( hashObj );
						var type = string.IsNullOrEmpty( hash ) ? FSType.Directory : FSType.File;

						result.Add( new FSItem( type, name, hash ) );
					}
				}
			}

			return result;
		}

		public void Insert( IEnumerable<FSItem> fsItems, Int64 pid )
		{
			BatchExecute(
				"insert into tblFileSystem (pid,name,hash) values (@pid,@name,@hash);",
				fsItems, pid );
		}

		public void Update( IEnumerable<FSItem> fsItems, Int64 pid )
		{
			BatchExecute(
				"update tblFileSystem set hash=@hash where pid=@pid and name=@name;",
				fsItems, pid );
		}

		public void Delete( IEnumerable<FSItem> fsItems, Int64 pid )
		{
			BatchExecute(
				"delete from tblFileSystem where pid=@pid and name=@name;",
				fsItems, pid );
		}

		private void BatchExecute(
			String commandText, IEnumerable<FSItem> fsItems, Int64 pid )
		{
			using( var transaction = connection.BeginTransaction( ) )
			{
				using( var cmd = CreateCommand( ) )
				{
					cmd.CommandText = commandText;
					foreach( var fsItem in fsItems )
					{
						cmd.Parameters[FileSystemPID].Value = pid;
						cmd.Parameters[FileSystemName].Value = fsItem.Name;
						cmd.Parameters[FileSystemHash].Value = fsItem.Hash;

						var result = cmd.ExecuteNonQuery( );
						Debug.Assert( result == 1 );
					}
				}
				transaction.Commit( );
			}
		}

		private SQLiteCommand CreateCommand( )
		{
			var cmd = connection.CreateCommand( );

			cmd.Parameters.Add( FileSystemID, DbType.Int64 );
			cmd.Parameters.Add( FileSystemPID, DbType.Int64 );
			cmd.Parameters.Add( FileSystemName, DbType.String );
			cmd.Parameters.Add( FileSystemHash, DbType.String );

			cmd.Parameters[FileSystemID].Value = DBNull.Value;
			cmd.Parameters[FileSystemPID].Value = DBNull.Value;
			cmd.Parameters[FileSystemName].Value = DBNull.Value;
			cmd.Parameters[FileSystemHash].Value = DBNull.Value;

			return cmd;
		}



		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose( bool disposing )
		{
			if( !disposedValue )
			{
				if( disposing )
				{
					// Dispose managed state (managed objects).
					connection.Dispose( );
				}

				// Free unmanaged resources (unmanaged objects) and override
				// a finalizer below. Set large fields to null.
				disposedValue = true;
			}
		}

		// Override a finalizer only if Dispose(bool disposing) above has code
		// to free unmanaged resources.
		// ~Database() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose( )
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose( true );
			// Uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}
