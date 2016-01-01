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
	public partial class Settings : Form
	{
		//=============================================================
		//	Private variables
		//=============================================================

		private Properties.Settings _settings = Properties.Settings.Default;

		//=============================================================
		//	Public constructors
		//=============================================================
		
		public Settings()
		{
			InitializeComponent();

			// Set default values if no value is set.
			if (_settings.MOVIE_NAME_FORMAT == string.Empty) _settings.MOVIE_NAME_FORMAT = Properties.Resources.DEFAULT_MOVIE_NAME_FORMAT;
			if (_settings.SERIES_NAME_FORMAT == string.Empty) _settings.SERIES_NAME_FORMAT = Properties.Resources.DEFAULT_SERIES_NAME_FORMAT;
			_settings.Save();

			UpdateUI();
		}

		//=============================================================
		//	Private events
		//=============================================================

		private void Btn_Save_Click(object sender, EventArgs e)
		{
			Save();
			this.Close();
		}

		private void Btn_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void Settings_Shown(object sender, EventArgs e)
		{
			UpdateUI();
		}

		//=============================================================
		//	Private methods
		//=============================================================

		private void UpdateUI(){
			_settings.Reload();
			TxtBox_MovieNameFormat.Text = _settings.MOVIE_NAME_FORMAT;
			TxtBox_SeriesNameFormat.Text = _settings.SERIES_NAME_FORMAT;
		}

		private void Save()
		{
			// TODO: settings validation.
			_settings.SERIES_NAME_FORMAT = TxtBox_SeriesNameFormat.Text;
			_settings.MOVIE_NAME_FORMAT = TxtBox_MovieNameFormat.Text;
			_settings.Save();
		}
	}
}
