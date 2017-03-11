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
			this.tcResult = new System.Windows.Forms.TabControl();
			this.tpChanged = new System.Windows.Forms.TabPage();
			this.dgvChanged = new System.Windows.Forms.DataGridView();
			this.tpFaulted = new System.Windows.Forms.TabPage();
			this.dgvFaulted = new System.Windows.Forms.DataGridView();
			this.tpAdded = new System.Windows.Forms.TabPage();
			this.dgvAdded = new System.Windows.Forms.DataGridView();
			this.tpDeleted = new System.Windows.Forms.TabPage();
			this.dgvDeleted = new System.Windows.Forms.DataGridView();
			this.tpExaminedPaths = new System.Windows.Forms.TabPage();
			this.dgvExaminedPaths = new System.Windows.Forms.DataGridView();
			this.tlpResult = new System.Windows.Forms.TableLayoutPanel();
			this.btnClose = new System.Windows.Forms.Button();
			this.pbProgress = new System.Windows.Forms.ProgressBar();
			this.tcResult.SuspendLayout();
			this.tpChanged.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvChanged)).BeginInit();
			this.tpFaulted.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvFaulted)).BeginInit();
			this.tpAdded.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvAdded)).BeginInit();
			this.tpDeleted.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDeleted)).BeginInit();
			this.tpExaminedPaths.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvExaminedPaths)).BeginInit();
			this.tlpResult.SuspendLayout();
			this.SuspendLayout();
			// 
			// tcResult
			// 
			this.tcResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpResult.SetColumnSpan(this.tcResult, 2);
			this.tcResult.Controls.Add(this.tpChanged);
			this.tcResult.Controls.Add(this.tpFaulted);
			this.tcResult.Controls.Add(this.tpAdded);
			this.tcResult.Controls.Add(this.tpDeleted);
			this.tcResult.Controls.Add(this.tpExaminedPaths);
			this.tcResult.Location = new System.Drawing.Point(3, 3);
			this.tcResult.Name = "tcResult";
			this.tcResult.SelectedIndex = 0;
			this.tcResult.Size = new System.Drawing.Size(760, 308);
			this.tcResult.TabIndex = 1;
			// 
			// tpChanged
			// 
			this.tpChanged.Controls.Add(this.dgvChanged);
			this.tpChanged.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tpChanged.Location = new System.Drawing.Point(4, 22);
			this.tpChanged.Name = "tpChanged";
			this.tpChanged.Padding = new System.Windows.Forms.Padding(3);
			this.tpChanged.Size = new System.Drawing.Size(752, 282);
			this.tpChanged.TabIndex = 0;
			this.tpChanged.Text = "Changed";
			this.tpChanged.UseVisualStyleBackColor = true;
			// 
			// dgvChanged
			// 
			this.dgvChanged.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvChanged.Location = new System.Drawing.Point(6, 6);
			this.dgvChanged.Name = "dgvChanged";
			this.dgvChanged.Size = new System.Drawing.Size(740, 270);
			this.dgvChanged.TabIndex = 0;
			this.dgvChanged.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_CellFormatting);
			// 
			// tpFaulted
			// 
			this.tpFaulted.Controls.Add(this.dgvFaulted);
			this.tpFaulted.Location = new System.Drawing.Point(4, 22);
			this.tpFaulted.Name = "tpFaulted";
			this.tpFaulted.Padding = new System.Windows.Forms.Padding(3);
			this.tpFaulted.Size = new System.Drawing.Size(752, 282);
			this.tpFaulted.TabIndex = 1;
			this.tpFaulted.Text = "Faulted";
			this.tpFaulted.UseVisualStyleBackColor = true;
			// 
			// dgvFaulted
			// 
			this.dgvFaulted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvFaulted.Location = new System.Drawing.Point(6, 6);
			this.dgvFaulted.Name = "dgvFaulted";
			this.dgvFaulted.RowHeadersVisible = false;
			this.dgvFaulted.Size = new System.Drawing.Size(740, 270);
			this.dgvFaulted.TabIndex = 1;
			this.dgvFaulted.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_CellFormatting);
			// 
			// tpAdded
			// 
			this.tpAdded.Controls.Add(this.dgvAdded);
			this.tpAdded.Location = new System.Drawing.Point(4, 22);
			this.tpAdded.Name = "tpAdded";
			this.tpAdded.Padding = new System.Windows.Forms.Padding(3);
			this.tpAdded.Size = new System.Drawing.Size(752, 282);
			this.tpAdded.TabIndex = 2;
			this.tpAdded.Text = "Added";
			this.tpAdded.UseVisualStyleBackColor = true;
			// 
			// dgvAdded
			// 
			this.dgvAdded.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvAdded.Location = new System.Drawing.Point(6, 6);
			this.dgvAdded.Name = "dgvAdded";
			this.dgvAdded.Size = new System.Drawing.Size(740, 270);
			this.dgvAdded.TabIndex = 0;
			this.dgvAdded.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_CellFormatting);
			// 
			// tpDeleted
			// 
			this.tpDeleted.Controls.Add(this.dgvDeleted);
			this.tpDeleted.Location = new System.Drawing.Point(4, 22);
			this.tpDeleted.Name = "tpDeleted";
			this.tpDeleted.Padding = new System.Windows.Forms.Padding(3);
			this.tpDeleted.Size = new System.Drawing.Size(752, 282);
			this.tpDeleted.TabIndex = 3;
			this.tpDeleted.Text = "Deleted";
			this.tpDeleted.UseVisualStyleBackColor = true;
			// 
			// dgvDeleted
			// 
			this.dgvDeleted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvDeleted.Location = new System.Drawing.Point(6, 6);
			this.dgvDeleted.Name = "dgvDeleted";
			this.dgvDeleted.Size = new System.Drawing.Size(740, 270);
			this.dgvDeleted.TabIndex = 0;
			this.dgvDeleted.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_CellFormatting);
			// 
			// tpExaminedPaths
			// 
			this.tpExaminedPaths.Controls.Add(this.dgvExaminedPaths);
			this.tpExaminedPaths.Location = new System.Drawing.Point(4, 22);
			this.tpExaminedPaths.Name = "tpExaminedPaths";
			this.tpExaminedPaths.Padding = new System.Windows.Forms.Padding(3);
			this.tpExaminedPaths.Size = new System.Drawing.Size(752, 282);
			this.tpExaminedPaths.TabIndex = 4;
			this.tpExaminedPaths.Text = "Examined paths";
			this.tpExaminedPaths.UseVisualStyleBackColor = true;
			// 
			// dgvExaminedPaths
			// 
			this.dgvExaminedPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvExaminedPaths.Location = new System.Drawing.Point(6, 6);
			this.dgvExaminedPaths.Name = "dgvExaminedPaths";
			this.dgvExaminedPaths.Size = new System.Drawing.Size(740, 270);
			this.dgvExaminedPaths.TabIndex = 0;
			this.dgvExaminedPaths.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_CellFormatting);
			// 
			// tlpResult
			// 
			this.tlpResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpResult.ColumnCount = 2;
			this.tlpResult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpResult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpResult.Controls.Add(this.tcResult, 0, 0);
			this.tlpResult.Controls.Add(this.pbProgress, 0, 1);
			this.tlpResult.Controls.Add(this.btnClose, 1, 1);
			this.tlpResult.Location = new System.Drawing.Point(9, 9);
			this.tlpResult.Margin = new System.Windows.Forms.Padding(0);
			this.tlpResult.Name = "tlpResult";
			this.tlpResult.RowCount = 2;
			this.tlpResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpResult.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpResult.Size = new System.Drawing.Size(766, 343);
			this.tlpResult.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(688, 317);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// pbProgress
			// 
			this.pbProgress.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.pbProgress.Location = new System.Drawing.Point(3, 323);
			this.pbProgress.Name = "pbProgress";
			this.pbProgress.Size = new System.Drawing.Size(200, 10);
			this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.pbProgress.TabIndex = 2;
			// 
			// ResultForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(784, 361);
			this.Controls.Add(this.tlpResult);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 400);
			this.Name = "ResultForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FileHasher Result";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResultForm_FormClosing);
			this.Load += new System.EventHandler(this.ResultForm_Load);
			this.tcResult.ResumeLayout(false);
			this.tpChanged.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvChanged)).EndInit();
			this.tpFaulted.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvFaulted)).EndInit();
			this.tpAdded.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvAdded)).EndInit();
			this.tpDeleted.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDeleted)).EndInit();
			this.tpExaminedPaths.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvExaminedPaths)).EndInit();
			this.tlpResult.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TabControl tcResult;
		private System.Windows.Forms.TabPage tpChanged;
		private System.Windows.Forms.TabPage tpFaulted;
		private System.Windows.Forms.TabPage tpAdded;
		private System.Windows.Forms.TabPage tpDeleted;
		private System.Windows.Forms.TabPage tpExaminedPaths;
		private System.Windows.Forms.DataGridView dgvChanged;
		private System.Windows.Forms.DataGridView dgvFaulted;
		private System.Windows.Forms.DataGridView dgvAdded;
		private System.Windows.Forms.DataGridView dgvDeleted;
		private System.Windows.Forms.DataGridView dgvExaminedPaths;
		private System.Windows.Forms.TableLayoutPanel tlpResult;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ProgressBar pbProgress;
	}
}