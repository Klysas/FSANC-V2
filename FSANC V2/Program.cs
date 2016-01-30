using System;
using System.Windows.Forms;

namespace FSANC_V2
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (Properties.Settings.Default.API_KEY.Equals(string.Empty))
			{
				Application.Run(new KeyGatherer());
			}

			if (!Properties.Settings.Default.API_KEY.Equals(string.Empty))
			{
				Application.Run(new MainForm());
			}
		}
	}
}