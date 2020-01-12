using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace RadeonWindowFix
{
    class Program
    {
        static void Main(string[] args)
        {
            if(Elevate())
            {
                Process p = new Process();
                p.StartInfo.FileName = Application.ExecutablePath;
                p.StartInfo.Verb = "runas";
                p.Start(); // start software in admin mode
                return;
            }
            Console.Title = "Radeon Window Fix - Nuttyb0il";
            List<string> files = new List<string>();
            Console.WriteLine("[+] Finding Radeon Processes..", Console.ForegroundColor = ConsoleColor.Yellow);
            foreach (Process p in Process.GetProcesses())
            {
                if(p.ProcessName.ToLower().Contains("radeon") && p != Process.GetCurrentProcess() || p.ProcessName.ToLower().Contains("amd")) // is a radeon process
                {
                    Console.WriteLine("[+] Attempting to kill : " + p.ProcessName, Console.ForegroundColor = ConsoleColor.Green);
                    try
                    {
                        files.Add(p.MainModule.FileName); // add path to list so we can restart it
                        p.Kill();
                    }
                    catch (System.ComponentModel.Win32Exception)
                    {
                        Console.WriteLine("[!] Couldn't kill " + p.ProcessName, Console.ForegroundColor = ConsoleColor.Red);
                    }

                }
            }
            Thread.Sleep(500); // Waiting till processes are correctly closed.
            foreach (string f in files)
            {
                Console.WriteLine("[+] Attempting to restart process.. " + f.Split('\\').Last(), Console.ForegroundColor = ConsoleColor.Green);
                Process.Start(f);
            }
            Console.Beep();
            Console.WriteLine("[+] Done !");
            Console.WriteLine("Press any key to exit...", Console.ForegroundColor = ConsoleColor.Gray);
            Console.ReadKey(true);
        }
        static bool Elevate()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent()) // get actual permission
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                if(!principal.IsInRole(WindowsBuiltInRole.Administrator)) // if not administrator
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
