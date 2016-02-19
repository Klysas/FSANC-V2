using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Aga.Controls.Tree;
using SeriesMovieInfoDatabase.Objects;
using FSANC_V2.StorageUnitTree;
using File = FSANC_V2.StorageUnitTree.File;

namespace FSANC_V2.Components
{
	public partial class FileRenameDisplayer : AbstractVideoDisplayer
	{
		//=============================================================
		//	Private variables
		//=============================================================

		// To add nodes to TreeViewAdv.
		private readonly TreeModel _model;

		private readonly SerialEpisodeValuesChanger _valuesChanger;

		private readonly TreeContainerConstructor _treeContainer;

		//=============================================================
		//	Public constructors
		//=============================================================

		public FileRenameDisplayer()
		{
			InitializeComponent();

			ContextMenuStrip_TreeViewAdvFiles.Items.Insert(0, new ToolStripLabel("S00E00") { Name = "MenuItem_SeasonEpisodeLabel" });

			_model = new TreeModel();
			TreeViewAdv_Files.Model = _model;
			_treeContainer = new TreeContainerConstructor();

			_valuesChanger = new SerialEpisodeValuesChanger();

			var languages = Properties.Resources.STR_ARRAY_LANGUAGES.Split('|');
			ComboBox_Languages.Items.AddRange(languages);
		}

		//=============================================================
		//	Private events
		//=============================================================

