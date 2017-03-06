using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHasher.ObjectModel
{
	public class ResultItem
	{
		public ResultItem( FSType type, String name )
		{
			Type = type;
			Name = name;
		}

		public ResultItem( FSItem fsItem )
		{
			Type = fsItem.Type;
			Name = fsItem.Name;
		}

		public FSType Type { get; private set; }
		public String Name { get; private set; }
	}
}
