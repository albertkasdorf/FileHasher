using FileHasher.Properties;
using System;
using System.Windows.Forms;

namespace FileHasher
{
	public static class Program
	{
		[STAThread]
		public static void Main( )
		{
			Application.EnableVisualStyles( );
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new MainForm( ) );

			Settings.Default.Save( );
		}
	}
}
//------------------------------------------------------------------------------
//SQLiteConnection.CreateFile( "" );
//------------------------------------------------------------------------------
//var results = new List<ResultSet>( );

//results.Add( new ResultSet( @"C:\Users\Albert\OneDrive", new IOException( ) ) );
//results.Add( new ResultSet( new FSItemSet(
//	@"C:\Users\Albert\OneDrive\Pictures",
//	new FSItem[] {
//		new FSItem( FSType.Directory, "Camera Roll" ),
//		new FSItem( FSType.File, "WP_20170228_005.jpg", "AA12" ),
//	},
//	new FSItem[] {
//		new FSItem( FSType.File, "WP_20170221_004.jpg", "BB34" ),
//	},
//	new FSItem[] {
//		new FSItem( FSType.File, "WP_20170228_001.jpg" ),
//		new FSItem( FSType.Directory, "Food" ),
//	},
//	new FSItem[] {
//		new FSItem( FSType.File, "2014-01-19 A-295504-1360490163-8311.jpeg", new IOException( ) ),
//		new FSItem( FSType.File, "tokyo_fashion_summer_2015_04.jpg", new InvalidDataException( ) ),
//	},
//	new FSItem[] { } ) ) );
//results.Add( new ResultSet( new FSItemSet(
//	@"C:\Users\Albert\OneDrive\Food",
//	new FSItem[] { }, new FSItem[] { }, new FSItem[] { }, new FSItem[] { }, new FSItem[] { } ) ) );
//results.Add( new ResultSet( new FSItemSet(
//	@"C:\Users\Albert\OneDrive\Gespeicherte Bilder",
//	new FSItem[] { }, new FSItem[] { }, new FSItem[] { }, new FSItem[] { }, new FSItem[] { } ) ) );
//results.Add( new ResultSet( new FSItemSet(
//	@"C:\Users\Albert\OneDrive\Häuser",
//	new FSItem[] { }, new FSItem[] { }, new FSItem[] { }, new FSItem[] { }, new FSItem[] { } ) ) );
//results.Add( new ResultSet( new FSItemSet(
//	@"C:\Users\Albert\OneDrive\Ideen",
//	new FSItem[] { }, new FSItem[] { }, new FSItem[] { }, new FSItem[] { }, new FSItem[] { } ) ) );
//results.Add( new ResultSet( new FSItemSet(
//	@"C:\Users\Albert\OneDrive\Kleidung",
//	new FSItem[] {
//		new FSItem( FSType.Directory, "Camera Roll" ),
//		new FSItem( FSType.File, "WP_20170228_005.jpg", "AA12" ),
//	},
//	new FSItem[] {
//		new FSItem( FSType.File, "WP_20170221_004.jpg", "BB34" ),
//	},
//	new FSItem[] {
//		new FSItem( FSType.File, "WP_20170228_001.jpg" ),
//		new FSItem( FSType.Directory, "Food" ),
//	},
//	new FSItem[] {
//		new FSItem( FSType.File, "2014-01-19 A-295504-1360490163-8311.jpeg", new IOException( ) ),
//		new FSItem( FSType.File, "tokyo_fashion_summer_2015_04.jpg", new InvalidDataException( ) ),
//	},
//	new FSItem[] { } ) ) );

//var resultForm = new ResultForm( results );
//resultForm.ShowDialog( );
//------------------------------------------------------------------------------
//	//var startPath = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
//	//var startPath = Environment.GetFolderPath( Environment.SpecialFolder.MyPictures );
//	//var startPath = @"C:\Users\Albert\Pictures\2001";
//	var startPath = @"C:\Users\Albert\OneDrive";
//	//var startPath = Environment.GetFolderPath( Environment.SpecialFolder.MyVideos );
//	//var startPath = @"C:\Users\Albert\Documents\Anleitungen";

//	using( var database = new Database( ) )
//	{
//		database.Open( "FileHasher.sqlite" );

//		var results = new List<ResultSet>( );
//		var startId = database.ItemIdGet( startPath );

//		var stack = new Stack<Tuple<Int64, String>>( );
//		stack.Push( new Tuple<Int64, String>( startId, startPath ) );

//		while( stack.Count > 0 )
//		{
//			var data = stack.Pop( );

//			var id = data.Item1;
//			var path = data.Item2;

//			Console.Write( path );

//			try
//			{
//				var dbItems = database.ItemsGet( id );
//				var fsItems = FileSystem.ItemsGet( path );

//				var fsItemSet = FSItemSetCreator.Create( dbItems, fsItems, path );

//				results.Add( new ResultSet( fsItemSet ) );

//				database.Insert( fsItemSet.Added, id );
//				database.Update( fsItemSet.Changed, id );
//				database.Delete( fsItemSet.Deleted, id );

//				var fsDirectoryItems = fsItems.Where(
//					fsItem => fsItem.Type == FSType.Directory );
//				foreach( var fsDirectoryItem in fsDirectoryItems )
//				{
//					var nextId = database.ItemIdGet( id, fsDirectoryItem.Name );
//					var nextPath = Path.Combine( path, fsDirectoryItem.Name );

//					stack.Push( new Tuple<Int64, String>( nextId.Value, nextPath ) );
//				}
//			}
//			catch( Exception ex )
//			{
//				results.Add( new ResultSet( path, ex ) );
//			}
//		}

//		var resultForm = new ResultForm( results );
//		resultForm.ShowDialog( );

//		return;
//	}