		private void ButtonRenameFiles_Click(object sender, EventArgs e)
		{
			if (!TreeViewAdv_Files.AllNodes.Any())
			{
				MessageBox.Show(@"No files are loaded.", "",
					MessageBoxButtons.OK);
				return;
			}

			// Get nodes that have "New title" value filled.
			var nodesWithNewTitle =
				TreeViewAdv_Files.AllNodes.Select(treeNodeAdv => treeNodeAdv.Tag as CustomNode)
					.Where(customNode => !customNode.SecondText.Equals(""))
					.ToList();

			if (!nodesWithNewTitle.Any())
			{
				MessageBox.Show("No files found that have \"New title\" value filled.", "", MessageBoxButtons.OK);
				return;
			}

			var dialogResult =
				MessageBox.Show(
					"All files that have \"New title\" value filled(not empty) will be renamed. Are you sure you want to do this?"
					, string.Format(@"{0} file(s) will be renamed.", nodesWithNewTitle.Count)
					, MessageBoxButtons.YesNo);
			if (dialogResult != DialogResult.Yes) { return; }

			try
			{
				// Renaming files.
				foreach (var node in nodesWithNewTitle)
				{
					if (node.Tag is File)
					{
						var file = (File)node.Tag;
						if (file == null) continue;
						System.IO.File.Move(file.ToString(), Path.Combine(file.OriginalPath, node.SecondText + file.Extension));
						_treeContainer.Remove(file);
					}
					else
					{
						var folder = node.Tag as Folder;
						if (folder == null) continue;
						Directory.Move(folder.ToString(), Path.Combine(folder.OriginalPath, node.SecondText));
						_treeContainer.Remove(folder);
					}
				}
			}
			catch (IOException ex)
			{
				MessageBox.Show(ex.Message, @"Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			finally
			{
				UpdateTreeView();
			}
		}

		private void ButtonLoadFiles_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialogEx
			{
				ShowNewFolderButton = true,
				ShowBothFilesAndFolders = true,
			};

			var result = dialog.ShowDialog();

			try
			{
				if (result != DialogResult.OK) return;
				_treeContainer.UpdateTreeContainer(dialog.SelectedPath);
				UpdateTreeView();
			}
			catch (ArgumentException)
			{
				MessageBox.Show(@"File or folder is already loaded.", @"Already loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			finally
			{
				dialog.Dispose();
			}
		}

		private void ContextMenuStripTreeViewAdvFiles_Opening(object sender, CancelEventArgs e)
		{
			if (!_treeContainer.TreeRootStorageUnits.Any())
			{
				e.Cancel = true;
				return;
			}

			var menuItemModifyValues = ContextMenuStrip_TreeViewAdvFiles.Items.Find("MenuItem_ModifyValues", false).FirstOrDefault();
			if (TreeViewAdv_Files.SelectedNodes.Count != 1)
			{
				if (menuItemModifyValues != null) menuItemModifyValues.Enabled = false;
				ContextMenuStrip_TreeViewAdvFiles.Items[0].Text = GetSeasonEpisodeInDefaultFormat(0, 0);
				return;
			}

			// Loads season and episode values to context menu.
			var customNode = TreeViewAdv_Files.SelectedNodes[0].Tag as CustomNode;
			if (customNode != null)
			{
				int season, episode;
				int.TryParse(customNode.ThirdText, out season);
				int.TryParse(customNode.ForthText, out episode);

				var menuItemSeasonEpisodeLabel = ContextMenuStrip_TreeViewAdvFiles.Items.Find("MenuItem_SeasonEpisodeLabel", false).FirstOrDefault();
				if (menuItemSeasonEpisodeLabel != null) menuItemSeasonEpisodeLabel.Text = GetSeasonEpisodeInDefaultFormat(season, episode);
			}
			if (menuItemModifyValues != null) menuItemModifyValues.Enabled = true;
		}

		private void ButtonConstructNames_Click(object sender, EventArgs e)
		{
			if (!TreeViewAdv_Files.SelectedNodes.Any())
			{
				MessageBox.Show(@"Select at least one item from the list, before trying to construct names.", @"No selected items",
					MessageBoxButtons.OK);
				return;
			}

			if (Video == null)
			{
				MessageBox.Show(@"No video is selected.", "", MessageBoxButtons.OK);
				return;
			}

			TreeViewAdv_Files.BeginUpdate();
			foreach (var customNode in TreeViewAdv_Files.SelectedNodes.Select(treeNodeAdv => treeNodeAdv.Tag as CustomNode).ToList())
			{
				int season, episode;
				int.TryParse(customNode.ThirdText, out season);
				int.TryParse(customNode.ForthText, out episode);

				var language = ComboBox_Languages.SelectedItem == null ? "" : ComboBox_Languages.SelectedItem.ToString();

				customNode.SecondText = ConstructName(customNode.Tag is File, language, season, episode);
				if (customNode.Tag is StorageUnit)
				{
					((StorageUnit)customNode.Tag).NewName = customNode.SecondText;
				}
			}
			TreeViewAdv_Files.EndUpdate();
			ResizeViewColumns();
		}

		private void MenuItemRemoveSelected_Click(object sender, EventArgs e)
		{
			foreach (var storageUnit in TreeViewAdv_Files.SelectedNodes.Select(treeNodeAdv => treeNodeAdv.Tag as Node).Select(node => node.Tag as StorageUnit).ToList())
			{
				_treeContainer.Remove(storageUnit);
			}
			UpdateTreeView();
		}

		private void MenuItemRemoveAll_Click(object sender, EventArgs e)
		{
			_treeContainer.Clear();
			UpdateTreeView();
		}

		private void MenuItemSelectAll_Click(object sender, EventArgs e)
		{
			TreeViewAdv_Files.SelectAllNodes();
		}

		private void MenuItemModifyValues_Click(object sender, EventArgs e)
		{
			if (_valuesChanger.ShowDialog() != DialogResult.OK) return;

			var customNode = TreeViewAdv_Files.SelectedNode.Tag as CustomNode;
			if (customNode == null) return;

			customNode.ThirdText = _valuesChanger.SeasonNumber.ToString();
			customNode.ForthText = _valuesChanger.EpisodeNumber.ToString();
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
		//	Private static methods
		//-------------------------------------------------------------

		/// <summary>
		/// Inserts season and episode values into S**E** string, where ** are season and episode values.
		/// </summary>
		/// <param name="season"></param>
		/// <param name="episode"></param>
		/// <returns></returns>
		private static string GetSeasonEpisodeInDefaultFormat(int season, int episode)
		{
			return "S" + (season < 10 ? "0" + season : season.ToString()) + "E" + (episode < 10 ? "0" + episode : episode.ToString());
		}

		/// <summary>
		/// Tries to find season and episode values in name by given regular expression. 
		/// </summary>
		/// <param name="fileName">Directory or file name without extension.</param>
		/// <param name="regularExpression"></param>
		/// <param name="extractedValues">Season and episode values(in that order). If extraction fails - zeros are returned.</param>
		/// <returns>True if values were extracted by using regular expression, otherwise false.</returns>
		private static bool TryExtractSeasonEpisodeValues(string fileName, string regularExpression,
			out Tuple<int, int> extractedValues)
		{
			var extractedValue = Regex.Match(fileName, regularExpression).ToString();

			if (Equals(extractedValue, ""))
			{
				extractedValues = new Tuple<int, int>(0, 0);
				return false;
			}

			var season = int.Parse(extractedValue.Substring(1, 2));
			var episode = int.Parse(extractedValue.Substring(4));

			extractedValues = new Tuple<int, int>(season, episode);
			return true;
		}

		/// <summary>
		/// Tries to find season and episode values in name by default regular expressions.
		/// </summary>
		/// <param name="fileName">Directory or file name without extension.</param>
		/// <param name="extractedValues">Season and episode values(in that order). If extraction fails - zeros are returned.</param>
		/// <returns>True if values were extracted by using regular expression, otherwise false.</returns>
		private static bool TryExtractSeasonEpisodeValues(string fileName, out Tuple<int, int> extractedValues)
		{
			return TryExtractSeasonEpisodeValues(fileName, @"S\d{2}E\d{2}", out extractedValues) || TryExtractSeasonEpisodeValues(fileName, @"s\d{2}e\d{2}", out extractedValues);
		}

		private static void UpdateTreeView(Folder folder, CustomNode folderNode)
		{
			foreach (var child in folder.Children)
			{
				Tuple<int, int> seasonAndEpisode;

				var file = child as File;
				if (file != null)
				{
					TryExtractSeasonEpisodeValues(file.OriginalName, out seasonAndEpisode);

					var fileNode = new CustomNode(file.OriginalName + file.Extension)
					{
						Tag = file,
						SecondText = file.NewName,
						ThirdText = seasonAndEpisode.Item1.ToString(),
						ForthText = seasonAndEpisode.Item2.ToString()
					};
					folderNode.Nodes.Add(fileNode);
				}

				var subFolder = child as Folder;
				if (subFolder == null) { continue; }

				TryExtractSeasonEpisodeValues(subFolder.OriginalName, out seasonAndEpisode);
				var subFolderNode = new CustomNode(subFolder.OriginalName)
				{
					Tag = subFolder,
					SecondText = subFolder.NewName,
					ThirdText = seasonAndEpisode.Item1.ToString(),
					ForthText = seasonAndEpisode.Item2.ToString()
				};
				folderNode.Nodes.Add(subFolderNode);
				UpdateTreeView(subFolder, subFolderNode);
			}
		}

		//-------------------------------------------------------------
		//	Private non-static methods
		//-------------------------------------------------------------

		private string ConstructName(bool isFile, string language, int season, int episode)
		{
			var name = "";
			switch (Video.Type)
			{
				case VideoType.Movie:
					{
						name = isFile ? Properties.Settings.Default.FORMAT_MOVIE_FILE_NAME : Properties.Settings.Default.FORMAT_MOVIE_DIR_NAME;
						var movie = Video as Movie;
						if (movie == null) break;
					}
					break;
				case VideoType.Series:
					{
						name = isFile ? Properties.Settings.Default.FORMAT_SERIES_FILE_NAME : Properties.Settings.Default.FORMAT_SERIES_DIR_NAME;
						var series = Video as Series;
						if (series == null) break;
						if (season > 0 && season <= series.SeasonsCount && episode > 0 && episode <= series.Seasons[season - 1].EpisodesCount)
						{
							name = name.Replace(Properties.Resources.STR_CODE_EPISODE_TITLE, series.Seasons[season - 1].Episodes[episode - 1].Title);
						}
						name = name.Replace(Properties.Resources.STR_CODE_SE, GetSeasonEpisodeInDefaultFormat(season, episode));
					}
					break;
			}
			name = name.Replace(Properties.Resources.STR_CODE_TITLE, Video.Title);
			name = name.Replace(Properties.Resources.STR_CODE_YEAR, Video.Year.ToString());
			name = name.Replace(Properties.Resources.STR_CODE_GENRES, Utils.ConcatWithSeparator(Video.Genres, "&"));
			name = name.Replace(Properties.Resources.STR_CODE_LANGUAGE, language);
			name = name.Replace(Properties.Resources.STR_CODE_EPISODE_TITLE, "");
			return name;
		}

		private void ResizeViewColumns()
		{
			if (!_treeContainer.TreeRootStorageUnits.Any()) return;
			var measureContext = new DrawContext
			{
				Graphics = Graphics.FromImage(new Bitmap(1, 1)),
				Font = TreeViewAdv_Files.Font
			};

			// On the first column take head for the plus/minus and lines. The 7 is the LeftMargin of the PlusMinus. 
			int newWidth = (TreeViewAdv_Files.ShowPlusMinus ? 20 : 0) + 7;
			foreach (var column in TreeViewAdv_Files.Columns)
			{
				foreach (var nodeControl in TreeViewAdv_Files.NodeControls)
				{
					if (nodeControl.ParentColumn != column) continue;
					// Many controls can be displayed in the same column
					int maxControlWidth = 0;
					foreach (var nodeAdv in TreeViewAdv_Files.AllNodes)
					{
						var size = nodeControl.MeasureSize(nodeAdv, measureContext);
						maxControlWidth = Math.Max(maxControlWidth, (size.Width + nodeControl.LeftMargin));
					}
					newWidth += maxControlWidth;
				}
				column.Width = newWidth;
				newWidth = 0;
			}
		}

		private void UpdateTreeView()
		{
			_model.Nodes.Clear();

			TreeViewAdv_Files.BeginUpdate();
			foreach (var storageUnit in _treeContainer.TreeRootStorageUnits)
			{
				Tuple<int, int> seasonAndEpisode;

				var file = storageUnit as File;
				if (file != null)
				{
					TryExtractSeasonEpisodeValues(file.OriginalName, out seasonAndEpisode);
					var fileNode = new CustomNode(file.OriginalName + file.Extension)
					{
						Tag = file,
						SecondText = file.NewName,
						ThirdText = seasonAndEpisode.Item1.ToString(),
						ForthText = seasonAndEpisode.Item2.ToString()
					};
					_model.Nodes.Add(fileNode);
				}

				var folder = storageUnit as Folder;
				if (folder == null) { continue; }

				TryExtractSeasonEpisodeValues(folder.OriginalName, out seasonAndEpisode);
				var folderNode = new CustomNode(folder.OriginalName)
				{
					Tag = folder,
					SecondText = folder.NewName,
					ThirdText = seasonAndEpisode.Item1.ToString(),
					ForthText = seasonAndEpisode.Item2.ToString()
				};
				_model.Nodes.Add(folderNode);
				UpdateTreeView(folder, folderNode);
			}
			TreeViewAdv_Files.EndUpdate();
			TreeViewAdv_Files.ExpandAll();
			ResizeViewColumns();
		}

		//=============================================================
		//	Private classes
		//=============================================================

		private class CustomNode : Node
		{
			private string _secondText = "";

			private string _thridText = "";

			private string _forthText = "";

			public CustomNode()
				: base()
			{

			}

			public CustomNode(string text)
				: base(text)
			{

			}

			/// <summary>
			/// [GET/SET]
			/// </summary>
			public string SecondText
			{
				get { return _secondText; }
				set
				{
					if (value == null) return;
					_secondText = value;
				}
			}

			/// <summary>
			/// [GET/SET]
			/// </summary>
			public string ThirdText
			{
				get { return _thridText; }
				set
				{
					if (value == null) return;
					_thridText = value;
				}
			}

			/// <summary>
			/// [GET/SET]
			/// </summary>
			public string ForthText
			{
				get { return _forthText; }
				set
				{
					if (value == null) return;
					_forthText = value;
				}
			}
		}
	}
}
