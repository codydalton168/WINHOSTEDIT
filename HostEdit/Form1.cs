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
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Reflection;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;
using System.Globalization;


namespace HostEdit {
       public partial class Form1 : Form{

		int counter = 0;

		string system32hosts = Environment.SystemDirectory + "\\drivers\\etc\\hosts";

		string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";

		private const int INTERNET_CONNECTION_MODEM = 1;
		private const int INTERNET_CONNECTION_LAN = 2;

		int startint = 0;
		int endunt = 0;

		private System.Threading.Timer timerClose;
		//檢查網卡是否斷線
		private System.Threading.Timer networkcheckup;

              private Boolean networkcheck = false;

		private Boolean Extranetcheck = false;
		//private Boolean ifautosave = false;

		private string networkcheckmsg;
		private string Extranetcheckmsg;


		public Boolean ifwindowsmax = false;


		setting fsetting  = new setting();

		CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);

		[DllImport("wininet.dll",EntryPoint = "InternetGetConnectedState")]
		private static extern bool InternetGetConnectedState(
			ref int dwFlag,
			int dwReserved
		);




		public Form1() {
			InitializeComponent();
		}

		public Form1(string[] args) {

			InitializeComponent();

			if (args[0].ToString().Length > 0 && args[0].ToString() == "/s") {
				ifwindowsmax = true;
			}
		}





		private void Form1_Load(object sender, EventArgs e) {

			try {

				if (ifwindowsmax == true){
					this.WindowState = FormWindowState.Minimized;
					this.ShowInTaskbar = false;
				}


				//載入語言
				this.ci = new CultureInfo(Global.LanguageCode);
				Thread.CurrentThread.CurrentCulture = this.ci;
				Thread.CurrentThread.CurrentUICulture = this.ci;


				if (System.IO.File.Exists(system32hosts)) {
                                          FileInfo fi = new FileInfo(system32hosts);
                                          if(fi.Attributes.ToString().Contains("ReadOnly")) {                                  
                                                 fi.Attributes = fi.Attributes & ~FileAttributes.ReadOnly; 
                                          }

                                          if(fi.Attributes.ToString().Contains("Hidden")) {
                                                 fi.Attributes = fi.Attributes & ~FileAttributes.Hidden;
                                          }
						ifkhosts();
                            }
		

				
				//檢查 內網 IP 及 外網 IP 
				timerClose = new System.Threading.Timer(new TimerCallback(timerCall),this,1000,2000);

				if (Global.Defaultnetworkcheck == "1"){
					//檢查區網是否正常
					networkcheckup = new System.Threading.Timer(new TimerCallback(Callnetworkchup),this,1000,6000);

				}

				// 瀏覽器檢查
				ifBrowsers();


				// 語言檢查
				LanguageDoWork();


				IniFile s = new IniFile(Application.StartupPath + "\\setting.ini");

				if (s.IniReadValue("setting","DefaultFontFamily").Length > 0 && s.IniReadValue("setting","DefaultFontSize").Length > 0){
					this.dataGridView1.DefaultCellStyle.Font = new Font(s.IniReadValue("setting","DefaultFontFamily"),int.Parse(s.IniReadValue("setting","DefaultFontSize")));
					defaultshow(int.Parse(s.IniReadValue("setting","DefaultFontSize")));
				}


			} catch(Exception ex) {
                            MessageBox.Show(ex.Message);
                     }
                     
              }

		private void defaultshow(int size){

			if (size ==9){

				toolStripMenuItem5.Checked = true;
				toolStripMenuItem6.Checked = false;
				toolStripMenuItem7.Checked = false;
				toolStripMenuItem8.Checked = false;
				toolStripMenuItem9.Checked = false;
				toolStripMenuItem10.Checked = false;
				toolStripMenuItem11.Checked = false;


			} else if (size ==10){

				toolStripMenuItem5.Checked = false;
				toolStripMenuItem6.Checked = true;
				toolStripMenuItem7.Checked = false;
				toolStripMenuItem8.Checked = false;
				toolStripMenuItem9.Checked = false;
				toolStripMenuItem10.Checked = false;
				toolStripMenuItem11.Checked = false;

			} else if (size == 12){

				toolStripMenuItem5.Checked = false;
				toolStripMenuItem6.Checked = false;
				toolStripMenuItem7.Checked = true;
				toolStripMenuItem8.Checked = false;
				toolStripMenuItem9.Checked = false;
				toolStripMenuItem10.Checked = false;
				toolStripMenuItem11.Checked = false;

			} else if (size == 14){

				toolStripMenuItem5.Checked = false;
				toolStripMenuItem6.Checked = false;
				toolStripMenuItem7.Checked = false;
				toolStripMenuItem8.Checked = true;
				toolStripMenuItem9.Checked = false;
				toolStripMenuItem10.Checked = false;
				toolStripMenuItem11.Checked = false;

			} else if (size == 16){

				toolStripMenuItem5.Checked = false;
				toolStripMenuItem6.Checked = false;
				toolStripMenuItem7.Checked = false;
				toolStripMenuItem8.Checked = false;
				toolStripMenuItem9.Checked = true;
				toolStripMenuItem10.Checked = false;
				toolStripMenuItem11.Checked = false;

			} else if (size ==18){

				toolStripMenuItem5.Checked = false;
				toolStripMenuItem6.Checked = false;
				toolStripMenuItem7.Checked = false;
				toolStripMenuItem8.Checked = false;
				toolStripMenuItem9.Checked = false;
				toolStripMenuItem10.Checked = true;
				toolStripMenuItem11.Checked = false;

			} else if (size ==20){

				toolStripMenuItem5.Checked = false;
				toolStripMenuItem6.Checked = false;
				toolStripMenuItem7.Checked = false;
				toolStripMenuItem8.Checked = false;
				toolStripMenuItem9.Checked = false;
				toolStripMenuItem10.Checked = false;
				toolStripMenuItem11.Checked = true;

			}
		}

