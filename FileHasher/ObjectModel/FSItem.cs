using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHasher.ObjectModel
{
	[DebuggerDisplay( "Name={Name}, Hash={Hash}" )]
	public class FSItem
	{
		public FSItem( FSType type, String name )
		{
			Type = type;
			Name = name;
			Hash = null;
			Exception = null;
		}

		public FSItem( FSType type, String name, String hash )
		{
			Type = type;
			Name = name;
			Hash = hash;
			Exception = null;
		}

		public FSItem( FSType type, String name, Exception exception )
		{
			Type = type;
			Name = name;
			Hash = null;
			Exception = exception;
		}

		public FSItem( FSItem fsItem )
		{
			Type = fsItem.Type;
			Name = fsItem.Name;
			Hash = fsItem.Hash;
			Exception = fsItem.Exception;
		}

		public FSType Type { get; private set; }
		public String Name { get; private set; }
		public String Hash { get; private set; }
		public Exception Exception { get; private set; }
	}
}
