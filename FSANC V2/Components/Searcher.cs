using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SeriesMovieInfoDatabase;
using SeriesMovieInfoDatabase.Objects;

namespace FSANC_V2.Components
{
	public partial class Searcher : UserControl
	{
		//=============================================================
		//	Private variables
		//=============================================================

		private SearchType _current;

		/// <summary>
		/// Movies and series database.
		/// </summary>
		private readonly Database _database;

		//=============================================================
		//	Public constructors
		//=============================================================

		public Searcher()
		{
			InitializeComponent();

			_database = new Database(Properties.Settings.Default.API_KEY);
			_database.VideoFound += Database_VideoFound;

			ComboBox_Type.DataSource = Enum.GetValues(typeof(SearchType));

			// CHECK: maybe change something?
			// Setting up current state
			ComboBox_Type.SelectedIndex = (int)SearchType.Both;
			ComboBox_Type.Focus();
			EnableControls(true);
		}

		//=============================================================
		//	Public events
		//=============================================================

		public event ListViewItemSelectionChangedEventHandler SearchResultSelectionChanged
		{
			add { ListView_SearchResults.ItemSelectionChanged += value; }
			remove { ListView_SearchResults.ItemSelectionChanged -= value; }
		}

		//-------------------------------------------------------------
		//	Private events
		//-------------------------------------------------------------

		private void ButtonSearch_Click(object sender, EventArgs e)
		{
			RunSearch();
		}

		private void ButtonStopSearch_Click(object sender, EventArgs e)
		{
			_database.Stop();
		}

		private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
		{
			_current = (SearchType)ComboBox_Type.SelectedItem;
		}

		private void Database_VideoFound(object sender, Database.VideoFoundEventArgs e)
		{
			if (ListView_SearchResults.InvokeRequired)
			{
				Invoke(new MethodInvoker(delegate
				{
					AddAbstractVideoToResultsListView(e.Video);
				}));
			}
			else
			{
				AddAbstractVideoToResultsListView(e.Video);
			}
		}

		private void TextBoxSearchField_KeyPress(object sender, KeyPressEventArgs e)
		{
			TextBox_ToolTip.Hide(TextBox_SearchField);

			if (e.KeyChar == (int)Keys.Enter)
			{
				RunSearch();
			}
		}

		//=============================================================
		//	Private enums
		//=============================================================

		private enum SearchType
		{
			Both,
			Movies,
			Series
		}

		private enum Keys
		{
			Enter = 13
		}

		//=============================================================
		//	Private methods
		//=============================================================

		private void AddAbstractVideoToResultsListView(AbstractVideo video)
		{
			var item = new ListViewItem(new[] { video.Type.ToString(), video.Title, video.Year.ToString() }) { Tag = video };
			ListView_SearchResults.Items.Add(item);
			ListView_SearchResults.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		private void EnableControls(bool enable)
		{
			ComboBox_Type.Enabled = enable;
			TextBox_SearchField.Enabled = enable;
			Button_Search.Enabled = enable;

			Button_StopSearch.Enabled = !enable;
		}

		private async void RunSearch()
		{
			var title = TextBox_SearchField.Text.Trim();
			if (string.IsNullOrEmpty(title))
			{
				TextBox_ToolTip.Show("", TextBox_SearchField, 10, 10, 5000);
				TextBox_ToolTip.Show("Field is empty.", TextBox_SearchField, 10, 10, 5000);
				return;
			}

			ListView_SearchResults.Items.Clear();

			EnableControls(false);
			switch (_current)
			{
				case SearchType.Both:
					{
						await Task.Run(() => _database.FindSeriesAndMovies(title));
						break;
					}
				case SearchType.Movies:
					{
						await Task.Run(() => _database.FindMovies(title));
						break;
					}
				case SearchType.Series:
					{
						await Task.Run(() => _database.FindSeries(title));
						break;
					}
			}
			EnableControls(true);
		}
	}
}
