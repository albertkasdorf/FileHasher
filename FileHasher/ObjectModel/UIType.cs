using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHasher.ObjectModel
{
	public enum UIType
	{
		AddedFile,
		AddedFolder,

		ChangedFile,

		DeletedFile,
		DeletedFolder,

		ExaminedFolder,

		FaultedFile,
		FaultedFolder,
	}
}
