namespace HostEdit {
       partial class AboutBox {
              /// <summary>
              /// 設計工具所需的變數。
              /// </summary>
              private System.ComponentModel.IContainer components = null;

              /// <summary>
              /// 清除任何使用中的資源。
              /// </summary>
              protected override void Dispose(bool disposing) {
                     if(disposing && (components != null)) {
                            components.Dispose();
                     }
                     base.Dispose(disposing);
              }

              #region Windows Form 設計工具產生的程式碼

              /// <summary>
              /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
              /// 修改這個方法的內容。
              /// </summary>
              private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
			this.okButton = new System.Windows.Forms.Button();
			this.textBoxDescription = new System.Windows.Forms.RichTextBox();
			this.labelProductName = new System.Windows.Forms.Label();
			this.labelVersion = new System.Windows.Forms.Label();
			this.labelCopyright = new System.Windows.Forms.Label();
			this.labelCompanyName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.Location = new System.Drawing.Point(333, 325);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 21);
			this.okButton.TabIndex = 24;
			this.okButton.Text = "確定(&O)";
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxDescription.DetectUrls = false;
			this.textBoxDescription.Location = new System.Drawing.Point(17, 199);
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.Size = new System.Drawing.Size(391, 110);
			this.textBoxDescription.TabIndex = 25;
			this.textBoxDescription.Text = "";
			// 
			// labelProductName
			// 
			this.labelProductName.AutoSize = true;
			this.labelProductName.Location = new System.Drawing.Point(15, 22);
			this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.labelProductName.MaximumSize = new System.Drawing.Size(0, 16);
			this.labelProductName.Name = "labelProductName";
			this.labelProductName.Size = new System.Drawing.Size(53, 12);
			this.labelProductName.TabIndex = 26;
			this.labelProductName.Text = "產品名稱";
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new System.Drawing.Point(95, 22);
			this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.labelVersion.MaximumSize = new System.Drawing.Size(0, 16);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(29, 12);
			this.labelVersion.TabIndex = 27;
			this.labelVersion.Text = "版本";
			// 
			// labelCopyright
			// 
			this.labelCopyright.AutoSize = true;
			this.labelCopyright.Location = new System.Drawing.Point(15, 75);
			this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 16);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new System.Drawing.Size(41, 12);
			this.labelCopyright.TabIndex = 28;
			this.labelCopyright.Text = "著作權";
			// 
			// labelCompanyName
			// 
			this.labelCompanyName.AutoSize = true;
			this.labelCompanyName.Location = new System.Drawing.Point(15, 48);
			this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 16);
			this.labelCompanyName.Name = "labelCompanyName";
			this.labelCompanyName.Size = new System.Drawing.Size(53, 12);
			this.labelCompanyName.TabIndex = 29;
			this.labelCompanyName.Text = "公司名稱";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 106);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(391, 23);
			this.label1.TabIndex = 30;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(17, 133);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(389, 23);
			this.label2.TabIndex = 31;
			this.label2.Text = "label2";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 159);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 12);
			this.label3.TabIndex = 32;
			this.label3.Text = "label3";
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// AboutBox
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 357);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelCompanyName);
			this.Controls.Add(this.labelCopyright);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.labelProductName);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox";
			this.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AboutBox";
			this.TopMost = true;
			this.Activated += new System.EventHandler(this.AboutBox_Activated);
			this.Load += new System.EventHandler(this.AboutBox_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

              }

              #endregion
              private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.RichTextBox textBoxDescription;
		private System.Windows.Forms.Label labelProductName;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label labelCopyright;
		private System.Windows.Forms.Label labelCompanyName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}
