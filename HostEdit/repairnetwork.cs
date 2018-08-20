using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace HostEdit {
	public partial class repairnetwork : Form {

		Form opener;

		Thread sample = null;

		setting fsetting = new setting();

		CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);

		public repairnetwork(Form parentForm) {
			InitializeComponent();
			opener = parentForm;
		}
		private void repairnetwork_Load(object sender, EventArgs e) {

			//載入語言
			this.ci = new CultureInfo(Global.LanguageCode);
			Thread.CurrentThread.CurrentCulture = this.ci;
			Thread.CurrentThread.CurrentUICulture = this.ci;

			this.Text = fsetting.Initializer("Other","Repairstatus");
			labelX1.Text = fsetting.Initializer("Other","Statusmeassage");


			sample = new Thread(new ThreadStart(ThreadFunction));
			sample.IsBackground = true;
			sample.Start();
		}

		private void ThreadFunction() {
			//throw new NotImplementedException();

			if (System.IO.File.Exists(Application.StartupPath + "\\fixshare.cmd")) {
				System.IO.File.Delete(Application.StartupPath + "\\fixshare.cmd");
			}

			byte[] okshare_data = System.Text.Encoding.Default.GetBytes(Properties.Resources.fixshare);
			System.IO.FileStream _FileStream = new System.IO.FileStream(Application.StartupPath + "\\fixshare.cmd", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			_FileStream.Write(okshare_data, 0, okshare_data.Length);
			_FileStream.Close();

			if (System.IO.File.Exists(Application.StartupPath + "\\fixshare.cmd")) {

				System.Diagnostics.Process p = new System.Diagnostics.Process();
				p.StartInfo.FileName = Application.StartupPath + "\\fixshare.cmd"; //設定程序名
				//p.StartInfo.Arguments = "-r -t 0"; 
				p.StartInfo.UseShellExecute = false; //關閉Shell的使用
				p.StartInfo.RedirectStandardInput = true; //重定向標準輸入
				p.StartInfo.RedirectStandardOutput = true; //重定向標準輸出
				p.StartInfo.RedirectStandardError = true; //重定向錯誤輸出
				p.StartInfo.CreateNoWindow = true; //設置不顯示窗口
				p.Start();
				p.WaitForExit();
				p.Close();

				System.IO.File.Delete(Application.StartupPath + "\\fixshare.cmd");
			}
			System.GC.Collect();
			sample.Interrupt();
		}

		private void timer1_Tick(object sender, EventArgs e) {

			if (!sample.IsAlive) {

				sample.Abort();
				
				timer1.Enabled = false;

				
				if (MessageBox.Show("您確定要重新開機嗎", "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK) {

					System.Diagnostics.Process p = new System.Diagnostics.Process();
					p.StartInfo.FileName = "shutdown.exe"; //設定程序名
					p.StartInfo.Arguments = "-r -t 0"; //設定程式執行參數
					p.StartInfo.UseShellExecute = false; //關閉Shell的使用
					p.StartInfo.RedirectStandardInput = true; //重定向標準輸入
					p.StartInfo.RedirectStandardOutput = true; //重定向標準輸出
					p.StartInfo.RedirectStandardError = true; //重定向錯誤輸出
					p.StartInfo.CreateNoWindow = true; //設置不顯示窗口
					p.Start();
					p.Close();
					System.GC.Collect();
					System.Environment.Exit(0);

				} else {
					this.Hide();
					opener.Show();
				}
			}
		}

              private void repairnetwork_FormClosing(object sender, FormClosingEventArgs e)
              {
                     DialogResult dr = MessageBox.Show("確定要關閉程式嗎?", "提醒", MessageBoxButtons.YesNo);
                     if (dr == DialogResult.No) {
                            e.Cancel = true;
                     } else {
                            sample.Interrupt();
                            e.Cancel = false;

                     }
              }
       }
}
