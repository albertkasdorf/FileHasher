using FileHasher.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHasher.Logic
{
	public static class FSItemSetCreator
	{
		/// <summary>
		/// Erstellen einer FSItemSet aus den DBItems und FSItems.
		/// </summary>
		public static FSItemSet Create(
			IEnumerable<FSItem> dbItems,
			IEnumerable<FSItem> fsItems,
			String path )
		{
			var comparer = new FSItemEqualityComparer( true, true );
			var ignoreHashComparer = new FSItemEqualityComparer( true, false );

			var added = fsItems
				.Where( fsItem => fsItem.Exception == null )
				.Except( dbItems, ignoreHashComparer );
			var deleted = dbItems.Where(
				dbItem => !fsItems.Any(
					fsItem => string.Compare( dbItem.Name, fsItem.Name ).Equals( 0 ) ) );
			var faulted = fsItems.Where( fsItem => fsItem.Exception != null );
			var changed = fsItems.Where( fsItem => dbItems
				.Any( dbItem =>
				{
					var isFileType = (fsItem.Type == FSType.File) && (dbItem.Type == FSType.File);
					var nameEqual = string.Compare( fsItem.Name, dbItem.Name ).Equals( 0 );
					var hashNotEqual = !string.Compare( fsItem.Hash, dbItem.Hash ).Equals( 0 );
					var noException = fsItem.Exception == null;

					return isFileType && nameEqual && hashNotEqual & noException;
				} ) );
			var unchanged = fsItems
				.Where( fsItem => fsItem.Type == FSType.File )
				.Intersect( dbItems, comparer );

			return new FSItemSet( path, added, changed, deleted, faulted, unchanged );
		}
	}
}
