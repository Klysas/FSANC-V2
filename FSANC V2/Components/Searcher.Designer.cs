namespace FSANC_V2.Components
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
			this.Button_StopSearch = new System.Windows.Forms.Button();
			this.Button_Search = new System.Windows.Forms.Button();
			this.ListView_SearchResults = new System.Windows.Forms.ListView();
			this.ColumnHeader_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColumnHeader_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColumnHeader_Year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TextBox_SearchField = new System.Windows.Forms.TextBox();
			this.ComboBox_Type = new System.Windows.Forms.ComboBox();
			this.TextBox_ToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.GrpBoxMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// GrpBoxMain
			// 
			this.GrpBoxMain.Controls.Add(this.Button_StopSearch);
			this.GrpBoxMain.Controls.Add(this.Button_Search);
			this.GrpBoxMain.Controls.Add(this.ListView_SearchResults);
			this.GrpBoxMain.Controls.Add(this.TextBox_SearchField);
			this.GrpBoxMain.Controls.Add(this.ComboBox_Type);
			this.GrpBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GrpBoxMain.Location = new System.Drawing.Point(0, 0);
			this.GrpBoxMain.MinimumSize = new System.Drawing.Size(349, 382);
			this.GrpBoxMain.Name = "GrpBoxMain";
			this.GrpBoxMain.Size = new System.Drawing.Size(349, 382);
			this.GrpBoxMain.TabIndex = 0;
			this.GrpBoxMain.TabStop = false;
			// 
			// Button_StopSearch
			// 
			this.Button_StopSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Button_StopSearch.Location = new System.Drawing.Point(295, 19);
			this.Button_StopSearch.Name = "Button_StopSearch";
			this.Button_StopSearch.Size = new System.Drawing.Size(48, 21);
			this.Button_StopSearch.TabIndex = 4;
			this.Button_StopSearch.Text = "Stop";
			this.Button_StopSearch.UseVisualStyleBackColor = true;
			this.Button_StopSearch.Click += new System.EventHandler(this.ButtonStopSearch_Click);
			// 
			// Button_Search
			// 
			this.Button_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Button_Search.BackgroundImage = global::FSANC_V2.Properties.Resources.search;
			this.Button_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Button_Search.Location = new System.Drawing.Point(269, 20);
			this.Button_Search.MaximumSize = new System.Drawing.Size(20, 20);
			this.Button_Search.MinimumSize = new System.Drawing.Size(20, 20);
			this.Button_Search.Name = "Button_Search";
			this.Button_Search.Size = new System.Drawing.Size(20, 20);
			this.Button_Search.TabIndex = 3;
			this.Button_Search.UseVisualStyleBackColor = true;
			this.Button_Search.Click += new System.EventHandler(this.ButtonSearch_Click);
			// 
			// ListView_SearchResults
			// 
			this.ListView_SearchResults.AllowColumnReorder = true;
			this.ListView_SearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ListView_SearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader_Type,
            this.ColumnHeader_Title,
            this.ColumnHeader_Year});
			this.ListView_SearchResults.FullRowSelect = true;
			this.ListView_SearchResults.HideSelection = false;
			this.ListView_SearchResults.Location = new System.Drawing.Point(6, 48);
			this.ListView_SearchResults.MinimumSize = new System.Drawing.Size(337, 329);
			this.ListView_SearchResults.MultiSelect = false;
			this.ListView_SearchResults.Name = "ListView_SearchResults";
			this.ListView_SearchResults.Size = new System.Drawing.Size(337, 329);
			this.ListView_SearchResults.TabIndex = 2;
			this.ListView_SearchResults.UseCompatibleStateImageBehavior = false;
			this.ListView_SearchResults.View = System.Windows.Forms.View.Details;
			// 
			// ColumnHeader_Type
			// 
			this.ColumnHeader_Type.Tag = "";
			this.ColumnHeader_Type.Text = "Type";
			// 
			// ColumnHeader_Title
			// 
			this.ColumnHeader_Title.Text = "Title";
			// 
			// ColumnHeader_Year
			// 
			this.ColumnHeader_Year.Text = "Year";
			// 
			// TextBox_SearchField
			// 
			this.TextBox_SearchField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_SearchField.Location = new System.Drawing.Point(115, 20);
			this.TextBox_SearchField.MinimumSize = new System.Drawing.Size(148, 20);
			this.TextBox_SearchField.Name = "TextBox_SearchField";
			this.TextBox_SearchField.Size = new System.Drawing.Size(148, 20);
			this.TextBox_SearchField.TabIndex = 1;
			this.TextBox_SearchField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSearchField_KeyPress);
			// 
			// ComboBox_Type
			// 
			this.ComboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox_Type.FormattingEnabled = true;
			this.ComboBox_Type.Location = new System.Drawing.Point(6, 19);
			this.ComboBox_Type.Name = "ComboBox_Type";
			this.ComboBox_Type.Size = new System.Drawing.Size(103, 21);
			this.ComboBox_Type.TabIndex = 0;
			this.ComboBox_Type.SelectedIndexChanged += new System.EventHandler(this.ComboBoxType_SelectedIndexChanged);
			// 
			// TextBox_ToolTip
			// 
			this.TextBox_ToolTip.AutomaticDelay = 50;
			this.TextBox_ToolTip.IsBalloon = true;
			this.TextBox_ToolTip.OwnerDraw = true;
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
		private System.Windows.Forms.ListView ListView_SearchResults;
		private System.Windows.Forms.TextBox TextBox_SearchField;
		private System.Windows.Forms.ComboBox ComboBox_Type;
		private System.Windows.Forms.ToolTip TextBox_ToolTip;
		private System.Windows.Forms.Button Button_Search;
		private System.Windows.Forms.ColumnHeader ColumnHeader_Type;
		private System.Windows.Forms.ColumnHeader ColumnHeader_Title;
		private System.Windows.Forms.ColumnHeader ColumnHeader_Year;
		private System.Windows.Forms.Button Button_StopSearch;
	}
}
