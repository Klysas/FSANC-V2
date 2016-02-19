using System;
using System.Windows.Forms;

namespace FSANC_V2
{
	public partial class Settings : Form
	{
		//=============================================================
		//	Private variables
		//=============================================================

		private readonly Properties.Settings _settings = Properties.Settings.Default;

		//=============================================================
		//	Public constructors
		//=============================================================

		public Settings()
		{
			InitializeComponent();

			// Set default values if no value is set.
			if (_settings.FORMAT_MOVIE_FILE_NAME.Equals(""))
				_settings.FORMAT_MOVIE_FILE_NAME = Properties.Resources.DEFAULT_FORMAT_MOVIE_FILE_NAME;
			if (_settings.FORMAT_SERIES_FILE_NAME.Equals(""))
				_settings.FORMAT_SERIES_FILE_NAME = Properties.Resources.DEFAULT_FORMAT_SERIES_FILE_NAME;
			if (_settings.FORMAT_MOVIE_DIR_NAME.Equals(""))
				_settings.FORMAT_MOVIE_DIR_NAME = Properties.Resources.DEFAULT_FORMAT_MOVIE_DIR_NAME;
			if (_settings.FORMAT_SERIES_DIR_NAME.Equals(""))
				_settings.FORMAT_SERIES_DIR_NAME = Properties.Resources.DEFAULT_FORMAT_SERIES_DIR_NAME;
			_settings.Save();

			UpdateUI();
		}

		//=============================================================
		//	Private events
		//=============================================================

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ButtonDefaultMovieFileNameFormat_Click(object sender, EventArgs e)
		{
			TextBox_MovieNameFileFormat.Text = Properties.Resources.DEFAULT_FORMAT_MOVIE_FILE_NAME;
		}

		private void ButtonDefaultSeriesFileNameFormat_Click(object sender, EventArgs e)
		{
			TextBox_SeriesNameFileFormat.Text = Properties.Resources.DEFAULT_FORMAT_SERIES_FILE_NAME;
		}

		private void ButtonDefaultMovieDirNameFormat_Click(object sender, EventArgs e)
		{
			TextBox_MovieNameDirFormat.Text = Properties.Resources.DEFAULT_FORMAT_MOVIE_DIR_NAME;
		}

		private void ButtonDefaultSeriesDirNameFormat_Click(object sender, EventArgs e)
		{
			TextBox_SeriesNameDirFormat.Text = Properties.Resources.DEFAULT_FORMAT_SERIES_DIR_NAME;
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			SaveSettings();
			Close();
		}

		private void Settings_Shown(object sender, EventArgs e)
		{
			UpdateUI();
		}

		//=============================================================
		//	Private static methods
		//=============================================================

		private static void UpdateSettings(Control control)
		{
			if (control == null) return;

			var settingsControl = control as ISettings;
			if (settingsControl != null)
			{
				settingsControl.UpdateSettings();
			}

			foreach (var item in control.Controls)
			{
				UpdateSettings((Control)item);
			}
		}

		//-------------------------------------------------------------
		//	Private non-static methods
		//-------------------------------------------------------------

		private void UpdateUI()
		{
			_settings.Reload();
			TextBox_MovieNameFileFormat.Text = _settings.FORMAT_MOVIE_FILE_NAME;
			TextBox_SeriesNameFileFormat.Text = _settings.FORMAT_SERIES_FILE_NAME;
			TextBox_MovieNameDirFormat.Text = _settings.FORMAT_MOVIE_DIR_NAME;
			TextBox_SeriesNameDirFormat.Text = _settings.FORMAT_SERIES_DIR_NAME;
		}

		private void SaveSettings()
		{
			// TODO: settings validation.
			_settings.FORMAT_SERIES_FILE_NAME = TextBox_SeriesNameFileFormat.Text;
			_settings.FORMAT_MOVIE_FILE_NAME = TextBox_MovieNameFileFormat.Text;
			_settings.FORMAT_MOVIE_DIR_NAME = TextBox_MovieNameDirFormat.Text;
			_settings.FORMAT_SERIES_DIR_NAME = TextBox_SeriesNameDirFormat.Text;
			_settings.Save();
			UpdateSettings(Owner);
		}
	}
}
