namespace FSANC_V2
{
	partial class SerialEpisodeValuesChanger
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
			this.Button_OK = new System.Windows.Forms.Button();
			this.Button_Cancel = new System.Windows.Forms.Button();
			this.Label_SeasonNumber = new System.Windows.Forms.Label();
			this.Label_EpisodeNumber = new System.Windows.Forms.Label();
			this.TextBox_SeasonNumber = new System.Windows.Forms.TextBox();
			this.TextBox_EpisodeNumber = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// Button_OK
			// 
			this.Button_OK.Location = new System.Drawing.Point(26, 71);
			this.Button_OK.Name = "Button_OK";
			this.Button_OK.Size = new System.Drawing.Size(50, 23);
			this.Button_OK.TabIndex = 0;
			this.Button_OK.Text = "OK";
			this.Button_OK.UseVisualStyleBackColor = true;
			this.Button_OK.Click += new System.EventHandler(this.ButtonOK_Click);
			// 
			// Button_Cancel
			// 
			this.Button_Cancel.Location = new System.Drawing.Point(82, 71);
			this.Button_Cancel.Name = "Button_Cancel";
			this.Button_Cancel.Size = new System.Drawing.Size(50, 23);
			this.Button_Cancel.TabIndex = 1;
			this.Button_Cancel.Text = "Cancel";
			this.Button_Cancel.UseVisualStyleBackColor = true;
			this.Button_Cancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// Label_SeasonNumber
			// 
			this.Label_SeasonNumber.AutoSize = true;
			this.Label_SeasonNumber.Location = new System.Drawing.Point(11, 9);
			this.Label_SeasonNumber.Name = "Label_SeasonNumber";
			this.Label_SeasonNumber.Size = new System.Drawing.Size(84, 13);
			this.Label_SeasonNumber.TabIndex = 2;
			this.Label_SeasonNumber.Text = "Season number:";
			// 
			// Label_EpisodeNumber
			// 
			this.Label_EpisodeNumber.AutoSize = true;
			this.Label_EpisodeNumber.Location = new System.Drawing.Point(11, 40);
			this.Label_EpisodeNumber.Name = "Label_EpisodeNumber";
			this.Label_EpisodeNumber.Size = new System.Drawing.Size(86, 13);
			this.Label_EpisodeNumber.TabIndex = 3;
			this.Label_EpisodeNumber.Text = "Episode number:";
			// 
			// TextBox_SeasonNumber
			// 
			this.TextBox_SeasonNumber.Location = new System.Drawing.Point(107, 6);
			this.TextBox_SeasonNumber.MaxLength = 2;
			this.TextBox_SeasonNumber.Name = "TextBox_SeasonNumber";
			this.TextBox_SeasonNumber.Size = new System.Drawing.Size(40, 20);
			this.TextBox_SeasonNumber.TabIndex = 4;
			this.TextBox_SeasonNumber.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			// 
			// TextBox_EpisodeNumber
			// 
			this.TextBox_EpisodeNumber.Location = new System.Drawing.Point(107, 37);
			this.TextBox_EpisodeNumber.MaxLength = 2;
			this.TextBox_EpisodeNumber.Name = "TextBox_EpisodeNumber";
			this.TextBox_EpisodeNumber.Size = new System.Drawing.Size(40, 20);
			this.TextBox_EpisodeNumber.TabIndex = 5;
			this.TextBox_EpisodeNumber.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			// 
			// SerialEpisodeValuesChanger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(159, 106);
			this.ControlBox = false;
			this.Controls.Add(this.TextBox_EpisodeNumber);
			this.Controls.Add(this.TextBox_SeasonNumber);
			this.Controls.Add(this.Label_EpisodeNumber);
			this.Controls.Add(this.Label_SeasonNumber);
			this.Controls.Add(this.Button_Cancel);
			this.Controls.Add(this.Button_OK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SerialEpisodeValuesChanger";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Modify values";
			this.Load += new System.EventHandler(this.SerialEpisodeValuesChanger_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Button_OK;
		private System.Windows.Forms.Button Button_Cancel;
		private System.Windows.Forms.Label Label_SeasonNumber;
		private System.Windows.Forms.Label Label_EpisodeNumber;
		private System.Windows.Forms.TextBox TextBox_SeasonNumber;
		private System.Windows.Forms.TextBox TextBox_EpisodeNumber;
	}
}