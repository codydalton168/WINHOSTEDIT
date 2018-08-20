using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace HostEdit {
	public partial class browserproxy : Form {
		public browserproxy() {
			InitializeComponent();
		}

		setting fsetting = new setting();
		CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);

		[DllImport("wininet.dll")]
		public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
		public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
		public const int INTERNET_OPTION_REFRESH = 37;


		private void browserproxy_Load(object sender, EventArgs e) {
			/*
			 * http://www.xuebuyuan.com/1820444.html
			 *
			 * 
			 */
			/*
			RegistryKey currentKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry32);
			currentKey = currentKey.OpenSubKey(@"Software/Microsoft/Windows/CurrentVersion/Internet Settings", true);
			*/

			RegistryKey mykey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings",true);

			if (mykey.GetValue("ProxyEnable") != null) {
				string myget = mykey.GetValue("ProxyEnable").ToString();
				if (myget != "") {
					if (myget == "0") {
						radioButton2.Checked = true;
					} else {
						radioButton1.Checked = true;
					}
				}

			}


			if (mykey.GetValue("ProxyServer") != null) {
				string myServer = mykey.GetValue("ProxyServer").ToString();
				if (myServer != "") {
					textBox1.Text = myServer;
				}
			}


			mykey.Close();
			//載入語言
			this.ci = new CultureInfo(Global.LanguageCode);
			Thread.CurrentThread.CurrentCulture = this.ci;
			Thread.CurrentThread.CurrentUICulture = this.ci;
			ShowUILang();
		}

		private void ShowUILang() {
			this.Text = fsetting.Initializer("proxy","title");
			label1.Text = fsetting.Initializer("proxy","label1");
			radioButton1.Text = fsetting.Initializer("proxy","radioButton1");
			radioButton2.Text = fsetting.Initializer("proxy","radioButton2");
			button_Clipboard.Text = fsetting.Initializer("proxy","button_Clipboard");
			button1.Text = fsetting.Initializer("proxy","button1");
			button2.Text = fsetting.Initializer("proxy","button2");
		}

		private void button1_Click(object sender, EventArgs e) {
			

			if (textBox1.Text.Trim().Length > 0 ) {

				RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);

				if (radioButton1.Checked == true) {

					regKey.SetValue("ProxyEnable", 1, RegistryValueKind.DWord);

				} else if (radioButton2.Checked == true) {

					regKey.SetValue("ProxyEnable", 0, RegistryValueKind.DWord);
				}

				regKey.SetValue("ProxyServer", textBox1.Text.Trim(), RegistryValueKind.String);

				regKey.Close();

				InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
				InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);

				this.Close();
			}
		}

		private void button2_Click(object sender, EventArgs e) {

			InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
			InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);

			this.Close();
		}

		private void enabletxt(object sender, MouseEventArgs e) {
			if (button1.Enabled == false) {
				button1.Enabled = true;
			}
		}

		private void button_Clipboard_Click(object sender, EventArgs e) {
			string message = Clipboard.GetText();

			if (message != "") {
				textBox1.Text = message;
			}
		
		}





	}
}
