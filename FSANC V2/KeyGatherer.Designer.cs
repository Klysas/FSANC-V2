namespace FSANC_V2
{
	partial class KeyGatherer
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
			this.components = new System.ComponentModel.Container();
			this.TextBox_Key = new System.Windows.Forms.TextBox();
			this.BtnOk = new System.Windows.Forms.Button();
			this.LblInputApiKey = new System.Windows.Forms.Label();
			this.LinkLabel_TMDB = new System.Windows.Forms.LinkLabel();
			this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// TextBox_Key
			// 
			this.TextBox_Key.Location = new System.Drawing.Point(12, 30);
			this.TextBox_Key.Name = "TextBox_Key";
			this.TextBox_Key.Size = new System.Drawing.Size(401, 20);
			this.TextBox_Key.TabIndex = 0;
			this.ToolTip.SetToolTip(this.TextBox_Key, "Input API key");
			// 
			// BtnOk
			// 
			this.BtnOk.Location = new System.Drawing.Point(175, 56);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(75, 23);
			this.BtnOk.TabIndex = 1;
			this.BtnOk.Text = "OK";
			this.BtnOk.UseVisualStyleBackColor = true;
			this.BtnOk.Click += new System.EventHandler(this.ButtonOK_Click);
			// 
			// LblInputApiKey
			// 
			this.LblInputApiKey.AutoSize = true;
			this.LblInputApiKey.Location = new System.Drawing.Point(12, 9);
			this.LblInputApiKey.Name = "LblInputApiKey";
			this.LblInputApiKey.Size = new System.Drawing.Size(298, 13);
			this.LblInputApiKey.TabIndex = 2;
			this.LblInputApiKey.Text = "Input TMDB API key in order to proceed. To get API key visit:";
			// 
			// LinkLabel_TMDB
			// 
			this.LinkLabel_TMDB.AutoSize = true;
			this.LinkLabel_TMDB.Location = new System.Drawing.Point(306, 9);
			this.LinkLabel_TMDB.Name = "LinkLabel_TMDB";
			this.LinkLabel_TMDB.Size = new System.Drawing.Size(107, 13);
			this.LinkLabel_TMDB.TabIndex = 3;
			this.LinkLabel_TMDB.TabStop = true;
			this.LinkLabel_TMDB.Text = "www.themoviedb.org";
			this.LinkLabel_TMDB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelTMDB_LinkClicked);
			// 
			// TolTip
			// 
			this.ToolTip.IsBalloon = true;
			// 
			// KeyGatherer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(425, 87);
			this.Controls.Add(this.LinkLabel_TMDB);
			this.Controls.Add(this.LblInputApiKey);
			this.Controls.Add(this.BtnOk);
			this.Controls.Add(this.TextBox_Key);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::FSANC_V2.Properties.Resources.plus;
			this.MaximizeBox = false;
			this.Name = "KeyGatherer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FSANC";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TextBox_Key;
		private System.Windows.Forms.Button BtnOk;
		private System.Windows.Forms.Label LblInputApiKey;
		private System.Windows.Forms.LinkLabel LinkLabel_TMDB;
		private System.Windows.Forms.ToolTip ToolTip;
	}
}