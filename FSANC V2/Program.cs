using LinkedListModifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMDbLib.Client;
using TMDbLib.Objects.Authentication;

namespace FSANC_V2
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
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

