using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileHasher.ObjectModel
{
	public class UIProgress
	{
		public UIProgress( String message )
		{
			Message = message;
			Style = ProgressBarStyle.Marquee;

			FileCount = FilesProcessed = Progress = 0;
		}

		public UIProgress( String message, Int32 fileCount, Int32 filesProcessed )
		{
			Message = message;
			Style = ProgressBarStyle.Continuous;
			FileCount = fileCount;
			FilesProcessed = filesProcessed;

			var progress =
				(Convert.ToDouble( filesProcessed ) / Convert.ToDouble( fileCount )) * 100;
			Progress = Math.Min( 100, Convert.ToInt32( progress ) );
		}

		public String Message { get; private set; }
		public ProgressBarStyle Style { get; private set; }

		public Int32 FileCount { get; private set; }
		public Int32 FilesProcessed { get; private set; }
		public Int32 Progress { get; private set; }
	}
}
