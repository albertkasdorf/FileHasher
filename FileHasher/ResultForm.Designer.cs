namespace FileHasher
{
	partial class ResultForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( )
		{
			this.rtbResults = new System.Windows.Forms.RichTextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.tlpCounter = new System.Windows.Forms.TableLayoutPanel();
			this.lblChanged = new System.Windows.Forms.Label();
			this.lblFaulted = new System.Windows.Forms.Label();
			this.lblAdded = new System.Windows.Forms.Label();
			this.lblDeleted = new System.Windows.Forms.Label();
			this.txbChanged = new System.Windows.Forms.TextBox();
			this.txbFaulted = new System.Windows.Forms.TextBox();
			this.txbAdded = new System.Windows.Forms.TextBox();
			this.txbDeleted = new System.Windows.Forms.TextBox();
			this.tlpResultForm = new System.Windows.Forms.TableLayoutPanel();
			this.pbProgress = new System.Windows.Forms.ProgressBar();
			this.tlpControl = new System.Windows.Forms.TableLayoutPanel();
			this.tlpCounter.SuspendLayout();
			this.tlpResultForm.SuspendLayout();
			this.tlpControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// rtbResults
			// 
			this.rtbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbResults.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbResults.Location = new System.Drawing.Point(3, 29);
			this.rtbResults.Name = "rtbResults";
			this.rtbResults.ReadOnly = true;
			this.rtbResults.Size = new System.Drawing.Size(754, 276);
			this.rtbResults.TabIndex = 1;
			this.rtbResults.Text = "";
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(682, 3);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// tlpCounter
			// 
			this.tlpCounter.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tlpCounter.AutoSize = true;
			this.tlpCounter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpCounter.ColumnCount = 8;
			this.tlpCounter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpCounter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpCounter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpCounter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpCounter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpCounter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpCounter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpCounter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpCounter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpCounter.Controls.Add(this.lblChanged, 0, 0);
			this.tlpCounter.Controls.Add(this.txbChanged, 1, 0);
			this.tlpCounter.Controls.Add(this.lblFaulted, 2, 0);
			this.tlpCounter.Controls.Add(this.txbFaulted, 3, 0);
			this.tlpCounter.Controls.Add(this.lblAdded, 4, 0);
			this.tlpCounter.Controls.Add(this.txbAdded, 5, 0);
			this.tlpCounter.Controls.Add(this.lblDeleted, 6, 0);
			this.tlpCounter.Controls.Add(this.txbDeleted, 7, 0);
			this.tlpCounter.Location = new System.Drawing.Point(163, 0);
			this.tlpCounter.Margin = new System.Windows.Forms.Padding(0);
			this.tlpCounter.Name = "tlpCounter";
			this.tlpCounter.RowCount = 1;
			this.tlpCounter.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpCounter.Size = new System.Drawing.Size(434, 26);
			this.tlpCounter.TabIndex = 0;
			// 
			// lblChanged
			// 
			this.lblChanged.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblChanged.AutoSize = true;
			this.lblChanged.Location = new System.Drawing.Point(3, 6);
			this.lblChanged.Name = "lblChanged";
			this.lblChanged.Size = new System.Drawing.Size(53, 13);
			this.lblChanged.TabIndex = 0;
			this.lblChanged.Text = "Changed:";
			// 
			// lblFaulted
			// 
			this.lblFaulted.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblFaulted.AutoSize = true;
			this.lblFaulted.Location = new System.Drawing.Point(118, 6);
			this.lblFaulted.Name = "lblFaulted";
			this.lblFaulted.Size = new System.Drawing.Size(45, 13);
			this.lblFaulted.TabIndex = 2;
			this.lblFaulted.Text = "Faulted:";
			// 
			// lblAdded
			// 
			this.lblAdded.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblAdded.AutoSize = true;
			this.lblAdded.Location = new System.Drawing.Point(225, 6);
			this.lblAdded.Name = "lblAdded";
			this.lblAdded.Size = new System.Drawing.Size(41, 13);
			this.lblAdded.TabIndex = 4;
			this.lblAdded.Text = "Added:";
			// 
			// lblDeleted
			// 
			this.lblDeleted.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblDeleted.AutoSize = true;
			this.lblDeleted.Location = new System.Drawing.Point(328, 6);
			this.lblDeleted.Name = "lblDeleted";
			this.lblDeleted.Size = new System.Drawing.Size(47, 13);
			this.lblDeleted.TabIndex = 6;
			this.lblDeleted.Text = "Deleted:";
			// 
			// txbChanged
			// 
			this.txbChanged.Location = new System.Drawing.Point(62, 3);
			this.txbChanged.Name = "txbChanged";
			this.txbChanged.ReadOnly = true;
			this.txbChanged.Size = new System.Drawing.Size(50, 20);
			this.txbChanged.TabIndex = 1;
			this.txbChanged.TabStop = false;
			this.txbChanged.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txbFaulted
			// 
			this.txbFaulted.Location = new System.Drawing.Point(169, 3);
			this.txbFaulted.Name = "txbFaulted";
			this.txbFaulted.ReadOnly = true;
			this.txbFaulted.Size = new System.Drawing.Size(50, 20);
			this.txbFaulted.TabIndex = 3;
			this.txbFaulted.TabStop = false;
			this.txbFaulted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txbAdded
			// 
			this.txbAdded.Location = new System.Drawing.Point(272, 3);
			this.txbAdded.Name = "txbAdded";
			this.txbAdded.ReadOnly = true;
			this.txbAdded.Size = new System.Drawing.Size(50, 20);
			this.txbAdded.TabIndex = 5;
			this.txbAdded.TabStop = false;
			this.txbAdded.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txbDeleted
			// 
			this.txbDeleted.Location = new System.Drawing.Point(381, 3);
			this.txbDeleted.Name = "txbDeleted";
			this.txbDeleted.ReadOnly = true;
			this.txbDeleted.Size = new System.Drawing.Size(50, 20);
			this.txbDeleted.TabIndex = 7;
			this.txbDeleted.TabStop = false;
			this.txbDeleted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tlpResultForm
			// 
			this.tlpResultForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpResultForm.ColumnCount = 1;
			this.tlpResultForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpResultForm.Controls.Add(this.tlpCounter, 0, 0);
			this.tlpResultForm.Controls.Add(this.rtbResults, 0, 1);
			this.tlpResultForm.Controls.Add(this.tlpControl, 0, 2);
			this.tlpResultForm.Location = new System.Drawing.Point(12, 12);
			this.tlpResultForm.Name = "tlpResultForm";
			this.tlpResultForm.RowCount = 3;
			this.tlpResultForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpResultForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpResultForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpResultForm.Size = new System.Drawing.Size(760, 337);
			this.tlpResultForm.TabIndex = 0;
			// 
			// pbProgress
			// 
			this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.pbProgress.Location = new System.Drawing.Point(3, 9);
			this.pbProgress.Name = "pbProgress";
			this.pbProgress.Size = new System.Drawing.Size(100, 10);
			this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.pbProgress.TabIndex = 0;
			// 
			// tlpControl
			// 
			this.tlpControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpControl.AutoSize = true;
			this.tlpControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpControl.ColumnCount = 3;
			this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpControl.Controls.Add(this.pbProgress, 0, 0);
			this.tlpControl.Controls.Add(this.btnClose, 2, 0);
			this.tlpControl.Location = new System.Drawing.Point(0, 308);
			this.tlpControl.Margin = new System.Windows.Forms.Padding(0);
			this.tlpControl.Name = "tlpControl";
			this.tlpControl.RowCount = 1;
			this.tlpControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpControl.Size = new System.Drawing.Size(760, 29);
			this.tlpControl.TabIndex = 2;
			// 
			// ResultForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(784, 361);
			this.Controls.Add(this.tlpResultForm);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 400);
			this.Name = "ResultForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FileHasher Result";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResultForm_FormClosing);
			this.Load += new System.EventHandler(this.ResultForm_Load);
			this.tlpCounter.ResumeLayout(false);
			this.tlpCounter.PerformLayout();
			this.tlpResultForm.ResumeLayout(false);
			this.tlpResultForm.PerformLayout();
			this.tlpControl.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox rtbResults;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.TableLayoutPanel tlpResultForm;
		private System.Windows.Forms.TableLayoutPanel tlpCounter;
		private System.Windows.Forms.Label lblChanged;
		private System.Windows.Forms.TextBox txbChanged;
		private System.Windows.Forms.TextBox txbFaulted;
		private System.Windows.Forms.Label lblAdded;
		private System.Windows.Forms.TextBox txbAdded;
		private System.Windows.Forms.Label lblDeleted;
		private System.Windows.Forms.TextBox txbDeleted;
		private System.Windows.Forms.Label lblFaulted;
		private System.Windows.Forms.TableLayoutPanel tlpControl;
		private System.Windows.Forms.ProgressBar pbProgress;
	}
}