using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FSANC_V2
{
	public partial class SerialEpisodeValuesChanger : Form
	{
		//=============================================================
		//	Private variables
		//=============================================================

		private readonly Regex _regex;

		//=============================================================
		//	Public constructors
		//=============================================================

		public SerialEpisodeValuesChanger()
		{
			InitializeComponent();

			_regex = new Regex(@"[^\d]+"); // Leaves only numeric.
		}

		//=============================================================
		//	Private events
		//=============================================================

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void ButtonOK_Click(object sender, EventArgs e)
		{
			int season, episode;
			int.TryParse(TextBox_SeasonNumber.Text, out season);
			int.TryParse(TextBox_EpisodeNumber.Text, out episode);

			SeasonNumber = season;
			EpisodeNumber = episode;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void SerialEpisodeValuesChanger_Load(object sender, EventArgs e)
		{
			TextBox_SeasonNumber.Text = "";
			TextBox_EpisodeNumber.Text = "";

			SeasonNumber = 0;
			EpisodeNumber = 0;
		}

		private void TextBox_TextChanged(object sender, EventArgs e)
		{
			var textBox = sender as TextBox;
			if (textBox == null) return;
			textBox.Text = _regex.Replace(textBox.Text, "");
		}

		//=============================================================
		//	Public properties
		//=============================================================

		/// <summary>
		/// [GET]
		/// </summary>
		public int SeasonNumber
		{
			get;
			private set;
		}

		/// <summary>
		/// [GET]
		/// </summary>
		public int EpisodeNumber
		{
			get;
			private set;
		}
	}
}
