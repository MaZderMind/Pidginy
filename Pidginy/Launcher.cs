using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Pidginy
{
    class Launcher
    {
        private const int SW_RESTORE = 9;

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);

        #region Singleton
        private static Launcher theInstance;

        public static Launcher getInstance()
        {
            if (theInstance == null)
            {
                theInstance = new Launcher();
            }

            return theInstance;
        }
        #endregion

        private Launcher()
        {

        }

        public bool CanLaunch(string protocol)
        {
            switch (protocol)
            {
                case "prpl-jabber":
                    return true;

                default:
                    return false;
            }
        }

        public void Launch(string protocol, string name)
        {
            switch (protocol)
            {
                case "prpl-jabber":
                    Process.Start("xmpp:" + name);
                    BringPidginToForeground();
                    break;

                default:
                    throw new NotImplementedException("Protocol "+protocol+" cannot be launched");
            }
        }

        private void BringPidginToForeground()
        {
            Process[] processes = Process.GetProcessesByName("pidgin");
            Console.Write(processes.Length + " processes");
            foreach(Process process in processes)
            {
                IntPtr handle = process.MainWindowHandle;
                if (handle == IntPtr.Zero)
                    continue;

                if (IsIconic(handle))
                {
                    ShowWindow(handle, SW_RESTORE);
                }

                SetForegroundWindow(handle);
            }
        }
    }
}
