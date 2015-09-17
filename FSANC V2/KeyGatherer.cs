using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSANC_V2
{
	public partial class KeyGatherer : Form
	{

		#region Public constructors

		public KeyGatherer()
		{
			InitializeComponent();

			_toolTipPosition = new Point(5, 5);

			TxtBoxKey.GotFocus += TxtBoxKey_GotFocus;
		}

		#endregion

		#region Private variables

		private Point _toolTipPosition;

		#endregion

		#region Private event handlers

		private void LnkLblTMDB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://www.themoviedb.org/");
		}

		private void BtnOk_Click(object sender, EventArgs e)
		{
			if (TxtBoxKey.Text.Trim().Equals(string.Empty))
			{
				TolTip.Show("Input API key.", this.TxtBoxKey, _toolTipPosition);
			}
			else
			{
				string key = TxtBoxKey.Text.Trim();
				if (Utils.IsKeyValid(key))
				{
					Properties.Settings.Default.API_KEY = key;
					Properties.Settings.Default.Save();
					this.Close();
					this.Dispose();
				}
				else
				{
					TolTip.Show("Incorrect API key, make sure that you input correct key.", this.TxtBoxKey, _toolTipPosition);
				}
			}
		}

		private void TxtBoxKey_GotFocus(object sender, EventArgs e)
		{
			TolTip.Hide(this.TxtBoxKey);
		}

		#endregion
	}
}
