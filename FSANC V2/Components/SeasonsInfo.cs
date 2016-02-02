using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SeriesMovieInfoDatabase.Objects;

namespace FSANC_V2.Components
{
	public partial class SeasonsInfo : UserControl
	{
		//=============================================================
		//	Private variables
		//=============================================================

		// X position, at which next created label will be set.
		private int _linkLabelPosX = 7;

		private readonly List<LinkLabel> _linkLables;

		//=============================================================
		//	Public constructors
		//=============================================================

		public SeasonsInfo()
		{
			InitializeComponent();

			_linkLables = new List<LinkLabel>();
		}

		//=============================================================
		//	Private events
		//=============================================================

		private void LinkLabel_Click(object sender, EventArgs e)
		{
			foreach (var label in _linkLables)
			{
				(label.Tag as ListBox).Hide();
			}
			((sender as LinkLabel).Tag as ListBox).Show();
		}

		//=============================================================
		//	Public methods
		//=============================================================

		/// <summary>
		/// Updates control using given series information(seasons & episodes).
		/// </summary>
		/// <param name="series"></param>
		public void Update(Series series)
		{
			ClearInfo();

			if (series.SeasonsCount == 0) return; // TODO: Show "No information".

			PrepareControls(series.SeasonsCount);

			// Add information.
			for (int index = 0; index < series.Seasons.Length; index++)
			{
				var season = series.Seasons[index];
				var listBox = _linkLables[index].Tag as ListBox;
				if (listBox == null) continue; // CHECK: maybe throw RunTimeException, because it shouldn't happen.
				foreach (var episode in season.Episodes)
				{
					listBox.Items.Add(string.Format("{0} \t{1}", episode.Number, episode.Title));
				}
			}

			ShowControls(series.SeasonsCount);
		}

		//-------------------------------------------------------------
		//	Private methods
		//-------------------------------------------------------------

		/// <summary>
		/// Clears all stored information in control.
		/// </summary>
		private void ClearInfo()
		{
			foreach (var listBox in _linkLables.Select(label => (label.Tag as ListBox)).Where(listBox => listBox != null))
			{
				listBox.Items.Clear();
				listBox.Items.Add(string.Format("{0} \t{1}", "Number", "Title"));
			}
		}

		// Creates link labels(adds to the end of list).
		private void CreateLinkLabels(int number)
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
				label.Text = label.Name = (i + 1).ToString();
				label.Font = new Font("Microsoft Sans Serif", 13);

				label.Location = new Point(x, 20);
				x += label.Width;

				label.Click += LinkLabel_Click;

				// List box...
				var listbox = CreateListBox();

				GrpSeasons.Controls.Add(listbox);

				label.Tag = listbox;
			}
			_linkLabelPosX = x;
		}

		private static ListBox CreateListBox()
		{
			var listBox = new ListBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom)
						  | AnchorStyles.Left) | AnchorStyles.Right,
				FormattingEnabled = true,
				Location = new Point(7, 47),
				Size = new Size(409, 147)
			};
			listBox.Items.Add(string.Format("{0} \t{1}", "Number", "Title"));

			return listBox;
		}

		// Prepares controls. Call this before adding information from Series. If needed creates more controls.
		private void PrepareControls(int seasonCount)
		{
			if (seasonCount > _linkLables.Count)
			{
				CreateLinkLabels(seasonCount - _linkLables.Count);
			}
		}

		// Shows required number of link labels
		private void ShowControls(int number)
		{
			// Hides unwanted controls(shows others).
			for (var i = 0; i < _linkLables.Count; i++)
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
	}
}
