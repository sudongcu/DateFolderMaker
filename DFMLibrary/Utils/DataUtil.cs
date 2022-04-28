using System;

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
			try
			{
				return DateTime.Parse(arg).ToShortDateString();
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public static string TotalTextFormat(int count)
		{
			return $"{count} Files";
		}
	}
}
