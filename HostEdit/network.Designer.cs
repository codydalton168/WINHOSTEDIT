namespace HostEdit {
	partial class network {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(network));
			this.buttonsave = new System.Windows.Forms.Button();
			this.buttonexit = new System.Windows.Forms.Button();
			this.ComboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtIP = new System.Windows.Forms.TextBox();
			this.txtSubmask = new System.Windows.Forms.TextBox();
			this.txtGateway = new System.Windows.Forms.TextBox();
			this.txtDNS1 = new System.Windows.Forms.TextBox();
			this.txtDNS2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.auto_button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonsave
			// 
			this.buttonsave.AutoSize = true;
			this.buttonsave.Enabled = false;
			this.buttonsave.Location = new System.Drawing.Point(231, 292);
			this.buttonsave.Name = "buttonsave";
			this.buttonsave.Size = new System.Drawing.Size(75, 23);
			this.buttonsave.TabIndex = 0;
			this.buttonsave.Text = "編輯修改";
			this.buttonsave.UseVisualStyleBackColor = true;
			this.buttonsave.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonexit
			// 
			this.buttonexit.AutoSize = true;
			this.buttonexit.Location = new System.Drawing.Point(312, 292);
			this.buttonexit.Name = "buttonexit";
			this.buttonexit.Size = new System.Drawing.Size(75, 23);
			this.buttonexit.TabIndex = 1;
			this.buttonexit.Text = "關閉";
			this.buttonexit.UseVisualStyleBackColor = true;
			this.buttonexit.Click += new System.EventHandler(this.button2_Click);
			// 
			// ComboBox1
			// 
			this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox1.FormattingEnabled = true;
			this.ComboBox1.Location = new System.Drawing.Point(111, 12);
			this.ComboBox1.Name = "ComboBox1";
			this.ComboBox1.Size = new System.Drawing.Size(264, 20);
			this.ComboBox1.TabIndex = 2;
			this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
			this.ComboBox1.Click += new System.EventHandler(this.editclicksites);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "網路卡：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "MAC：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(109, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "...";
			// 
			// txtIP
			// 
			this.txtIP.Location = new System.Drawing.Point(111, 128);
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(264, 22);
			this.txtIP.TabIndex = 6;
			this.txtIP.Click += new System.EventHandler(this.editclicksites);
			// 
			// txtSubmask
			// 
			this.txtSubmask.Location = new System.Drawing.Point(111, 160);
			this.txtSubmask.Name = "txtSubmask";
			this.txtSubmask.Size = new System.Drawing.Size(264, 22);
			this.txtSubmask.TabIndex = 7;
			this.txtSubmask.Click += new System.EventHandler(this.editclicksites);
			// 
			// txtGateway
			// 
			this.txtGateway.Location = new System.Drawing.Point(111, 189);
			this.txtGateway.Name = "txtGateway";
			this.txtGateway.Size = new System.Drawing.Size(264, 22);
			this.txtGateway.TabIndex = 8;
			this.txtGateway.Click += new System.EventHandler(this.editclicksites);
			// 
			// txtDNS1
			// 
			this.txtDNS1.Location = new System.Drawing.Point(111, 219);
			this.txtDNS1.Name = "txtDNS1";
			this.txtDNS1.Size = new System.Drawing.Size(264, 22);
			this.txtDNS1.TabIndex = 9;
			this.txtDNS1.Click += new System.EventHandler(this.editclicksites);
			// 
			// txtDNS2
			// 
			this.txtDNS2.Location = new System.Drawing.Point(111, 249);
			this.txtDNS2.Name = "txtDNS2";
			this.txtDNS2.Size = new System.Drawing.Size(264, 22);
			this.txtDNS2.TabIndex = 10;
			this.txtDNS2.Click += new System.EventHandler(this.editclicksites);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(10, 78);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 12);
			this.label4.TabIndex = 11;
			this.label4.Text = "名稱：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(109, 78);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 12);
			this.label5.TabIndex = 12;
			this.label5.Text = "...";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(10, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(90, 12);
			this.label6.TabIndex = 13;
			this.label6.Text = "編號：";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(109, 104);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(17, 12);
			this.label7.TabIndex = 14;
			this.label7.Text = "....";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(10, 133);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(90, 12);
			this.label8.TabIndex = 15;
			this.label8.Text = "IP位址：";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(10, 165);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(90, 12);
			this.label9.TabIndex = 16;
			this.label9.Text = "網路遮罩：";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(10, 195);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(90, 12);
			this.label10.TabIndex = 17;
			this.label10.Text = "預設閘道：";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(10, 224);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(90, 12);
			this.label11.TabIndex = 18;
			this.label11.Text = "慣用DNS：";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(10, 254);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(89, 12);
			this.label12.TabIndex = 19;
			this.label12.Text = "其他DNS：";
			this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// auto_button
			// 
			this.auto_button.AutoSize = true;
			this.auto_button.Location = new System.Drawing.Point(10, 292);
			this.auto_button.Name = "auto_button";
			this.auto_button.Size = new System.Drawing.Size(77, 23);
			this.auto_button.TabIndex = 20;
			this.auto_button.Text = "自動取得 IP";
			this.auto_button.UseVisualStyleBackColor = true;
			this.auto_button.Click += new System.EventHandler(this.auto_button_Click);
			// 
			// network
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CausesValidation = false;
			this.ClientSize = new System.Drawing.Size(399, 329);
			this.Controls.Add(this.auto_button);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDNS2);
			this.Controls.Add(this.txtDNS1);
			this.Controls.Add(this.txtGateway);
			this.Controls.Add(this.txtSubmask);
			this.Controls.Add(this.txtIP);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ComboBox1);
			this.Controls.Add(this.buttonexit);
			this.Controls.Add(this.buttonsave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "network";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "網路屬性";
			this.Load += new System.EventHandler(this.network_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonsave;
		private System.Windows.Forms.Button buttonexit;
		private System.Windows.Forms.ComboBox ComboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.TextBox txtSubmask;
		private System.Windows.Forms.TextBox txtGateway;
		private System.Windows.Forms.TextBox txtDNS1;
		private System.Windows.Forms.TextBox txtDNS2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button auto_button;
	}
}