using System;
using System.Globalization;

namespace DFMLibrary.Utils
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

		/// <summary>
		/// get only date string
		/// </summary>
		/// <param name="arg"></param>
		/// <returns></returns>
		public static string ShortDateTimeFormat(string arg)
		{
			return DateTime.Parse(arg).ToShortDateString();
		}
	}
}
