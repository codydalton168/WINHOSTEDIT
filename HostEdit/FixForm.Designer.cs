namespace HostEdit
{
       partial class FixForm
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

              #region Windows Form Designer generated code

              /// <summary>
              /// Required method for Designer support - do not modify
              /// the contents of this method with the code editor.
              /// </summary>
              private void InitializeComponent()
              {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FixForm));
			this.button_ok = new System.Windows.Forms.Button();
			this.button_exit = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.BranchCachelabel = new System.Windows.Forms.Label();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.progressBar_label = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.checkBox11 = new System.Windows.Forms.CheckBox();
			this.checkBox10 = new System.Windows.Forms.CheckBox();
			this.checkBox9 = new System.Windows.Forms.CheckBox();
			this.button_selectall = new System.Windows.Forms.Button();
			this.button_antielection = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_ok
			// 
			this.button_ok.AutoSize = true;
			this.button_ok.Location = new System.Drawing.Point(280, 302);
			this.button_ok.Name = "button_ok";
			this.button_ok.Size = new System.Drawing.Size(75, 23);
			this.button_ok.TabIndex = 0;
			this.button_ok.Text = "確定";
			this.button_ok.UseVisualStyleBackColor = true;
			this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
			// 
			// button_exit
			// 
			this.button_exit.AutoSize = true;
			this.button_exit.Location = new System.Drawing.Point(361, 302);
			this.button_exit.Name = "button_exit";
			this.button_exit.Size = new System.Drawing.Size(75, 23);
			this.button_exit.TabIndex = 1;
			this.button_exit.Text = "取消";
			this.button_exit.UseVisualStyleBackColor = true;
			this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(11, 10);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(170, 16);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "還原 Windows 防火牆預設值";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(11, 35);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(142, 16);
			this.checkBox2.TabIndex = 3;
			this.checkBox2.Text = "還原網路TCP/IP預設值";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(11, 58);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(147, 16);
			this.checkBox3.TabIndex = 4;
			this.checkBox3.Text = "還原BranchCache預設值";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// BranchCachelabel
			// 
			this.BranchCachelabel.ForeColor = System.Drawing.Color.Gray;
			this.BranchCachelabel.Location = new System.Drawing.Point(28, 77);
			this.BranchCachelabel.Name = "BranchCachelabel";
			this.BranchCachelabel.Size = new System.Drawing.Size(348, 28);
			this.BranchCachelabel.TabIndex = 5;
			this.BranchCachelabel.Text = "BranchCache(TM) 的設計目的是降低 WAN 連結使用量，並為從遠端位置伺服器中存取內容的分公司工作者改善應用程式回應。";
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(11, 113);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(126, 16);
			this.checkBox4.TabIndex = 6;
			this.checkBox4.Text = "還原網路 IPV4 元件";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(11, 135);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(126, 16);
			this.checkBox5.TabIndex = 7;
			this.checkBox5.Text = "還原網路 IPV6 元件";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// checkBox6
			// 
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new System.Drawing.Point(11, 157);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(211, 16);
			this.checkBox6.TabIndex = 8;
			this.checkBox6.Text = "還原 DHCP Client 預設服務自動啟用";
			this.checkBox6.UseVisualStyleBackColor = true;
			// 
			// progressBar_label
			// 
			this.progressBar_label.AutoSize = true;
			this.progressBar_label.Location = new System.Drawing.Point(13, 260);
			this.progressBar_label.Name = "progressBar_label";
			this.progressBar_label.Size = new System.Drawing.Size(33, 12);
			this.progressBar_label.TabIndex = 10;
			this.progressBar_label.Text = "label2";
			this.progressBar_label.Visible = false;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(15, 277);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(421, 16);
			this.progressBar1.Step = 1;
			this.progressBar1.TabIndex = 11;
			this.progressBar1.Visible = false;
			// 
			// checkBox7
			// 
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new System.Drawing.Point(11, 180);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(127, 16);
			this.checkBox7.TabIndex = 12;
			this.checkBox7.Text = "還原WinSock預設值";
			this.checkBox7.UseVisualStyleBackColor = true;
			// 
			// checkBox8
			// 
			this.checkBox8.AutoSize = true;
			this.checkBox8.Location = new System.Drawing.Point(11, 203);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(123, 16);
			this.checkBox8.TabIndex = 13;
			this.checkBox8.Text = "還原 Host 預設屬性";
			this.checkBox8.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.AutoScrollMargin = new System.Drawing.Size(6, 10);
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.checkBox11);
			this.panel1.Controls.Add(this.checkBox10);
			this.panel1.Controls.Add(this.checkBox9);
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.checkBox8);
			this.panel1.Controls.Add(this.checkBox2);
			this.panel1.Controls.Add(this.checkBox7);
			this.panel1.Controls.Add(this.checkBox3);
			this.panel1.Controls.Add(this.BranchCachelabel);
			this.panel1.Controls.Add(this.checkBox4);
			this.panel1.Controls.Add(this.checkBox6);
			this.panel1.Controls.Add(this.checkBox5);
			this.panel1.Location = new System.Drawing.Point(15, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(421, 232);
			this.panel1.TabIndex = 14;
			// 
			// checkBox11
			// 
			this.checkBox11.AutoSize = true;
			this.checkBox11.Location = new System.Drawing.Point(11, 267);
			this.checkBox11.Name = "checkBox11";
			this.checkBox11.Size = new System.Drawing.Size(182, 16);
			this.checkBox11.TabIndex = 16;
			this.checkBox11.Text = "還原 Windows Update 預設屬性";
			this.checkBox11.UseVisualStyleBackColor = true;
			// 
			// checkBox10
			// 
			this.checkBox10.AutoSize = true;
			this.checkBox10.Location = new System.Drawing.Point(11, 246);
			this.checkBox10.Name = "checkBox10";
			this.checkBox10.Size = new System.Drawing.Size(130, 16);
			this.checkBox10.TabIndex = 15;
			this.checkBox10.Text = "還原 Proxy 預設屬性";
			this.checkBox10.UseVisualStyleBackColor = true;
			// 
			// checkBox9
			// 
			this.checkBox9.AutoSize = true;
			this.checkBox9.Location = new System.Drawing.Point(11, 225);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new System.Drawing.Size(100, 16);
			this.checkBox9.TabIndex = 14;
			this.checkBox9.Text = "還原 ARP 快取";
			this.checkBox9.UseVisualStyleBackColor = true;
			// 
			// button_selectall
			// 
			this.button_selectall.AutoSize = true;
			this.button_selectall.Location = new System.Drawing.Point(284, 247);
			this.button_selectall.Name = "button_selectall";
			this.button_selectall.Size = new System.Drawing.Size(75, 23);
			this.button_selectall.TabIndex = 15;
			this.button_selectall.Text = "全選";
			this.button_selectall.UseVisualStyleBackColor = true;
			this.button_selectall.Click += new System.EventHandler(this.button_selectall_Click);
			// 
			// button_antielection
			// 
			this.button_antielection.AutoSize = true;
			this.button_antielection.Location = new System.Drawing.Point(361, 247);
			this.button_antielection.Name = "button_antielection";
			this.button_antielection.Size = new System.Drawing.Size(75, 23);
			this.button_antielection.TabIndex = 16;
			this.button_antielection.Text = "反選";
			this.button_antielection.UseVisualStyleBackColor = true;
			this.button_antielection.Click += new System.EventHandler(this.button_antielection_Click);
			// 
			// FixForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(454, 334);
			this.Controls.Add(this.button_antielection);
			this.Controls.Add(this.button_selectall);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.progressBar_label);
			this.Controls.Add(this.button_exit);
			this.Controls.Add(this.button_ok);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FixForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "一鍵還原預設值";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FixForm_FormClosing);
			this.Load += new System.EventHandler(this.FixForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

              }

              #endregion

              private System.Windows.Forms.Button button_ok;
              private System.Windows.Forms.Button button_exit;
              private System.Windows.Forms.CheckBox checkBox1;
              private System.Windows.Forms.CheckBox checkBox2;
              private System.Windows.Forms.CheckBox checkBox3;
              private System.Windows.Forms.Label BranchCachelabel;
              private System.Windows.Forms.CheckBox checkBox4;
              private System.Windows.Forms.CheckBox checkBox5;
              private System.Windows.Forms.CheckBox checkBox6;
              private System.ComponentModel.BackgroundWorker backgroundWorker1;
              protected internal System.Windows.Forms.Label progressBar_label;
              private System.Windows.Forms.ProgressBar progressBar1;
              private System.Windows.Forms.CheckBox checkBox7;
              private System.Windows.Forms.CheckBox checkBox8;
              private System.Windows.Forms.CheckBox checkBox9;
              private System.Windows.Forms.CheckBox checkBox11;
              private System.Windows.Forms.CheckBox checkBox10;
              private System.Windows.Forms.Button button_selectall;
              private System.Windows.Forms.Button button_antielection;
              public System.Windows.Forms.Panel panel1;
       }
}