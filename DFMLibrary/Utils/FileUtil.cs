using DFMObject.Enums;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

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
				// 이미지 유효성 검사
				if (ValidationUtil.IsValidImage(imgFile))
				{
					Image image = new Bitmap(imgFile);
					PropertyItem[] propItems = image.PropertyItems;
					image.Dispose();

					ASCIIEncoding encoding = new ASCIIEncoding();

					string[] values = encoding.GetString(propItems.Where(s => s.Id == (int)IMAGE_META_DATA.CREATE_DATE_TIME).Select(s => s.Value).FirstOrDefault()).Replace("?", "").Split(' ');

					return values[0].Replace(":", "-") + " " + values[1];
				}
				else
				{
					FileInfo fileInfo = new FileInfo(imgFile);
					return fileInfo.LastWriteTime.ToString();
				}
			}
			catch
			{
				FileInfo fileInfo = new FileInfo(imgFile);
				return fileInfo.LastWriteTime.ToString();
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
