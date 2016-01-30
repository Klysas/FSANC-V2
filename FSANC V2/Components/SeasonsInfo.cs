using System;
using System.Collections.Generic;
using System.Drawing;
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
		/// Updates control using given series information(seasons & episodes). If required, updates series info from database.
		/// </summary>
		/// <param name="series"></param>
		public void Update(Series series)
		{
			// TODO: implement.
		}

		/// <summary>
		/// Clears all stored information in control.
		/// </summary>
		public void ClearInfo()
		{
			foreach (var label in _linkLables)
			{
				var listBox = (label.Tag as ListBox);
				if (listBox != null)
				{
					listBox.Items.Clear();
					listBox.Items.Add(string.Format("{0} \t{1}", "Number", "Title"));
				}
			}
		}

		//-------------------------------------------------------------
		//	Private methods
		//-------------------------------------------------------------

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

		private ListBox CreateListBox()
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

		// Shows required number of link labels(adds more if needed).
		private void ShowLinkLables(int number)
		{
			if (number > _linkLables.Count)
			{
				CreateLinkLabels(number - _linkLables.Count);
			}

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
