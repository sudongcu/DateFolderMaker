using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateFolderMaker.Utils
{
	/// <summary>
	/// Util about data
	/// </summary>
	public static class DataUtil
	{
		/// <summary>
		/// make string file path
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static string FilePath(params string[] args)
		{
			return string.Join("\\", args);
		}
	}
}
