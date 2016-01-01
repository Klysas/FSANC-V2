namespace FSANC_V2
{
	partial class Settings
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
			this.GrpBox_NameChanger = new System.Windows.Forms.GroupBox();
			this.TxtBox_SeriesNameFormat = new System.Windows.Forms.TextBox();
			this.TxtBox_MovieNameFormat = new System.Windows.Forms.TextBox();
			this.Lbl_SeriesNameFormat = new System.Windows.Forms.Label();
			this.Lbl_MovieNameFormat = new System.Windows.Forms.Label();
			this.PicBox_QuestionMark = new System.Windows.Forms.PictureBox();
			this.Btn_Save = new System.Windows.Forms.Button();
			this.Btn_Cancel = new System.Windows.Forms.Button();
			this.GrpBox_NameChanger.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PicBox_QuestionMark)).BeginInit();
			this.SuspendLayout();
			// 
			// GrpBox_NameChanger
			// 
			this.GrpBox_NameChanger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GrpBox_NameChanger.Controls.Add(this.PicBox_QuestionMark);
			this.GrpBox_NameChanger.Controls.Add(this.TxtBox_SeriesNameFormat);
			this.GrpBox_NameChanger.Controls.Add(this.TxtBox_MovieNameFormat);
			this.GrpBox_NameChanger.Controls.Add(this.Lbl_SeriesNameFormat);
			this.GrpBox_NameChanger.Controls.Add(this.Lbl_MovieNameFormat);
			this.GrpBox_NameChanger.Location = new System.Drawing.Point(13, 13);
			this.GrpBox_NameChanger.Name = "GrpBox_NameChanger";
			this.GrpBox_NameChanger.Size = new System.Drawing.Size(259, 69);
			this.GrpBox_NameChanger.TabIndex = 0;
			this.GrpBox_NameChanger.TabStop = false;
			this.GrpBox_NameChanger.Text = "Name changer";
			// 
			// TxtBox_SeriesNameFormat
			// 
			this.TxtBox_SeriesNameFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtBox_SeriesNameFormat.Location = new System.Drawing.Point(127, 38);
			this.TxtBox_SeriesNameFormat.Name = "TxtBox_SeriesNameFormat";
			this.TxtBox_SeriesNameFormat.Size = new System.Drawing.Size(126, 20);
			this.TxtBox_SeriesNameFormat.TabIndex = 3;
			// 
			// TxtBox_MovieNameFormat
			// 
			this.TxtBox_MovieNameFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtBox_MovieNameFormat.Location = new System.Drawing.Point(127, 17);
			this.TxtBox_MovieNameFormat.Name = "TxtBox_MovieNameFormat";
			this.TxtBox_MovieNameFormat.Size = new System.Drawing.Size(126, 20);
			this.TxtBox_MovieNameFormat.TabIndex = 2;
			// 
			// Lbl_SeriesNameFormat
			// 
			this.Lbl_SeriesNameFormat.AutoSize = true;
			this.Lbl_SeriesNameFormat.Location = new System.Drawing.Point(21, 41);
			this.Lbl_SeriesNameFormat.Name = "Lbl_SeriesNameFormat";
			this.Lbl_SeriesNameFormat.Size = new System.Drawing.Size(100, 13);
			this.Lbl_SeriesNameFormat.TabIndex = 1;
			this.Lbl_SeriesNameFormat.Text = "Series name format:";
			// 
			// Lbl_MovieNameFormat
			// 
			this.Lbl_MovieNameFormat.AutoSize = true;
			this.Lbl_MovieNameFormat.Location = new System.Drawing.Point(21, 20);
			this.Lbl_MovieNameFormat.Name = "Lbl_MovieNameFormat";
			this.Lbl_MovieNameFormat.Size = new System.Drawing.Size(100, 13);
			this.Lbl_MovieNameFormat.TabIndex = 0;
			this.Lbl_MovieNameFormat.Text = "Movie name format:";
			// 
			// PicBox_QuestionMark
			// 
			this.PicBox_QuestionMark.BackgroundImage = global::FSANC_V2.Properties.Resources.questionMark;
			this.PicBox_QuestionMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.PicBox_QuestionMark.Location = new System.Drawing.Point(6, 17);
			this.PicBox_QuestionMark.Name = "PicBox_QuestionMark";
			this.PicBox_QuestionMark.Size = new System.Drawing.Size(14, 41);
			this.PicBox_QuestionMark.TabIndex = 1;
			this.PicBox_QuestionMark.TabStop = false;
			// 
			// Btn_Save
			// 
			this.Btn_Save.Location = new System.Drawing.Point(59, 226);
			this.Btn_Save.Name = "Btn_Save";
			this.Btn_Save.Size = new System.Drawing.Size(75, 23);
			this.Btn_Save.TabIndex = 1;
			this.Btn_Save.Text = "Save";
			this.Btn_Save.UseVisualStyleBackColor = true;
			this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
			// 
			// Btn_Cancel
			// 
			this.Btn_Cancel.Location = new System.Drawing.Point(154, 226);
			this.Btn_Cancel.Name = "Btn_Cancel";
			this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.Btn_Cancel.TabIndex = 2;
			this.Btn_Cancel.Text = "Cancel";
			this.Btn_Cancel.UseVisualStyleBackColor = true;
			this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.Btn_Cancel);
			this.Controls.Add(this.Btn_Save);
			this.Controls.Add(this.GrpBox_NameChanger);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::FSANC_V2.Properties.Resources.plus;
			this.MaximizeBox = false;
			this.Name = "Settings";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.Shown += new System.EventHandler(this.Settings_Shown);
			this.GrpBox_NameChanger.ResumeLayout(false);
			this.GrpBox_NameChanger.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PicBox_QuestionMark)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox GrpBox_NameChanger;
		private System.Windows.Forms.TextBox TxtBox_SeriesNameFormat;
		private System.Windows.Forms.TextBox TxtBox_MovieNameFormat;
		private System.Windows.Forms.Label Lbl_SeriesNameFormat;
		private System.Windows.Forms.Label Lbl_MovieNameFormat;
		private System.Windows.Forms.PictureBox PicBox_QuestionMark;
		private System.Windows.Forms.Button Btn_Save;
		private System.Windows.Forms.Button Btn_Cancel;
	}
}