using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSANC_V2
{
	public partial class MainForm : Form
	{

		#region Public constructors

		public MainForm()
		{
			InitializeComponent();

			this.TabControl.MaximumSize = new Size( (int)(SystemInformation.VirtualScreen.Width * 0.6), 0);
			this.Searcher.MaximumSize = new Size((int)(SystemInformation.VirtualScreen.Width * 0.4), 0);
			this.Resize += MainForm_Resize;
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Sets status value to status bar.
		/// </summary>
		/// <param name="status">Status value.</param>
		public void SetStatus(string status)
		{
			this.Invoke(new MethodInvoker(delegate()
			{
				this.ToolStripStatusLbl.Text = status;
			}));
		}

		#endregion

		#region Private event handlers

		private void searcher_Load(object sender, EventArgs e)
		{
			this.Searcher.AddEvenHandlerItemSelectionChanged(new ListViewItemSelectionChangedEventHandler(ItemSelectedInSearcher));
		}

		private void ItemSelectedInSearcher(object sender, ListViewItemSelectionChangedEventArgs e)
		{			
			var item = e.Item.Tag as AbstractVideo;

			if (CurrentVideo == null || CurrentVideo.Id != item.Id)
			{
				this.CurrentVideo = item;
				this.Displayer.Update(CurrentVideo);
				this.FileRenamer.Update(CurrentVideo);
				this.Torrent.Update(CurrentVideo);
			}
		}

		void MainForm_Resize(object sender, EventArgs e)
		{
			this.Searcher.Location = new Point(this.TabControl.Size.Width + 18, this.Searcher.Location.Y); // TODO: fix positioning when resizing.
			this.Searcher.Size = new Size((this.Size.Width - this.TabControl.Size.Width) - this.TabControl.Margin.Horizontal - this.Searcher.Margin.Horizontal - 30, this.Searcher.Size.Height);
		}

		#endregion

		#region Public properties

		public AbstractVideo CurrentVideo
		{
			get;
			private set;
		}

		#endregion

	}
}
