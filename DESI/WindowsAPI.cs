using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowAPI
{
    public class vars
    {
        public static string CurrentMessage = String.Empty;
        public static int CurrentStatus = 0;
    }
    public class consts
    {
        // Constant value was found in the "windows.h" header file.
        public const int 
            WM_ACTIVATEAPP = 0x001C
        ,   WM_CLOSE = 0x0010
        ,   WS_CHILD = 0x40000000
        ,   WS_VISIBLE = 0x10000000
            /* ms-help://MS.VSCC.v90/MS.MSDNQTR.v90.en/winui/winui/windowsuserinterface/windowing/windows/windowreference/windowfunctions/showwindow.htm
             * ShowWindow() Commands
             */
        ,   SW_HIDE = 0
        ,   SW_SHOWNORMAL = 1
        ,   SW_NORMAL = 1
        ,   SW_SHOWMINIMIZED = 2
        ,   SW_SHOWMAXIMIZED = 3
        ,   SW_MAXIMIZE = 3
        ,   SW_SHOWNOACTIVATE = 4
        ,   SW_SHOW = 5
        ,   SW_MINIMIZE = 6
        ,   SW_SHOWMINNOACTIVE = 7
        ,   SW_SHOWNA = 8
        ,   SW_RESTORE = 9
        ,   SW_SHOWDEFAULT = 10
        ,   SW_FORCEMINIMIZE = 11
        ,   SW_MAX = 11
        // User
        ,   WM_USER = 0x0400
        ,   WM_DESI = WM_USER + 1;
    }

    /*public class structure
    {
        public struct LPSTARTUPINFO 
        {  
            DWORD cb;  
            LPTSTR lpReserved;  
            LPTSTR lpDesktop;  
            LPTSTR lpTitle;  
            DWORD dwX;  
            DWORD dwY;  
            DWORD dwXSize;  
            DWORD dwYSize;  
            DWORD dwXCountChars;  
            DWORD dwYCountChars;  
            DWORD dwFillAttribute;  
            DWORD dwFlags;  
            WORD wShowWindow;  
            WORD cbReserved2;  
            LPBYTE lpReserved2;  
            HANDLE hStdInput;  
            HANDLE hStdOutput;  
            HANDLE hStdError;
        };
    }*/

    public class user32
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, long lParam);
        [DllImport("user32.dll")]
        public static extern int GetWindow(IntPtr hWnd, uint uCmd);
        [DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll")]
        public static extern int FindWindow(StringBuilder lpClassName, StringBuilder lpWindow);
        [DllImport("user32.dll")]
        public static extern bool DestroyWindow(IntPtr hWnd);
        // Constant values were found in the "windows.h" header file.
    }
  
   /* public class kernel32
    {
        [DllImport("kernel32.dll")]
        public static extern bool CreateProcess(
            LPCTSTR lpApplicationName,             // Module name .__in
            LPTSTR lpCommandLine,          // Command line.__in_out
            LPSECURITY_ATTRIBUTES lpProcessAttributes,             // Process handle not inheritable. __in
            LPSECURITY_ATTRIBUTES lpThreadAttributes,             // Thread handle not inheritable. __in
            bool bInheritHandles,            // Set handle inheritance to FALSE. __in
            DWORD dwCreationFlags,                // No creation flags. __in
            LPVOID lpEnvironment,             // Use parent's environment block. __in
            LPCTSTR lpCurrentDirectory,             // Use parent's starting directory. __in
            LPSTARTUPINFO lpStartupInfo,            // Pointer to STARTUPINFO structure. __in
            LPPROCESS_INFORMATION lpProcessInformation);          // Pointer to PROCESS_INFORMATION structure. __out

        // Constant values were found in the "windows.h" header file.

    }*/
}