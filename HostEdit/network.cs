using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions; // System.Collections 命名空間
using System.Globalization;
using System.Threading;

namespace HostEdit {
	public partial class network : Form {

		ManagementObject objCls; // ManagementObject 類別 , 表示 WMI 執行個體。
		string strCls = "Win32_NetworkAdapterConfiguration"; // WMI 名稱空間 ( Namespace )
		string strNS = "root\\CIMV2"; // WMI 類別 (Class)
		int strIndex; // 用來記錄網路介面卡 Index
		string[] addresses;
		string[] subnets;
		string[] defaultgateways;
		string[] DNSServer;



		[DllImport("kernel32.dll")]
		static extern bool SetComputerName(string lpComputerName);
		[DllImport("kernel32.dll")]
		static extern bool SetComputerNameEx(_COMPUTER_NAME_FORMAT iType, string lpComputerName);

		setting fsetting = new setting();

		CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);

		public network() {
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e) {
			this.Close();

		}

		enum _COMPUTER_NAME_FORMAT {
			ComputerNameNetBIOS,
			ComputerNameDnsHostname,
			ComputerNameDnsDomain,
			ComputerNameDnsFullyQualified,
			ComputerNamePhysicalNetBIOS,
			ComputerNamePhysicalDnsHostname,
			ComputerNamePhysicalDnsDomain,
			ComputerNamePhysicalDnsFullyQualified,
			ComputerNameMax
		};


		public class MyItem {
			public string text;
			public string value;

			public MyItem(string text, string value) {
				this.text = text;
				this.value = value;
			}

			public override string ToString() {
				return text;
			}
		}


		private void network_Load(object sender, EventArgs e) {

			GetAdtInfo(); // 呼叫 GetAdtInfo 程序來取得網路介面卡資訊
					//載入語言
			this.ci = new CultureInfo(Global.LanguageCode);
			Thread.CurrentThread.CurrentCulture = this.ci;
			Thread.CurrentThread.CurrentUICulture = this.ci;

			ShowUILang();


		}

		private void ShowUILang(){

				this.Text = fsetting.Initializer("Network","title");
				label1.Text = fsetting.Initializer("Network","label1");
				label4.Text = fsetting.Initializer("Network","label4");
				label6.Text = fsetting.Initializer("Network","label6");
				label8 .Text = fsetting.Initializer("Network","label8");
				label9.Text = fsetting.Initializer("Network","label9");
				label10.Text = fsetting.Initializer("Network","label10");
				label11.Text = fsetting.Initializer("Network","label11");
				label12.Text = fsetting.Initializer("Network","label12");
				auto_button.Text = fsetting.Initializer("Network","auto_button");
				buttonsave.Text = fsetting.Initializer("Network","buttonsave");
				buttonexit.Text = fsetting.Initializer("Network","buttonexit");

		}



		private void GetAdtInfo() {

			ComboBox1.Items.Clear();

			// 指定查詢網路介面卡組態 ( IPEnabled 為 True 的 )
			string strQry = "Select * from Win32_NetworkAdapterConfiguration where IPEnabled=True";

			// ManagementObjectSearcher 類別 , 根據指定的查詢擷取管理物件的集合。
			ManagementObjectSearcher objSc = new ManagementObjectSearcher(strQry);

			// 使用 Foreach 陳述式 存取集合類別中物件 (元素)
			// Get 方法 , 叫用指定的 WMI 查詢 , 並傳回產生的集合。
			foreach (ManagementObject objQry in objSc.Get()) {
				// 取網路介面卡資訊
				ComboBox1.Items.Add(new MyItem(objQry["Caption"].ToString(), objQry["Index"].ToString())); // 將 Caption 新增至 ComboBox

			}
			ComboBox1.SelectedIndex = 0;//預設選擇第一個


		}

