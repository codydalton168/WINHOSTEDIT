using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace HostEdit{
       class IniFile{

              string _charSet = "UTF-8";

              public string path;

              //[DllImport("kernel32")]
              //private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

              [DllImport("kernel32")]
              private static extern long WritePrivateProfileString(string section,string key,byte[] val,string filePath);

              //[DllImport("kernel32")]
              //private static extern int GetPrivateProfileString(string section,string key, string def, StringBuilder retVal,int size, string filePath);

              [DllImport("kernel32")]
              private static extern int GetPrivateProfileString(string section,string key,string def,byte[] retVal,int size,string filePath);



              public IniFile(String INIPath){
                     path = INIPath;
              }

              public void IniWriteValue(string Section,string Key,string Value) {
                     try{
                            //WritePrivateProfileString(Section, Key, Value, this.path);
                            WritePrivateProfileString(Section,Key,Encoding.GetEncoding(_charSet).GetBytes('"' + Value +'"'),this.path);
                     } catch (Exception) {

                     }
              }

              public string IniReadValue(string Section,string Key) {

                     try{

                            byte[] byt = new byte[500];

                            int i = GetPrivateProfileString(Section,Key,null,byt,500,this.path);

                            return Encoding.GetEncoding(_charSet).GetString(byt,0,i);

                            /*
				StringBuilder temp = new StringBuilder(1024);
				int i = GetPrivateProfileString(Section, Key, "", temp,1024, this.path);

				return temp.ToString();
				*/
                     } catch (Exception) {

                     }
                     return null;

              }


       }
}
