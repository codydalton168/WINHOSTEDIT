using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Windows.Forms;

namespace HostEdit
{
       class setting {

		IniFile lang;


		public setting(){
                     IniFile s = new IniFile(Application.StartupPath + "\\setting.ini");
                     if (s.IniReadValue("setting","DefaultLanguage").ToString().Length > 0) {
                            Global.Language = s.IniReadValue("setting","DefaultLanguage").ToString();
                     }

                     if(s.IniReadValue("setting","Defaultshowip").ToString().Length > 0){

                            Global.Defaultshowip = s.IniReadValue("setting","Defaultshowip").ToString();
                     }

                     if (s.IniReadValue("setting","Defaultnetworkcheck").ToString().Length > 0)  {
				Global.Defaultnetworkcheck = s.IniReadValue("setting","Defaultnetworkcheck").ToString();
			}

                     if (s.IniReadValue("setting","Defaultipcheck").ToString().Length > 0) {
                            Global.Defaultipcheck = s.IniReadValue("setting","Defaultipcheck").ToString();
			}

			Global.LanguageCode = this.Initializer("LangOptions","LanguageCode");

			
		}

              public string Initializer(string name,string value){

			try{

					string stringreplay = "" ;

					if (!System.IO.File.Exists(Application.StartupPath + "\\Languages\\" + Global.Language + ".ini")){

						MessageBox.Show("Language Reading Error ?","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);

						stringreplay = "null";

					} else {

						lang = new IniFile(Application.StartupPath + "\\Languages\\" + Global.Language + ".ini");

						if (lang.IniReadValue(name,value).ToString().Length > 0) {

							stringreplay = lang.IniReadValue(name,value).ToString();

						} else {

							stringreplay = "null";
						}
						lang = null;
					}

					return stringreplay;

			}catch(Exception ex){
				MessageBox.Show(ex.Message);
				return "null";
			}
		}



       }
}
