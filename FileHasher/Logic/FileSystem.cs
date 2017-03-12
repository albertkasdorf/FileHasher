using FileHasher.ObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

namespace FileHasher.Logic
{
	public static class FileSystem
	{
		/// <summary>
		/// Gibt eine Liste von Verzeichnis- und Dateinamen zurück die sich
		/// in dem Pfad befinden. Zu jeder Datei wird der zugehörige Hash
		/// berechnet.
		/// </summary>
		public static IEnumerable<FSItem> ItemsGet(
			string path, CancellationToken cancellationToken )
		{
			var result = new List<FSItem>( );

			result.AddRange( Directory
				.GetDirectories( path )
				.Select( fullPath =>
				{
					var name = Path.GetFileName( fullPath );
					return new FSItem( FSType.Directory, name );
				} ) );

			result.AddRange( Directory
				.GetFiles( path )
				.Select( fullPath =>
				{
					cancellationToken.ThrowIfCancellationRequested( );

					var name = Path.GetFileName( fullPath );
					var type = FSType.File;

					try
					{
						var hash = FileToHash( fullPath );

						return new FSItem( type, name, hash );
					}
					catch( Exception ex )
					{
						return new FSItem( type, name, ex );
					}
				} ) );

			return result;
		}

		/// <summary>
		/// Hash einer Datei berechnen.
		/// </summary>
		/// <example>
		/// var hash = FileToHash( @"C:\Users\Albert\Documents\The Cult of Done Manifesto.docx" );
		/// </example>
		private static string FileToHash( string filePath )
		{
			using( var hashAlgorithm = HashAlgorithm.Create( "SHA1" ) )
			{
				using( var fileStream = File.OpenRead( filePath ) )
				{
					var hashByte = hashAlgorithm.ComputeHash( fileStream );
					var hashString = HashToString( hashByte );

					return hashString;
				}
			}
		}

		/// <summary>
		/// Hash-Byte-Folge in eine leserliche Zeichenkette umwandeln.
		/// </summary>
		private static string HashToString( byte[] hash )
		{
			return BitConverter
				.ToString( hash )
				.Replace( "-", string.Empty )
				.ToLower( );
		}
	}
}