		private void LanguageDoWork(){
			//Menu
			fileMenuItem.Text = fsetting.Initializer("Menu","fileMenuItem");
			MenuItem1.Text = fsetting.Initializer("Menu","MenuItem1");
			MenuItem2.Text = fsetting.Initializer("Menu","MenuItem2");
			MenuItem3.Text = fsetting.Initializer("Menu","MenuItem3");
			MenuItem4.Text = fsetting.Initializer("Menu","MenuItem4");
			MenuItem5.Text = fsetting.Initializer("Menu","MenuItem5");
			MenuItem6.Text = fsetting.Initializer("Menu","MenuItem6");

			viewStripMenuItem.Text = fsetting.Initializer("Menu","viewStripMenuItem"); 
			viewMenuItem1.Text = fsetting.Initializer("Menu","viewMenuItem1"); 
			viewMenuItem2.Text = fsetting.Initializer("Menu","viewMenuItem2"); 
			viewMenuItem3.Text = fsetting.Initializer("Menu","viewMenuItem3"); 
			viewMenuItem4.Text = fsetting.Initializer("Menu","viewMenuItem4");

			ToolMenuItem.Text = fsetting.Initializer("Menu","ToolMenuItem");
			ToolMenuItem_setting.Text = fsetting.Initializer("Menu","ToolMenuItem_setting");
			ToolMenuItem1.Text = fsetting.Initializer("Menu","ToolMenuItem1");
			ToolMenuItem2.Text = fsetting.Initializer("Menu","ToolMenuItem2");
			ToolMenuItem3.Text = fsetting.Initializer("Menu","ToolMenuItem3");
			ToolMenuItem4.Text = fsetting.Initializer("Menu","ToolMenuItem4");
			ToolMenuItem5.Text = fsetting.Initializer("Menu","ToolMenuItem5");
			ToolMenuItem6.Text = fsetting.Initializer("Menu","ToolMenuItem6");
			ToolMenuItem7.Text = fsetting.Initializer("Menu","ToolMenuItem7");
			ToolMenuItem8.Text = fsetting.Initializer("Menu","ToolMenuItem8");
			ToolMenuItem9.Text = fsetting.Initializer("Menu","ToolMenuItem9");

			helpToolStripMenuItem.Text = fsetting.Initializer("Menu","helpToolStripMenuItem");
			helpMenuItem1.Text = fsetting.Initializer("Menu","helpMenuItem1");

			toolStripButton1.Text = fsetting.Initializer("toolStrip","toolStripButton1");
			toolStripButton5.Text = fsetting.Initializer("toolStrip","toolStripButton5");
			toolStripButton2.Text = fsetting.Initializer("toolStrip","toolStripButton2");
			toolStripButton3.Text = fsetting.Initializer("toolStrip","toolStripButton3");
			toolStripButton4.Text = fsetting.Initializer("toolStrip","toolStripButton4");
			toolStripButton6.Text = fsetting.Initializer("toolStrip","toolStripButton6");
			toolStripButton7.Text = fsetting.Initializer("toolStrip","toolStripButton7");
			toolStripButton8.Text = fsetting.Initializer("toolStrip","toolStripButton8");



			Column1.HeaderText = fsetting.Initializer("HeaderText","Column1HeaderText");
			Column3.HeaderText = fsetting.Initializer("HeaderText","Column3HeaderText");
			Column4.HeaderText = fsetting.Initializer("HeaderText","Column4HeaderText");

			toolStripTextBox1.Text = fsetting.Initializer("Other","toolStripTextBox1");
			toolStripStatusLabel1.Text = fsetting.Initializer("Other","toolStripStatusLabel1");
			toolStripStatusLabel2.Text = fsetting.Initializer("Other","toolStripStatusLabel2");


			copydominStripMenuItem.Text = fsetting.Initializer("contextMenuStrip","copydominStripMenuItem");
			copyipStripMenuItem.Text = fsetting.Initializer("contextMenuStrip","copyipStripMenuItem");

			toolStripMenuItem_moveup.Text = fsetting.Initializer("contextMenuStrip","MenuItemmoveup");
			toolStripMenuItem_movedown.Text = fsetting.Initializer("contextMenuStrip","MenuItemmovedown");

			enable_domin.Text = fsetting.Initializer("contextMenuStrip","enable_domin");
			disable_domin.Text = fsetting.Initializer("contextMenuStrip","disable_domin");
			ping_domin.Text = fsetting.Initializer("contextMenuStrip","ping_domin");
			nslookup_domin.Text = fsetting.Initializer("contextMenuStrip","nslookup_domin");




			aboutToolStripMenuItem.Text = fsetting.Initializer("contextMenuStrip","aboutToolStripMenuItem");
			toolStripMenuItem_network.Text = fsetting.Initializer("contextMenuStrip","toolStripMenuItem_network");
			toolStripMenuItem_proxy.Text = fsetting.Initializer("contextMenuStrip","toolStripMenuItem_proxy");
			openHostsfileToolStripMenuItem.Text = fsetting.Initializer("contextMenuStrip","openHostsfileToolStripMenuItem");
			openHostsdirToolStripMenuItem.Text = fsetting.Initializer("contextMenuStrip","openHostsdirToolStripMenuItem");
			LocalAreaConnection_enable.Text = fsetting.Initializer("contextMenuStrip","LocalAreaConnection_enable");
			LocalAreaConnection_disable.Text = fsetting.Initializer("contextMenuStrip","LocalAreaConnection_disable");
			show_wintoolStripMenuItem.Text = fsetting.Initializer("contextMenuStrip","show_wintoolStripMenuItem");
			toolStripMenuClearDNScache.Text = fsetting.Initializer("contextMenuStrip","toolStripMenuClearDNScache");
			toolStripMenuupdateip.Text = fsetting.Initializer("contextMenuStrip","toolStripMenuupdateip");
			toolStripMenuexit.Text = fsetting.Initializer("contextMenuStrip","toolStripMenuexit");



		}




              #region  瀏覽器檢查安裝多少

              private class Browser {
                     public string Name { get; set; }
                     public string Exe { get; set; }
                     public override string ToString(){
                            return Name;
                     }
              }
              private Dictionary<string, string> diChkData;

              private void ifBrowsers(){

                     diChkData = new Dictionary<string, string>();
                     int count = 0;

                     const string browserListKey = @"SOFTWARE\Clients\StartMenuInternet";
                     using (var clients = Registry.LocalMachine.OpenSubKey(browserListKey)) {
                            foreach (var client in clients.GetSubKeyNames()) {
                                   using (var clientKey = clients.OpenSubKey(client)) {
                                          string name = (string)clientKey.GetValue(string.Empty);
                                          using (var commandKey = clientKey.OpenSubKey(@"shell\open\command")) {
                                                 string exe = (string)commandKey.GetValue(string.Empty);
                                                 //Browsers.Add(new Browser() { Name = name, Exe = exe });

                                                 if (name.Length > 0) {
                                                        count++;

                                                        diChkData.Add(name, exe);
                                                        ToolStripItem item = contextMenuStrip1.Items.Add(fsetting.Initializer("Other","MenuUse") + name + fsetting.Initializer("Other","MenuBrowse"));
                                                        item.Click += new EventHandler(menuItem_Click);
                                                 }

                                          }
                                   }
                            }
                     }

			if (count > 0){
				toolStripSeparatormenu4.Visible = true;
			}


		}

