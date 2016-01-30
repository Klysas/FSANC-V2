using SeriesMovieInfoDatabase;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FSANC_V2
{
	public partial class KeyGatherer : Form
	{
		//=============================================================
		//	Private variables
		//=============================================================

		private readonly Point _toolTipPosition;

		//=============================================================
		//	Public constructors
		//=============================================================

		public KeyGatherer()
		{
			InitializeComponent();

			_toolTipPosition = new Point(5, 5);

			TextBox_Key.GotFocus += TextBoxKey_GotFocus;
		}

		//=============================================================
		//	Private events
		//=============================================================

		private void ButtonOK_Click(object sender, EventArgs e)
		{
			if (TextBox_Key.Text.Trim().Equals(string.Empty))
			{
				ToolTip.Show("Input API key.", TextBox_Key, _toolTipPosition);
			}
			else
			{
				string key = TextBox_Key.Text.Trim();
				if (Database.IsKeyValid(key))
				{
					Properties.Settings.Default.API_KEY = key;
					Properties.Settings.Default.Save();
					Close();
				}
				else
				{
					ToolTip.Show("Incorrect API key, make sure that you input correct key.", TextBox_Key, _toolTipPosition);
				}
			}
		}

		private void LinkLabelTMDB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://www.themoviedb.org/");
		}

		private void TextBoxKey_GotFocus(object sender, EventArgs e)
		{
			ToolTip.Hide(TextBox_Key);
		}
	}
}
