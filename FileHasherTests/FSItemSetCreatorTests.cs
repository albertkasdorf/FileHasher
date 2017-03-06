using FileHasher.Logic;
using FileHasher.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace FileHasher.Tests
{
	[TestClass( )]
	public class FSItemSetCreatorTests
	{
		private FSItem[] dbItems;
		private FSItem[] fsItems;

		[TestInitialize( )]
		public void TestInitialize( )
		{
			var ioException = new IOException( );

			dbItems = new FSItem[] {
				new FSItem( FSType.Directory, "DirDBAndFS" ),
				new FSItem( FSType.Directory, "DirDBOnly" ),

				new FSItem( FSType.File, "FileDBAndFSEqualHash", "0845" ),
				new FSItem( FSType.File, "FileDBAndFSDiffHash", "1111" ),
				new FSItem( FSType.File, "FileDBAndFSWithEx", "4545" ),
				new FSItem( FSType.File, "FileDBOnly", "2023" ),
			};

			fsItems = new FSItem[] {
				new FSItem( FSType.Directory, "DirDBAndFS" ),
				new FSItem( FSType.Directory, "DirFSOnly" ),

				new FSItem( FSType.File, "FileDBAndFSEqualHash", "0845" ),
				new FSItem( FSType.File, "FileDBAndFSDiffHash", "2222" ),
				new FSItem( FSType.File, "FileDBAndFSWithEx", ioException ),

				new FSItem( FSType.File, "FileFSOnly", "2013" ),
				new FSItem( FSType.File, "FileFSOnlyWithEx", ioException ),
			};
		}

		[TestMethod( )]
		public void AddedTest( )
		{
			var added = new FSItem[] {
				new FSItem( FSType.Directory, "DirFSOnly" ),
				new FSItem( FSType.File, "FileFSOnly", "2013" ),
			};
			var itemSet = FSItemSetCreator.Create( dbItems, fsItems, string.Empty );
			var comparer = new FSItemEqualityComparer( true, false );

			Assert.AreEqual( added.Count( ), itemSet.Added.Count( ) );
			Assert.IsTrue( added.SequenceEqual( itemSet.Added, comparer ) );
		}

		[TestMethod( )]
		public void DeletedTest( )
		{
			var deleted = new FSItem[] {
				new FSItem( FSType.Directory, "DirDBOnly" ),
				new FSItem( FSType.File, "FileDBOnly", "2023" ),
			};
			var itemSet = FSItemSetCreator.Create( dbItems, fsItems, string.Empty );
			var comparer = new FSItemEqualityComparer( );

			Assert.AreEqual( deleted.Count( ), itemSet.Deleted.Count( ) );
			Assert.IsTrue( deleted.SequenceEqual( itemSet.Deleted, comparer ) );
		}

		[TestMethod( )]
		public void FaultedTest( )
		{
			var ioException = new IOException( );
			var faulted = new FSItem[] {
				new FSItem( FSType.File, "FileDBAndFSWithEx", ioException ),
				new FSItem( FSType.File, "FileFSOnlyWithEx", ioException ),
			};
			var itemSet = FSItemSetCreator.Create( dbItems, fsItems, string.Empty );
			var comparer = new FSItemEqualityComparer( );

			Assert.AreEqual( faulted.Count( ), itemSet.Faulted.Count( ) );
			Assert.IsTrue( faulted.SequenceEqual( itemSet.Faulted, comparer ) );
		}

		[TestMethod( )]
		public void ChangedTest( )
		{
			var changed = new FSItem[] {
				new FSItem( FSType.File, "FileDBAndFSDiffHash", "2222" ),
			};
			var itemSet = FSItemSetCreator.Create( dbItems, fsItems, string.Empty );
			var comparer = new FSItemEqualityComparer( );

			Assert.AreEqual( changed.Count( ), itemSet.Changed.Count( ) );
			Assert.IsTrue( changed.SequenceEqual( itemSet.Changed, comparer ) );
		}

		[TestMethod( )]
		public void UnchangedTest( )
		{
			var unchanged = new FSItem[] {
				new FSItem( FSType.File, "FileDBAndFSEqualHash", "0845" ),
			};
			var itemSet = FSItemSetCreator.Create( dbItems, fsItems, string.Empty );
			var comparer = new FSItemEqualityComparer( );

			Assert.AreEqual( unchanged.Count( ), itemSet.Unchanged.Count( ) );
			Assert.IsTrue( unchanged.SequenceEqual( itemSet.Unchanged, comparer ) );
		}
	}
}