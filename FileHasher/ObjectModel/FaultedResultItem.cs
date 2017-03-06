using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHasher.ObjectModel
{
	public class FaultedResultItem : ResultItem
	{
		public FaultedResultItem( FSType fsType, String name, Exception exception )
			: base( fsType, name )
		{
			Exception = exception;
		}

		public FaultedResultItem( FSItem fsItem )
			: base( fsItem.Type, fsItem.Name )
		{
			Exception = fsItem.Exception;
		}

		public Exception Exception { get; private set; }
	}
}
