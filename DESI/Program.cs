using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Text;

namespace DESI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            bool AlreadyIs = false; // mutexWasCreated
            /*
            const string mutexName = "DESI";
            Mutex m = null;
            m = new Mutex(true, mutexName, out AlreadyIs);
            // */

            StringBuilder lpClassName = new StringBuilder("MainForm");
            lpClassName = null;
            StringBuilder lpWindow = new StringBuilder(MainForm.MainFormCaption);
            //lpWindow = null;
            IntPtr hWnd = new IntPtr(WindowAPI.user32.FindWindow(lpClassName, lpWindow));
            
            if ((int)hWnd != 0)
                AlreadyIs = true;

            if (AlreadyIs)
            {
                // */
                //MessageBox.Show("Приложение уже запущено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                //WindowAPI.user32.ShowWindow(hWnd, WindowAPI.consts.SW_FORCEMINIMIZE);
                WindowAPI.user32.ShowWindow(hWnd, WindowAPI.consts.SW_SHOWDEFAULT);
                WindowAPI.user32.SendMessage(hWnd, WindowAPI.consts.WM_USER, (uint)101, (long)0);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
