using SeriesMovieInfoDatabase.Objects;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FSANC_V2.Components;

namespace FSANC_V2
{
	public partial class MainForm : Form
	{
		//=============================================================
		//	Public constructors
		//=============================================================

		public MainForm()
		{
			InitializeComponent();

			Control_Searcher.SearchResultSelectionChanged += SelectedItemInSearcherChanged;

			TabControl.MaximumSize = new Size((int)(SystemInformation.VirtualScreen.Width * 0.6), 0);
			Control_Searcher.MaximumSize = new Size((int)(SystemInformation.VirtualScreen.Width * 0.4), 0);
		}

		//=============================================================
		//	Private events
		//=============================================================

		private void SelectedItemInSearcherChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			var item = e.Item.Tag as AbstractVideo;

			if (item == null) return;

			// We look for objects, derived from AbstractVideoDisplayer class, in TabPages to update them with new AbstractVideo.
			foreach (var abstractControl in TabControl.Controls.OfType<TabPage>().SelectMany(tabPage => tabPage.Controls.OfType<AbstractVideoDisplayer>()))
			{
				abstractControl.Update(item);
			}
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			Control_Searcher.Location = new Point(TabControl.Size.Width + 18, Control_Searcher.Location.Y);
			Control_Searcher.Size = new Size((Size.Width - TabControl.Size.Width) - TabControl.Margin.Horizontal - Control_Searcher.Margin.Horizontal - 30, Control_Searcher.Size.Height);
		}

		private void ToolStripButtonSettings_Click(object sender, EventArgs e)
		{
			SettingsWindow.ShowDialog();
		}
	}
}
