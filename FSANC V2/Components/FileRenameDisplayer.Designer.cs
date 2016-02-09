namespace FSANC_V2.Components
{
	partial class FileRenameDisplayer
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Label_Title = new System.Windows.Forms.Label();
			this.Label_Separator = new System.Windows.Forms.Label();
			this.Button_SelectFiles = new System.Windows.Forms.Button();
			this.Button_RenameFiles = new System.Windows.Forms.Button();
			this.TreeViewAdv_Files = new Aga.Controls.Tree.TreeViewAdv();
			this.TreeColumn_Title = new Aga.Controls.Tree.TreeColumn();
			this.TreeColumn_NewTitle = new Aga.Controls.Tree.TreeColumn();
			this.ContextMenuStrip_TreeViewAdvFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MenuItem_RemoveSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem_RemoveAll = new System.Windows.Forms.ToolStripMenuItem();
			this.NodeTextBox_Title = new Aga.Controls.Tree.NodeControls.NodeTextBox();
			this.NodeTextBox_NewTitle = new Aga.Controls.Tree.NodeControls.NodeTextBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.ContextMenuStrip_TreeViewAdvFiles.SuspendLayout();
			this.SuspendLayout();
			// 
			// Label_Title
			// 
			this.Label_Title.AutoSize = true;
			this.Label_Title.Location = new System.Drawing.Point(9, 10);
			this.Label_Title.Name = "Label_Title";
			this.Label_Title.Size = new System.Drawing.Size(35, 13);
			this.Label_Title.TabIndex = 0;
			this.Label_Title.Text = "Name";
			// 
			// Label_Separator
			// 
			this.Label_Separator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Label_Separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Label_Separator.Location = new System.Drawing.Point(12, 32);
			this.Label_Separator.Name = "Label_Separator";
			this.Label_Separator.Size = new System.Drawing.Size(421, 2);
			this.Label_Separator.TabIndex = 1;
			// 
			// Button_SelectFiles
			// 
			this.Button_SelectFiles.Location = new System.Drawing.Point(12, 38);
			this.Button_SelectFiles.Name = "Button_SelectFiles";
			this.Button_SelectFiles.Size = new System.Drawing.Size(75, 23);
			this.Button_SelectFiles.TabIndex = 2;
			this.Button_SelectFiles.Text = "Select files";
			this.Button_SelectFiles.UseVisualStyleBackColor = true;
			this.Button_SelectFiles.Click += new System.EventHandler(this.ButtonSelectFiles_Click);
			// 
			// Button_RenameFiles
			// 
			this.Button_RenameFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Button_RenameFiles.Location = new System.Drawing.Point(346, 38);
			this.Button_RenameFiles.Name = "Button_RenameFiles";
			this.Button_RenameFiles.Size = new System.Drawing.Size(87, 23);
			this.Button_RenameFiles.TabIndex = 3;
			this.Button_RenameFiles.Text = "Rename files";
			this.Button_RenameFiles.UseVisualStyleBackColor = true;
			this.Button_RenameFiles.Click += new System.EventHandler(this.ButtonRenameFiles_Click);
			// 
			// TreeViewAdv_Files
			// 
			this.TreeViewAdv_Files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TreeViewAdv_Files.BackColor = System.Drawing.SystemColors.Window;
			this.TreeViewAdv_Files.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TreeViewAdv_Files.ColumnHeaderHeight = 21;
			this.TreeViewAdv_Files.Columns.Add(this.TreeColumn_Title);
			this.TreeViewAdv_Files.Columns.Add(this.TreeColumn_NewTitle);
			this.TreeViewAdv_Files.ContextMenuStrip = this.ContextMenuStrip_TreeViewAdvFiles;
			this.TreeViewAdv_Files.DefaultToolTipProvider = null;
			this.TreeViewAdv_Files.DragDropMarkColor = System.Drawing.Color.Black;
			this.TreeViewAdv_Files.FullRowSelect = true;
			this.TreeViewAdv_Files.FullRowSelectActiveColor = System.Drawing.SystemColors.Highlight;
			this.TreeViewAdv_Files.FullRowSelectInactiveColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.TreeViewAdv_Files.GridLineStyle = Aga.Controls.Tree.GridLineStyle.Horizontal;
			this.TreeViewAdv_Files.LineColor = System.Drawing.SystemColors.ControlDark;
			this.TreeViewAdv_Files.Location = new System.Drawing.Point(12, 67);
			this.TreeViewAdv_Files.Model = null;
			this.TreeViewAdv_Files.Name = "TreeViewAdv_Files";
			this.TreeViewAdv_Files.NodeControls.Add(this.NodeTextBox_Title);
			this.TreeViewAdv_Files.NodeControls.Add(this.NodeTextBox_NewTitle);
			this.TreeViewAdv_Files.NodeFilter = null;
			this.TreeViewAdv_Files.SelectedNode = null;
			this.TreeViewAdv_Files.SelectionMode = Aga.Controls.Tree.TreeSelectionMode.Multi;
			this.TreeViewAdv_Files.Size = new System.Drawing.Size(421, 251);
			this.TreeViewAdv_Files.TabIndex = 5;
			this.TreeViewAdv_Files.UseColumns = true;
			// 
			// TreeColumn_Title
			// 
			this.TreeColumn_Title.Header = "Title";
			this.TreeColumn_Title.SortOrder = System.Windows.Forms.SortOrder.None;
			this.TreeColumn_Title.TooltipText = null;
			// 
			// TreeColumn_NewTitle
			// 
			this.TreeColumn_NewTitle.Header = "New title";
			this.TreeColumn_NewTitle.SortOrder = System.Windows.Forms.SortOrder.None;
			this.TreeColumn_NewTitle.TooltipText = null;
			// 
			// ContextMenuStrip_TreeViewAdvFiles
			// 
			this.ContextMenuStrip_TreeViewAdvFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_RemoveSelected,
            this.MenuItem_RemoveAll});
			this.ContextMenuStrip_TreeViewAdvFiles.Name = "ContextMenuStrip_TreeViewAdvFiles";
			this.ContextMenuStrip_TreeViewAdvFiles.ShowItemToolTips = false;
			this.ContextMenuStrip_TreeViewAdvFiles.Size = new System.Drawing.Size(164, 70);
			this.ContextMenuStrip_TreeViewAdvFiles.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripTreeViewAdvFiles_Opening);
			// 
			// MenuItem_RemoveSelected
			// 
			this.MenuItem_RemoveSelected.Name = "MenuItem_RemoveSelected";
			this.MenuItem_RemoveSelected.Size = new System.Drawing.Size(163, 22);
			this.MenuItem_RemoveSelected.Text = "Remove selected";
			this.MenuItem_RemoveSelected.Click += new System.EventHandler(this.MenuItemRemoveSelected_Click);
			// 
			// MenuItem_RemoveAll
			// 
			this.MenuItem_RemoveAll.Name = "MenuItem_RemoveAll";
			this.MenuItem_RemoveAll.Size = new System.Drawing.Size(163, 22);
			this.MenuItem_RemoveAll.Text = "Remove all";
			this.MenuItem_RemoveAll.Click += new System.EventHandler(this.MenuItemRemoveAll_Click);
			// 
			// NodeTextBox_Title
			// 
			this.NodeTextBox_Title.DataPropertyName = "Text";
			this.NodeTextBox_Title.IncrementalSearchEnabled = true;
			this.NodeTextBox_Title.LeftMargin = 3;
			this.NodeTextBox_Title.ParentColumn = this.TreeColumn_Title;
			// 
			// NodeTextBox_NewTitle
			// 
			this.NodeTextBox_NewTitle.IncrementalSearchEnabled = true;
			this.NodeTextBox_NewTitle.LeftMargin = 3;
			this.NodeTextBox_NewTitle.ParentColumn = this.TreeColumn_NewTitle;
			// 
			// FileRenameDisplayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.TreeViewAdv_Files);
			this.Controls.Add(this.Button_RenameFiles);
			this.Controls.Add(this.Button_SelectFiles);
			this.Controls.Add(this.Label_Separator);
			this.Controls.Add(this.Label_Title);
			this.Name = "FileRenameDisplayer";
			this.Size = new System.Drawing.Size(456, 321);
			this.ContextMenuStrip_TreeViewAdvFiles.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Label_Title;
		private System.Windows.Forms.Label Label_Separator;
		private System.Windows.Forms.Button Button_SelectFiles;
		private System.Windows.Forms.Button Button_RenameFiles;
		private Aga.Controls.Tree.TreeViewAdv TreeViewAdv_Files;
		private Aga.Controls.Tree.TreeColumn TreeColumn_Title;
		private Aga.Controls.Tree.TreeColumn TreeColumn_NewTitle;
		private Aga.Controls.Tree.NodeControls.NodeTextBox NodeTextBox_Title;
		private Aga.Controls.Tree.NodeControls.NodeTextBox NodeTextBox_NewTitle;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_TreeViewAdvFiles;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_RemoveSelected;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_RemoveAll;
	}
}
