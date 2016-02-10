using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Aga.Controls.Tree;
using SeriesMovieInfoDatabase.Objects;
using FSANC_V2.StorageUnitTree;

namespace FSANC_V2.Components
{
	public partial class FileRenameDisplayer : AbstractVideoDisplayer
	{
		//=============================================================
		//	Private variables
		//=============================================================

		// To add nodes to TreeViewAdv.
		private readonly TreeModel _model;

		private readonly TreeContainerConstructor _treeContainer;

		//=============================================================
		//	Public constructors
		//=============================================================

		public FileRenameDisplayer()
		{
			InitializeComponent();

			_model = new TreeModel();
			TreeViewAdv_Files.Model = _model;
			_treeContainer = new TreeContainerConstructor();
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
				MessageBox.Show(@"File or folder is already loaded.", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			}
		}

		private void MenuItemRemoveSelected_Click(object sender, EventArgs e)
		{
			foreach (var storageUnit in TreeViewAdv_Files.SelectedNodes.Select(treeNodeAdv => treeNodeAdv.Tag as Node).Select(node => node.Tag as StorageUnit))
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

		private static void UpdateTreeView(Folder folder, CustomNode folderNode)
		{
			foreach (var child in folder.Children)
			{
				var file = child as File;
				if (file != null)
				{
					var fileNode = new CustomNode(file.OriginalName + file.Extension) { Tag = file };
					folderNode.Nodes.Add(fileNode);
				}

				var subFolder = child as Folder;
				if (subFolder == null) { continue; }

				var subFolderNode = new CustomNode(subFolder.OriginalName) { Tag = subFolder };
				folderNode.Nodes.Add(subFolderNode);
				UpdateTreeView(subFolder, subFolderNode);
			}
		}

		//-------------------------------------------------------------
		//	Private non-static methods
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
				var file = storageUnit as File;
				if (file != null)
				{
					var fileNode = new CustomNode(file.OriginalName + file.Extension) { Tag = file };
					_model.Nodes.Add(fileNode);
				}

				var folder = storageUnit as Folder;
				if (folder == null) { continue; }

				var folderNode = new CustomNode(folder.OriginalName) { Tag = folder };
				_model.Nodes.Add(folderNode);
				UpdateTreeView(folder, folderNode);
			}
			TreeViewAdv_Files.EndUpdate();
			TreeViewAdv_Files.ExpandAll();
			ResizeViewColumns();
		}

		private void UpdateUI()
		{
			// Empty. For future.
		}

		//=============================================================
		//	Private classes
		//=============================================================

		private class CustomNode : Node
		{
			private string _secondText = "";

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
		}
	}
}
