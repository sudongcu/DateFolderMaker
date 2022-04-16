using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateFolderMaker.Utils
{
	// util only for validation
	public static class ValidationUtil
	{
		/// <summary>
		/// check image validation
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static bool IsValidImage(string fileName)
		{
			try
			{
				using (Image newImage = Image.FromFile(fileName))
				{ }
			}
			catch (OutOfMemoryException)
			{
				return false;
			}
			return true;
		}

	}
}
