using FileHasher.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHasher.ObjectModel
{
	public class ResultSet
	{
		public ResultSet( string path, Exception exception )
		{
			Path = path;
			Exception = exception;

			Added = new List<ResultItem>( );
			Deleted = new List<ResultItem>( );
			Faulted = new List<FaultedResultItem>( );
			Changed = new List<ResultItem>( );
		}

		public ResultSet( FSItemSet fsItemSet )
		{
			Path = fsItemSet.Path;
			Exception = null;

			Added = new List<ResultItem>( fsItemSet.Added.Select( item => new ResultItem( item ) ) );
			Deleted = new List<ResultItem>( fsItemSet.Deleted.Select( item => new ResultItem( item ) ) );
			Faulted = new List<FaultedResultItem>( fsItemSet.Faulted.Select( item => new FaultedResultItem( item ) ) );
			Changed = new List<ResultItem>( fsItemSet.Changed.Select( item => new ResultItem( item ) ) );
		}

		/// <summary>
		/// Untersuchter Dateipfad.
		/// </summary>
		public string Path { get; private set; }

		/// <summary>
		/// Fehlermeldung beim Zugriff auf den Pfad.
		/// </summary>
		public Exception Exception { get; private set; }


		public List<ResultItem> Added { get; private set; }
		public List<ResultItem> Deleted { get; private set; }
		public List<FaultedResultItem> Faulted { get; private set; }
		public List<ResultItem> Changed { get; private set; }
		
		
	}
}
