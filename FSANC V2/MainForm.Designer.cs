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
			this.Control_InfoDisp = new InfoDisplayer();
			this.TabPageRename = new System.Windows.Forms.TabPage();
			this.Control_FileRenameDisp = new FSANC_V2.Components.FileRenameDisplayer();
			this.TabPageTorrent = new System.Windows.Forms.TabPage();
			this.Control_TorrentDisp = new FSANC_V2.Components.TorrentDisplayer();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.ToolStripLabel_Status = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStrip = new System.Windows.Forms.ToolStrip();
			this.ToolStripBtnSettings = new System.Windows.Forms.ToolStripButton();
			this.Control_Searcher = new Searcher();
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
			this.TabPageMain.Controls.Add(this.Control_InfoDisp);
			this.TabPageMain.Location = new System.Drawing.Point(4, 22);
			this.TabPageMain.Name = "TabPageMain";
			this.TabPageMain.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageMain.Size = new System.Drawing.Size(676, 425);
			this.TabPageMain.TabIndex = 0;
			this.TabPageMain.Text = "Main";
			this.TabPageMain.UseVisualStyleBackColor = true;
			// 
			// Displayer
			// 
			this.Control_InfoDisp.AutoSize = true;
			this.Control_InfoDisp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Control_InfoDisp.Location = new System.Drawing.Point(3, 3);
			this.Control_InfoDisp.Name = "Displayer";
			this.Control_InfoDisp.Size = new System.Drawing.Size(670, 419);
			this.Control_InfoDisp.TabIndex = 1;
			// 
			// TabPageRename
			// 
			this.TabPageRename.Controls.Add(this.Control_FileRenameDisp);
			this.TabPageRename.Location = new System.Drawing.Point(4, 22);
			this.TabPageRename.Name = "TabPageRename";
			this.TabPageRename.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageRename.Size = new System.Drawing.Size(676, 425);
			this.TabPageRename.TabIndex = 1;
			this.TabPageRename.Text = "Rename files";
			this.TabPageRename.UseVisualStyleBackColor = true;
			// 
			// FileRenamer
			// 
			this.Control_FileRenameDisp.AutoSize = true;
			this.Control_FileRenameDisp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Control_FileRenameDisp.Location = new System.Drawing.Point(3, 3);
			this.Control_FileRenameDisp.Name = "FileRenamer";
			this.Control_FileRenameDisp.Size = new System.Drawing.Size(670, 419);
			this.Control_FileRenameDisp.TabIndex = 1;
			// 
			// TabPageTorrent
			// 
			this.TabPageTorrent.Controls.Add(this.Control_TorrentDisp);
			this.TabPageTorrent.Location = new System.Drawing.Point(4, 22);
			this.TabPageTorrent.Name = "TabPageTorrent";
			this.TabPageTorrent.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageTorrent.Size = new System.Drawing.Size(676, 425);
			this.TabPageTorrent.TabIndex = 2;
			this.TabPageTorrent.Text = "Torrent";
			this.TabPageTorrent.UseVisualStyleBackColor = true;
			// 
			// Torrent
			// 
			this.Control_TorrentDisp.AutoSize = true;
			this.Control_TorrentDisp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Control_TorrentDisp.Location = new System.Drawing.Point(3, 3);
			this.Control_TorrentDisp.Name = "Torrent";
			this.Control_TorrentDisp.Size = new System.Drawing.Size(670, 419);
			this.Control_TorrentDisp.TabIndex = 1;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLabel_Status});
			this.statusStrip1.Location = new System.Drawing.Point(0, 479);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1082, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// ToolStripLabel_Status
			// 
			this.ToolStripLabel_Status.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ToolStripLabel_Status.Name = "ToolStripLabel_Status";
			this.ToolStripLabel_Status.Size = new System.Drawing.Size(39, 17);
			this.ToolStripLabel_Status.Text = "Status";
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
			this.ToolStripBtnSettings.Click += new System.EventHandler(this.ToolStripButtonSettings_Click);
			// 
			// Searcher
			// 
			this.Control_Searcher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Control_Searcher.AutoSize = true;
			this.Control_Searcher.Location = new System.Drawing.Point(696, 28);
			this.Control_Searcher.MinimumSize = new System.Drawing.Size(349, 451);
			this.Control_Searcher.Name = "Searcher";
			this.Control_Searcher.Size = new System.Drawing.Size(374, 451);
			this.Control_Searcher.TabIndex = 0;
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
			this.Controls.Add(this.Control_Searcher);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(1079, 515);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FSANC";
			this.Resize += new System.EventHandler(this.MainForm_Resize);
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

		private Searcher Control_Searcher;
		private InfoDisplayer Control_InfoDisp;
		private FileRenameDisplayer Control_FileRenameDisp;
		private TorrentDisplayer Control_TorrentDisp;
		private Settings SettingsWindow;
		private System.Windows.Forms.TabControl TabControl;
		private System.Windows.Forms.TabPage TabPageMain;
		private System.Windows.Forms.TabPage TabPageRename;
		private System.Windows.Forms.TabPage TabPageTorrent;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel ToolStripLabel_Status;
		private System.Windows.Forms.ToolStrip ToolStrip;
		private System.Windows.Forms.ToolStripButton ToolStripBtnSettings;
	}
}