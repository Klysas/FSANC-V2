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
			this.Lbl_Name = new System.Windows.Forms.Label();
			this.Lbl_Separator = new System.Windows.Forms.Label();
			this.Btn_SelectFiles = new System.Windows.Forms.Button();
			this.Btn_RenameFiles = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.ListView_Files = new System.Windows.Forms.ListView();
			this.Original = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Renamed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// Lbl_Name
			// 
			this.Lbl_Name.AutoSize = true;
			this.Lbl_Name.Location = new System.Drawing.Point(9, 10);
			this.Lbl_Name.Name = "Lbl_Name";
			this.Lbl_Name.Size = new System.Drawing.Size(35, 13);
			this.Lbl_Name.TabIndex = 0;
			this.Lbl_Name.Text = "Name";
			// 
			// Lbl_Separator
			// 
			this.Lbl_Separator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Lbl_Separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Lbl_Separator.Location = new System.Drawing.Point(12, 32);
			this.Lbl_Separator.Name = "Lbl_Separator";
			this.Lbl_Separator.Size = new System.Drawing.Size(421, 2);
			this.Lbl_Separator.TabIndex = 1;
			// 
			// Btn_SelectFiles
			// 
			this.Btn_SelectFiles.Location = new System.Drawing.Point(12, 38);
			this.Btn_SelectFiles.Name = "Btn_SelectFiles";
			this.Btn_SelectFiles.Size = new System.Drawing.Size(75, 23);
			this.Btn_SelectFiles.TabIndex = 2;
			this.Btn_SelectFiles.Text = "Select files";
			this.Btn_SelectFiles.UseVisualStyleBackColor = true;
			this.Btn_SelectFiles.Click += new System.EventHandler(this.Btn_SelectFiles_Click);
			// 
			// Btn_RenameFiles
			// 
			this.Btn_RenameFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn_RenameFiles.Location = new System.Drawing.Point(346, 38);
			this.Btn_RenameFiles.Name = "Btn_RenameFiles";
			this.Btn_RenameFiles.Size = new System.Drawing.Size(87, 23);
			this.Btn_RenameFiles.TabIndex = 3;
			this.Btn_RenameFiles.Text = "Rename files";
			this.Btn_RenameFiles.UseVisualStyleBackColor = true;
			this.Btn_RenameFiles.Click += new System.EventHandler(this.Btn_RenameFiles_Click);
			// 
			// OpenFileDialog
			// 
			this.OpenFileDialog.Multiselect = true;
			this.OpenFileDialog.Title = "Select video file(s)";
			// 
			// ListView_Files
			// 
			this.ListView_Files.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ListView_Files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Original,
            this.Renamed});
			this.ListView_Files.FullRowSelect = true;
			this.ListView_Files.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ListView_Files.Location = new System.Drawing.Point(12, 68);
			this.ListView_Files.MultiSelect = false;
			this.ListView_Files.Name = "ListView_Files";
			this.ListView_Files.Size = new System.Drawing.Size(421, 241);
			this.ListView_Files.TabIndex = 4;
			this.ListView_Files.UseCompatibleStateImageBehavior = false;
			this.ListView_Files.View = System.Windows.Forms.View.Details;
			// 
			// Original
			// 
			this.Original.Text = "Original name";
			// 
			// Renamed
			// 
			this.Renamed.Text = "New name";
			// 
			// FileRenameDisplayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ListView_Files);
			this.Controls.Add(this.Btn_RenameFiles);
			this.Controls.Add(this.Btn_SelectFiles);
			this.Controls.Add(this.Lbl_Separator);
			this.Controls.Add(this.Lbl_Name);
			this.Name = "FileRenameDisplayer";
			this.Size = new System.Drawing.Size(456, 321);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Lbl_Name;
		private System.Windows.Forms.Label Lbl_Separator;
		private System.Windows.Forms.Button Btn_SelectFiles;
		private System.Windows.Forms.Button Btn_RenameFiles;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.ListView ListView_Files;
		private System.Windows.Forms.ColumnHeader Original;
		private System.Windows.Forms.ColumnHeader Renamed;
	}
}
