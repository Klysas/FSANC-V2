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

		private void Search()
		{
			SetStatus("Searching...");

			LstViewSearchResults.Items.Clear();
			this.LstViewSearchResults.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

			string name = TxtBoxSearch.Text.Trim();
			if (name == string.Empty) return;

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

			this.LstViewSearchResults.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

			SetStatus("Search complete.");
		}

		private void AddToSearchResultsListView(AbstractVideo[] list)
		{
			foreach (AbstractVideo video in list)
			{
				LstViewSearchResults.Items.Add(new ListViewItem(new[] { video.Type.ToString(), video.Name, video.Year.ToString() })).Tag = video;
			}
		}

		private void SetStatus(string status)
		{
			if (this.Parent is MainForm)
			{
				((MainForm)this.Parent).SetStatus(status);
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
			if ((int)e.KeyChar == (int)Keys.ENTER)
			{
				Search();
			}
		}

		private void CmbBoxType_SelectedIndexChanged(object sender, EventArgs e)
		{
			_current = (SearchType)this.CmbBoxType.SelectedValue;
		}

		#endregion

	}
}
