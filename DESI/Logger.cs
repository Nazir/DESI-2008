using System;
using System.IO;

namespace Logger
{
    public partial class Log
    {
        public static string LogPath = @"d:\DESI\logs\";
        public static string LogFileExt = ".log";
        public static string LogName = String.Empty;
        public static string LogFile = String.Empty;
        public static string AppName = String.Empty;

        public static void SaveLog(string ALogName, string ALogText, string ALogStatus)
        {
            if (LogName == String.Empty)
            {
                LogName = DateTime.Today.ToString("yyyyMMdd");
                if (AppName != String.Empty)
                    LogName += "_" + AppName;
            }
            if (LogFile == String.Empty)
                LogFile = LogPath + LogName + LogFileExt;
            string LogTime = Convert.ToString(DateTime.Now);
            if (true)
            {
                Utils.Util.SaveTextToFile(LogTime + " " + ALogName + " " + ALogStatus + " " + AppName + " " + ALogText + "\r\n", LogFile, true);
            }
        }
    }
 }
