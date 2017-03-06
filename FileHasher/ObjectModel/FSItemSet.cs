using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHasher.ObjectModel
{
	public class FSItemSet
	{
		public FSItemSet(
			String path,
			IEnumerable<FSItem> added,
			IEnumerable<FSItem> changed,
			IEnumerable<FSItem> deleted,
			IEnumerable<FSItem> faulted,
			IEnumerable<FSItem> unchanged )
		{
			Path = path;
			Added = new List<FSItem>( added );
			Changed = new List<FSItem>( changed );
			Deleted = new List<FSItem>( deleted );
			Faulted = new List<FSItem>( faulted );
			Unchanged = new List<FSItem>( unchanged );
		}

		public String Path { get; private set; }

		/// <summary>
		/// Alle Elemente die sich nicht in der Datenbank befinden.
		/// Ausnahmen: Dateien mit Fehlern werden ausgeschlossen.
		/// </summary>
		public IEnumerable<FSItem> Added { get; private set; }

		/// <summary>
		/// Alle Elemente die sich nicht in dem Dateisystem befinden.
		/// Ausnahmen: Dateien mit Fehlern werden ausgeschlossen.
		/// </summary>
		public IEnumerable<FSItem> Deleted { get; private set; }

		/// <summary>
		/// Alle Dateien bei denen sich der Hashwert geändert hat.
		/// Ausnahme: Dateien mit Fehlern werden ausgeschlossen.
		/// </summary>
		public IEnumerable<FSItem> Changed { get; private set; }

		/// <summary>
		/// Alle Dateien bei denen sich der Hashwert nicht geändert hat.
		/// Ausnahme: Dateien mit Fehlern werden ausgeschlossen.
		/// </summary>
		public IEnumerable<FSItem> Unchanged { get; private set; }

		/// <summary>
		/// Alle Dateien bei denen ein Fehler während der Verarbeitung
		/// aufgetreten ist.
		/// </summary>
		public IEnumerable<FSItem> Faulted { get; private set; }
	}
}
