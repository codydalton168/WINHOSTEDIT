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
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace HostEdit{

       public partial class Formsetting:Form{

              public Formsetting(){
                     InitializeComponent();
              }

              IniFile ini = null;
              IniFile setting = null;
              string DefaultLanguage = "";
              string msg = "";

		setting fsetting = new setting();

		CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);


		public class langDataList{
                     public string Name {
                            get;
                            set;
                     }
                     public string Value {
                            get;
                            set;
                     }
              }

              private void Formsetting_Load(object sender,EventArgs e){
              
                     try{

                                   showlanglist();

                                   showfontFamilylist();

                                   showfontsizelist();

                                   IniFile s = new IniFile(Application.StartupPath + "\\setting.ini");

                                   if(s.IniReadValue("setting","Defaultshowip").ToString().Length > 0){

                                          textBox1.Text = s.IniReadValue("setting","Defaultshowip").ToString();
                                   }

                                   if(s.IniReadValue("setting","Defaultwinstart").ToString().Length > 0 && s.IniReadValue("setting","Defaultwinstart").ToString() == "1") {
                                          checkBox1.Checked = true;
                                   }

                                   if (s.IniReadValue("setting","Defaultnetworkcheck").ToString().Length > 0 && s.IniReadValue("setting","Defaultnetworkcheck").ToString() == "1")  {
                                          checkBox2.Checked = true;
                                   }

                                   if (s.IniReadValue("setting","Defaultipcheck").ToString().Length > 0 && s.IniReadValue("setting","Defaultipcheck").ToString() == "1") {
                                          checkBox3.Checked = true;
                                   }

					//載入語言
					this.ci = new CultureInfo(Global.LanguageCode);
					Thread.CurrentThread.CurrentCulture = this.ci;
					Thread.CurrentThread.CurrentUICulture = this.ci;

					ShowUILang();


			} catch(Exception ex){

                            MessageBox.Show(ex.Message);
                     }

              }

		private void ShowUILang(){
			this.Text = fsetting.Initializer("setting","title");
			groupBox1.Text = fsetting.Initializer("setting","groupBox1");
			groupBox2.Text = fsetting.Initializer("setting","groupBox2");
			label1.Text = fsetting.Initializer("setting","label1");
			label2.Text = fsetting.Initializer("setting","label2");
			label3.Text = fsetting.Initializer("setting","label3");
			label4.Text = fsetting.Initializer("setting","label4");

			checkBox1.Text = fsetting.Initializer("setting","checkBox1txt");
			checkBox2.Text = fsetting.Initializer("setting","checkBox2txt");
			checkBox3.Text = fsetting.Initializer("setting","checkBox3txt");


			label5.Text = fsetting.Initializer("setting","label5");
			label6.Text = fsetting.Initializer("setting","label6");

			buttonok.Text = fsetting.Initializer("setting","buttonok");
			buttonexit.Text = fsetting.Initializer("setting","buttonexit");

		}

		private void showfontsizelist(){

                     setting = new IniFile(Application.StartupPath + "\\setting.ini");

                     string Default = setting.IniReadValue("setting","DefaultFontSize");

                     if (Default.ToString().Length > 0){

                            for (int i = 0; i < comboBox3.Items.Count; i++) {
                                   if (comboBox3.Items[i].ToString() == Default){
                                          comboBox3.SelectedIndex = i;
                                          break;
                                   }
                            }
                            System.GC.Collect();
                     } else{
                            comboBox2.SelectedIndex = 0;
                     }

              }


              private void showfontFamilylist() {

                     // Get the array of FontFamily objects.
                     InstalledFontCollection fonts = new InstalledFontCollection();
                     foreach (FontFamily ff in fonts.Families){
                            if (ff.IsStyleAvailable(FontStyle.Regular)) {
                                   comboBox2.Items.Add(ff.Name);
                            }
                     }

                     setting = new IniFile(Application.StartupPath + "\\setting.ini");

                     string Default = setting.IniReadValue("setting","DefaultFontFamily");

                     if (Default.ToString().Length > 0) {

                            for (int i = 0; i < comboBox2.Items.Count; i++) {
                                   if (comboBox2.Items[i].ToString() == Default) {
                                          comboBox2.SelectedIndex = i;
                                          break;
                                   }
                            }
                            System.GC.Collect();
                     } else {
                                   comboBox2.SelectedIndex = 0;
                     }

              }

               private void showlanglist(){

                     DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "\\Languages");


                     List<langDataList> lisDataList = new List<langDataList>();

                     foreach (var fi in di.GetFiles("*.ini")) {

                            ini = new IniFile(Application.StartupPath + "\\Languages\\" + fi.Name);

                            lisDataList.Add(new langDataList {
                                   Name = "" + ini.IniReadValue("LangOptions","LanguageName") + "",
                                   Value = "" + fi.Name.Replace(".ini","") + ""
                            });

                            //MessageBox.Show(ini.IniReadValue("LangOptions","LanguageName"),"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                     }


                     if (lisDataList.Count > 0){

                            comboBox1.DataSource = lisDataList;
                            comboBox1.DisplayMember = "Name";
                            comboBox1.ValueMember = "Value";

                            setting = new IniFile(Application.StartupPath + "\\setting.ini");

                            string Default = setting.IniReadValue("setting","DefaultLanguage");

                            if(Default.ToString().Length > 0){

                                   DefaultLanguage = Default;

                                   for (int i = 0; i < comboBox1.Items.Count; i++){
                                          if (((langDataList)comboBox1.Items[i]).Value.ToString() == Default){
                                                 comboBox1.SelectedIndex = i;
                                                 break;
                                          }
                                   }
                            }

                     }
                     System.GC.Collect();
              }

              private void SelectedChanged(object sender,EventArgs e) {

                     buttonok.Enabled = true;

              }


              private void button_ok_Click(object sender,EventArgs e)  {

                     try{

                            if(!Regex.IsMatch(textBox1.Text,@"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$")){
                                   MessageBox.Show(fsetting.Initializer("Other","DefaultdisplayIP"),fsetting.Initializer("Other","Information"),MessageBoxButtons.OK,MessageBoxIcon.Error);
                            } else {

                                   if (checkBox1.Checked == true){
                                                 RegistryKey regdhcpKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",true);
                                                 regdhcpKey.SetValue("Win Host Edit",Application.ExecutablePath +"  /s",RegistryValueKind.String);
                                                 regdhcpKey.Close();
                                                 regdhcpKey.Dispose();
                                   } else {
                                                 RegistryKey noSuch = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",true);

                                                 if (noSuch.GetValue("Win Host Edit") != null){
                                                        noSuch.DeleteValue("Win Host Edit");
                                                 }
                                                 noSuch.Close();
                                                 noSuch.Dispose();
                                   }


                                   IniFile setting = new IniFile(Application.StartupPath + "\\setting.ini");

                                   setting.IniWriteValue("setting","DefaultLanguage",comboBox1.SelectedValue.ToString());

                                   setting.IniWriteValue("setting","Defaultwinstart",(checkBox1.Checked == true ? "1" : "0"));

                                   setting.IniWriteValue("setting","Defaultnetworkcheck",(checkBox2.Checked == true ? "1" : "0"));

                                   setting.IniWriteValue("setting","Defaultipcheck",(checkBox3.Checked == true ? "1" : "0"));


                                   setting.IniWriteValue("setting","Defaultshowip",textBox1.Text);

                                   setting.IniWriteValue("setting","DefaultFontFamily",comboBox2.Text);

                                   setting.IniWriteValue("setting","DefaultFontSize",comboBox3.Text);


                                   buttonok.Enabled = false;


                                   if(DefaultLanguage != comboBox1.SelectedValue.ToString()){
                                          msg = fsetting.Initializer("setting","StorageSuccess") + "\r\n" +fsetting.Initializer("setting","StorageSuccessLang");
						MessageBox.Show(msg,fsetting.Initializer("Other","Information"),MessageBoxButtons.OK,MessageBoxIcon.Information);
						Form1 lForm1 = (Form1)this.Owner;
						lForm1.ApplicationRestart();
					} else {
                                          msg = fsetting.Initializer("setting","StorageSuccess");
						MessageBox.Show(msg,fsetting.Initializer("Other","Information"),MessageBoxButtons.OK,MessageBoxIcon.Information);
						this.Close();
					}


				}

                     } catch (Exception ex){
                            MessageBox.Show(ex.Message);

                     }


              }




              private void button_exit_Click(object sender,EventArgs e)
              {
                     this.Close();
              }


       }
}
