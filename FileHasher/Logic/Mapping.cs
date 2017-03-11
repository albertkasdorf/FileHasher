using FileHasher.ObjectModel;
using FileHasher.Properties;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileHasher.Logic
{
	public static class Mapping
	{
		public static TaskbarProgressBarState ToTaskbarProgressBarState(
			ProgressBarStyle style )
		{
			switch( style )
			{
			case ProgressBarStyle.Blocks: return TaskbarProgressBarState.Normal;
			case ProgressBarStyle.Continuous: return TaskbarProgressBarState.Normal;
			case ProgressBarStyle.Marquee: return TaskbarProgressBarState.Indeterminate;
			default:
				throw new NotImplementedException( typeof( ProgressBarStyle).Name );
			}
		}

		public static Image ToImage( UIType uiType )
		{
			switch( uiType )
			{
			case UIType.AddedFile: return Resources.AddFile_16x;
			case UIType.AddedFolder: return Resources.AddFolder_16x;
			case UIType.ChangedFile: return Resources.EditPage_16x;
			case UIType.DeletedFile: return Resources.NoResults_16x;
			case UIType.DeletedFolder: return Resources.DeleteFolder_16x;
			case UIType.ExaminedFolder: return Resources.FindinFiles_16x;
			case UIType.FaultedFile: return Resources.FileError_16x;
			case UIType.FaultedFolder: return Resources.FolderError_16x;
			default:
				throw new NotImplementedException( typeof( UIType ).Name );
			}
		}
	}
}
