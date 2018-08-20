using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using System.Globalization;

namespace HostEdit {
	public partial class Form_sell : Form {
		public Form_sell() {
			InitializeComponent();
		}

		String pingdata = null;
		String pingtype = null;
		//private int counter;

		setting fsetting = new setting();
		CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);

		public Form_sell(string Datatype,string DataFromForm1) {
			InitializeComponent();
			
			
			pingtype = Datatype;
			pingdata = DataFromForm1;
		}


		private void Form_sell_Load(object sender, EventArgs e) {
			//載入語言
			this.ci = new CultureInfo(Global.LanguageCode);
			Thread.CurrentThread.CurrentCulture = this.ci;
			Thread.CurrentThread.CurrentUICulture = this.ci;


			this.Text = pingtype + " " + pingdata + " " + fsetting.Initializer("Other","Inconnection");

			this.richTextBox1.Text = pingtype + " " + pingdata + " " + fsetting.Initializer("Other","Inconnection") +"...\r\n";

			Endbuttonsell.Text = fsetting.Initializer("Other","Endbuttonsell");

		}

              private void backgroundWorker1_DoWork(object sender,DoWorkEventArgs e){


                            Process p = new Process();

				p.StartInfo.FileName = "cmd.exe";           //設定程序名

				//p.StartInfo.Arguments = "/c ";
                            p.StartInfo.UseShellExecute = false;

                            p.StartInfo.RedirectStandardError = true;

                            p.StartInfo.RedirectStandardInput = true;

                            p.StartInfo.RedirectStandardOutput = true;

                            p.StartInfo.CreateNoWindow = true;

                            p.Start();   //啟動

                            p.BeginOutputReadLine();  

                            p.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);  

				p.StandardInput.WriteLine(pingtype + "     " + pingdata);

                            p.StandardInput.WriteLine("exit");

                           // string str = p.StandardOutput.ReadToEnd();

                            

                            p.WaitForExit();

				p.Close();

				p.Dispose();


		}

              private void process_OutputDataReceived(object sender,DataReceivedEventArgs e)
              {
                     if (!string.IsNullOrEmpty(e.Data))
                            ReportProgress(e.Data + Environment.NewLine);
              }

              delegate void bar_up_msg(string text);
              private void ReportProgress(string text) {

                     if (this.InvokeRequired){
                            bar_up_msg d = new bar_up_msg(ReportProgress);
                            this.Invoke(d,text);

                     } else {

                            this.richTextBox1.Text+= text;
                     }
              }



              private void button1_Click(object sender, EventArgs e) {
			this.Close();
		}

              private void backgroundWorker1_RunWorkerCompleted(object sender,RunWorkerCompletedEventArgs e) {
                     timer1.Enabled = false;
                     Endbuttonsell.Enabled = true;
              }

              private void timer1_Tick(object sender,EventArgs e)
              {
                     if (this.backgroundWorker1.IsBusy != true)
                     {
                            this.backgroundWorker1.RunWorkerAsync();
                     }
              }
       }
}
