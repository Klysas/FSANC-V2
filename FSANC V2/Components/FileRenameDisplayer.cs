using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SeriesMovieInfoDatabase.Objects;

namespace FSANC_V2.Components
{
	public partial class FileRenameDisplayer : AbstractVideoDisplayer
	{
		//=============================================================
		//	Private variables
		//=============================================================

		private readonly List<File> _files;

		//=============================================================
		//	Public constructors
		//=============================================================

		public FileRenameDisplayer()
		{
			InitializeComponent();

			_files = new List<File>();

			UpdateUI();
		}

		//=============================================================
		//	Private events
		//=============================================================

		private void ButtonRenameFiles_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void ButtonSelectFiles_Click(object sender, EventArgs e)
		{
			OpenFileDialog.ShowDialog();
			foreach (var path in OpenFileDialog.FileNames.Where(path => !IsFileLoaded(path)))
			{
				_files.Add(new File(path));
			}
			UpdateUI(); 
		}

		//=============================================================
		//	Public methods
		//=============================================================

		/// <summary>
		/// Updates control with given video.
		/// </summary>
		/// <param name="video"></param>
		public override void Update(AbstractVideo video)
		{
			Label_Title.Text = video.Title;

			base.Update(video);
			UpdateRenamedNamesInListView();
		}

		//-------------------------------------------------------------
		//	Protected methods
		//-------------------------------------------------------------

		protected override void Update(Movie movie)
		{
			Label_Title.Text += @" [Movie]";
		}

		protected override void Update(Series series)
		{
			Label_Title.Text += @" [Series]";
		}

		//-------------------------------------------------------------
		//	Private methods
		//-------------------------------------------------------------

		private string ConstructName(AbstractVideo video)
		{
			var name = string.Empty;
			switch (video.Type)
			{
				case VideoType.Movie:
					{
						name = Properties.Settings.Default.MOVIE_NAME_FORMAT;
						var movie = video as Movie;

					}
					break;
				case VideoType.Series:
					{
						name = Properties.Settings.Default.SERIES_NAME_FORMAT;
						var series = video as Series;

					}
					break;
			}
			name = name.Replace(Properties.Resources.STR_CODE_NAME, video.Title);
			name = name.Replace(Properties.Resources.STR_CODE_YEAR, video.Year.ToString());
			name = name.Replace(Properties.Resources.STR_CODE_GENRES, Utils.ConcatWithSeparator(video.Genres, "&"));
			return name;
		}

		private bool IsFileLoaded(string path)
		{
			return _files.Any(file => file.ToString().Equals(path));
		}

		private void UpdateRenamedNamesInListView()
		{
			if (Video == null || _files.Count <= 0) return;

			var name = ConstructName(Video);

			foreach (ListViewItem item in ListView_Files.Items)
			{
				item.SubItems[1].Text = name;
			}
		}

		private void UpdateUI()
		{
			ListView_Files.Items.Clear();
			foreach (var file in _files)
			{
				ListView_Files.Items.Add(new ListViewItem(new[] { file.OriginalName, string.Empty })).Tag = file;
			}

			UpdateRenamedNamesInListView();
			ListView_Files.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}
	}
}
