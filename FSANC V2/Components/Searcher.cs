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
	public partial class Searcher : UserControl
	{
		#region Enum

		private enum SearchType
		{
			BOTH,
			MOVIE,
			SERIES
		}

		private enum Keys
		{
			ENTER = 13
		}

		#endregion

		#region Public constructors

		public Searcher()
		{
			InitializeComponent();

			this.CmbBoxType.DataSource = Enum.GetValues(typeof(SearchType));

			// TODO(Klysas): Move to designer file.
			this.LstViewSearchResults.Columns.Add("Type", -2, HorizontalAlignment.Left);
			this.LstViewSearchResults.Columns.Add("Title", -2, HorizontalAlignment.Left);
			this.LstViewSearchResults.Columns.Add("Year", -2, HorizontalAlignment.Left);

			// Event handlers
			this.LstViewSearchResults.ColumnClick += LstViewSearchResults_ColumnClick;
			this.CmbBoxType.SelectedIndexChanged += CmbBoxType_SelectedIndexChanged;
			this.TxtBoxSearch.KeyPress += TxtBoxSearch_KeyPress;
			this.BkWorkerSearcher.RunWorkerCompleted += BkWorkerSearcher_RunWorkerCompleted;
			this.BkWorkerSearcher.DoWork += BkWorkerSearcher_DoWork;

			// Setting up current state
			this.CmbBoxType.SelectedIndex = (int)SearchType.BOTH;
			this.CmbBoxType.Focus();
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Event when item is selected in list view.
		/// </summary>
		/// <param name="handler"></param>
		public void AddEvenHandlerItemSelectionChanged(ListViewItemSelectionChangedEventHandler handler)
		{
			this.LstViewSearchResults.ItemSelectionChanged += handler;
		}

		#endregion

		#region Private variables

		private SearchType _current;

		#endregion

		#region Private methods

		private void RunSearch()
		{
			string name = TxtBoxSearch.Text.Trim();
			if (name == string.Empty)
			{
				TxtBoxToolTip.Show("", this.TxtBoxSearch, 10, 10, 5000);
				TxtBoxToolTip.Show("Field is empty.", this.TxtBoxSearch, 10, 10, 5000);
				return;
			}

			LstViewSearchResults.Items.Clear();
			LstViewResizeColumns();
			EnableControls(false);
			BkWorkerSearcher.RunWorkerAsync();
		}

		private void AddToSearchResultsListView(AbstractVideo[] list)
		{
			if (this.LstViewSearchResults.InvokeRequired)
			{
				this.Invoke(new MethodInvoker(delegate()
				{
					foreach (AbstractVideo video in list)
					{
						LstViewSearchResults.Items.Add(new ListViewItem(new[] { video.Type.ToString(), video.Name, video.Year.ToString() })).Tag = video;
					}
				}));
			}
			else
			{
				foreach (AbstractVideo video in list)
				{
					LstViewSearchResults.Items.Add(new ListViewItem(new[] { video.Type.ToString(), video.Name, video.Year.ToString() })).Tag = video;
				}
			}
		}

		private void SetStatus(string status)
		{
			if (this.Parent is MainForm)
			{
				((MainForm)this.Parent).SetStatus(status);
			}
		}

		/// <summary>
		/// NOTE: Thread NOT safe.
		/// </summary>
		/// <param name="enable"></param>
		private void EnableControls(bool enable)
		{
			this.CmbBoxType.Enabled = enable;
			this.TxtBoxSearch.Enabled = enable;
			this.LstViewSearchResults.Enabled = enable;
			this.BtnSearch.Enabled = enable;
		}

		/// <summary>
		/// NOTE: Thread NOT safe.
		/// </summary>
		private void LstViewResizeColumns(){
			if (this.LstViewSearchResults.Items.Count == 0)
			{
				this.LstViewSearchResults.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			}
			else
			{
				this.LstViewSearchResults.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			}
		}

		#endregion

		#region Private event handlers

		void LstViewSearchResults_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			this.LstViewSearchResults.Sort(); // TODO: Sorting by selected column.
		}

		private void TxtBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.TxtBoxToolTip.Hide(this.TxtBoxSearch);

			if ((int)e.KeyChar == (int)Keys.ENTER)
			{
				RunSearch();
			}
		}

		private void CmbBoxType_SelectedIndexChanged(object sender, EventArgs e)
		{
			_current = (SearchType)this.CmbBoxType.SelectedValue;
		}

		void BkWorkerSearcher_DoWork(object sender, DoWorkEventArgs e)
		{
			SetStatus("Searching...");

			string name = TxtBoxSearch.Text.Trim();

			switch (_current)
			{
				case SearchType.BOTH:
					{
						AddToSearchResultsListView(Database.Instance.FindMoviesAndTvShows(name));
					}
					break;
				case SearchType.MOVIE:
					{
						AddToSearchResultsListView(Database.Instance.FindMovies(name));
					}
					break;
				case SearchType.SERIES:
					{
						AddToSearchResultsListView(Database.Instance.FindTvShows(name));
					}
					break;
			}
		}

		private void BkWorkerSearcher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			LstViewResizeColumns();
			EnableControls(true);
			SetStatus("Search complete.");
		}

		private void BtnSearch_Click(object sender, EventArgs e)
		{
			RunSearch();
		}

		#endregion
	}
}
