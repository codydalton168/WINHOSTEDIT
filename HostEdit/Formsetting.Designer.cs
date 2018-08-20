namespace HostEdit
{
       partial class Formsetting
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formsetting));
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.buttonok = new System.Windows.Forms.Button();
			this.buttonexit = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "語言介面";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(96, 25);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(210, 20);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Click += new System.EventHandler(this.SelectedChanged);
			// 
			// buttonok
			// 
			this.buttonok.AutoSize = true;
			this.buttonok.Enabled = false;
			this.buttonok.Location = new System.Drawing.Point(316, 355);
			this.buttonok.Name = "buttonok";
			this.buttonok.Size = new System.Drawing.Size(75, 23);
			this.buttonok.TabIndex = 2;
			this.buttonok.Text = "儲存";
			this.buttonok.UseVisualStyleBackColor = true;
			this.buttonok.Click += new System.EventHandler(this.button_ok_Click);
			// 
			// buttonexit
			// 
			this.buttonexit.AutoSize = true;
			this.buttonexit.Location = new System.Drawing.Point(400, 355);
			this.buttonexit.Name = "buttonexit";
			this.buttonexit.Size = new System.Drawing.Size(75, 23);
			this.buttonexit.TabIndex = 3;
			this.buttonexit.Text = "關閉";
			this.buttonexit.UseVisualStyleBackColor = true;
			this.buttonexit.Click += new System.EventHandler(this.button_exit_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "進入執行";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(96, 63);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(170, 16);
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Text = "勾選隨者 Windows 起動執行";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.Click += new System.EventHandler(this.SelectedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 6;
			this.label3.Text = "區網撿測";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(96, 96);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(245, 16);
			this.checkBox2.TabIndex = 7;
			this.checkBox2.Text = "網路斷線將提醒顯示(提醒6次後,將不提醒)";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.Click += new System.EventHandler(this.SelectedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 12);
			this.label4.TabIndex = 8;
			this.label4.Text = "外網撿測";
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(96, 126);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(188, 16);
			this.checkBox3.TabIndex = 9;
			this.checkBox3.Text = "外網路IP如與之前IP不同將提醒";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.Click += new System.EventHandler(this.SelectedChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 36);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(111, 12);
			this.label5.TabIndex = 10;
			this.label5.Text = "新增一筆預設顯示IP";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(133, 30);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(195, 22);
			this.textBox1.TabIndex = 11;
			this.textBox1.Click += new System.EventHandler(this.SelectedChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 78);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(161, 12);
			this.label6.TabIndex = 12;
			this.label6.Text = "攔位預設顯示字型及文字大小";
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(18, 102);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(159, 20);
			this.comboBox2.TabIndex = 13;
			this.comboBox2.Click += new System.EventHandler(this.SelectedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.checkBox3);
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(15, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(460, 165);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "基本";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.comboBox3);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Controls.Add(this.comboBox2);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Location = new System.Drawing.Point(15, 188);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(460, 150);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "顯示預設值";
			// 
			// comboBox3
			// 
			this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[] {
            "9",
            "10",
            "12",
            "14",
            "16",
            "18",
            "20"});
			this.comboBox3.Location = new System.Drawing.Point(198, 102);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(51, 20);
			this.comboBox3.TabIndex = 14;
			this.comboBox3.Click += new System.EventHandler(this.SelectedChanged);
			// 
			// Formsetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(492, 388);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonexit);
			this.Controls.Add(this.buttonok);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Formsetting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "選項屬性";
			this.Load += new System.EventHandler(this.Formsetting_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

              }

              #endregion

              private System.Windows.Forms.Label label1;
              private System.Windows.Forms.ComboBox comboBox1;
              private System.Windows.Forms.Button buttonok;
              private System.Windows.Forms.Button buttonexit;
              private System.Windows.Forms.Label label2;
              private System.Windows.Forms.CheckBox checkBox1;
              private System.Windows.Forms.Label label3;
              private System.Windows.Forms.CheckBox checkBox2;
              private System.Windows.Forms.Label label4;
              private System.Windows.Forms.CheckBox checkBox3;
              private System.Windows.Forms.Label label5;
              private System.Windows.Forms.TextBox textBox1;
              private System.Windows.Forms.Label label6;
              private System.Windows.Forms.ComboBox comboBox2;
              private System.Windows.Forms.GroupBox groupBox1;
              private System.Windows.Forms.GroupBox groupBox2;
              private System.Windows.Forms.ComboBox comboBox3;
       }
}