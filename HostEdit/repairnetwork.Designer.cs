namespace HostEdit {
	partial class repairnetwork {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
                     this.components = new System.ComponentModel.Container();
                     System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(repairnetwork));
                     this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
                     this.labelX1 = new DevComponents.DotNetBar.LabelX();
                     this.pictureBox1 = new System.Windows.Forms.PictureBox();
                     this.timer1 = new System.Windows.Forms.Timer(this.components);
                     ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                     this.SuspendLayout();
                     // 
                     // progressBarX1
                     // 
                     // 
                     // 
                     // 
                     this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                     this.progressBarX1.Location = new System.Drawing.Point(94, 53);
                     this.progressBarX1.Name = "progressBarX1";
                     this.progressBarX1.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
                     this.progressBarX1.Size = new System.Drawing.Size(260, 23);
                     this.progressBarX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                     this.progressBarX1.TabIndex = 0;
                     this.progressBarX1.Text = "progressBarX1";
                     // 
                     // labelX1
                     // 
                     // 
                     // 
                     // 
                     this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                     this.labelX1.Location = new System.Drawing.Point(94, 28);
                     this.labelX1.Name = "labelX1";
                     this.labelX1.Size = new System.Drawing.Size(172, 23);
                     this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                     this.labelX1.TabIndex = 1;
                     this.labelX1.Text = "正在一鍵修復區網共享中....";
                     // 
                     // pictureBox1
                     // 
                     this.pictureBox1.Image = global::HostEdit.Properties.Resources.big_loading_gif;
                     this.pictureBox1.Location = new System.Drawing.Point(17, 18);
                     this.pictureBox1.Name = "pictureBox1";
                     this.pictureBox1.Size = new System.Drawing.Size(64, 64);
                     this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                     this.pictureBox1.TabIndex = 2;
                     this.pictureBox1.TabStop = false;
                     // 
                     // timer1
                     // 
                     this.timer1.Enabled = true;
                     this.timer1.Interval = 1000;
                     this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                     // 
                     // repairnetwork
                     // 
                     this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                     this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                     this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                     this.ClientSize = new System.Drawing.Size(370, 102);
                     this.Controls.Add(this.pictureBox1);
                     this.Controls.Add(this.labelX1);
                     this.Controls.Add(this.progressBarX1);
                     this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                     this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                     this.MaximizeBox = false;
                     this.MinimizeBox = false;
                     this.Name = "repairnetwork";
                     this.ShowInTaskbar = false;
                     this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                     this.Text = "修復狀況";
                     this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.repairnetwork_FormClosing);
                     this.Load += new System.EventHandler(this.repairnetwork_Load);
                     ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                     this.ResumeLayout(false);

		}

		#endregion

		private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
		private DevComponents.DotNetBar.LabelX labelX1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer timer1;
	}
}