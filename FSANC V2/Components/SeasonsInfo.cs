using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSANC_V2
{
	public partial class SeasonsInfo : UserControl
	{
		#region Private variables

		// X postion, at which next created label will be set.
		private int _linkLabelPosX = 7;

		private List<LinkLabel> _linkLables;

		#endregion

		#region Public properties

		public bool IsLoading
		{
			get;
			private set;
		}

		public bool IsEmpty
		{
			get;
			private set;
		}

		#endregion

		#region Public constructors

		public SeasonsInfo()
		{
			InitializeComponent();

			_linkLables = new List<LinkLabel>();
		}

		#endregion

		#region Private methods

		private void ShowLinkLables(int number)
		{
			if (number > _linkLables.Count)
			{
				CreateLinkLabels(number - _linkLables.Count);
			}

			// Hides unwanted controls.
			for (int i = 0; i < _linkLables.Count; i++)
			{
				if (i < number) 
				{ 
					_linkLables[i].Show(); 
				}
				else
				{ 
					_linkLables[i].Hide();
				}
			}
		}

		// Creates link lables(adds to the end of list).
		private void CreateLinkLabels(int number)//TODO: put all to list, so later I can dispose of them. Create at start and use how many you need(create more if needed), but don't recreate.
		{
			int x = _linkLabelPosX;
			int upperLimit = number + _linkLables.Count;
			for (int i = _linkLables.Count; i < upperLimit; i++)
			{
				// Link label...
				var label = new LinkLabel();

				GrpSeasons.Controls.Add(label);
				_linkLables.Add(label);

				label.AutoSize = true;
				label.Text = (i + 1).ToString();

				label.Location = new System.Drawing.Point(x, 20);
				x += label.Width;

				// List box...
				var listbox = CreateListBox();

				GrpSeasons.Controls.Add(listbox);

				label.Tag = listbox;
			}
			_linkLabelPosX = x;
		}

		private ListBox CreateListBox()
		{
			var listBox = new ListBox();
			listBox.FormattingEnabled = true;
			listBox.Location = new System.Drawing.Point(7, 47);
			listBox.Size = new System.Drawing.Size(409, 147);

			listBox.Items.Add(string.Format("{0} \t{1}", "Number", "Title"));

			return listBox;
		}

		#endregion

		#region Public methods

		public void UpdateInfo(Series series)
		{
			//TODO: Validate seasons and episodes info.

			//TODO: update seasons and episodes information.

			ShowLinkLables(series.Seasons.Length);


			foreach (Episode episode in series.Seasons[0].Episodes)
			{
				((ListBox)_linkLables[0].Tag).Items.Add(string.Format("{0} \t{1}", episode.EpisodeNumber, episode.Name));
			}
			//listBox1.Items.Add(string.Format("{0} \t{1}", series.Seasons[0].getEpisode(1).EpisodeNumber, series.Seasons[0].getEpisode(1).Name));
		}

		public void ClearInfo()
		{
			//TODO: clear list.
		}

		#endregion
	}
}
