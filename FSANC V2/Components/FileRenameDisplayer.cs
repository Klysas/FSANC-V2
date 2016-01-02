﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSANC_V2.Components
{
	public partial class FileRenameDisplayer : AbstractVideoDisplayer
	{
		//=============================================================
		//	Private variables
		//=============================================================

		private List<File> _files;

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

		private void Btn_SelectFiles_Click(object sender, EventArgs e)
		{
			OpenFileDialog.ShowDialog();
			foreach (var path in OpenFileDialog.FileNames)
			{
				if(!IsFileLoaded(path)) _files.Add(new File(path));
			}
			UpdateUI();
		}

		private void Btn_RenameFiles_Click(object sender, EventArgs e)
		{
			// TODO: implement.
		}

		//=============================================================
		//	Public methods
		//=============================================================

		/// <summary>
		/// Updates control with given video.
		/// </summary>
		/// <param name="video"></param>
		public new void Update(AbstractVideo video)
		{
			Lbl_Name.Text = video.Name;

			base.Update(video);
			UpdateRenamedNamesInListView();
		}

		//-------------------------------------------------------------
		//	Protected methods
		//-------------------------------------------------------------

		protected override void Update(Movie movie)
		{
			Lbl_Name.Text += " [Movie]";
		}

		protected override void Update(Series series)
		{
			Lbl_Name.Text += " [Series]";
		}

		//-------------------------------------------------------------
		//	Private methods
		//-------------------------------------------------------------

		private bool IsFileLoaded(string path)
		{
			foreach (var file in _files)
			{
				if (file.ToString().Equals(path)) return true;
			}
			return false;
		}

		private void UpdateRenamedNamesInListView()
		{
			if (Video != null && _files.Count > 0)
			{
				string name = ConstructName(Video);

				foreach (ListViewItem item in ListView_Files.Items)
				{
					item.SubItems[1].Text = name;
				}
			}
		}

		private void UpdateUI()
		{
			ListView_Files.Items.Clear();
			foreach (var file in _files)
			{
				ListView_Files.Items.Add(new ListViewItem(new []{file.OriginalName, string.Empty})).Tag = file;
			}
			UpdateRenamedNamesInListView();

			ListView_Files.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		private string ConstructName(AbstractVideo video)
		{
			string name = string.Empty;
			switch (video.Type)
			{
				case AbstractVideo.VideoType.MOVIE:
					{
						name = Properties.Settings.Default.MOVIE_NAME_FORMAT;
						var movie = video as Movie;

					}
					break;
				case AbstractVideo.VideoType.SERIES:
					{
						name = Properties.Settings.Default.SERIES_NAME_FORMAT;
						var series = video as Series;

					}
					break;
			}
			name = name.Replace(Properties.Resources.STR_CODE_NAME, video.Name);
			name = name.Replace(Properties.Resources.STR_CODE_YEAR, video.Year.ToString());
			name = name.Replace(Properties.Resources.STR_CODE_GENRES, Utils.ConcatWithSeparator(video.Genres, "&"));
			return name;
		}
	}
}
