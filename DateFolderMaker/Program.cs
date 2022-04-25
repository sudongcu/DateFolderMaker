using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DateFolderMaker
{
	static class Program
	{
		/// <summary>
		/// main
		/// </summary>
		[STAThread]
		static void Main()
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.UnhandledException += new UnhandledExceptionEventHandler(CustomExceptionHandler);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new DateFolderMaker());
		}

		/// <summary>
		/// custom exception handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		static void CustomExceptionHandler(object sender, UnhandledExceptionEventArgs args)
		{
			Exception ex = (Exception)args.ExceptionObject;
			Trace.WriteLine($"CustomExceptionHandler[{ex.Source}] : {ex.Message}");
			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
