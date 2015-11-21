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

			BgWorker_SeriesUpdater.RunWorkerCompleted += BgWorker_SeriesUpdater_RunWorkerCompleted;
			BgWorker_SeriesUpdater.DoWork += BgWorker_SeriesUpdater_DoWork;
		}

		#endregion

		#region Private methods

		private void SetLoading(bool loading = true)
		{
			IsLoading = loading;
			if (loading)
			{	//Loading.

			}
			else
			{	//Not loading.

			}
		}

		// Shows required number of link lables(adds more if needed).
		private void ShowLinkLables(int number)
		{
			if (number > _linkLables.Count)
			{
				CreateLinkLabels(number - _linkLables.Count);
			}

			// Hides unwanted controls(shows others).
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

				label.Location = new System.Drawing.Point(x, 20);
				x += label.Width;

				label.Click += LnkLabel_Click;

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

		void LnkLabel_Click(object sender, EventArgs e)
		{
			foreach (var label in _linkLables)
			{
				(label.Tag as ListBox).Hide();
			}
			((sender as LinkLabel).Tag as ListBox).Show();
		}

		void BgWorker_SeriesUpdater_DoWork(object sender, DoWorkEventArgs e)
		{
			SetLoading();
			e.Result = Database.Instance.UpdateSeasonsEpisodesInfo(e.Argument as Series);
			if ((sender as BackgroundWorker).CancellationPending)
			{
				e.Cancel = true;
			}
		}

		void BgWorker_SeriesUpdater_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{
				var series = (e.Result as Series);

				ShowLinkLables(series.Seasons.Length);
				// Store information.
				ClearInfo();
				foreach (var season in series.Seasons)
				{
					foreach (Episode episode in season.Episodes)
					{
						((ListBox)_linkLables[episode.SeasonNumber - 1].Tag).Items.Add(string.Format("{0} \t{1}", episode.EpisodeNumber, episode.Name));
					}
				}

				SetLoading(false);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Thread stopped.");
				SetLoading(false);
				(sender as BackgroundWorker).Dispose();
			}
			finally
			{
			
			}
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Updates control using given series information(seasons & episodes). If required, updates series info from database.
		/// </summary>
		/// <param name="series"></param>
		public void UpdateInfo(Series series)
		{
			if (series == null)
			{
				new ArgumentNullException("Series is null.");
			}

			//TODO: async cancellation.
			if (!BgWorker_SeriesUpdater.IsBusy)
			{
				BgWorker_SeriesUpdater.RunWorkerAsync(series);
			}
			else
			{
				Console.WriteLine("BGWorker is busy.");
				//BgWorker_SeriesUpdater.CancelAsync();
				//BgWorker_SeriesUpdater = new BackgroundWorker();
				//BgWorker_SeriesUpdater.WorkerSupportsCancellation = true;
				//BgWorker_SeriesUpdater.RunWorkerAsync(series);
			}
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

		#endregion
	}
}
