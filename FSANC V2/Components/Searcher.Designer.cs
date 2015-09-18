namespace FSANC_V2
{
	partial class Searcher
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
			this.GrpBoxMain = new System.Windows.Forms.GroupBox();
			this.LstViewSearchResults = new System.Windows.Forms.ListView();
			this.TxtBoxSearch = new System.Windows.Forms.TextBox();
			this.CmbBoxType = new System.Windows.Forms.ComboBox();
			this.BkWorkerSearcher = new System.ComponentModel.BackgroundWorker();
			this.TxtBoxToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.GrpBoxMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// GrpBoxMain
			// 
			this.GrpBoxMain.Controls.Add(this.LstViewSearchResults);
			this.GrpBoxMain.Controls.Add(this.TxtBoxSearch);
			this.GrpBoxMain.Controls.Add(this.CmbBoxType);
			this.GrpBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GrpBoxMain.Location = new System.Drawing.Point(0, 0);
			this.GrpBoxMain.MinimumSize = new System.Drawing.Size(349, 382);
			this.GrpBoxMain.Name = "GrpBoxMain";
			this.GrpBoxMain.Size = new System.Drawing.Size(349, 382);
			this.GrpBoxMain.TabIndex = 0;
			this.GrpBoxMain.TabStop = false;
			// 
			// LstViewSearchResults
			// 
			this.LstViewSearchResults.AllowColumnReorder = true;
			this.LstViewSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LstViewSearchResults.FullRowSelect = true;
			this.LstViewSearchResults.Location = new System.Drawing.Point(6, 48);
			this.LstViewSearchResults.MinimumSize = new System.Drawing.Size(337, 329);
			this.LstViewSearchResults.MultiSelect = false;
			this.LstViewSearchResults.Name = "LstViewSearchResults";
			this.LstViewSearchResults.Size = new System.Drawing.Size(337, 329);
			this.LstViewSearchResults.TabIndex = 2;
			this.LstViewSearchResults.UseCompatibleStateImageBehavior = false;
			this.LstViewSearchResults.View = System.Windows.Forms.View.Details;
			// 
			// TxtBoxSearch
			// 
			this.TxtBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtBoxSearch.Location = new System.Drawing.Point(145, 19);
			this.TxtBoxSearch.MinimumSize = new System.Drawing.Size(198, 20);
			this.TxtBoxSearch.Name = "TxtBoxSearch";
			this.TxtBoxSearch.Size = new System.Drawing.Size(198, 20);
			this.TxtBoxSearch.TabIndex = 1;
			// 
			// CmbBoxType
			// 
			this.CmbBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbBoxType.FormattingEnabled = true;
			this.CmbBoxType.Location = new System.Drawing.Point(6, 19);
			this.CmbBoxType.Name = "CmbBoxType";
			this.CmbBoxType.Size = new System.Drawing.Size(132, 21);
			this.CmbBoxType.TabIndex = 0;
			// 
			// TxtBoxToolTip
			// 
			this.TxtBoxToolTip.AutomaticDelay = 50;
			this.TxtBoxToolTip.IsBalloon = true;
			this.TxtBoxToolTip.OwnerDraw = true;
			// 
			// Searcher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.Controls.Add(this.GrpBoxMain);
			this.Name = "Searcher";
			this.Size = new System.Drawing.Size(349, 382);
			this.GrpBoxMain.ResumeLayout(false);
			this.GrpBoxMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox GrpBoxMain;
		private System.Windows.Forms.ListView LstViewSearchResults;
		private System.Windows.Forms.TextBox TxtBoxSearch;
		private System.Windows.Forms.ComboBox CmbBoxType;
		private System.ComponentModel.BackgroundWorker BkWorkerSearcher;
		private System.Windows.Forms.ToolTip TxtBoxToolTip;
	}
}
