﻿namespace FSANC_V2
{
	partial class SeasonsInfo
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
			this.GrpSeasons = new System.Windows.Forms.GroupBox();
			this.BgWorker_SeriesUpdater = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// GrpSeasons
			// 
			this.GrpSeasons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GrpSeasons.Location = new System.Drawing.Point(0, 0);
			this.GrpSeasons.Name = "GrpSeasons";
			this.GrpSeasons.Size = new System.Drawing.Size(365, 235);
			this.GrpSeasons.TabIndex = 0;
			this.GrpSeasons.TabStop = false;
			this.GrpSeasons.Text = "Seasons";
			// 
			// BgWorker_SeriesUpdater
			// 
			this.BgWorker_SeriesUpdater.WorkerSupportsCancellation = true;
			// 
			// SeasonsInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.GrpSeasons);
			this.Name = "SeasonsInfo";
			this.Size = new System.Drawing.Size(365, 235);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox GrpSeasons;
		private System.ComponentModel.BackgroundWorker BgWorker_SeriesUpdater;
	}
}
