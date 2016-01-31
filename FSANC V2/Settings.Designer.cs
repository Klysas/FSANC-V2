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
			this.GroupBox_NameChanger = new System.Windows.Forms.GroupBox();
			this.PictureBox_QuestionMark = new System.Windows.Forms.PictureBox();
			this.TextBox_SeriesNameFormat = new System.Windows.Forms.TextBox();
			this.TextBox_MovieNameFormat = new System.Windows.Forms.TextBox();
			this.Label_SeriesNameFormat = new System.Windows.Forms.Label();
			this.Label_MovieNameFormat = new System.Windows.Forms.Label();
			this.Button_Save = new System.Windows.Forms.Button();
			this.Button_Cancel = new System.Windows.Forms.Button();
			this.GroupBox_NameChanger.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox_QuestionMark)).BeginInit();
			this.SuspendLayout();
			// 
			// GroupBox_NameChanger
			// 
			this.GroupBox_NameChanger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GroupBox_NameChanger.Controls.Add(this.PictureBox_QuestionMark);
			this.GroupBox_NameChanger.Controls.Add(this.TextBox_SeriesNameFormat);
			this.GroupBox_NameChanger.Controls.Add(this.TextBox_MovieNameFormat);
			this.GroupBox_NameChanger.Controls.Add(this.Label_SeriesNameFormat);
			this.GroupBox_NameChanger.Controls.Add(this.Label_MovieNameFormat);
			this.GroupBox_NameChanger.Location = new System.Drawing.Point(13, 13);
			this.GroupBox_NameChanger.Name = "GroupBox_NameChanger";
			this.GroupBox_NameChanger.Size = new System.Drawing.Size(259, 69);
			this.GroupBox_NameChanger.TabIndex = 0;
			this.GroupBox_NameChanger.TabStop = false;
			this.GroupBox_NameChanger.Text = "Name changer";
			// 
			// PictureBox_QuestionMark
			// 
			this.PictureBox_QuestionMark.BackgroundImage = global::FSANC_V2.Properties.Resources.questionMark;
			this.PictureBox_QuestionMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.PictureBox_QuestionMark.Location = new System.Drawing.Point(6, 17);
			this.PictureBox_QuestionMark.Name = "PictureBox_QuestionMark";
			this.PictureBox_QuestionMark.Size = new System.Drawing.Size(14, 41);
			this.PictureBox_QuestionMark.TabIndex = 1;
			this.PictureBox_QuestionMark.TabStop = false;
			// 
			// TextBox_SeriesNameFormat
			// 
			this.TextBox_SeriesNameFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_SeriesNameFormat.Location = new System.Drawing.Point(127, 38);
			this.TextBox_SeriesNameFormat.Name = "TextBox_SeriesNameFormat";
			this.TextBox_SeriesNameFormat.Size = new System.Drawing.Size(126, 20);
			this.TextBox_SeriesNameFormat.TabIndex = 3;
			// 
			// TextBox_MovieNameFormat
			// 
			this.TextBox_MovieNameFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_MovieNameFormat.Location = new System.Drawing.Point(127, 17);
			this.TextBox_MovieNameFormat.Name = "TextBox_MovieNameFormat";
			this.TextBox_MovieNameFormat.Size = new System.Drawing.Size(126, 20);
			this.TextBox_MovieNameFormat.TabIndex = 2;
			// 
			// Label_SeriesNameFormat
			// 
			this.Label_SeriesNameFormat.AutoSize = true;
			this.Label_SeriesNameFormat.Location = new System.Drawing.Point(21, 41);
			this.Label_SeriesNameFormat.Name = "Label_SeriesNameFormat";
			this.Label_SeriesNameFormat.Size = new System.Drawing.Size(100, 13);
			this.Label_SeriesNameFormat.TabIndex = 1;
			this.Label_SeriesNameFormat.Text = "Series name format:";
			// 
			// Label_MovieNameFormat
			// 
			this.Label_MovieNameFormat.AutoSize = true;
			this.Label_MovieNameFormat.Location = new System.Drawing.Point(21, 20);
			this.Label_MovieNameFormat.Name = "Label_MovieNameFormat";
			this.Label_MovieNameFormat.Size = new System.Drawing.Size(100, 13);
			this.Label_MovieNameFormat.TabIndex = 0;
			this.Label_MovieNameFormat.Text = "Movie name format:";
			// 
			// Button_Save
			// 
			this.Button_Save.Location = new System.Drawing.Point(59, 226);
			this.Button_Save.Name = "Button_Save";
			this.Button_Save.Size = new System.Drawing.Size(75, 23);
			this.Button_Save.TabIndex = 1;
			this.Button_Save.Text = "Save";
			this.Button_Save.UseVisualStyleBackColor = true;
			this.Button_Save.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// Button_Cancel
			// 
			this.Button_Cancel.Location = new System.Drawing.Point(154, 226);
			this.Button_Cancel.Name = "Button_Cancel";
			this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.Button_Cancel.TabIndex = 2;
			this.Button_Cancel.Text = "Cancel";
			this.Button_Cancel.UseVisualStyleBackColor = true;
			this.Button_Cancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.Button_Cancel);
			this.Controls.Add(this.Button_Save);
			this.Controls.Add(this.GroupBox_NameChanger);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::FSANC_V2.Properties.Resources.plus;
			this.MaximizeBox = false;
			this.Name = "Settings";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.Shown += new System.EventHandler(this.Settings_Shown);
			this.GroupBox_NameChanger.ResumeLayout(false);
			this.GroupBox_NameChanger.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox_QuestionMark)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox GroupBox_NameChanger;
		private System.Windows.Forms.TextBox TextBox_SeriesNameFormat;
		private System.Windows.Forms.TextBox TextBox_MovieNameFormat;
		private System.Windows.Forms.Label Label_SeriesNameFormat;
		private System.Windows.Forms.Label Label_MovieNameFormat;
		private System.Windows.Forms.PictureBox PictureBox_QuestionMark;
		private System.Windows.Forms.Button Button_Save;
		private System.Windows.Forms.Button Button_Cancel;
	}
}