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
			this.SuspendLayout();
			// 
			// LblTitle
			// 
			this.LblTitle.AutoSize = true;
			this.LblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
			this.LblTitle.Location = new System.Drawing.Point(14, 10);
			this.LblTitle.Name = "LblTitle";
			this.LblTitle.Size = new System.Drawing.Size(71, 31);
			this.LblTitle.TabIndex = 0;
			this.LblTitle.Text = "Title";
			// 
			// LblYear
			// 
			this.LblYear.AutoSize = true;
			this.LblYear.Location = new System.Drawing.Point(17, 41);
			this.LblYear.Name = "LblYear";
			this.LblYear.Size = new System.Drawing.Size(29, 13);
			this.LblYear.TabIndex = 1;
			this.LblYear.Text = "Year";
			// 
			// LblGenres
			// 
			this.LblGenres.AutoSize = true;
			this.LblGenres.Location = new System.Drawing.Point(20, 58);
			this.LblGenres.Name = "LblGenres";
			this.LblGenres.Size = new System.Drawing.Size(41, 13);
			this.LblGenres.TabIndex = 2;
			this.LblGenres.Text = "Genres";
			// 
			// InfoDisplayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.LblGenres);
			this.Controls.Add(this.LblYear);
			this.Controls.Add(this.LblTitle);
			this.Name = "InfoDisplayer";
			this.Size = new System.Drawing.Size(428, 279);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LblTitle;
		private System.Windows.Forms.Label LblYear;
		private System.Windows.Forms.Label LblGenres;
	}
}
