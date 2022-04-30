using System.Collections.Generic;

namespace DFMObject.Models
{
	public class ModelDateFolderAndFiles
	{
		/// <summary>
		/// folder name ( yyyy-MM-dd )
		/// </summary>
		public string folder { get; set; }

		/// <summary>
		/// files that will move to folder 
		/// </summary>
		public List<string> fileList { get; set; }
	}
}
