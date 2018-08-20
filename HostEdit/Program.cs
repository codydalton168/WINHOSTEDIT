using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// 增加
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
// 增加

namespace HostEdit {
       static class Program {
              /// <summary>
              /// 應用程式的主要進入點。
              /// </summary>
		/// 
		
		
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);
		[DllImport("user32.dll")]
		private static extern bool ShowWindowAsync(IntPtr hWnd,int nCmdShow);
	
		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd,int nCmdShow);
		
		[DllImport("user32.dll")]
		public static extern bool OpenIcon(IntPtr hwnd);
	
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(String sClassName,String sAppName);


		private const int SW_HIDE = 0;
		private const int SW_MAXIMIZE = 3;
		private const int SW_MINIMIZE = 6;
		private const int SW_RESTORE = 9;
		private const int SW_SHOW = 5;
		private const int SW_SHOWDEFAULT = 10;
		private const int SW_SHOWMAXIMIZED = 3;
		private const int SW_SHOWMINIMIZED = 2;
		private const int SW_SHOWMINNOACTIVE = 7;
		private const int SW_SHOWNA = 8;
		private const int SW_SHOWNOACTIVATE = 4;
		private const int SW_SHOWNORMAL = 1;

              [STAThread]
              static void Main(string[] args) {
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());


			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);


			Process instance = RunningInstance();

			if(instance == null) {


				if (args.Length > 0) {

                                   Application.Run(new Form1(args));
                            } else {

					Application.Run(new Form1());
                                   //Application.Run(new Form1());
                            }

                     } else {
                            //There is another instance of this process.  
                            // 增加
				//HandleRunningInstance(instance);
				IntPtr hwnd = FindWindow(null,"Win Host Edit");
				ShowWindowAsync(hwnd,SW_SHOWDEFAULT);

				ShowWindow(hwnd,SW_SHOWNORMAL);
				SetForegroundWindow(hwnd);

				
				//OpenIcon(hwnd); 
                     } 
              }
              // 增加
              public static Process RunningInstance() {
                     Process current = Process.GetCurrentProcess();
                     Process[] processes = Process.GetProcessesByName(current.ProcessName);
                     //Loop through  the running processes in with the same name   
                     foreach(Process process in processes) {
                            //Ignore   the   current   process  
                            if(process.Id != current.Id) {
                                   //Make sure that the process is running from the exe file.   
                                   if(Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName) {
                                          //Return   the   other   process   instance.  
                                          return process;
                                   }
                            }
                     }
                     //No other instance was found, return null. 
                     return null;
              }

              public static void HandleRunningInstance(Process instance) {
                     //Make sure the window is not minimized or maximized 
			//ShowWindowAsync(instance.MainWindowHandle,WS_SHOWNORMAL);

                     //Set the real intance to foreground window
                     //SetForegroundWindow(instance.MainWindowHandle);

			//ShowWindowAsync(instance.MainWindowHandle,SW_SHOWDEFAULT);


			//ShowWindow(instance.MainWindowHandle,SW_RESTORE);

			//SetForegroundWindow(instance.MainWindowHandle);

			//OpenIcon(instance.MainWindowHandle);
			



              }


       }
}
