namespace FSANC_V2
{
	partial class InfoDisplayer
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
			this.LblTitle = new System.Windows.Forms.Label();
			this.LblYear = new System.Windows.Forms.Label();
			this.LblGenres = new System.Windows.Forms.Label();
			this.GrpMainInformation = new System.Windows.Forms.GroupBox();
			this.SeasonInfo = new FSANC_V2.SeasonsInfo();
			this.GrpMainInformation.SuspendLayout();
			this.SuspendLayout();
			// 
			// LblTitle
			// 
			this.LblTitle.AutoSize = true;
			this.LblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.LblTitle.Location = new System.Drawing.Point(6, 16);
			this.LblTitle.Name = "LblTitle";
			this.LblTitle.Size = new System.Drawing.Size(71, 31);
			this.LblTitle.TabIndex = 0;
			this.LblTitle.Text = "Title";
			// 
			// LblYear
			// 
			this.LblYear.AutoSize = true;
			this.LblYear.Location = new System.Drawing.Point(12, 47);
			this.LblYear.Name = "LblYear";
			this.LblYear.Size = new System.Drawing.Size(29, 13);
			this.LblYear.TabIndex = 1;
			this.LblYear.Text = "Year";
			// 
			// LblGenres
			// 
			this.LblGenres.AutoSize = true;
			this.LblGenres.Location = new System.Drawing.Point(47, 47);
			this.LblGenres.Name = "LblGenres";
			this.LblGenres.Size = new System.Drawing.Size(41, 13);
			this.LblGenres.TabIndex = 2;
			this.LblGenres.Text = "Genres";
			// 
			// GrpMainInformation
			// 
			this.GrpMainInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GrpMainInformation.Controls.Add(this.LblTitle);
			this.GrpMainInformation.Controls.Add(this.LblGenres);
			this.GrpMainInformation.Controls.Add(this.LblYear);
			this.GrpMainInformation.Location = new System.Drawing.Point(3, 3);
			this.GrpMainInformation.Name = "GrpMainInformation";
			this.GrpMainInformation.Size = new System.Drawing.Size(527, 69);
			this.GrpMainInformation.TabIndex = 3;
			this.GrpMainInformation.TabStop = false;
			// 
			// SeasonInfo
			// 
			this.SeasonInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SeasonInfo.AutoSize = true;
			this.SeasonInfo.Location = new System.Drawing.Point(2, 78);
			this.SeasonInfo.Name = "SeasonInfo";
			this.SeasonInfo.Size = new System.Drawing.Size(528, 232);
			this.SeasonInfo.TabIndex = 1;
			// 
			// InfoDisplayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.GrpMainInformation);
			this.Controls.Add(this.SeasonInfo);
			this.Name = "InfoDisplayer";
			this.Size = new System.Drawing.Size(533, 312);
			this.GrpMainInformation.ResumeLayout(false);
			this.GrpMainInformation.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private FSANC_V2.SeasonsInfo SeasonInfo;
		private System.Windows.Forms.Label LblTitle;
		private System.Windows.Forms.Label LblYear;
		private System.Windows.Forms.Label LblGenres;
		private System.Windows.Forms.GroupBox GrpMainInformation;
	}
}
