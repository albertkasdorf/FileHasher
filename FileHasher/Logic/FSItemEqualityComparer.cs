using FileHasher.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHasher.Logic
{
	public class FSItemEqualityComparer : IEqualityComparer<FSItem>
	{
		public FSItemEqualityComparer(
			bool includeName = true, bool includeHash = true )
		{
			this.includeName = includeName;
			this.includeHash = includeHash;
		}

		private bool includeName;
		private bool includeHash;

		public Boolean Equals( FSItem x, FSItem y )
		{
			var typeEqual = (x.Type == y.Type);
			var nameEqual = includeName ? string.Compare( x.Name, y.Name, false ).Equals( 0 ) : true;
			var hashEqual = includeHash ? string.Compare( x.Hash, y.Hash, true ).Equals( 0 ) : true;

			return typeEqual && nameEqual && hashEqual;
		}

		public Int32 GetHashCode( FSItem obj )
		{
			var hash1 = obj.Type.GetHashCode( );
			var hash2 = includeName ? obj.Name.GetHashCode( ) : 0;
			var hash3 = (includeHash && obj.Hash != null) ? obj.Hash.GetHashCode( ) : 0;
			var hash4 = (includeHash && obj.Exception != null) ? obj.Exception.GetHashCode( ) : 0;

			return hash1 + hash2 + hash3 + hash4;
		}
	}
}
