namespace FileHasher
{
	partial class MainForm
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
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.tlpStartStop = new System.Windows.Forms.TableLayoutPanel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.lblDirectories = new System.Windows.Forms.Label();
			this.txbDirectories = new System.Windows.Forms.TextBox();
			this.btnDirectories = new System.Windows.Forms.Button();
			this.ssStatus = new System.Windows.Forms.StatusStrip();
			this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.tsslPath = new System.Windows.Forms.ToolStripStatusLabel();
			this.tlpMain.SuspendLayout();
			this.tlpStartStop.SuspendLayout();
			this.ssStatus.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpMain
			// 
			this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpMain.ColumnCount = 2;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.Controls.Add(this.tlpStartStop, 0, 2);
			this.tlpMain.Controls.Add(this.lblDirectories, 0, 0);
			this.tlpMain.Controls.Add(this.txbDirectories, 0, 1);
			this.tlpMain.Controls.Add(this.btnDirectories, 1, 0);
			this.tlpMain.Location = new System.Drawing.Point(12, 12);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.RowCount = 3;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMain.Size = new System.Drawing.Size(760, 224);
			this.tlpMain.TabIndex = 0;
			// 
			// tlpStartStop
			// 
			this.tlpStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpStartStop.AutoSize = true;
			this.tlpStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpStartStop.ColumnCount = 3;
			this.tlpMain.SetColumnSpan(this.tlpStartStop, 2);
			this.tlpStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpStartStop.Controls.Add(this.btnCancel, 2, 0);
			this.tlpStartStop.Controls.Add(this.btnStart, 1, 0);
			this.tlpStartStop.Location = new System.Drawing.Point(0, 195);
			this.tlpStartStop.Margin = new System.Windows.Forms.Padding(0);
			this.tlpStartStop.Name = "tlpStartStop";
			this.tlpStartStop.RowCount = 1;
			this.tlpStartStop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpStartStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.tlpStartStop.Size = new System.Drawing.Size(760, 29);
			this.tlpStartStop.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.Enabled = false;
			this.btnCancel.Location = new System.Drawing.Point(682, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(601, 3);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// lblDirectories
			// 
			this.lblDirectories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblDirectories.AutoSize = true;
			this.lblDirectories.Location = new System.Drawing.Point(3, 13);
			this.lblDirectories.Margin = new System.Windows.Forms.Padding(3);
			this.lblDirectories.Name = "lblDirectories";
			this.lblDirectories.Size = new System.Drawing.Size(60, 13);
			this.lblDirectories.TabIndex = 0;
			this.lblDirectories.Text = "Directories:";
			// 
			// txbDirectories
			// 
			this.txbDirectories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpMain.SetColumnSpan(this.txbDirectories, 2);
			this.txbDirectories.Location = new System.Drawing.Point(3, 32);
			this.txbDirectories.Multiline = true;
			this.txbDirectories.Name = "txbDirectories";
			this.txbDirectories.Size = new System.Drawing.Size(754, 160);
			this.txbDirectories.TabIndex = 3;
			// 
			// btnDirectories
			// 
			this.btnDirectories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDirectories.AutoSize = true;
			this.btnDirectories.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnDirectories.Location = new System.Drawing.Point(734, 3);
			this.btnDirectories.Name = "btnDirectories";
			this.btnDirectories.Size = new System.Drawing.Size(23, 23);
			this.btnDirectories.TabIndex = 2;
			this.btnDirectories.Text = "+";
			this.btnDirectories.UseVisualStyleBackColor = true;
			this.btnDirectories.Click += new System.EventHandler(this.btnDirectories_Click);
			// 
			// ssStatus
			// 
			this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbProgress,
            this.tsslPath});
			this.ssStatus.Location = new System.Drawing.Point(0, 239);
			this.ssStatus.Name = "ssStatus";
			this.ssStatus.Size = new System.Drawing.Size(784, 22);
			this.ssStatus.TabIndex = 1;
			this.ssStatus.Text = "statusStrip1";
			// 
			// tspbProgress
			// 
			this.tspbProgress.Name = "tspbProgress";
			this.tspbProgress.Size = new System.Drawing.Size(150, 16);
			this.tspbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.tspbProgress.Visible = false;
			// 
			// tsslPath
			// 
			this.tsslPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsslPath.Name = "tsslPath";
			this.tsslPath.Size = new System.Drawing.Size(536, 17);
			this.tsslPath.Spring = true;
			this.tsslPath.Text = "<Path>";
			this.tsslPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsslPath.Visible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 261);
			this.Controls.Add(this.tlpMain);
			this.Controls.Add(this.ssStatus);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FileHasher";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.tlpMain.ResumeLayout(false);
			this.tlpMain.PerformLayout();
			this.tlpStartStop.ResumeLayout(false);
			this.ssStatus.ResumeLayout(false);
			this.ssStatus.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.TableLayoutPanel tlpStartStop;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnDirectories;
		private System.Windows.Forms.TextBox txbDirectories;
		private System.Windows.Forms.Label lblDirectories;
		private System.Windows.Forms.StatusStrip ssStatus;
		private System.Windows.Forms.ToolStripProgressBar tspbProgress;
		private System.Windows.Forms.ToolStripStatusLabel tsslPath;
	}
}