		private void SetNetCfg(string strIP, string strSubmask, string strGateway, string strDNS1, string strDNS2) {
			// 建立 ManagementObject 物件 ( Scope , Path , options )

			objCls = new ManagementObject(strNS, strCls + ".Index=" + strIndex, null);

			ManagementBaseObject objInPara; // 宣告管理物件類別的基本類別

			objInPara = objCls.GetMethodParameters("EnableStatic");
			objInPara["IPAddress"] = new string[] { strIP }; // 設定 "IP" 屬性
			objInPara["SubnetMask"] = new string[] { strSubmask }; // 設定 "子網路遮罩" 屬性
			objCls.InvokeMethod("EnableStatic", objInPara, null);

			objInPara = objCls.GetMethodParameters("SetGateways");
			objInPara["DefaultIPGateway"] = new string[] { strGateway }; // 設定 "Gateway" 屬性
			objCls.InvokeMethod("SetGateways", objInPara, null);

			objInPara = objCls.GetMethodParameters("SetDNSServerSearchOrder");
			objInPara["DNSServerSearchOrder"] = new string[] { strDNS1, strDNS2 }; // 設定 "DNS" 屬性
			objCls.InvokeMethod("SetDNSServerSearchOrder", objInPara, null);

			// GetMethodParameters 方法 : 用來取得 SetDNSServerSearchOrder 參數清單。
			// InvokeMethod 方法 : 在物件上叫用方法。

			this.Hide();

			MessageBox.Show(fsetting.Initializer("Network","ChangeSuccess"),fsetting.Initializer("Other","Information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
			
			DisableAllAdapters();
			
			EnableAllAdapters();

			this.Close();

		}


		/// <summary>
		/// 啟用所有網路卡
		/// </summary>
		/// <returns></returns>
		public void EnableAllAdapters() {

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

					}
				}


			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}

		}

		/// <summary>
		/// 禁用所有網路卡
		/// </summary>
		public void DisableAllAdapters() {

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

					} 
				}

			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}

		}


		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			GetNetInfo(ComboBox1.SelectedItem.ToString());
		}

		//http://www.java2s.com/Code/CSharp/Development-Class/ManagementObjectSearcher.htm
		//https://dotblogs.com.tw/box5068/2012/01/30/67097




		private void GetNetInfo(string strNetAdapterName) {

			try {

				// 指定查詢網路介面卡組態 ( IPEnabled 為 True 的 )
				string strQry = "Select * from Win32_NetworkAdapterConfiguration where IPEnabled=True";

				// ManagementObjectSearcher 類別 , 根據指定的查詢擷取管理物件的集合。
				ManagementObjectSearcher objSc = new ManagementObjectSearcher(strQry);

				// 使用 Foreach 陳述式 存取集合類別中物件 (元素)
				// Get 方法 , 叫用指定的 WMI 查詢 , 並傳回產生的集合。
				foreach (ManagementObject objQry in objSc.Get()) {
					//判斷是否與選取網卡名稱一樣
					if (objQry["Caption"].ToString() == strNetAdapterName) {
						addresses = (string[])objQry["IPAddress"];
						subnets = (string[])objQry["IPSubnet"];
						defaultgateways = (string[])objQry["DefaultIPGateway"];
						DNSServer = (string[])objQry["DNSServerSearchOrder"];

						label3.Text = objQry["MACAddress"].ToString();
						label5.Text = objQry["ServiceName"].ToString();
						label7.Text = objQry["Index"].ToString();
					}
				}
				if (addresses[0].ToString().Length > 0) {
					txtIP.Text = addresses[0].ToString();

				}

				if (subnets[0].ToString().Length > 0) {
					txtSubmask.Text = subnets[0].ToString();
				}
				if (defaultgateways[0].ToString().Length > 0) {
					txtGateway.Text = defaultgateways[0].ToString();
				}

				if (DNSServer[0].ToString().Length > 0) {
					txtDNS1.Text = DNSServer[0].ToString();
				}
				if (DNSServer[1].ToString().Length > 0) {
					txtDNS2.Text = DNSServer[1].ToString();
				}
			} catch (Exception) {
				//MessageBox.Show(ex.Message);
			}


		}


		public static bool IsIPAddress(string ip)//驗證IP位置是否為正確
		{
			string[] arr = ip.Split('.');
			if (arr.Length != 4)
				return false;
			string pattern = @"\d{1,3}";
			for (int i = 0; i < arr.Length; i++) {
				string d = arr[i];
				if (i == 0 && d == "0")
					return false;
				if (!Regex.IsMatch(d, pattern))
					return false;
				if (d != "0") {
					d = d.TrimStart('0');
					if (d == "")
						return false;
					if (int.Parse(d) > 255)
						return false;
				}
			}
			return true;
		}

		private void button1_Click(object sender, EventArgs e) {
			if (IsIPAddress(txtIP.Text)) {

				if (MessageBox.Show(fsetting.Initializer("Network","Determinechanges") + "\r\n"+ fsetting.Initializer("Network","ReplaceIPmsg"),fsetting.Initializer("Other","Information"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

					MyItem myItem = (MyItem)this.ComboBox1.SelectedItem;


					string strIP = txtIP.Text.Trim();  // IP 位址
					string strSubmask = txtSubmask.Text.Trim(); // 子網路遮罩
					string strGateway = txtGateway.Text.Trim(); // 預設閘道
					string strDNS1 = txtDNS1.Text.Trim(); // 慣用 DNS 伺服器
					string strDNS2 = txtDNS2.Text.Trim(); // 其他 DNS 伺服器
					strIndex = int.Parse(myItem.value); //取的要設定之網卡Index
					// 呼叫 SetNetCfg 程序 , 設定網路介面卡組態
					SetNetCfg(strIP, strSubmask, strGateway, strDNS1, strDNS2);
				}

			} else {

				MessageBox.Show(fsetting.Initializer("Network","IPError"),fsetting.Initializer("Other","Information"), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void auto_button_Click(object sender, EventArgs e) {

			auto_button.Enabled = false;

			MyItem myItem = (MyItem)this.ComboBox1.SelectedItem;
			strIndex = int.Parse(myItem.value);

			// 建立 ManagementObject 物件 ( Scope , Path , options )
			objCls = new ManagementObject(strNS, strCls + ".INDEX=" + strIndex, null);
			// InvokeMethod 方法 : 在物件上叫用方法。
			objCls.InvokeMethod("EnableDHCP", null); // 設定自動取得 IP
			objCls.InvokeMethod("ReleaseDHCPLease", null); // 釋放 IP
			objCls.InvokeMethod("RenewDHCPLease", null); // 重新取得 IP
			objCls.InvokeMethod("SetDNSServerSearchOrder", null);//設定自動取得DNS

			//GetAdtInfo();

			GetNetInfo(ComboBox1.SelectedItem.ToString());

			//MessageBox.Show(ComboBox1.SelectedItem.ToString());

			MessageBox.Show(fsetting.Initializer("Network","AutomaticIP"),fsetting.Initializer("Other","Information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

			auto_button.Enabled = true;
		}

		private void editclicksites(object sender,EventArgs e)
		{
			buttonsave.Enabled = true;
		}
	}
}
