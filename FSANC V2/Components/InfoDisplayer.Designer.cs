namespace FSANC_V2.Components
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
			this.Label_Title = new System.Windows.Forms.Label();
			this.Label_Year = new System.Windows.Forms.Label();
			this.Label_Genres = new System.Windows.Forms.Label();
			this.GrpMainInformation = new System.Windows.Forms.GroupBox();
			this.Control_SeasonsInfo = new SeasonsInfo();
			this.GrpMainInformation.SuspendLayout();
			this.SuspendLayout();
			// 
			// LblTitle
			// 
			this.Label_Title.AutoSize = true;
			this.Label_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.Label_Title.Location = new System.Drawing.Point(6, 16);
			this.Label_Title.Name = "LblTitle";
			this.Label_Title.Size = new System.Drawing.Size(71, 31);
			this.Label_Title.TabIndex = 0;
			this.Label_Title.Text = "Title";
			// 
			// LblYear
			// 
			this.Label_Year.AutoSize = true;
			this.Label_Year.Location = new System.Drawing.Point(12, 47);
			this.Label_Year.Name = "LblYear";
			this.Label_Year.Size = new System.Drawing.Size(29, 13);
			this.Label_Year.TabIndex = 1;
			this.Label_Year.Text = "Year";
			// 
			// LblGenres
			// 
			this.Label_Genres.AutoSize = true;
			this.Label_Genres.Location = new System.Drawing.Point(47, 47);
			this.Label_Genres.Name = "LblGenres";
			this.Label_Genres.Size = new System.Drawing.Size(41, 13);
			this.Label_Genres.TabIndex = 2;
			this.Label_Genres.Text = "Genres";
			// 
			// GrpMainInformation
			// 
			this.GrpMainInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GrpMainInformation.Controls.Add(this.Label_Title);
			this.GrpMainInformation.Controls.Add(this.Label_Genres);
			this.GrpMainInformation.Controls.Add(this.Label_Year);
			this.GrpMainInformation.Location = new System.Drawing.Point(3, 3);
			this.GrpMainInformation.Name = "GrpMainInformation";
			this.GrpMainInformation.Size = new System.Drawing.Size(527, 69);
			this.GrpMainInformation.TabIndex = 3;
			this.GrpMainInformation.TabStop = false;
			// 
			// Control_SeasonsInfo
			// 
			this.Control_SeasonsInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Control_SeasonsInfo.AutoSize = true;
			this.Control_SeasonsInfo.Location = new System.Drawing.Point(2, 78);
			this.Control_SeasonsInfo.Name = "Control_SeasonsInfo";
			this.Control_SeasonsInfo.Size = new System.Drawing.Size(528, 232);
			this.Control_SeasonsInfo.TabIndex = 1;
			// 
			// InfoDisplayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.GrpMainInformation);
			this.Controls.Add(this.Control_SeasonsInfo);
			this.Name = "InfoDisplayer";
			this.Size = new System.Drawing.Size(533, 312);
			this.GrpMainInformation.ResumeLayout(false);
			this.GrpMainInformation.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private SeasonsInfo Control_SeasonsInfo;
		private System.Windows.Forms.Label Label_Title;
		private System.Windows.Forms.Label Label_Year;
		private System.Windows.Forms.Label Label_Genres;
		private System.Windows.Forms.GroupBox GrpMainInformation;
	}
}
