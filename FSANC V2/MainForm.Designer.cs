using FSANC_V2.Components;
namespace FSANC_V2
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.TabControl = new System.Windows.Forms.TabControl();
			this.TabPageMain = new System.Windows.Forms.TabPage();
			this.TabPageRename = new System.Windows.Forms.TabPage();
			this.TabPageTorrent = new System.Windows.Forms.TabPage();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.ToolStripStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStrip = new System.Windows.Forms.ToolStrip();
			this.ToolStripBtnSettings = new System.Windows.Forms.ToolStripButton();
			this.Displayer = new FSANC_V2.InfoDisplayer();
			this.FileRenamer = new FSANC_V2.Components.FileRenameDisplayer();
			this.Torrent = new FSANC_V2.Components.TorrentDisplayer();
			this.Searcher = new FSANC_V2.Searcher();
			this.SettingsWindow = new FSANC_V2.Settings();
			this.TabControl.SuspendLayout();
			this.TabPageMain.SuspendLayout();
			this.TabPageRename.SuspendLayout();
			this.TabPageTorrent.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.ToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabControl
			// 
			this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TabControl.Controls.Add(this.TabPageMain);
			this.TabControl.Controls.Add(this.TabPageRename);
			this.TabControl.Controls.Add(this.TabPageTorrent);
			this.TabControl.Location = new System.Drawing.Point(12, 28);
			this.TabControl.MinimumSize = new System.Drawing.Size(684, 451);
			this.TabControl.Name = "TabControl";
			this.TabControl.SelectedIndex = 0;
			this.TabControl.Size = new System.Drawing.Size(684, 451);
			this.TabControl.TabIndex = 2;
			// 
			// TabPageMain
			// 
			this.TabPageMain.Controls.Add(this.Displayer);
			this.TabPageMain.Location = new System.Drawing.Point(4, 22);
			this.TabPageMain.Name = "TabPageMain";
			this.TabPageMain.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageMain.Size = new System.Drawing.Size(676, 425);
			this.TabPageMain.TabIndex = 0;
			this.TabPageMain.Text = "Main";
			this.TabPageMain.UseVisualStyleBackColor = true;
			// 
			// TabPageRename
			// 
			this.TabPageRename.Controls.Add(this.FileRenamer);
			this.TabPageRename.Location = new System.Drawing.Point(4, 22);
			this.TabPageRename.Name = "TabPageRename";
			this.TabPageRename.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageRename.Size = new System.Drawing.Size(676, 425);
			this.TabPageRename.TabIndex = 1;
			this.TabPageRename.Text = "Rename files";
			this.TabPageRename.UseVisualStyleBackColor = true;
			// 
			// TabPageTorrent
			// 
			this.TabPageTorrent.Controls.Add(this.Torrent);
			this.TabPageTorrent.Location = new System.Drawing.Point(4, 22);
			this.TabPageTorrent.Name = "TabPageTorrent";
			this.TabPageTorrent.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageTorrent.Size = new System.Drawing.Size(676, 425);
			this.TabPageTorrent.TabIndex = 2;
			this.TabPageTorrent.Text = "Torrent";
			this.TabPageTorrent.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLbl});
			this.statusStrip1.Location = new System.Drawing.Point(0, 479);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1082, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// ToolStripStatusLbl
			// 
			this.ToolStripStatusLbl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ToolStripStatusLbl.Name = "ToolStripStatusLbl";
			this.ToolStripStatusLbl.Size = new System.Drawing.Size(39, 17);
			this.ToolStripStatusLbl.Text = "Status";
			// 
			// ToolStrip
			// 
			this.ToolStrip.AllowMerge = false;
			this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnSettings});
			this.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.ToolStrip.Location = new System.Drawing.Point(0, 0);
			this.ToolStrip.Name = "ToolStrip";
			this.ToolStrip.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
			this.ToolStrip.ShowItemToolTips = false;
			this.ToolStrip.Size = new System.Drawing.Size(1082, 22);
			this.ToolStrip.TabIndex = 4;
			this.ToolStrip.Text = "toolStrip1";
			// 
			// ToolStripBtnSettings
			// 
			this.ToolStripBtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ToolStripBtnSettings.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnSettings.Image")));
			this.ToolStripBtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolStripBtnSettings.Name = "ToolStripBtnSettings";
			this.ToolStripBtnSettings.Size = new System.Drawing.Size(53, 19);
			this.ToolStripBtnSettings.Text = "Settings";
			this.ToolStripBtnSettings.ToolTipText = "Settings";
			this.ToolStripBtnSettings.Click += new System.EventHandler(this.ToolStripBtnSettings_Click);
			// 
			// Displayer
			// 
			this.Displayer.AutoSize = true;
			this.Displayer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Displayer.Location = new System.Drawing.Point(3, 3);
			this.Displayer.Name = "Displayer";
			this.Displayer.Size = new System.Drawing.Size(670, 419);
			this.Displayer.TabIndex = 1;
			// 
			// FileRenamer
			// 
			this.FileRenamer.AutoSize = true;
			this.FileRenamer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FileRenamer.Location = new System.Drawing.Point(3, 3);
			this.FileRenamer.Name = "FileRenamer";
			this.FileRenamer.Size = new System.Drawing.Size(670, 419);
			this.FileRenamer.TabIndex = 1;
			// 
			// Torrent
			// 
			this.Torrent.AutoSize = true;
			this.Torrent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Torrent.Location = new System.Drawing.Point(3, 3);
			this.Torrent.Name = "Torrent";
			this.Torrent.Size = new System.Drawing.Size(670, 419);
			this.Torrent.TabIndex = 1;
			// 
			// Searcher
			// 
			this.Searcher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Searcher.AutoSize = true;
			this.Searcher.Location = new System.Drawing.Point(696, 28);
			this.Searcher.MinimumSize = new System.Drawing.Size(349, 451);
			this.Searcher.Name = "Searcher";
			this.Searcher.Size = new System.Drawing.Size(374, 451);
			this.Searcher.TabIndex = 0;
			this.Searcher.Load += new System.EventHandler(this.searcher_Load);
			// 
			// SettingsWindow
			// 
			this.SettingsWindow.ClientSize = new System.Drawing.Size(284, 261);
			this.SettingsWindow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.SettingsWindow.Icon = ((System.Drawing.Icon)(resources.GetObject("SettingsWindow.Icon")));
			this.SettingsWindow.Location = new System.Drawing.Point(26, 26);
			this.SettingsWindow.MaximizeBox = false;
			this.SettingsWindow.Name = "SettingsWindow";
			this.SettingsWindow.ShowInTaskbar = false;
			this.SettingsWindow.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.SettingsWindow.Text = "Settings";
			this.SettingsWindow.Visible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1082, 501);
			this.Controls.Add(this.ToolStrip);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.TabControl);
			this.Controls.Add(this.Searcher);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(1079, 515);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FSANC";
			this.TabControl.ResumeLayout(false);
			this.TabPageMain.ResumeLayout(false);
			this.TabPageMain.PerformLayout();
			this.TabPageRename.ResumeLayout(false);
			this.TabPageRename.PerformLayout();
			this.TabPageTorrent.ResumeLayout(false);
			this.TabPageTorrent.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ToolStrip.ResumeLayout(false);
			this.ToolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Searcher Searcher;
		private InfoDisplayer Displayer;
		private FileRenameDisplayer FileRenamer;
		private TorrentDisplayer Torrent;
		private Settings SettingsWindow;
		private System.Windows.Forms.TabControl TabControl;
		private System.Windows.Forms.TabPage TabPageMain;
		private System.Windows.Forms.TabPage TabPageRename;
		private System.Windows.Forms.TabPage TabPageTorrent;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLbl;
		private System.Windows.Forms.ToolStrip ToolStrip;
		private System.Windows.Forms.ToolStripButton ToolStripBtnSettings;
	}
}