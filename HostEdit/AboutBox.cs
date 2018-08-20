using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;


namespace HostEdit {
       partial class AboutBox : Form {
              public AboutBox() {
                     InitializeComponent();
              }

		setting fsetting = new setting();

		CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);



		private void AboutBox_Load(object sender,EventArgs e){

			try{
				//載入語言
				this.ci = new CultureInfo(Global.LanguageCode);
				Thread.CurrentThread.CurrentCulture = this.ci;
				Thread.CurrentThread.CurrentUICulture = this.ci;

				this.okButton.Text = fsetting.Initializer("Other","Endbuttonsell");

				this.Text = fsetting.Initializer("Other","Abouttitle") +" "+AssemblyTitle;
				this.labelProductName.Text = AssemblyProduct;
				this.labelVersion.Text = String.Format("Version {0}",AssemblyVersion);
				this.labelCopyright.Text = AssemblyCopyright;
				this.labelCompanyName.Text = AssemblyCompany;
				//this.textBoxDescription.Text = AssemblyDescription;

				this.textBoxDescription.Text = AssemblyProduct;


				if (File.Exists(Application.StartupPath + "\\Languages\\" + Global.Language + ".txt")){

					string str = File.ReadAllText(Application.StartupPath + "\\Languages\\" + Global.Language + ".txt");

					if(str.Length > 0){

						this.textBoxDescription.Text += " "+str;

						this.Show();

						if (this.backgroundWorker1.IsBusy != true){

							label1.Text = "...";
							label2.Text = "...";
							label3.Text = "...";

							this.backgroundWorker1.RunWorkerAsync();
						}


					} else{

						MessageBox.Show("Error Read ");
						this.Close();
					}




				} else {

					MessageBox.Show("Error Read ");
					this.Close();
				}


			} catch(Exception ex){

				MessageBox.Show(ex.Message);
			}




		}

		private void backgroundWorker1_DoWork(object sender,DoWorkEventArgs e){

			Reportmsg(1,HardwareInfo.GetProcessorInformation());
			Reportmsg(2,HardwareInfo.GetPhysicalMemory());
			Reportmsg(3,HardwareInfo.GetOSInformation());

		}

		private void backgroundWorker1_RunWorkerCompleted(object sender,RunWorkerCompletedEventArgs e){

			this.backgroundWorker1.Dispose();
		}


		delegate void upmsg(int values,string text);
		private void Reportmsg(int values,string text){

			if (this.InvokeRequired){
				upmsg d = new upmsg(Reportmsg);
				this.Invoke(d,values,text);

			} else{
				if (values == 1){
					label1.Text = text;
				} else if(values == 2){
					label2.Text = text;
				} else if (values == 3){
					label3.Text = text;

				}


			}

		}

		private void AboutBox_Activated(object sender,EventArgs e)
		{
			this.Hide();
		}


		#region 組件屬性存取子

		public string AssemblyTitle {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute),false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion {
			get {
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute),false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute),false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute),false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute),false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion




	}
}