              void menuItem_Click(object sender, EventArgs e)  {

                     if (dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[3].Value.ToString().Length > 0) {

                            string str_url = dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();

                            if (Regex.IsMatch(str_url, @"^(http|http(s)?://)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?", RegexOptions.IgnoreCase)) {

                                   ToolStripMenuItem menuItm = (ToolStripMenuItem)sender;

                                   string exe = diChkData[menuItm.Text.Replace(fsetting.Initializer("Other","MenuUse"),"").Replace(fsetting.Initializer("Other","MenuBrowse"), "")];

                                   Process explorer = new Process();

                                   explorer.StartInfo.FileName = exe;

                                   explorer.StartInfo.Arguments = str_url;
                                   explorer.Start();

                            } else {


                                   DevComponents.DotNetBar.MessageBoxEx.Show("此攔位不是網址?", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                     }


              }
              #endregion

              private void ifkhosts(){
                     try{

                            Regex check = new Regex(pattern);
				StreamReader status = null;
                            using (status = new StreamReader(system32hosts, System.Text.Encoding.Default)) {
                                   String line;
                                   while((line = status.ReadLine()) != null) {

                                                        if (line.Trim().Contains("localhost"))
                                                        {
                                                               continue;
                                                        }

                                                        line = line.Trim().Replace("  "," ").Replace("   "," ").Replace("     "," ").Replace("      "," ").Replace("       "," ").Replace("        "," ").Replace("         "," ").Replace("          "," ").Replace("           "," ").Replace("            "," ").Replace("             "," ").Replace("              "," ").Replace("               "," ") + " #";

                                                        string[] log = line.Split(' ');

                                                         if (check.IsMatch(log[0].Trim().ToString().Replace("#", ""), 0)) {

                                                             if(log[0].Trim().Contains("#")) {

                                                                      dataGridView1.Rows.Add(Properties.Resources.Error,0, log[0].Trim().Replace("#", ""), log[1].Trim(), log[2].Trim().Replace("#", ""));
								              endunt++;

                                                              } else {
                                                                      dataGridView1.Rows.Add(Properties.Resources.success,1, log[0].Trim().Replace("#", ""), log[1].Trim(), log[2].Trim().Replace("#", ""));
								              startint++;
                                                              }                                                                                                
                                                        }
                                   }
					

				}
				status.Close();
				status.Dispose();
                            dataGridView1.EndEdit();
				//ifautosave = true;
				toolStripLabel1.Text = fsetting.Initializer("Other","toolStripLabel1").Replace("%s",startint.ToString()).Replace("%d",endunt.ToString());
				startint= 0;
				endunt = 0;
                     } catch(Exception ex) {
                            MessageBox.Show(ex.Message);
                     }

              }


		private void Statistics() {

			try {

				Regex check = new Regex(pattern);
				StreamReader status = null;
                            using (status = new StreamReader(system32hosts, System.Text.Encoding.Default)) {
					String line;
					while ((line = status.ReadLine()) != null) {


						if (line.Contains("localhost")) {
							continue;
						}
							

						line = line.Trim().Replace("  "," ").Replace("   "," ").Replace("     "," ").Replace("      "," ").Replace("       "," ").Replace("        "," ").Replace("         "," ").Replace("          "," ").Replace("           "," ").Replace("            "," ").Replace("             "," ").Replace("              "," ").Replace("               "," ") + " #";
						string[] log = line.Split(' ');

						if (check.IsMatch(log[0].Trim().ToString().Replace("#", ""), 0)) {
							if (log[0].Trim().Contains("#")) {
								
								endunt++;
							} else {
								
								startint++;
							}



						}
					}

				}
				status.Close();
				status.Dispose();

				toolStripLabel1.Text = fsetting.Initializer("Other","toolStripLabel1").Replace("%s",startint.ToString()).Replace("%d",endunt.ToString());
				startint = 0;
				endunt = 0;
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}

		}



              private void toolStripButton1_Click(object sender, EventArgs e) {
                     if(System.IO.File.Exists(system32hosts)) {
                            System.Diagnostics.Process.Start("notepad.exe", system32hosts);
                     } else {
                            MessageBox.Show(system32hosts + fsetting.Initializer("Other","Filenotexist"),fsetting.Initializer("Other","Information"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
              }


		private void toolStripButton11_Click(object sender,EventArgs e) {
			System.Diagnostics.Process.Start("explorer.exe",Environment.SystemDirectory + "\\drivers\\etc\\");
		}

		private void toolStripButton2_Click(object sender, EventArgs e) {
			dataGridView1.Rows.Add(Properties.Resources.success, "1",Global.Defaultshowip, "www", "");

			dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;

		}
              private void toolStripButton3_Click(object sender, EventArgs e) {
                     if(MessageBox.Show(fsetting.Initializer("Other","confirmdelete"),fsetting.Initializer("Other","Information"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
				SaveData(false);
				Statistics();
                     } 
              }

              private void toolStripButton4_Click(object sender, EventArgs e) {
                     dataGridView1.Rows.Clear();
                     ifkhosts();
              }

              private void toolStripButton5_Click(object sender, EventArgs e) {

              }
		private void SaveData(Boolean type) {       
                     try{
                            //dataGridView1.Refresh();

                            if(dataGridView1.Rows.Count > 0){

					// StreamWriter sw = new StreamWriter(Application.StartupPath + "\\websites.txt");

					

					StreamWriter sw = new StreamWriter(system32hosts,false, Encoding.UTF8);
					sw.Flush();
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
                                   sw.WriteLine("127.0.0.1 localhost");
					
                                   foreach(DataGridViewRow row in dataGridView1.Rows) {

                                          if(row.Cells[2].Value.ToString().Length > 0 && row.Cells[3].Value.ToString().Length>0) {


							if (row.Cells[1].Value.ToString() == "0") {
							
								sw.WriteLine("#" + row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString() + " #" + row.Cells[4].Value.ToString());
							} else {

								sw.WriteLine(row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString() + " #" + row.Cells[4].Value.ToString());
							}
							
							
							
						}

                                   }
					
					sw.Close();
					sw.Dispose();
					
					
					if(type == true) {
						MessageBox.Show(fsetting.Initializer("Other","Savecomplete"),fsetting.Initializer("Other","Information"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					}


					//這個是釋放ip地址
					//Process.Start(Environment.SystemDirectory + "\\IPConfig.exe", "/release");
					//這個是獲取IP地址； 
					//Process.Start(Environment.SystemDirectory + "\\IPConfig.exe", "/renew");

					//dataGridView1.Rows.Clear();
					//ifkhosts();
				} else {

					StreamWriter sw = new StreamWriter(system32hosts, false, Encoding.UTF8);
					sw.Flush();
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
					sw.WriteLine("127.0.0.1 localhost");
					sw.Close();
					sw.Dispose();


					//MessageBox.Show("沒有任何筆數,無法儲存", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

	

                     } catch(Exception ex) {
                            MessageBox.Show(ex.Message);
                     }
              }

              private void toolStripButton6_Click(object sender, EventArgs e) {
                     AboutBox f = new AboutBox();
                     f.ShowDialog();
              }

 

              private void toolStripButton8_Click(object sender, EventArgs e) {

			this.WindowState = FormWindowState.Minimized;
			this.ShowInTaskbar = false;
		}




		private void copyip_Click(object sender,EventArgs e) {
			if(dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString() != "") {
				Clipboard.Clear();
				Clipboard.SetDataObject(dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString());
			}
		}

		private void copydominStripMenuItem_Click(object sender,EventArgs e) {
			if(dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[3].Value.ToString() != "") {

				Clipboard.Clear();   
				Clipboard.SetDataObject(dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[3].Value.ToString());   

				//MessageBox.Show(dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString());
				//System.Diagnostics.Process.Start("cmd.exe","/c ping " + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
			}
		}

		private void dataGridView1_KeyUp(object sender,KeyEventArgs e) {
			if(e.KeyCode == Keys.Enter) {
				SaveData(false);
				Statistics();
			}

		}



		private void toolStripButton12_Click(object sender,EventArgs e) {
			this.notifyIcon1.Visible = false;
			System.GC.Collect();
			System.Environment.Exit(0);
		}



		private void remDNSToolStripMenuItem_Click(object sender,EventArgs e) {

			System.Diagnostics.Process p = new System.Diagnostics.Process();
			p.StartInfo.FileName = "cmd.exe";
			p.StartInfo.Arguments = "/c ipconfig /flushdns";
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.RedirectStandardInput = true;
			p.StartInfo.RedirectStandardOutput = true;
			p.StartInfo.RedirectStandardError = true;
			p.StartInfo.CreateNoWindow =true; //不跳出cmd視窗
			p.Start();
			//p.StandardInput.WriteLine("");

			//string strOutput = p.StandardOutput.ReadToEnd();//匯出整個執行過程

			p.WaitForExit();

			p.Close();

			MessageBox.Show(fsetting.Initializer("Other","ClearDNScache"),fsetting.Initializer("Other","Information"),MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void updateToolStripMenuItem_Click(object sender,EventArgs e) {
			System.Diagnostics.Process p = new System.Diagnostics.Process();
			p.StartInfo.FileName = "cmd.exe";
			p.StartInfo.Arguments = "/c ipconfig /renew";
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.RedirectStandardInput = true;
			p.StartInfo.RedirectStandardOutput = true;
			p.StartInfo.RedirectStandardError = true;
			p.StartInfo.CreateNoWindow = true; //不跳出cmd視窗
			p.Start();
			//p.StandardInput.WriteLine("ipconfig /renew");

			//string strOutput = p.StandardOutput.ReadToEnd();//匯出整個執行過程

			p.WaitForExit();

			p.Close();

			MessageBox.Show(fsetting.Initializer("Other","Updatesuccess"),fsetting.Initializer("Other","Information"),MessageBoxButtons.OK,MessageBoxIcon.Information);
		}







		private void show_wintoolStripMenuItem_Click(object sender,EventArgs e) {
			this.Activate();
			this.WindowState = FormWindowState.Normal;
			this.ShowInTaskbar = true;
		}



		private void Callnetworkchup(object obj) {

			if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == false) {

				this.notifyIcon1.ShowBalloonTip(1000, this.Text,fsetting.Initializer("Other","Networkbreak"),ToolTipIcon.Error);
			}

		}



		private void timerCall(object obj) {

				counter = counter + 1;


			
				try {
			
					System.Int32 dwFlag = new int();

					if(!InternetGetConnectedState(ref dwFlag,0)) {
						networkcheckmsg = fsetting.Initializer("Other","NativeIPerror");
				} else if((dwFlag & INTERNET_CONNECTION_MODEM) != 0) {

						//network_msg.Text = "目前內部網路使用 ADSL MODEM 方式或其他的 VPN 連線成功。";

						List<string> SvrIPIP = GetHostIPAddress();

						if(SvrIPIP[0].ToString() == "") {
							networkcheckmsg = fsetting.Initializer("Other","NativeIPerror");
						} else {
							networkcheckmsg = fsetting.Initializer("Other","NativeIP") + SvrIPIP[1].ToString();
							networkcheck = true;
                                          }

					} else if((dwFlag & INTERNET_CONNECTION_LAN) != 0) {

						//network_msg.Text = "目前使用區網連線成功。";


						List<string> SvrIPIP = GetHostIPAddress();

						if(SvrIPIP[0].ToString() == "") {
							networkcheckmsg = fsetting.Initializer("Other","NativeIPerror");
						} else {
							networkcheckmsg = fsetting.Initializer("Other","NativeIP") + SvrIPIP[0].ToString();
							networkcheck = true;
						}

					}
					if (networkcheck == true) {
						this.SetnetworkmsgText(networkcheckmsg);
					}
					
				} catch (Exception) {
					this.SetnetworkmsgText(fsetting.Initializer("Other","NativeIPerror"));
				}
			

				try {
			
					if (new Ping().Send("www.google.com",2000).Status  == IPStatus.Success) {


						//System.Net.IPAddress SvrIP = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);

						HttpWebRequest req = WebRequest.Create("http://dir.twseo.org/ip-check.php") as HttpWebRequest;
						HttpWebResponse rsp = req.GetResponse() as HttpWebResponse;
						//從 Server 回傳的資料。
						Stream data2 = rsp.GetResponseStream();
						StreamReader sr = new StreamReader(data2);
						string resp = sr.ReadToEnd();
						sr.Close();
						data2.Close();



						Match charSetMatch = Regex.Match(resp, "你的IP為:([^<]*)<font([^<]*)color=#ff6600>([^<]*)</font>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
						string webCharSet = charSetMatch.Groups[3].Value;


						if(Global.Defaultipcheck == "1"){


									if (File.Exists(Application.StartupPath + "\\iplog.dat")){
											string[] allLines = File.ReadAllLines(Application.StartupPath + "\\iplog.dat");

											if (allLines.Count() > 0){

												string lastestLine = allLines[allLines.Length - 1];
												if (lastestLine.Trim() != webCharSet){

													if (allLines.Count() > 50){
														File.WriteAllText(Application.StartupPath + "\\iplog.dat", webCharSet.Trim() + "\n", Encoding.UTF8);
													} else{
														File.AppendAllText(Application.StartupPath + "\\iplog.dat", webCharSet.Trim() + "\n", Encoding.UTF8);
													}
                                                                      
													this.notifyIcon1.ShowBalloonTip(2000, this.Text,fsetting.Initializer("Other","ExtranetIP") + webCharSet.Trim(), ToolTipIcon.Info);
												}

											} else{

												File.AppendAllText(Application.StartupPath + "\\iplog.dat", webCharSet.Trim() + "\n", Encoding.UTF8);
											}
									} else {
										File.WriteAllText(Application.StartupPath + "\\iplog.dat", webCharSet.Trim() + "\n", Encoding.UTF8);
									}

						}





                                          Extranetcheckmsg = fsetting.Initializer("Other","ExtranetIP") + webCharSet; //GetExtranetIPAddress();

						//System.Net.IPAddress SvrIPIP = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);

						Extranetcheck = true;

					} else {

						Extranetcheckmsg = fsetting.Initializer("Other","ExtranetIPerror");
					//System.Net.IPAddress SvrIPIP = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);


				}


					if (Extranetcheck == true) {
						this.SetmsgText(Extranetcheckmsg);

					} 

				} catch( Exception) {
					this.SetmsgText(fsetting.Initializer("Other","ExtranetIPerror"));
				}
				
				if (networkcheck == true && Extranetcheck == true) {
					timerClose.Dispose();
				}

		}


		private delegate void networkmsgCallback(string networkmsg);

		private void SetnetworkmsgText(string networkmsg) {

			if (this.InvokeRequired) {

				networkmsgCallback d = new networkmsgCallback(SetnetworkmsgText);

				this.Invoke(d, networkmsg);
			} else {

				this.toolStripStatusLabel1.Text = networkmsg;
			}

		}


		private delegate void msgCallback(string Extranetmsg);

		private void SetmsgText(string Extranetmsg) {

			if (this.InvokeRequired) {

				msgCallback d = new msgCallback(SetmsgText);

				this.Invoke(d, Extranetmsg );
			} else {



				this.toolStripStatusLabel2.Text = Extranetmsg;
			}

		}




		/// <summary>
		/// 取得本機 IP Address
		/// </summary>
		/// <returns></returns>
		private List<string> GetHostIPAddress() {
			List<string> lstIPAddress = new List<string>();
			IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName());
			foreach(IPAddress ipa in IpEntry.AddressList) {
				if(ipa.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
					
						lstIPAddress.Add(ipa.ToString());
					

				}
					
			}
			return lstIPAddress; // result: 192.168.1.17 ......
		}
		/// <summary>
		/// 取得外網 IP Address
		/// </summary>
		/// <returns></returns>

		private string GetExtranetIPAddress() {
			HttpWebRequest request = HttpWebRequest.Create("http://www.whatismyip.com.tw") as HttpWebRequest;
			request.Method = "GET";
			request.ContentType = "application/x-www-form-urlencoded";
			request.UserAgent = "Mozilla/5.0";
			string ip = string.Empty;
			WebResponse response = request.GetResponse();
			using(StreamReader reader = new StreamReader(response.GetResponseStream())) {
				string result = reader.ReadToEnd();
				string pattern = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";
				ip = Regex.Match(result,pattern).ToString();
			}
			return ip; // result: 210.125.21.xxx
		}

		private void RestarttoolStripButton_Click(object sender,EventArgs e) {

			ApplicationRestart();

		}

		public void ApplicationRestart(){

			try
			{
				networkcheckup.Dispose();
				string filename = Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString());

				this.notifyIcon1.Visible = false;
				this.notifyIcon1.Dispose();
				if (Environment.Is64BitOperatingSystem){
					if (System.IO.File.Exists(Application.StartupPath + "\\program64.exe"))
					{
						Process.Start("program64.exe","start " + filename);
					}
				} else{
					if (System.IO.File.Exists(Application.StartupPath + "\\program86.exe"))
					{
						Process.Start("program86.exe","start " + filename);
					}
				}

				System.GC.Collect();
				System.Environment.Exit(0);

			} catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}


		}

		private void toolStripButton13_Click(object sender, EventArgs e) {

			

			if (dataGridView1.Rows.Count > 0) {

				string str = toolStripTextBox2.Text.Trim();

                            foreach (DataGridViewRow row in dataGridView1.Rows) {



					if (str.Length > 0 &&  row.Cells[3].Value.ToString().Contains(str)) {
						//row.Selected = true;
						row.DefaultCellStyle.BackColor = Color.Yellow;
					}

					if (str.Length < 1) {
						row.DefaultCellStyle.BackColor = Color.White;
					}
                                   
				}

				toolStripTextBox2.Text ="";

			}
		}

		private void enable_domin_Click(object sender, EventArgs e) {

			//dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Value = true;
			//dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Selected = true;

			dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Value = Properties.Resources.success;
			dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[1].Value = 1;
			//dataGridView1.EndEdit();
			SaveData(false);
			Statistics();

		}

		private void disable_domin_Click(object sender, EventArgs e) {
			//dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Value = false;
			//dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Selected = false;
			dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Value = Properties.Resources.Error;
			dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[1].Value = 0;
			//dataGridView1.EndEdit();
			SaveData(false);
			Statistics();
		}

		private void ping_domin_Click(object sender, EventArgs e) {

			try {
				if (dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[3].Value.ToString() != "") {

					//MessageBox.Show(dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString());

					String selldata = dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();

					Form_sell f = new Form_sell("ping",selldata);
					f.ShowDialog();

				}

			} catch (Exception ex) {

				MessageBox.Show(ex.Message,fsetting.Initializer("Other","Information"));

			}

		}

		private void nslookup_domin_Click(object sender, EventArgs e) {
			try {
				if (dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[3].Value.ToString() != "") {
					//MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

					String selldata = dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();

					Form_sell f = new Form_sell("nslookup", selldata);
					f.ShowDialog();
				}
			} catch (Exception ex) {

				MessageBox.Show(ex.Message,fsetting.Initializer("Other","Information"));

			}
		}


		private void HostToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				saveFileDialog1.FileName = "Hosts";
				saveFileDialog1.Title = fsetting.Initializer("Other","BackupHostsfiles");
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
					string savepos = saveFileDialog1.FileName;

					System.IO.File.Copy(system32hosts, savepos, true);
					MessageBox.Show(fsetting.Initializer("Other","Backupsuccess"),fsetting.Initializer("Other","Information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void ToolStripMenuItem_b_Click(object sender, EventArgs e) {

			try {

				if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {


                                   if (MessageBox.Show(fsetting.Initializer("Other","Overlaydata"),fsetting.Initializer("Other","Information"),MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.No) {

                                          dataGridView1.Rows.Clear();
                                   } 

                                   Regex check = new Regex(pattern);
					StreamReader status = null;
					using (status = new StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default)) {
						String line;
						while ((line = status.ReadLine()) != null) {


							if (line.Contains("localhost")) {
								continue;
							}
                                                 string[] log = line.Trim().Replace("  ", " ").Replace("   ", " ").Replace("     ", " ").Replace("      ", " ").Replace("       ", " ").Replace("        ", " ").Replace("         ", " ").Replace("          ", " ").Replace("           ", " ").Replace("            ", " ").Replace("             ", " ").Replace("              ", " ").Replace("               ", " ").Split(new char[] { ' ' });

                                                 if (check.IsMatch(log[0].ToString().Replace("#", ""), 0)) {
								if (log[0].Contains("#")) {
									dataGridView1.Rows.Add(Properties.Resources.Error, 0, log[0].Trim().Replace("#", ""), log[1].Trim(), log[2].Trim().Replace("#", ""));
								} else {
									dataGridView1.Rows.Add(Properties.Resources.success, 1, log[0].Trim().Replace("#", ""), log[1].Trim(), log[2].Trim().Replace("#", ""));
								}
							}
						}


					}
					status.Close();
					status.Dispose();
					dataGridView1.EndEdit();
					SaveData(false);
					Statistics();
				}
                     } catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}

			
		}
		private void ToolStripMenuItem_a_Click(object sender, EventArgs e) {
			try {

				if (dataGridView1.Rows.Count > 0) {
					saveFileDialog1.FileName = DateTime.Now.ToString("yyyy-MM-dd") + "_" + saveFileDialog1.FileName;
					saveFileDialog1.Title = fsetting.Initializer("Other","Exportlist");

					if (saveFileDialog1.ShowDialog() == DialogResult.OK) {



						StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8);
						foreach (DataGridViewRow row in dataGridView1.Rows) {
							if (row.Cells[2].Value.ToString().Length > 0 && row.Cells[3].Value.ToString().Length > 0) {
								if (row.Cells[1].Value.ToString() == "0") {

									sw.WriteLine("#" + row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString() + " #" + row.Cells[4].Value.ToString());
								} else {

									sw.WriteLine(row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString() + " #" + row.Cells[4].Value.ToString());
								}
							}
						}
						sw.Close();
						sw.Dispose();
						saveFileDialog1.FileName = "Hosts";
						saveFileDialog1.Title = fsetting.Initializer("Other","BackupHostsfiles");
					} 

				} else {

					MessageBox.Show(fsetting.Initializer("Other","Nolistexport"),fsetting.Initializer("Other","Information"), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			} catch (Exception ex) {
                            MessageBox.Show(ex.Message);
			}
		}

		private void LocalAreaConnection_enable_Click(object sender, EventArgs e) {

			try {

				if (Environment.Is64BitOperatingSystem) {
					if (System.IO.File.Exists(Application.StartupPath + "\\devcon64.exe") && System.IO.File.Exists(Application.StartupPath + "\\64enable.exe")) {

						System.Diagnostics.Process p = new System.Diagnostics.Process();
						p.StartInfo.FileName = "64enable.exe";
						//p.StartInfo.Arguments = "enable =ne";
						p.StartInfo.UseShellExecute = false;
						p.StartInfo.RedirectStandardInput = true;
						p.StartInfo.RedirectStandardOutput = true;
						p.StartInfo.RedirectStandardError = true;
						p.StartInfo.CreateNoWindow = true; //不跳出cmd視窗
						p.Start();


						p.WaitForExit();

						p.Close();
						MessageBox.Show("啟用區域連線完成", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);

					} else {

						MessageBox.Show("啟用區域連線異常", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}


				} else {
					if (System.IO.File.Exists(Application.StartupPath + "\\devcon32.exe") && System.IO.File.Exists(Application.StartupPath + "\\32enable.exe")) {

						System.Diagnostics.Process p = new System.Diagnostics.Process();
						p.StartInfo.FileName = "32enable.exe";
						//p.StartInfo.Arguments = "enable =ne";
						p.StartInfo.UseShellExecute = false;
						p.StartInfo.RedirectStandardInput = true;
						p.StartInfo.RedirectStandardOutput = true;
						p.StartInfo.RedirectStandardError = true;
						p.StartInfo.CreateNoWindow = true;
						p.Start();
						p.WaitForExit();
						p.Close();

						MessageBox.Show("啟用區域連線完成", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);

					} else {

						MessageBox.Show("啟用區域連線異常", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}


			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}


		}

		private void LocalAreaConnection_disable_Click(object sender, EventArgs e) {

			try {

				if (Environment.Is64BitOperatingSystem) {
					if (System.IO.File.Exists(Application.StartupPath + "\\devcon64.exe") && System.IO.File.Exists(Application.StartupPath + "\\64disable.exe")) {

						System.Diagnostics.Process p = new System.Diagnostics.Process();
						p.StartInfo.FileName = "64disable.exe";
						//p.StartInfo.Arguments = " disable =ne";
						//p.StartInfo.WorkingDirectory = Application.StartupPath;
						p.StartInfo.UseShellExecute = false;
						p.StartInfo.RedirectStandardInput = true;
						p.StartInfo.RedirectStandardOutput = true;
						p.StartInfo.RedirectStandardError = true;
						p.StartInfo.CreateNoWindow = true;
						p.Start();

						p.WaitForExit();

						p.Close();



						MessageBox.Show("停用區域連線完成", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);

					} else {

						MessageBox.Show("停用區域連線異常", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}


				} else {
					if (System.IO.File.Exists(Application.StartupPath + "\\devcon32.exe") && System.IO.File.Exists(Application.StartupPath + "\\32disable.exe")) {

						System.Diagnostics.Process p = new System.Diagnostics.Process();
						p.StartInfo.FileName = "32disable.exe";
						//p.StartInfo.Arguments = " disable =ne";
						p.StartInfo.UseShellExecute = false;
						p.StartInfo.RedirectStandardInput = true;
						p.StartInfo.RedirectStandardOutput = true;
						p.StartInfo.RedirectStandardError = true;
						p.StartInfo.CreateNoWindow = true; 
						p.Start();
						p.WaitForExit();
						p.Close();

						MessageBox.Show("停用區域連線完成", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);

					} else {

						MessageBox.Show("停用區域連線異常", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}

			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}

		}

		private void toolStripMenuItem_ip_Click(object sender, EventArgs e) {
			this.toolStripStatusLabel1.Text = fsetting.Initializer("Other","toolStripStatusLabel1");
			this.toolStripStatusLabel2.Text = fsetting.Initializer("Other","toolStripStatusLabel2");
			timerClose = new System.Threading.Timer(new TimerCallback(timerCall), this, 1000, 2000);
		}



		private void tool_Button_network_Click(object sender, EventArgs e) {
			network f = new network();
			f.ShowDialog();

		}

		private void toolStripButton_repair_Click(object sender, EventArgs e) {
			this.Hide();
			if (MessageBox.Show(fsetting.Initializer("Other","Restnetworkshare"),fsetting.Initializer("Other","Information"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK) {
				
				repairnetwork f = new repairnetwork(this);
				f.ShowDialog();
			} else {
				this.Show();
			}
		}

		private void toolStripButton_proxy_Click(object sender, EventArgs e) {
			browserproxy f = new browserproxy();
			f.ShowDialog();
		}

              private void viewMenuItem1_Click(object sender, EventArgs e)
              {

			IniFile s = new IniFile(Application.StartupPath + "\\setting.ini");

			fontDialog1.MinSize = 9;
                     fontDialog1.MaxSize = 20;
			fontDialog1.Font = new Font(s.IniReadValue("setting","DefaultFontFamily"),int.Parse(s.IniReadValue("setting","DefaultFontSize")));




			if (fontDialog1.ShowDialog() == DialogResult.OK){

                            this.dataGridView1.DefaultCellStyle.Font = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size);

				

				s.IniWriteValue("setting","DefaultFontFamily",fontDialog1.Font.FontFamily.Name.ToString());

				s.IniWriteValue("setting","DefaultFontSize",fontDialog1.Font.Size.ToString());

				if (fontDialog1.Font.Size ==9){

                                   toolStripMenuItem5.Checked = true;
                                   toolStripMenuItem6.Checked = false;
                                   toolStripMenuItem7.Checked = false;
                                   toolStripMenuItem8.Checked = false;
                                   toolStripMenuItem9.Checked = false;
                                   toolStripMenuItem10.Checked = false;
                                   toolStripMenuItem11.Checked = false;

                            } else if (fontDialog1.Font.Size ==10) {

                                   toolStripMenuItem5.Checked = false;
                                   toolStripMenuItem6.Checked = true;
                                   toolStripMenuItem7.Checked = false;
                                   toolStripMenuItem8.Checked = false;
                                   toolStripMenuItem9.Checked = false;
                                   toolStripMenuItem10.Checked = false;
                                   toolStripMenuItem11.Checked = false;

                            } else if (fontDialog1.Font.Size == 12){

                                   toolStripMenuItem5.Checked = false;
                                   toolStripMenuItem6.Checked = false;
                                   toolStripMenuItem7.Checked = true;
                                   toolStripMenuItem8.Checked = false;
                                   toolStripMenuItem9.Checked = false;
                                   toolStripMenuItem10.Checked = false;
                                   toolStripMenuItem11.Checked = false;


                            } else if (fontDialog1.Font.Size == 14) {

                                   toolStripMenuItem5.Checked = false;
                                   toolStripMenuItem6.Checked = false;
                                   toolStripMenuItem7.Checked = false;
                                   toolStripMenuItem8.Checked = true;
                                   toolStripMenuItem9.Checked = false;
                                   toolStripMenuItem10.Checked = false;
                                   toolStripMenuItem11.Checked = false;

                            } else if (fontDialog1.Font.Size == 16) {

                                   toolStripMenuItem5.Checked = false;
                                   toolStripMenuItem6.Checked = false;
                                   toolStripMenuItem7.Checked = false;
                                   toolStripMenuItem8.Checked = false;
                                   toolStripMenuItem9.Checked = true;
                                   toolStripMenuItem10.Checked = false;
                                   toolStripMenuItem11.Checked = false;

                            } else if (fontDialog1.Font.Size == 18) {

                                   toolStripMenuItem5.Checked = false;
                                   toolStripMenuItem6.Checked = false;
                                   toolStripMenuItem7.Checked = false;
                                   toolStripMenuItem8.Checked = false;
                                   toolStripMenuItem9.Checked = false;
                                   toolStripMenuItem10.Checked = true;
                                   toolStripMenuItem11.Checked = false;

                            } else if (fontDialog1.Font.Size ==20) {

                                   toolStripMenuItem5.Checked = false;
                                   toolStripMenuItem6.Checked = false;
                                   toolStripMenuItem7.Checked = false;
                                   toolStripMenuItem8.Checked = false;
                                   toolStripMenuItem9.Checked = false;
                                   toolStripMenuItem10.Checked = false;
                                   toolStripMenuItem11.Checked = true;
                            }
                     }
              }

              private void checkfontszie(object sender, EventArgs e){

                     if (sender == toolStripMenuItem5) {

                            toolStripMenuItem5.Checked = true;
                            toolStripMenuItem6.Checked = false;
                            toolStripMenuItem7.Checked = false;
                            toolStripMenuItem8.Checked = false;
                            toolStripMenuItem9.Checked = false;
                            toolStripMenuItem10.Checked = false;
                            toolStripMenuItem11.Checked = false;


                            this.dataGridView1.DefaultCellStyle.Font = new Font(this.dataGridView1.DefaultCellStyle.Font.FontFamily, 9);

                     } else if (sender == toolStripMenuItem6){

                            toolStripMenuItem5.Checked = false;
                            toolStripMenuItem6.Checked = true;
                            toolStripMenuItem7.Checked = false;
                            toolStripMenuItem8.Checked = false;
                            toolStripMenuItem9.Checked = false;
                            toolStripMenuItem10.Checked = false;
                            toolStripMenuItem11.Checked = false;
                            this.dataGridView1.DefaultCellStyle.Font = new Font(this.dataGridView1.DefaultCellStyle.Font.FontFamily, 10);
                     } else if (sender == toolStripMenuItem7){

                            toolStripMenuItem5.Checked = false;
                            toolStripMenuItem6.Checked = false;
                            toolStripMenuItem7.Checked = true; 
                            toolStripMenuItem8.Checked = false;
                            toolStripMenuItem9.Checked = false;
                            toolStripMenuItem10.Checked = false;
                            toolStripMenuItem11.Checked = false;

                            this.dataGridView1.DefaultCellStyle.Font = new Font(this.dataGridView1.DefaultCellStyle.Font.FontFamily, 12);
                     } else if (sender == toolStripMenuItem8) {

                            toolStripMenuItem5.Checked = false;
                            toolStripMenuItem6.Checked = false;
                            toolStripMenuItem7.Checked =  false;
                            toolStripMenuItem8.Checked = true;
                            toolStripMenuItem9.Checked = false;
                            toolStripMenuItem10.Checked = false;
                            toolStripMenuItem11.Checked = false;
                            this.dataGridView1.DefaultCellStyle.Font = new Font(this.dataGridView1.DefaultCellStyle.Font.FontFamily, 14);

                     } else if (sender == toolStripMenuItem9) {

                            toolStripMenuItem5.Checked = false;
                            toolStripMenuItem6.Checked = false;
                            toolStripMenuItem7.Checked = false;
                            toolStripMenuItem8.Checked = false;
                            toolStripMenuItem9.Checked =  true;
                            toolStripMenuItem10.Checked = false;
                            toolStripMenuItem11.Checked = false;
                            this.dataGridView1.DefaultCellStyle.Font = new Font(this.dataGridView1.DefaultCellStyle.Font.FontFamily, 16);

                     } else if (sender == toolStripMenuItem10) {

                            toolStripMenuItem5.Checked = false;
                            toolStripMenuItem6.Checked = false;
                            toolStripMenuItem7.Checked = false;
                            toolStripMenuItem8.Checked = false;
                            toolStripMenuItem9.Checked = false;
                            toolStripMenuItem10.Checked =  true;
                            toolStripMenuItem11.Checked = false;
                            this.dataGridView1.DefaultCellStyle.Font = new Font(this.dataGridView1.DefaultCellStyle.Font.FontFamily, 18);

                     } else if (sender == toolStripMenuItem11) {

                            toolStripMenuItem5.Checked = false;
                            toolStripMenuItem6.Checked = false;
                            toolStripMenuItem7.Checked = false;
                            toolStripMenuItem8.Checked = false;
                            toolStripMenuItem9.Checked = false;
                            toolStripMenuItem10.Checked = false;
                            toolStripMenuItem11.Checked =  true;


                            this.dataGridView1.DefaultCellStyle.Font = new Font(this.dataGridView1.DefaultCellStyle.Font.FontFamily, 20);
                     }

              }

		private void dataGridView1_UserDeletingRow(object sender,DataGridViewRowCancelEventArgs e)
		{

			if (MessageBox.Show(fsetting.Initializer("Other","confirmdelete"),fsetting.Initializer("Other","Information"),MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
			{
				e.Cancel = true;
				SaveData(false);
				Statistics();
			}
		}

		private void ToolMenuItem9_Click(object sender,EventArgs e) {

                     this.Hide();
                     FixForm f = new FixForm();
                     f.Owner = this;
                     f.ShowDialog();

              }

              private void notifyIcon1_MouseDoubleClick(object sender,MouseEventArgs e)
              {
                     this.Activate();
                     this.WindowState = FormWindowState.Normal;
                     this.ShowInTaskbar = true;
              }

              private void ToolMenuItem_setting_Click(object sender,EventArgs e){
                     Formsetting f = new Formsetting();
                     f.Owner = this;
                     f.ShowDialog();
              }

		private void dataGridViewmoveUp(object sender,EventArgs e){

			moveUp();
			SaveData(false);
		}

		private void dataGridViewdown(object sender,EventArgs e)
		{
			movedown();
			SaveData(false);
		}
		private void moveUp(){
			if (dataGridView1.RowCount > 0)
			{

				if (dataGridView1.SelectedRows.Count > 0)
				{

					int rowCount = dataGridView1.Rows.Count;
					int index = dataGridView1.SelectedCells[0].OwningRow.Index;

					if (index == 0)
					{
						return;
					}
					DataGridViewRowCollection rows = dataGridView1.Rows;

					// remove the previous row and add it behind the selected row.
					DataGridViewRow prevRow = rows[index - 1];
					rows.Remove(prevRow);
					prevRow.Frozen = false;
					rows.Insert(index,prevRow);
					dataGridView1.ClearSelection();
					dataGridView1.Rows[index - 1].Selected = true;

					
				}
			}
		}

		private void movedown(){

			if (dataGridView1.RowCount > 0)
			{
				if (dataGridView1.SelectedRows.Count > 0)
				{
					int rowCount = dataGridView1.Rows.Count;
					int index = dataGridView1.SelectedCells[0].OwningRow.Index;

					if (index == (rowCount - 2)) // include the header row
					{
						return;
					}
					DataGridViewRowCollection rows = dataGridView1.Rows;

					// remove the next row and add it in front of the selected row.
					DataGridViewRow nextRow = rows[index + 1];
					rows.Remove(nextRow);
					nextRow.Frozen = false;
					rows.Insert(index,nextRow);
					dataGridView1.ClearSelection();
					dataGridView1.Rows[index + 1].Selected = true;

					
				}
			}
		}

		private void dataGridView1_KeyDown(object sender,KeyEventArgs e)
		{
			if (e.KeyCode.Equals(Keys.Up))
			{
				moveUp();
				SaveData(false);
			}
			if (e.KeyCode.Equals(Keys.Down))
			{
				movedown();
				SaveData(false);
			}
			e.Handled = true;
		}
	}
}
