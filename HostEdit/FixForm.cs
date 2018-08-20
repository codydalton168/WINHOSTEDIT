using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace HostEdit
{
       public partial class FixForm:Form
       {
              public FixForm(){
                     InitializeComponent();
              }

              int counts = 0;
              int tocount = 0;
              bool ifcheckloading = false;
		setting fsetting = new setting();

		CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);

		//https://www.speedguide.net/articles/windows-7-vista-2008-tweaks-2574rn

		private void button_exit_Click(object sender,EventArgs e){
                     Form1 lForm1 = (Form1)this.Owner;
                     lForm1.Show();
                     this.Close();
              }


              private void button_ok_Click(object sender,EventArgs e)  {


                     var checkedBoxes = panel1.Controls.OfType<CheckBox>().Count(c => c.Checked);

                     if (checkedBoxes < 1){

                            MessageBox.Show(fsetting.Initializer("fix","NotselectedMessage"),fsetting.Initializer("Other","Information"),MessageBoxButtons.OK,MessageBoxIcon.Question);

                     } else {
				


					ifcheckloading = true;

                                   counts = checkedBoxes;


                                   if (this.backgroundWorker1.IsBusy != true){
                                          this.Cursor = Cursors.WaitCursor;
                                          progressBar_label.Visible = true;
                                          progressBar1.Visible = true;
                                          checkBox1.Enabled = false;
                                          checkBox2.Enabled = false;
                                          checkBox3.Enabled = false;
                                          checkBox4.Enabled = false;
                                          checkBox5.Enabled = false;
                                          checkBox6.Enabled = false;
                                          checkBox7.Enabled = false;
                                          checkBox8.Enabled = false;
                                          checkBox9.Enabled = false;
                                          checkBox10.Enabled = false;
                                          checkBox11.Enabled = false;

                                          button_ok.Enabled = false;
                                          button_exit.Enabled = false;
                                          button_antielection.Visible = false;
                                          button_selectall.Visible = false;

                                          this.backgroundWorker1.RunWorkerAsync();
                                   }

                     }

              }


              private void backgroundWorker1_DoWork(object sender,DoWorkEventArgs e){


                                   System.Diagnostics.Process p = new System.Diagnostics.Process();
                                   p.StartInfo.FileName = "cmd.exe";
                                   p.StartInfo.UseShellExecute = false;
                                   p.StartInfo.RedirectStandardInput = true;
                                   p.StartInfo.RedirectStandardOutput = true;
                                   p.StartInfo.RedirectStandardError = true;
                                   p.StartInfo.CreateNoWindow = true; //不跳出cmd視窗

                                   p.Start();

                                   if (checkBox1.Checked == true){

                                          ReportProgress(1,fsetting.Initializer("fix","ReadyMessage1"));
                                          p.StandardInput.WriteLine("netsh advfirewall reset");             
                                          System.Threading.Thread.Sleep(1000);

                                   }

                                   if (checkBox2.Checked == true) {

                                           ReportProgress(1,fsetting.Initializer("fix","ReadyMessage2"));
                                          p.StandardInput.WriteLine("netsh interface ip reset");     
                                          System.Threading.Thread.Sleep(1000);

                                    }

                                   if (checkBox3.Checked == true){


                                          ReportProgress(1,fsetting.Initializer("fix","ReadyMessage3"));
                                          p.StandardInput.WriteLine("netsh branchcache reset"); 
                                          System.Threading.Thread.Sleep(1000);

                                   }

                                   if (checkBox4.Checked == true){


                                          ReportProgress(1,fsetting.Initializer("fix","ReadyMessage4"));
                                          p.StandardInput.WriteLine("netsh int ip reset"); 
                                          System.Threading.Thread.Sleep(1000);

                                    }

                                   if (checkBox5.Checked == true){


                                          ReportProgress(1,fsetting.Initializer("fix","ReadyMessage5"));
                                          p.StandardInput.WriteLine("netsh int ipv6 reset"); 

                                          System.Threading.Thread.Sleep(1000);

                                   }

                                   if (checkBox6.Checked == true) {

                                          ReportProgress(1,fsetting.Initializer("fix","ReadyMessage6"));

                                          RegistryKey regdhcpKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\services\\Dhcp",true);
                                          regdhcpKey.SetValue("Start",2,RegistryValueKind.DWord);
                                          regdhcpKey.Close();


                                          System.Threading.Thread.Sleep(1000);

                                   }

                                   if (checkBox7.Checked == true) {

                                          ReportProgress(1,fsetting.Initializer("fix","ReadyMessage7"));
                                          p.StandardInput.WriteLine("netsh winsock reset"); 
                                          System.Threading.Thread.Sleep(1000);
                                   }

                                   if (checkBox8.Checked == true){

                                          ReportProgress(1,fsetting.Initializer("fix","ReadyMessage8"));


                                          string ProductName = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion",false).GetValue("ProductName");


					       StreamWriter sw = new StreamWriter(Environment.SystemDirectory + "\\drivers\\etc\\hosts", false, Encoding.UTF8);
					       sw.Flush();

                                          if (ProductName.Contains("Windows 7")){

					                            sw.WriteLine("# Copyright (c) 1993-2009 Microsoft Corp.");
					                            sw.WriteLine("#");
					                            sw.WriteLine("# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.");
					                            sw.WriteLine("#");
					                            sw.WriteLine("# This file contains the mappings of IP addresses to host names. Each");
					                            sw.WriteLine("# entry should be kept on an individual line. The IP address should");
					                            sw.WriteLine("# be placed in the first column followed by the corresponding host name.");
					                            sw.WriteLine("# The IP address and the host name should be separated by at least one");
					                            sw.WriteLine("# space.");
					                            sw.WriteLine("#");
					                            sw.WriteLine("# Additionally, comments (such as these) may be inserted on individual");
					                            sw.WriteLine("# lines or following the machine name denoted by a '#' symbol.");
					                            sw.WriteLine("#");
					                            sw.WriteLine("# For example:");
					                            sw.WriteLine("#");
					                            sw.WriteLine("#      102.54.94.97     rhino.acme.com          # source server");
					                            sw.WriteLine("#       38.25.63.10     x.acme.com              # x client host");
					                            sw.WriteLine("# localhost name resolution is handled within DNS itself.");
					                            sw.WriteLine("#	127.0.0.1       localhost");
					                            sw.WriteLine("#	::1             localhost");
					                            sw.WriteLine("");

                                          } else if (ProductName.Contains("Windows 8") || ProductName.Contains("Windows 10")){

                                                               sw.WriteLine("#Copyright(c) 1993 - 2006 Microsoft Corp.");
                                                               sw.WriteLine("#");
                                                               sw.WriteLine("#This is a sample HOSTS file used by Microsoft TCP/ IP for Windows.");
                                                               sw.WriteLine("#");
                                                               sw.WriteLine("#This file contains the mappings of IP addresses to host names.Each");
                                                               sw.WriteLine("#entry should be kept on an individual line.The IP address should");
                                                               sw.WriteLine("#be placed in the first column followed by the corresponding host name.");
                                                               sw.WriteLine("#The IP address and the host name should be separated by at least one");
                                                               sw.WriteLine("#space.");
                                                               sw.WriteLine("#Additionally, comments(such as these) may be inserted on individual");
                                                               sw.WriteLine("# lines or following the machine name denoted by a '#' symbol.");
                                                               sw.WriteLine("#");
                                                               sw.WriteLine("#For example:");
                                                               sw.WriteLine("#");
                                                               sw.WriteLine("#102.54.94.97     rhino.acme.com");
                                                               sw.WriteLine("#38.25.63.10     x.acme.com");
                                                               sw.WriteLine("#localhost name resolution is handle within DNS itself.");
                                                               sw.WriteLine("#127.0.0.1       localhost");
                                                               sw.WriteLine("#::1             localhost");


                                          }
					       sw.WriteLine("127.0.0.1 localhost");
					       sw.Close();
					       sw.Dispose();

                                          System.Threading.Thread.Sleep(1000);
                                   }

                                   if (checkBox9.Checked == true){

                                          ReportProgress(1,fsetting.Initializer("fix","ReadyMessage9"));

                                          p.StandardInput.WriteLine("netsh interface ip delete arpcache"); 

                                          System.Threading.Thread.Sleep(1000);
                                   }

                                   if (checkBox10.Checked == true){

                                          ReportProgress(1,fsetting.Initializer("fix","ReadyMessage10"));
                                          RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings",true);
                                          regKey.SetValue("ProxyEnable",0,RegistryValueKind.DWord);
                                          regKey.SetValue("ProxyServer","",RegistryValueKind.String);
                                          regKey.Close();

                            
                   
                                          p.StandardInput.WriteLine("netsh winhttp reset proxy"); 

                                          System.Threading.Thread.Sleep(1000);
                                   }

                                   if (checkBox11.Checked == true){

                                          ReportProgress(1,fsetting.Initializer("fix","ReadyMessage11"));


                                          RegistryKey regwuauservKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\services\\wuauserv",true);
                                          regwuauservKey.SetValue("Start",2,RegistryValueKind.DWord);
                                          regwuauservKey.Close();

      
                                          p.StandardInput.WriteLine("net stop bits");
                                          p.StandardInput.WriteLine("net stop wuauserv");
                                          p.StandardInput.WriteLine("net stop appidsvc");
                                          p.StandardInput.WriteLine("net stop cryptsvc");

                                          p.StandardInput.WriteLine("Del  %ALLUSERSPROFILE%\\Application Data\\Microsoft\\Network\\Downloader\\qmgr*.dat");

                                          p.StandardInput.WriteLine("Ren %systemroot%\\SoftwareDistribution SoftwareDistribution.bak");
                                          p.StandardInput.WriteLine("Ren %systemroot%\\system32\\catroot2 catroot2.bak");

                                          p.StandardInput.WriteLine("sc.exe sdset bits D:(A; ; CCLCSWRPWPDTLOCRRC; ; ; SY)(A; ; CCDCLCSWRPWPDTLOCRSDRCWDWO; ; ; BA)(A; ; CCLCSWLOCRRC; ; ; AU)(A; ; CCLCSWRPWPDTLOCRRC; ; ; PU)");


                                          p.StandardInput.WriteLine("sc.exe sdset wuauserv D:(A; ; CCLCSWRPWPDTLOCRRC; ; ; SY)(A; ; CCDCLCSWRPWPDTLOCRSDRCWDWO; ; ; BA)(A; ; CCLCSWLOCRRC; ; ; AU)(A; ; CCLCSWRPWPDTLOCRRC; ; ; PU)");

                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s atl.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s urlmon.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s mshtml.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s shdocvw.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s browseui.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s jscript.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s vbscript.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s scrrun.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s msxml.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s msxml3.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s msxml6.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s actxprxy.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s softpub.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s wintrust.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s dssenh.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s rsaenh.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s gpkcsp.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s sccbase.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s slbcsp.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s cryptdlg.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s oleaut32.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s ole32.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s shell32.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s initpki.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s wuapi.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s wuaueng.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s wuaueng1.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s wucltui.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s wups.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s wups2.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s wuweb.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s qmgr.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s qmgrprxy.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s wucltux.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s muweb.dll");
                                          p.StandardInput.WriteLine("%windir%\\system32\\regsvr32.exe /s wuwebv.dll");


                                          p.StandardInput.WriteLine("netsh winsock reset");
                                          p.StandardInput.WriteLine("netsh winhttp reset proxy");

                                          p.StandardInput.WriteLine("net start bits");
                                          p.StandardInput.WriteLine("net start wuauserv");
                                          p.StandardInput.WriteLine("net start appidsvc");
                                          p.StandardInput.WriteLine("net start cryptsvc");



                                          RegistryKey regAutoUpdateKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate\\Auto Update",true);
                                          regAutoUpdateKey.SetValue("ElevateNonAdmins",1,RegistryValueKind.DWord);
                                          regAutoUpdateKey.SetValue("IncludeRecommendedUpdates",1,RegistryValueKind.DWord);
                                          regAutoUpdateKey.SetValue("ScheduledInstallDay",0,RegistryValueKind.DWord);
                                          regAutoUpdateKey.SetValue("ScheduledInstallTime",0,RegistryValueKind.DWord);
                                          regAutoUpdateKey.SetValue("AUOptions",4,RegistryValueKind.DWord);
                                          regAutoUpdateKey.Close();


                                          System.Threading.Thread.Sleep(1000);
                                   }

                                   p.StandardInput.WriteLine("ipconfig / release");
                                   p.StandardInput.WriteLine("ipconfig / renew");
                                   p.StandardInput.WriteLine("ipconfig / flushdns");
                                   p.StandardInput.WriteLine("ipconfig / registerdns");
                                   p.StandardInput.WriteLine("netsh int tcp set heuristics disabled");
                                   p.StandardInput.WriteLine("netsh int tcp set global autotuninglevel = disabled");
                                   p.StandardInput.WriteLine("exit");
                                   p.StandardOutput.ReadToEnd();//匯出整個執行過程
                                   p.WaitForExit();
                                   p.Close();
              }

              delegate void bar_up_msg(int values,string text);
              private void ReportProgress(int values,string text) {
                            
                            if (this.InvokeRequired){
                                   bar_up_msg d = new bar_up_msg(ReportProgress);
                                   this.Invoke(d,values,text);

                            } else {

                                   tocount+= values;
                            
                                   int endcount = (tocount *100/counts) ;

                                   progressBar1.Value= endcount;

                                   progressBar_label.Text = text;
                     }
                    
                    

              }

              private void backgroundWorker1_RunWorkerCompleted(object sender,RunWorkerCompletedEventArgs e){
                     
                     tocount = 0;
                     counts = 0;
                     checkBox1.Enabled = true;
                     checkBox2.Enabled = true;
                     checkBox3.Enabled = true;
                     checkBox4.Enabled = true;
                     checkBox5.Enabled = true;
                     checkBox6.Enabled = true;
                     checkBox7.Enabled = false;
                     checkBox8.Enabled = false;
                     checkBox9.Enabled = false;
                     checkBox10.Enabled = false;
                     checkBox11.Enabled = false;

                     progressBar_label.Visible = false;
                     progressBar1.Visible = false;

                     button_ok.Enabled = true;
                     button_exit.Enabled = true;

                     ifcheckloading = false;
                     //backgroundWorker1.CancelAsync();

                     this.Cursor = Cursors.Default;

			this.backgroundWorker1.Dispose();

			if (MessageBox.Show(fsetting.Initializer("fix","RestorecompleteMessage"),fsetting.Initializer("Other","Information"),MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK) {
					System.GC.Collect();
					Process.Start("shutdown.exe","-f -r -t 0");
                                   System.Environment.Exit(0);
                     } else {
                                   this.Close();
                     }



              }

              private void FixForm_FormClosing(object sender,FormClosingEventArgs e) {


                     if (ifcheckloading == true) {

                            if (MessageBox.Show(fsetting.Initializer("fix","RestoreCloseMessage"),fsetting.Initializer("Other","Information"),MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK) {
                                   e.Cancel = false;
					Form1 lForm1 = (Form1)this.Owner;
					lForm1.Show();

				} else{

                                   e.Cancel = true;

                            }




			}  else {


				Form1 lForm1 = (Form1)this.Owner;
				lForm1.Show();
			}


              }

   
              private void button_selectall_Click(object sender,EventArgs e){

                     foreach (CheckBox control in panel1.Controls.OfType<CheckBox>()){
                            control.Checked = true;
                     }


              }

              private void button_antielection_Click(object sender,EventArgs e){

                     foreach(CheckBox control in panel1.Controls.OfType<CheckBox>()) {
                            control.Checked = false;                          
                     }
              }

		private void FixForm_Load(object sender,EventArgs e){

			this.ci = new CultureInfo(Global.LanguageCode);
			Thread.CurrentThread.CurrentCulture = this.ci;
			Thread.CurrentThread.CurrentUICulture = this.ci;

			ShowUILang();
		}

		private void ShowUILang() {

						this.Text = fsetting.Initializer("fix","title");
						checkBox1.Text = fsetting.Initializer("fix","checkBox1");
						checkBox2.Text = fsetting.Initializer("fix","checkBox2");
						checkBox3.Text = fsetting.Initializer("fix","checkBox3");
						checkBox4.Text = fsetting.Initializer("fix","checkBox4");
						checkBox5.Text = fsetting.Initializer("fix","checkBox5");
						checkBox6.Text = fsetting.Initializer("fix","checkBox6");
						checkBox7.Text = fsetting.Initializer("fix","checkBox7");
						checkBox8.Text = fsetting.Initializer("fix","checkBox8");
						checkBox9.Text = fsetting.Initializer("fix","checkBox9");
						checkBox10 .Text = fsetting.Initializer("fix","checkBox10");
						checkBox11.Text = fsetting.Initializer("fix","checkBox11");



						BranchCachelabel.Text = fsetting.Initializer("fix","BranchCachelabel");

						button_selectall.Text = fsetting.Initializer("fix","button_selectall");
						button_antielection.Text = fsetting.Initializer("fix","button_antielection");
						button_ok.Text = fsetting.Initializer("fix","button_ok");
						button_exit.Text = fsetting.Initializer("fix","button_exit");

		}
	}
}
