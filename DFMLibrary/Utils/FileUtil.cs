using DFMObject.Enums;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DFMLibrary.Utils
{
	public static class FileUtil
	{
		/// <summary>
		/// get file's property date value
		/// </summary>
		/// <param name="imgFile"></param>
		/// <returns></returns>
		public static string GetFileDate(string imgFile)
		{
			try
			{
				using (FileStream fs = File.OpenRead(imgFile))
				{
					using (Image image = Image.FromStream(fs, false, true))
					{
						PropertyItem[] propItems = image.PropertyItems;

						ASCIIEncoding encoding = new ASCIIEncoding();

						string[] values = encoding.GetString(propItems.Where(s => s.Id == (int)IMAGE_META_DATA.CREATE_DATE_TIME).Select(s => s.Value).FirstOrDefault()).Replace("?", "").Split(' ');

						values[1] = values[1].Length > 8 ? values[1].Substring(0, 8) : values[1];
						// replace 24:00:00 to 00:00:00
						values[1] = Regex.Replace(values[1], @"24:(\d\d:\d\d)$", "00:$1");

						return values[0].Replace(":", "-") + " " + values[1];
					}
				}
			}
			catch
			{
				FileInfo fileInfo = new FileInfo(imgFile);
				return fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
			}
		}

		/// <summary>
		/// open directory popup
		/// </summary>
		/// <param name="path"></param>
		public static void OpenDirectory(string path)
		{
			if (string.IsNullOrEmpty(path) == false)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(path);

				if (directoryInfo.Exists)
					Process.Start(path);
			}
		}
	}
}
