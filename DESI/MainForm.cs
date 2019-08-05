using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.IO;
using System.Threading;

namespace DESI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.Exit);
        }

        public const string MainFormCaption = "Система обмена данными \"Интеркама\"";
        private bool appActive = true;
        private bool CanExit = true;
        private bool AutoStart = false;
        private bool DebugMode = true;
        public static string CurrentStartMode = String.Empty;

        public static string EqConnectionString = String.Empty;
        public static string EqUnit = String.Empty;
        public static string AccountsFileExt = String.Empty; // ".acc";
        public static string[] AccountType;
        public static string[] AccountFile;
        public static string[] AccountSQL;
        public static string[] AccountResultFile;
        public static string[] AccountDB;
        public static int AccountIndex;
        public static string AccFile = String.Empty; // "iBank";
        public static string WorkPath = String.Empty;// @"e:\EqDES_Work\";
        public static string AppPath = String.Empty;
        public static string AppName = String.Empty;
        public static string UserLogFile = String.Empty; //WorkPath + "log.txt";
        public static string SettingsFile = String.Empty; //WorkPath + "DESI.xml";
        public static string ResultFile = String.Empty;
        public static string ResultFileStartAfter = String.Empty;
        public static string ResultFileStartAfterArguments = String.Empty;
        public static string ResultFileStartBefore = String.Empty;
        public static string ResultFileStartBeforeArguments = String.Empty;
        public static string ResultFileSQL = String.Empty;
        public static string ResultFileDivider = String.Empty;
        public static string ResultFileDividerFirst = String.Empty;
        public static string ResultFileDividerLast = String.Empty;
        public static string ResultFileEncoding = String.Empty;
        public static string ResultFileFormatDate = String.Empty;
        public static string ResultFileFormatMoney = String.Empty;
        public static string ResultFileFormatDebit = String.Empty;
        public static string ResultFileFormatCredit = String.Empty;
        public static bool ResultFileShowCaptions = false;
        public static bool ResultFileFormatFields = false;
        public static bool ResultFileTrimFields = false;
        public static string ResultFileNextLine = String.Empty;
        public static string ResultFileEOF = String.Empty;
        public static string EqDateFormat = String.Empty; //"yyyyMMdd";
        public static string SQLDateFormat = String.Empty; //"dd.MM.yyyy";
        public static DateTime StartDate = DateTime.Now; //"20081110";
        public static DateTime LastDate = DateTime.Now; //"20081110";
        public static DateTime LastStarted_RUN_5;
        public static DateTime AutoStarted;
        public static ListView lvTemp;

        public static string ProcessFormInfo = String.Empty;
        public static IntPtr ProcessFormHandle;

        // Determine whether Windows XP or a later
        // operating system is present.
        private bool isRunningXPOrLater =
            OSFeature.Feature.IsPresent(OSFeature.Themes);

        // Declare a Hashtable array in which to store the groups.
        private Hashtable[] groupTables;

        // Declare a variable to store the current grouping column.
        int groupColumn = 0;

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            this.Text = MainFormCaption;
            FileInfo fi = new FileInfo(Application.ExecutablePath);
            AppPath = fi.DirectoryName + @"\";
            AppName = fi.Name;
            // Настройка фала логов
            Logger.Log.LogPath = AppPath + @"logs\";
            if (!Directory.Exists(Logger.Log.LogPath))
                Directory.CreateDirectory(Logger.Log.LogPath);
            Logger.Log.AppName = AppName;
            // ^ Настройка фала логов

            string Temp = String.Empty;
            Temp = "Старт приложения: «" + Environment.CommandLine + "»";
            Temp += " [Версия продукта: " + Application.ProductVersion + "]";
            Temp += " [Имя пользователя: " + Environment.UserName + "]";
            Temp += " [OS Version: " + Environment.OSVersion + "]";
            Temp += " [Machine Name: " + Environment.MachineName + "]";
            if (Environment.OSVersion.Version.Major > 4)
                Temp += " [User Domain Name: " + Environment.UserDomainName + "]";
            Logger.Log.SaveLog("Main", Temp, "inf");

            //
                //Environment.CommandLine
            String[] arguments = Environment.GetCommandLineArgs();
            //MessageBox.Show(String.Join(", ", arguments));

            SettingsFile = String.Empty;
            if (arguments.Length > 1)
            {
                SettingsFile = arguments[1].ToString();
                if (!File.Exists(SettingsFile))
                {
                    if (!Path.IsPathRooted(SettingsFile))
                    {
                        SettingsFile = AppPath + SettingsFile;
                    }

                }
            }
            if ((SettingsFile == String.Empty) || (!File.Exists(SettingsFile)))
            {
                SettingsFile = AppPath + Path.GetFileNameWithoutExtension(AppName) + ".xml";
            }

            Logger.Log.SaveLog("Main", "Чтение настроек из файла: «" + SettingsFile + "»", "inf");
            DESI.RootNode = "//" + Path.GetFileNameWithoutExtension(AppName);
            if (!DESI.InitXML(SettingsFile))
            {
                string sTemp = "Основной файл «" + SettingsFile + "» с настройками не найден! Прииложение будет закрыто...";
                Logger.Log.SaveLog("Main", sTemp, "err");
                MessageBox.Show(sTemp, "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            DebugMode = DESI.GetBooleanValue("DebugMode", "");
            AutoStart = DESI.GetBooleanAttribute("Enabled", "AutoStart", "");
            timer_RUN_5.Interval = DESI.GetIntValue("Interval", "AutoStart");

            AutoStart = !AutoStart;
            ChangeAutoStart(sender, e);

            AccountsFileExt = DESI.GetAttribute("Ext", "Accounts", "");

            WorkPath = DESI.GetValue("WorkPath", "");
            if (!Path.IsPathRooted(WorkPath))
                WorkPath = AppPath + WorkPath;

            if (!Directory.Exists(WorkPath))
            {
                string sTemp = "Рабочий каталог «" + WorkPath + "» не найден! Прииложение будет закрыто...";
                Logger.Log.SaveLog("Main", sTemp, "err");
                MessageBox.Show(sTemp, "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            UserLogFile = WorkPath + DESI.GetValue("UserLogFile", "");
            if (File.Exists(UserLogFile))
                File.Delete(UserLogFile);

            EqDateFormat = DESI.GetValue("DateFormat", "DB/Equation");
            EqUnit = DESI.GetValue("Unit", "DB/Equation"); //"ABO";

            // ODBC MisysEquation IBM DB2 
            //Logger.Log.SaveLog("Main", "Получение ConnectionString для «ODBC MisysEquation IBM DB2»", "inf");
            OdbcConnectionStringBuilder builder =
                new OdbcConnectionStringBuilder();
            builder.Clear();
            // {Client Access ODBC Driver (32-bit)};System=my_system_name;Uid=myUserName;Pwd=myPwd"
            builder.Dsn = DESI.GetValue("Dsn", "DB/Equation"); // "Equation" or "ibank to eq";
            //builder.Driver = "{Client Access ODBC Driver (32-bit)}";
            //builder.Add("System", DESI.GetValue("IP", "/DB/Equation/")); // "192.168.9.179"
            builder.Add("Uid", "DB06"); // DESI.GetValue("Uid", "/DB/Equation/")
            builder.Add("Pwd", "zx4dF"); // DESI.GetValue("Pwd", "/DB/Equation/")
            EqConnectionString = builder.ConnectionString;

            //
            int Count = DESI.GetChildNodesCount("Accounts", "");
            AccountType = new string[Count];
            AccountFile = new string[Count];
            AccountSQL = new string[Count];
            AccountResultFile = new string[Count];
            AccountDB = new string[Count];
            for (int iCounter = 0; iCounter < Count; iCounter++)
            {
                AccountType[iCounter] = DESI.GetAttribute("Type", "", "Accounts", iCounter);
                AccountFile[iCounter] = DESI.GetAttribute("Name", "", "Accounts", iCounter);
                AccountResultFile[iCounter] = DESI.GetAttribute("ResultFile", "", "Accounts", iCounter);
                if (AccountType[iCounter] == "SQL")
                {
                    AccountDB[iCounter] = DESI.GetAttribute("DB", "", "Accounts", iCounter);
                    AccountSQL[iCounter] = DESI.GetValue("", "Accounts", iCounter);
                }
                comboBox_AccountsList.Items.Insert(iCounter, DESI.GetAttribute("Description", "", "Accounts", iCounter)
                    + " [" + AccountFile[iCounter] + "]"
                    + " {" + AccountType[iCounter] + "}");
            }

            if (comboBox_AccountsList.Items.Count > 0)
                comboBox_AccountsList.SelectedIndex = 0;

            dateTimePicker_StartDate.Value = DateTime.Today;
            dateTimePicker_LastDate.Value = DateTime.Today;
            
            //
            LastStarted_RUN_5 = DateTime.Today;
            LastStarted_RUN_5 = LastStarted_RUN_5.AddHours(DateTime.Now.Hour);
            LastStarted_RUN_5 = LastStarted_RUN_5.AddMinutes(DateTime.Now.Minute);

            lvTemp = new ListView();
            lvTemp.SmallImageList = listView_Events.SmallImageList;
            for (int iCounter = 0; iCounter < listView_Events.Columns.Count; iCounter++)
            {
                lvTemp.Columns.Add(new ColumnHeader());
            }

            if (!DebugMode)
                return;

            // 
            //listView_Events.Sorting = SortOrder.Ascending;

            // Create and initialize column headers for listView_Events.
            
            ColumnHeader columnHeader0 = new ColumnHeader();
            columnHeader0.Text = "Title";
            columnHeader0.Width = 400;
            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Author";
            columnHeader1.Width = 200;
            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Year";
            columnHeader2.Width = 50;

            // Add the column headers to listView_Events.
            listView_Events.Columns.AddRange(new ColumnHeader[] { columnHeader0, columnHeader1, columnHeader2 });

            // Add a handler for the ColumnClick event.
            listView_Events.ColumnClick +=
                new ColumnClickEventHandler(listView_Events_ColumnClick);

            // Create items and add them to listView_Events.
            ListViewItem item0 = new ListViewItem(new string[] 
            {"Programming Windows", 
            "Petzold, Charles", 
            "1998"});
            ListViewItem item1 = new ListViewItem(new string[] 
            {"Code: The Hidden Language of Computer Hardware and Software", 
            "Petzold, Charles", 
            "2000"});
            ListViewItem item2 = new ListViewItem(new string[] 
            {"Programming Windows with C#", 
            "Petzold, Charles", 
            "2001"});
            ListViewItem item3 = new ListViewItem(new string[] 
            {"Coding Techniques for Microsoft Visual Basic .NET", 
            "Connell, John", 
            "2001"});
            ListViewItem item4 = new ListViewItem(new string[] 
            {"C# for Java Developers", 
            "Jones, Allen & Freeman, Adam", 
            "2002"});
            ListViewItem item5 = new ListViewItem(new string[] 
            {"Microsoft .NET XML Web Services Step by Step", 
            "Jones, Allen & Freeman, Adam", 
            "2002"});
            listView_Events.Items.AddRange(
                new ListViewItem[] { item0, item1, item2, item3, item4, item5 });

            if (isRunningXPOrLater)
            {
                // Create the groupsTable array and populate it with one 
                // hash table for each column.
                groupTables = new Hashtable[listView_Events.Columns.Count];
                for (int column = 0; column < listView_Events.Columns.Count; column++)
                {
                    // Create a hash table containing all the groups 
                    // needed for a single column.
                    groupTables[column] = CreateGroupsTable(column);
                }

                // Start with the groups created for the Title column.
                SetGroups(0);
            }
        }

        private void listView_Events_ColumnClick(
            object sender, ColumnClickEventArgs e)
        {
            // Set the sort order to ascending when changing
            // column groups; otherwise, reverse the sort order.
            if (listView_Events.Sorting == SortOrder.Descending ||
                (isRunningXPOrLater && (e.Column != groupColumn)))
            {
                listView_Events.Sorting = SortOrder.Ascending;
            }
            else
            {
                listView_Events.Sorting = SortOrder.Descending;
            }
            groupColumn = e.Column;

            // Set the groups to those created for the clicked column.
            if (isRunningXPOrLater)
            {
                SetGroups(e.Column);
            }
        }

        // Sets listView_Events to the groups created for the specified column.
        private void SetGroups(int column)
        {
            // Remove the current groups.
            listView_Events.Groups.Clear();

            // Retrieve the hash table corresponding to the column.
            Hashtable groups = (Hashtable)groupTables[column];

            // Copy the groups for the column to an array.
            ListViewGroup[] groupsArray = new ListViewGroup[groups.Count];
            groups.Values.CopyTo(groupsArray, 0);

            // Sort the groups and add them to listView_Events.
            Array.Sort(groupsArray, new ListViewGroupSorter(listView_Events.Sorting));
            listView_Events.Groups.AddRange(groupsArray);

            // Iterate through the items in listView_Events, assigning each 
            // one to the appropriate group.
            foreach (ListViewItem item in listView_Events.Items)
            {
                // Retrieve the subitem text corresponding to the column.
                string subItemText = item.SubItems[column].Text;

                // For the Title column, use only the first letter.
                if (column == 0)
                {
                    subItemText = subItemText.Substring(0, 1);
                }

                // Assign the item to the matching group.
                item.Group = (ListViewGroup)groups[subItemText];
            }
        }

        // Creates a Hashtable object with one entry for each unique
        // subitem value (or initial letter for the parent item)
        // in the specified column.
        private Hashtable CreateGroupsTable(int column)
        {
            // Create a Hashtable object.
            Hashtable groups = new Hashtable();

            // Iterate through the items in listView_Events.
            foreach (ListViewItem item in listView_Events.Items)
            {
                // Retrieve the text value for the column.
                string subItemText = item.SubItems[column].Text;

                // Use the initial letter instead if it is the first column.
                if (column == 0)
                {
                    subItemText = subItemText.Substring(0, 1);
                }

                // If the groups table does not already contain a group
                // for the subItemText value, add a new group using the 
                // subItemText value for the group header and Hashtable key.
                if (!groups.Contains(subItemText))
                {
                    groups.Add(subItemText, new ListViewGroup(subItemText,
                        HorizontalAlignment.Left));
                }
            }

            // Return the Hashtable object.
            return groups;
        }

        // Sorts ListViewGroup objects by header value.
        private class ListViewGroupSorter : IComparer
        {
            private SortOrder order;

            // Stores the sort order.
            public ListViewGroupSorter(SortOrder theOrder)
            {
                order = theOrder;
            }

            // Compares the groups by header value, using the saved sort
            // order to return the correct value.
            public int Compare(object x, object y)
            {
                int result = String.Compare(
                    ((ListViewGroup)x).Header,
                    ((ListViewGroup)y).Header
                );
                if (order == SortOrder.Ascending)
                {
                    return result;
                }
                else
                {
                    return -result;
                }
            }
        }

        private void Exit(Object sender, CancelEventArgs e)
        {
            if (!CanExit)
            {
                e.Cancel = true;
                if (MessageBox.Show("Выйти из программы?", "Выход",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                      == DialogResult.Yes)
                {
                    e.Cancel = false;
                    Logger.Log.SaveLog("Main", "Закрытие приложения: «" + Application.ExecutablePath + "»", "inf");
                    Application.Exit();
                }
            }
            else
            {
                Logger.Log.SaveLog("Main", "Закрытие приложения: «" + Application.ExecutablePath + "»", "inf");
                e.Cancel = false;
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
           
        }

        private void ExitClick(object sender, EventArgs e)
        {
            Close();
            /*
            ProgressForm pf = new ProgressForm();

            pf.CanClose = true;
            pf.Show();


           // bool res = WindowAPI.user32.DestroyWindow(Convert.ToUInt32(pf.Handle.ToInt32()));
            WindowAPI.user32.SendMessage(pf.Handle, WindowAPI.user32.WM_CLOSE);
            */
        }

        private void AccountsFillFromSQL()
        {
            CanExit = false;

            string Result = String.Empty;
            string queryString = String.Empty;
            string Temp = String.Empty;
            
            Logger.Log.SaveLog("AccountsFillFromSQL", "Заливка счетов из системы «" + AccountDB[AccountIndex] + "»", "inf");
            SaveLog("Заливка счетов из системы «" + AccountDB[AccountIndex] + "»", "AccountsFillFromSQL", "inf", true, false, true, 1);

            queryString = AccountSQL[AccountIndex];
            
            if (queryString != String.Empty)
            {
                OdbcConnectionStringBuilder builder =
                    new OdbcConnectionStringBuilder();
                // ODBC Microsoft SQL Server 2000
                //Logger.Log.SaveLog("Main", "Получение ConnectionString для «ODBC «" + AccountDB[AccountIndex] + "» Microsoft SQL Server 2000»", "inf");

                builder.Clear();
                builder.Dsn = DESI.GetValue("Dsn", "DB/" + AccountDB[AccountIndex]); //"iBank";
                builder.Add("Uid", "equsr"); // DESI.GetValue("Uid", "DB/" + AccountDB[AccountIndex]); 
                builder.Add("Pwd", "zx4dF"); // DESI.GetValue("Pwd", "DB/" + AccountDB[AccountIndex]); 

                using (OdbcConnection connection = new OdbcConnection(builder.ConnectionString))
                {
                    OdbcCommand command = new OdbcCommand();
                    command.Connection = connection;
                    if (queryString == String.Empty)
                        return;
                        //queryString = "select 40702810106020001731";
                    command.CommandText = queryString;
                    try
                    {
                        SaveLog("Подключение к системе «" + AccountDB[AccountIndex] + "» через ODBC", "AccountsFillFromSQL", "inf", true, false, true, 1);
                        connection.Open();
                        command.Prepare();
                        SaveLog("Подключение к системе «" + AccountDB[AccountIndex] + "» через ODBC - прошло УСПЕШНО", "AccountsFillFromSQL", "inf", true, false, true, 1);
                    }
                    catch (InvalidOperationException e)
                    {
                        CanExit = true;
                        Temp = e.ToString();
                        SaveLog("Ошибка (InvalidOperationException): «" + Temp + "»", "AccountsFillFromSQL", "err", true, false, false, -1);
                        SaveLog("Ошибка подключения!!! Обратитесь к разработчикам!", "AccountsFillFromSQL", "err", false, true, false, -1);
                    }
                    catch (Exception e)
                    {
                        CanExit = true;
                        Temp = e.ToString();
                        SaveLog("Ошибка (InvalidOperationException): «" + Temp + "»", "AccountsFillFromSQL", "err", true, false, false, -1);
                        SaveLog("Ошибка подключения!!! Обратитесь к разработчикам!", "AccountsFillFromSQL", "err", false, true, false, -1);
                    }
                    if (!CanExit)
                    {
                        try
                        {
                            Temp = "";
                            Result = "";
                            Logger.Log.SaveLog("AccountsFillFromSQL", "Заливка данных.", "inf");
                            //40702810106020001731
                            //"40702810106020001731";
                            //"40603810906020006899";

                            if (File.Exists(AccFile))
                            {
                                File.Delete(AccFile);
                            }

                            Logger.Log.SaveLog("AccountsFillFromSQL", "Заливка счетов в файл «" + AccFile + "»", "inf");
                            SaveLog("Заливка данных в файл «" + AccFile + "»", "AccountsFillFromSQL", "inf", true, false, true, -1);
                            using (StreamWriter sw = File.CreateText(AccFile))
                            {
                                OdbcDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                                //command.ExecuteNonQuery();
                                while (reader.Read())
                                {
                                    sw.WriteLine(reader[0].ToString());

                                }
                                reader.Close();
                                Result = sw.ToString();
                            }
                        }
                        catch (Exception e)
                        {
                            Result = e.ToString();
                            SaveLog("Ошибка (Exception): " + Result, "AccountsFillFromSQL", "err", true, false, false, 1);
                            SaveLog("Ошибка при получении списка счетов!", "AccountsFillFromSQL", "err", false, true, true, -1);
                            CanExit = true;
                        }
                        SaveLog("Заливка данных в файл «" + AccFile + "»  - прошло УСПЕШНО!", "AccountsFillFromSQL", "inf", true, false, true, 1);
                    }
                }
            }
            if ((CanExit) && (DebugMode))
                MessageBox.Show(Result.Trim());
            CanExit = true;
        }

        private void GetResultFile(string Name)
        {
            int Count = DESI.GetChildNodesCount("Results", "");
            for (int iCounter = 0; iCounter < Count; iCounter++)
            {
                if (DESI.GetAttribute("Name", "", "Results", iCounter) == Name)
                {
                    ResultFile = DESI.GetValue("FileName", "Results", iCounter);
                    if (!Path.IsPathRooted(ResultFile))
                        ResultFile = WorkPath + ResultFile;
                    ResultFileStartBefore = DESI.GetValue("StartBefore", "Results", iCounter);
                    ResultFileStartAfter = DESI.GetValue("StartAfter", "Results", iCounter);
                    ResultFileStartBeforeArguments = DESI.GetAttribute("Arguments", "StartBefore", "Results", iCounter);
                    ResultFileStartAfterArguments = DESI.GetAttribute("Arguments", "StartAfter", "Results", iCounter);
                    ResultFileSQL = DESI.GetValue("SQL", "Results", iCounter);
                    ResultFileEncoding = DESI.GetAttribute("Encoding", "", "Results", iCounter);
                    ResultFileFormatDate = DESI.GetValue("FormatDate", "Results", iCounter);
                    ResultFileFormatMoney = DESI.GetValue("FormatMoney", "Results", iCounter);
                    ResultFileFormatDebit = DESI.GetValue("FormatDebit", "Results", iCounter);
                    ResultFileFormatCredit = DESI.GetValue("FormatCredit", "Results", iCounter);
                    ResultFileTrimFields = Convert.ToBoolean(DESI.GetValue("TrimFields", "Results", iCounter));
                    ResultFileShowCaptions = Convert.ToBoolean(DESI.GetValue("ShowCaptions", "Results", iCounter));
                    ResultFileFormatFields = Convert.ToBoolean(DESI.GetValue("FormatFields", "Results", iCounter)); 
                    ResultFileDivider = DESI.GetValue("Divider", "Results", iCounter); 
                    ResultFileDivider = ResultFileDivider.Replace("#9", "\t");
                    ResultFileDivider = ResultFileDivider.Replace("#10", "\n");
                    ResultFileDivider = ResultFileDivider.Replace("#13", "\r");
                    ResultFileDividerFirst = DESI.GetValue("DividerFirst", "Results", iCounter); 
                    ResultFileDividerFirst = ResultFileDividerFirst.Replace("#9", "\t");
                    ResultFileDividerFirst = ResultFileDividerFirst.Replace("#10", "\n");
                    ResultFileDividerFirst = ResultFileDividerFirst.Replace("#13", "\r");
                    ResultFileDividerLast = DESI.GetValue("DividerLast", "Results", iCounter); 
                    ResultFileDividerLast = ResultFileDividerLast.Replace("#9", "\t");
                    ResultFileDividerLast = ResultFileDividerLast.Replace("#10", "\n");
                    ResultFileDividerLast = ResultFileDividerLast.Replace("#13", "\r");
                    ResultFileNextLine = DESI.GetValue("NextLine", "Results", iCounter);
                    ResultFileNextLine = ResultFileNextLine.Replace("#9", "\t");
                    ResultFileNextLine = ResultFileNextLine.Replace("#10", "\n");
                    ResultFileNextLine = ResultFileNextLine.Replace("#13", "\r");
                    ResultFileEOF = DESI.GetValue("EOF", "Results", iCounter); 
                    ResultFileEOF = ResultFileEOF.Replace("#9", "\t");
                    ResultFileEOF = ResultFileEOF.Replace("#10", "\n");
                    ResultFileEOF = ResultFileEOF.Replace("#13", "\r");
                    break;
                }
            }
        }

        public void SaveLog(string Msg, string LogName, string LogStatus, bool FullLog, bool UserLog, bool ProgressLog, int ProgressValue)
        {
            int iLogStatus = 0;
            if (LogStatus == "inf")
                iLogStatus = 0;
            if (LogStatus == "wrn")
                iLogStatus = 1;
            if (LogStatus == "err")
                iLogStatus = 2;
            if (FullLog)
                Logger.Log.SaveLog(LogName, Msg, LogStatus);
            if (UserLog)
            {
                ListViewItem item = new ListViewItem("", iLogStatus);
                item.SubItems.Add(DateTime.Now.ToShortDateString());
                item.SubItems.Add(DateTime.Now.ToLongTimeString());
                item.SubItems.Add(Msg);
                lvTemp.Items.AddRange(new ListViewItem[] { item });
                if (!File.Exists(UserLogFile))
                {
                    using (StreamWriter sw = File.CreateText(UserLogFile))
                        sw.Write("");
                }
                using (StreamWriter sw = File.AppendText(UserLogFile))
                    sw.WriteLine(Msg);

            }
            if (ProgressLog)
                ToProgress(Msg, 1, ProgressValue, iLogStatus);

            if (ProgressValue > 0)
                ToProgress("", 2, ProgressValue, iLogStatus);

            if (ProgressValue < 0)
                ToProgress("", 100, ProgressValue, iLogStatus);
        }

        public void ToProgress(string Msg, int ProgressType, int ProgressValue, int LogStatus)
        {
           WindowAPI.vars.CurrentMessage = Msg;
           WindowAPI.vars.CurrentStatus = LogStatus;
           WindowAPI.user32.SendMessage(ProcessFormHandle, WindowAPI.consts.WM_USER, (uint)ProgressType, (long)ProgressValue);
        }

        private void RUN_5()
        {
            ToProgress("", 3, 3, 0);
            ToProgress("", 4, 0, 0);
            SaveLog("НАЧАЛО: RUN_5 - " + CurrentStartMode, "RUN_5", "inf", true, false, false, 0);
            string Temp = String.Empty;
            Temp = "Ручной";
            if (CurrentStartMode == "Auto")
                Temp = "Автоматичекий";
            Temp += " запуск процедуры ";
            Temp += "«" + DESI.GetChildValue("Description", "Procedure", "name", "RUN_5") + "»";
            SaveLog(Temp, "RUN_5", "inf", false, true, true, 0);
            CanExit = false;

            string Result = String.Empty;
            string queryString = String.Empty;
            Temp = String.Empty;
            int NotFoundCount = 0;
            int NotLoadedCount = 0;
            int AccCount = 0;
            int RowsCount = 0;

            if (File.Exists(ResultFile))
                File.Delete(ResultFile);

            if (AccountType[AccountIndex] == "SQL")
            {
                AccountsFillFromSQL();
                CanExit = false;
            }
            if (!File.Exists(AccFile))
            {
                CanExit = true;
                SaveLog("Файл со счетами «" + AccFile + "» не найден!", "RUN_5", "err", true, true, false, -1);
            }
            if (!CanExit)
            {
                SaveLog("Подключение к системе MisysEquation через ODBC", "RUN_5", "inf", true, false, false, 1);
                using (OdbcConnection connection = new OdbcConnection(EqConnectionString))
                {
                    //string queryString = "select * from sysibm.sysdummy1";
                    // ===== 5.1 Процедура Актуализация «юнита» =========================
                    OdbcCommand command = new OdbcCommand();
                    command.Connection = connection;
                    //command.CommandType = CommandType.StoredProcedure;
                    //command.CommandText = "BSS_Create_Table";
                    queryString = "CALL KLIB" + EqUnit + ".BSS_Create_Table (?, ?)";
                    command.CommandText = queryString;
                    command.Parameters.Clear();
                    command.Parameters.Add("iUnit", OdbcType.Char, 3).Value = EqUnit;
                    command.Parameters["iUnit"].Direction = ParameterDirection.Input;
                    command.Parameters.Add("oError", OdbcType.Char, 37).Value = null;
                    command.Parameters["oError"].Direction = ParameterDirection.Output;
                    try
                    {
                        connection.Open();
                        command.Prepare();
                    }
                    catch (InvalidOperationException e)
                    {
                        Temp = e.ToString();
                        CanExit = true;
                        SaveLog("Ошибка (InvalidOperationException): «" + Temp + "»", "RUN_5", "err", true, false, false, -1);
                        SaveLog("Ошибка подключения!!! Обратитесь к разработчикам!", "RUN_5", "err", false, true, false, -1);
                    }
                    catch (Exception e)
                    {
                        Temp = e.ToString();
                        CanExit = true;
                        SaveLog("Ошибка (Exception): «" + Temp + "»", "RUN_5", "err", true, false, false, -1);
                        SaveLog("Ошибка подключения!!! Обратитесь к разработчикам!", "RUN_5", "err", false, true, false, -1);
                    }
                    if (!CanExit)
                    {
                        SaveLog("5.1 Процедура Актуализация «юнита» «" + EqUnit + "» BSS_Create_Table", "RUN_5", "inf", true, false, true, 1);
                        command.ExecuteNonQuery();

                        Result = Convert.ToString(command.Parameters["oError"].Value);
                        //MessageBox.Show(Result.Trim() + " - " + Convert.ToString(command.Parameters["oResultInfo"].Value));
                        string delim = "\0";
                        if (Result.Trim(delim.ToCharArray()) != "")
                        {
                            Result = Result.Trim() + " - " + Convert.ToString(command.Parameters["oResultInfo"].Value);
                            CanExit = true;
                            SaveLog("BSS_Create_Table: «" + Result + "»", "RUN_5", "wrn", true, true, true, -1);
                        }
                        // ====== 5.2 Процедура загрузки счетов =============================
                        if ((!CanExit) && (File.Exists(AccFile)))
                        {
                            FileInfo fi = new FileInfo(AccFile);
                            using (StreamReader sr = new StreamReader(AccFile))
                            {
                                SaveLog("5.2 Процедура загрузки счетов из файла «" + AccFile + "» BSS_LOAD_ACC", "RUN_5", "inf", true, false, true, 1);
                                ToProgress("", 4, 0, 0);
                                ToProgress("", 3, (int)(fi.Length + 2) / 22, 0);
                                queryString = "CALL KLIB" + EqUnit + ".BSS_LOAD_ACC (?, ?, ?, ?, ?)";
                                command.CommandText = queryString;
                                while (sr.Peek() >= 0)
                                {
                                    ToProgress("", 2, 1, 0);
                                    if (connection.State != ConnectionState.Open)
                                    {
                                        Temp = "Ошибка: Соединение разорвано «" + connection.State.ToString() + "» при попытке загрузки счёта «" + sr.ReadLine() + "»";
                                        SaveLog(Temp, "RUN_5", "err", true, true, true, sr.Peek());
                                        NotLoadedCount++;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            AccCount++;
                                            command.Parameters.Clear();
                                            command.Parameters.Add("iAccNum", OdbcType.Char, 20).Value = sr.ReadLine(); // "40702810106020001731";
                                            command.Parameters["iAccNum"].Direction = ParameterDirection.Input;
                                            command.Parameters.Add("iStartDate", OdbcType.Char, 8).Value = StartDate.ToString(EqDateFormat);
                                            command.Parameters["iStartDate"].Direction = ParameterDirection.Input;
                                            command.Parameters.Add("iLastDate", OdbcType.Char, 8).Value = LastDate.ToString(EqDateFormat);
                                            command.Parameters["iLastDate"].Direction = ParameterDirection.Input;
                                            command.Parameters.Add("oResultCode", OdbcType.Char, 15).Value = null;
                                            command.Parameters["oResultCode"].Direction = ParameterDirection.Output;
                                            command.Parameters.Add("oResultInfo", OdbcType.Char, 255).Value = null;
                                            command.Parameters["oResultInfo"].Direction = ParameterDirection.Output;
                                            command.Prepare();
                                            command.ExecuteNonQuery();

                                            Result = Convert.ToString(command.Parameters["oResultCode"].Value);
                                            if (Convert.ToInt32(Result.Trim()) != 0)
                                            {
                                                if (Convert.ToInt32(Result.Trim()) == 3)
                                                {
                                                    NotFoundCount++;
                                                }
                                                else
                                                {
                                                    CanExit = true;
                                                    SaveLog("", "RUN_5", "err", false, false, false, -1);
                                                }
                                                Result = Result.Trim() + " - " + Convert.ToString(command.Parameters["oResultInfo"].Value);
                                                SaveLog("BSS_LOAD_ACC: «" + Result.Trim() + "»", "RUN_5", "wrn", true, true, true, 0);
                                            }
                                            Result = String.Empty;
                                        }
                                        catch (InvalidOperationException e)
                                        {
                                            NotLoadedCount++;
                                            Temp = e.ToString();
                                            SaveLog("Ошибка (InvalidOperationException): «" + Temp + "» при попытке загрузки счёта «" + sr.ReadLine() + "»", "RUN_5", "err", true, false, false, 0);
                                            SaveLog("Ошибка при попытке загрузки счёта «" + sr.ReadLine() + "»", "RUN_5", "err", false, true, true, 0);
                                            //Result = "Ошибка загрузки!!!";
                                        }
                                        catch (Exception e)
                                        {
                                            NotLoadedCount++;
                                            Temp = e.ToString();
                                            SaveLog("Ошибка (Exception): «" + Temp + "» при попытке загрузки счёта «" + sr.ReadLine() + "»", "RUN_5", "err", true, false, false, 0);
                                            SaveLog("Ошибка при попытке загрузки счёта «" + sr.ReadLine() + "»", "RUN_5", "err", false, true, true, 0);
                                            //Result = "Ошибка загрузки!!!";
                                        }
                                    }
                                }
                            }
                            if (!CanExit)
		                    {
                                ToProgress("", 3, 1, 0);
                                ToProgress("", 4, 0, 0);
                                SaveLog("5.3 Процедура формирования данных по выписке за период с «" + dateTimePicker_StartDate.Value.Date.ToShortDateString() + "» по «" + dateTimePicker_LastDate.Value.Date.ToShortDateString() + "»  BSS_FORM_VYP", "RUN_5", "inf", true, false, true, 1);
                                // ====== 5.3 Процедура формирования данных по выписке ========================
                                if (connection.State != ConnectionState.Open)
                                {
                                    Temp = "Ошибка: Соединение разорвано «" + connection.State.ToString() + "» при попытке формирования данных по выписке";
                                    SaveLog(Temp, "RUN_5", "err", true, true, false, -1);
                                }
                                else
                                {
                                    queryString = "CALL KLIB" + EqUnit + ".BSS_FORM_VYP (?, ?)";
		                            command.Parameters.Clear();
		                            command.CommandText = queryString;
		                            command.Parameters.Add("oResultCode", OdbcType.Char, 15).Value = null;
		                            command.Parameters["oResultCode"].Direction = ParameterDirection.Output;
		                            command.Parameters.Add("oResultInfo", OdbcType.Char, 255).Value = null;
		                            command.Parameters["oResultInfo"].Direction = ParameterDirection.Output;
                                    command.Prepare();
                                    command.ExecuteNonQuery();

		                            Result = Convert.ToString(command.Parameters["oResultCode"].Value);
		                            if (Convert.ToInt32(Result.Trim()) != 0)
		                            {
                                        CanExit = true;
                                        Result = Result + " - " + Convert.ToString(command.Parameters["oResultInfo"].Value);
                                        SaveLog("BSS_FORM_VYP - " + Result, "RUN_5", "err", true, true, false, -1);
		                            }
                                    if (!CanExit)
                                    {
                                        // ====== 5.4 Представления данных БД АБС с информацией по выписке ========================
                                        //queryString = "SELECT ACCOUNT, VALUEDATE, DOCNUM, DOCDATE, RECINN, RECIEVER, RECACC, RECBIC, RECCORACC, RECBANKN, DOCTYP, AMOUNT, GROUND, RECKPP, STAT1256, CBCCODE, OKATOCOD, PAYGRNDP, TAXPRERP, DOCNUMP, PAYTYPEP, DOCDATEP FROM QTEMP.Y9Q10PF WHERE RECTYP = 1";
                                        //queryString = "SELECT ACCOUNT, STATDAT, RECTYP, OPENBAL, CLOSBAL, OPENBALN, CLOSBALN, DEBETTURN, CREDITTURN, DEBETTURNN, CREDTURNN FROM QTEMP.Y9Q10PF WHERE RECTYP = 0";

                                        GetResultFile(AccountResultFile[AccountIndex]);
                                        queryString = ResultFileSQL;
                                        command.Parameters.Clear();
                                        command.CommandText = queryString;
                                        OdbcDataReader reader;
                                        SaveLog("ЗАПРОС: 5.4 Представления данных БД АБС с информацией по выписке", "RUN_5", "inf", true, false, true, 0);
                                        try
                                        {
                                            Temp = String.Empty;
                                            Result = String.Empty;
                                            command.Cancel();
                                            command.Prepare();
                                            reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                                            if (reader.HasRows)
                                            {
                                                string[] Types = new string[reader.FieldCount];
                                                string Cell = "";
                                                if (ResultFileShowCaptions)
                                                    Result += ResultFileDividerFirst;
                                                for (int iCounter = 0; iCounter < reader.FieldCount; iCounter++)
                                                {
                                                    if (ResultFileShowCaptions)
                                                    {
                                                        if (iCounter != 0)
                                                            Result += ResultFileDivider;
                                                        Result += DESI.GetFieldsValue("RUN_5", reader.GetName(iCounter), "caption");
                                                    }
                                                    if (Types[iCounter] == null)
                                                        Types[iCounter] = DESI.GetFieldsValue("RUN_5", reader.GetName(iCounter), "type");
                                                }
                                                if (ResultFileShowCaptions)
                                                    Result += ResultFileDividerLast + ResultFileNextLine;

                                                SaveLog("Заливка данных во временный файл «" + ResultFile + ".tmp»", "RUN_5", "inf", true, false, true, 0);
                                                if (File.Exists(ResultFile + ".tmp"))
                                                    File.Delete(ResultFile + ".tmp");

                                                using (StreamWriter sw = new StreamWriter(ResultFile + ".tmp", false, Encoding.GetEncoding(ResultFileEncoding)))
                                                {
                                                    sw.Write(Result);
                                                    while (reader.Read())
                                                    {
                                                        Result = String.Empty;
                                                        if (RowsCount != 0)
                                                            Result += ResultFileNextLine;
                                                        // if (ConvertDateToFormat(reader[1].ToString(), "") != "01.01.1900")
                                                        //  {
                                                        RowsCount++;
                                                        Result += ResultFileDividerFirst;
                                                        for (int iCounter = 0; iCounter < reader.FieldCount; iCounter++)
                                                        {
                                                            Cell = reader.GetString(iCounter);
                                                            if (Types[iCounter] == "string")
                                                                Cell = Cell.Replace(ResultFileDivider, " ");
                                                            Cell = Cell.Replace(ResultFileDivider, "");
                                                            if (ResultFileFormatFields)
                                                            {
                                                                if (ResultFileTrimFields)
                                                                    Cell = Cell.Trim();
                                                                if (iCounter != 0)
                                                                    Result += ResultFileDivider;
                                                                if (Types[iCounter] == "Date")
                                                                    Cell = Utils.Util.ConvertDateToFormat(Cell, ResultFileFormatDate);
                                                                //if (Types[iCounter] == "Money")
                                                                //  Cell = Utils.Util.ConvertDateToFormat(Cell, SQLDateFormat);
                                                                if ((Types[iCounter] == "DocType") && (Cell != String.Empty))
                                                                {
                                                                    int caseSwitch = Convert.ToInt16(Cell);
                                                                    switch (caseSwitch)
                                                                    {
                                                                        case -1: 
                                                                            Cell = ResultFileFormatDebit;
                                                                            break;
                                                                        case 1:
                                                                            Cell = ResultFileFormatCredit;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                }
                                                            }
                                                            Result += Cell;
                                                        }
                                                        Result += ResultFileDividerLast;
                                                        sw.Write(Result);
                                                    }
                                                    sw.Write(ResultFileEOF);
                                                }

                                                SaveLog("Заливка данных в файл «" + ResultFile + "»", "RUN_5", "inf", true, false, true, 0);
                                                File.Copy(ResultFile + ".tmp", ResultFile, true);
                                                File.Delete(ResultFile + ".tmp");
                                                SaveLog("По текущему списку счетов и периоду дат получено " + RowsCount.ToString() + " записей", "RUN_5", "inf", true, false, false, 0);
                                                if (ResultFileStartAfter != String.Empty)
                                                {
                                                    if ((!Path.IsPathRooted(ResultFileStartAfter)) && (!File.Exists(ResultFileStartAfter)))
                                                    {
                                                        if (File.Exists(Environment.SystemDirectory + @"\" + ResultFileStartAfter))
                                                            ResultFileStartAfter = Environment.SystemDirectory + @"\" + ResultFileStartAfter;
                                                    }

                                                    if (File.Exists(ResultFileStartAfter))
                                                    {
                                                        SaveLog("Запуск «" + ResultFileStartAfter + "»", "RUN_5", "inf", true, false, true, 0);
                                                        // System.Diagnostics.Process.Start("notepad.exe", ResultFileStartAfter);
                                                        try
                                                        {
                                                            //System.Diagnostics.Process.Start(ResultFileStartAfter, ResultFileStartAfterArguments);
                                                            System.Diagnostics.Process.Start(@"" + ResultFileStartAfter, ResultFileStartAfterArguments);
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            SaveLog("Ошибка запуска «" + e.ToString() + "» файла «" + ResultFileStartAfter + "»", "RUN_5", "err", true, false, false, 0);
                                                        }
                                                        /*
                                                        if (WindowAPI.kernel32.CreateProcess(
                                                            null,             // Module name .
                                                            ResultFileStartAfter,          // Command line.
                                                            null,             // Process handle not inheritable.
                                                            null,             // Thread handle not inheritable.
                                                            false,            // Set handle inheritance to FALSE.
                                                            0,                // No creation flags.
                                                            null,             // Use parent's environment block.
                                                            null,             // Use parent's starting directory.
                                                            &si_p,            // Pointer to STARTUPINFO structure.
                                                            &pi_p )           // Pointer to PROCESS_INFORMATION structure.
                                                        )
                                                        SaveLog("Запуск «" + ResultFileStartAfter + "»", "RUN_5", "inf", true, false, true, 0);
                                                       else
                                                        SaveLog("О шибка запуска «" + ResultFileStartAfter + "»", "RUN_5", "inf", true, false, true, 0);
                                                         */
                                                        SaveLog("Запуск «" + ResultFileStartAfter + "» - ПРОШЛО успешно!", "RUN_5", "inf", true, false, true, 0);
                                                    }
                                                    else
                                                        SaveLog("Не найден файл запуска «" + ResultFileStartAfter + "»", "RUN_5", "err", true, true, true, 0);
                                                }
                                            }
                                            else
                                                SaveLog("По текущему списку счетов и периоду дат иформации нет!", "RUN_5", "wrn", true, false, false, 0);
                                            if (!reader.IsClosed)
                                                reader.Close();
                                            command.Cancel();
                                            Result = String.Empty;
                                        }
                                        catch (InvalidOperationException e)
                                        {
                                            Temp = e.ToString();
                                            SaveLog("Ошибка (InvalidOperationException): «" + Temp + "» при попытке заливки данных в файл «" + ResultFile + "»", "RUN_5", "err", true, false, true, 0);
                                            SaveLog("Ошибка при попытке заливки данных в файл «" + ResultFile + "»", "RUN_5", "err", false, true, true, 0);
                                            //Result = "Ошибка загрузки!!!";
                                        }
                                        catch (Exception e)
                                        {
                                            Temp = e.ToString();
                                            SaveLog("Ошибка (Exception): «" + Temp + "» при попытке заливки данных в файл «" + ResultFile + "»", "RUN_5", "err", true, false, true, 0);
                                            SaveLog("Ошибка при попытке заливки данных в файл «" + ResultFile + "»", "RUN_5", "err", false, true, true, 0);
                                            //Result = "Ошибка загрузки!!!";
                                        }
                                        command.Cancel();
                                    }
								}
                            }
                            /*if ((NotFoundCount > 0) && (!AutoStart))
                            {
                                Result = "Не найдено " + NotFoundCount.ToString() + " счетов!\r\n";
                                MessageBox.Show(Result);
                            }*/
                        }
                    }
                }

            }
            if (CanExit)
            {
                //textBox_Info.Text.Insert(0, Result.Trim() + "\r\n");
                //    MessageBox.Show(Result.Trim());
                //listView_Events.Groups.IndexOf()
            }
            if (!CanExit)
            {
                DateTime date_now = DateTime.Now;
                TimeSpan Duration = date_now.Subtract(LastStarted_RUN_5);

                Temp = "Статистика загрузки (выполнение с " + LastStarted_RUN_5.ToString() + " по " + date_now.ToString();
                Temp += " =";
                if (Duration.Hours > 0)
                    Temp += " " + Duration.Hours.ToString() + " час.";
                if (Duration.Minutes > 0)
                    Temp += " " + Duration.Minutes.ToString() + " минут.";
                Temp += " " + Duration.Seconds.ToString() + " секунд.";
                Temp += "):";
                SaveLog(Temp, "RUN_5", "inf", true, true, false, 0);
                Temp = "Список счетов из «" + AccFile + "» за перод с " + StartDate.ToShortDateString() + " по " + LastDate.ToShortDateString();
                SaveLog(Temp, "RUN_5", "inf", true, true, false, 0);
                Temp = "Всего " + Convert.ToString(AccCount) + " счет(а)(ов)!";
                SaveLog(Temp, "RUN_5", "inf", true, true, false, 0);
                if (NotFoundCount > 0)
                {
                    Temp = "Не найдено в Equation " + NotFoundCount.ToString() + " счетов!";
                    SaveLog(Temp, "RUN_5", "wrn", true, true, false, 0);
                }
                if (NotLoadedCount > 0)
                {
                    Temp = "Не загружено в Equation " + NotLoadedCount.ToString() + " счетов!";
                    SaveLog(Temp, "RUN_5", "err", true, true, false, 0);
                }
                if (RowsCount > 0)
                {
                    Temp = "По текущему списку счетов и периоду дат получено " + RowsCount.ToString() + " записей.";
                    SaveLog(Temp, "RUN_5", "inf", true, true, false, 0);
                }
                else
                {
                    Temp = "По текущему списку счетов и периоду дат данные не получены!";
                    SaveLog(Temp, "RUN_5", "wrn", true, true, false, 0);
                }
            }
//            SaveLog("BSS_LOAD_ACC: " + Temp, "RUN_5", "inf", true, false, false, 0);

            if (Result.Trim() != String.Empty)
                SaveLog(Result, "RUN_5", "inf", false, true, false, 0);
            SaveLog("КОНЕЦ: RUN_5", "RUN_5", "inf", true, false, false, 0);
            CanExit = true;
            // Закрытия окна с прогрессом
            Thread.Sleep(0);
            ToProgress("", 100, 0, 0);
            WindowAPI.user32.SendMessage(ProcessFormHandle, WindowAPI.consts.WM_CLOSE, (uint)0, (long)0);
            //WindowAPI.user32.DestroyWindow(ProcessFormHandle);
            // ^Закрытия окна с прогрессом

//                MessageBox.Show("Обмен данными прошёл успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void RUN_5_Click(object sender, EventArgs e)
        {
            CurrentStartMode = "Auto";
            StartDate = DateTime.Today;
            LastDate = DateTime.Today;
            SQLDateFormat = DESI.GetValue("DateFormat", "DB/" + AccountDB[AccountIndex]); // iBank 

            if (sender is Button)
            {
                Button bt;
                bt = (Button)sender;
                if (bt.Tag.ToString() == "Manual")
                {
                   CurrentStartMode = "Manual";
                   StartDate = dateTimePicker_StartDate.Value;
                   LastDate = dateTimePicker_LastDate.Value;
                   //bt.Image = imageList_Main.Images["spinner.png"];
                }
            }

            if ((!AutoStart) && (CurrentStartMode == "Auto"))
            {
                return;
            }

            if (comboBox_AccountsList.SelectedIndex != -1)
                AccountIndex = comboBox_AccountsList.SelectedIndex;
            else
                return;

            AccFile = WorkPath + AccountFile[AccountIndex] + AccountsFileExt;

            if ((AutoStart) && (CurrentStartMode == "Auto") && (timer_RUN_5.Enabled))
            {
                // 217я комната ===============================================
                if (AccountFile[AccountIndex] == "iBankRUR") 
                {
                    if (DateTime.Now.Hour < 10)
                    {
                        if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                        {
                            StartDate = DateTime.Today.AddDays(-3);
                            LastDate = DateTime.Today;
                        }
                        else
                        {
                            StartDate = DateTime.Today.AddDays(-1);
                            LastDate = DateTime.Today;
                        }
                    }
                }
                //^ 217я комната ===============================================

                int iPeriod = -1;
                iPeriod = DESI.GetIntValue("Period", "AutoStart");
                int iHour = -1;
                iHour = DESI.GetIntValue("Hour", "AutoStart");
                int iMinute = -1;
                iMinute = DESI.GetIntValue("Minute", "AutoStart");

                if (iPeriod > 0)
                {
                    TimeSpan Duration = DateTime.Now.Subtract(AutoStarted);
                    progressBar_RUN_5_AutoStart.Maximum = 100;
                    int iTemp = (int)(((Duration.Hours * 60 * 60 + Duration.Minutes * 60 + Duration.Seconds) * progressBar_RUN_5_AutoStart.Maximum) / (iPeriod * 60));
                    if (iTemp <= progressBar_RUN_5_AutoStart.Maximum)
                        progressBar_RUN_5_AutoStart.Value = iTemp;
                    label_RUN_5_AutoStart_Info.Text = "      Автостарт через ";// +iTemp.ToString() + " минут(ы)(у).";
                    //label_RUN_5_AutoStart_Info.Text += " Счётчик: ";
                    /*iTemp = (int) (iPeriod * 60 - Duration.Hours) / 60;
                    if (iTemp > 0)
                        label_RUN_5_AutoStart_Info.Text += iTemp.ToString() + " час. ";
                     //*/
                    iTemp = iPeriod - Duration.Minutes - 1;
                    if (iTemp > 0)
                        label_RUN_5_AutoStart_Info.Text += iTemp.ToString() + " мин. ";
                    iTemp = 60 - Duration.Seconds;
                    label_RUN_5_AutoStart_Info.Text += iTemp.ToString() + " сек.";
                    if (iPeriod > Duration.Minutes)
                        return;
                    AutoStarted = DateTime.Now;
                }

                if (iHour != -1)
                {
                    //TimeSpan Duration = Now.Subtract(AutoStarted);
                    if (DateTime.Now.Hour != iHour)
                        return;
                    if (iMinute != -1)
                    {
                        if ((DateTime.Now.Hour != iHour) && (DateTime.Now.Minute != iMinute))
                            return;
                    }
                    AutoStarted = DateTime.Now;
                }

                if (iMinute != -1)
                {
                    /*
                    if (DateTime.Now.Minute < iMinute)
                    {

                        TimeSpan Duration = DateTime.Now.Subtract(AutoStarted);
                        progressBar_RUN_5_AutoStart.Maximum = 100;
                        int iTemp = (int)(((Duration.Hours * 60 * 60 + Duration.Minutes * 60 + Duration.Seconds) * progressBar_RUN_5_AutoStart.Maximum) / (iPeriod * 60));
                        if (iTemp <= progressBar_RUN_5_AutoStart.Maximum)
                            progressBar_RUN_5_AutoStart.Value = iTemp;

                    }
                    // */
                    if (DateTime.Now.Minute != iMinute)
                        return;
                    AutoStarted = DateTime.Now;
                }
            }
            timer_RUN_5.Enabled = false;
            //button_RUN.Image = imageList_Main.Images["spinner.gif"];

            Cursor = Cursors.WaitCursor;

            LastStarted_RUN_5 = DateTime.Now;
            //LastStarted_RUN_5 = new System.DateTime(LastStarted_RUN_5.Year, LastStarted_RUN_5.Month, LastStarted_RUN_5.Day, LastStarted_RUN_5.Hour, LastStarted_RUN_5.Minute, 0);

            /*if (File.Exists(ResultFile))
                File.Delete(ResultFile);*/
            //this.TopMost = !this.TopMost;
            using (ProgressForm pf = new ProgressForm())
            {

                Thread t = new Thread(new ThreadStart(RUN_5));
                t.Start();
                pf.CanClose = false;
                ProcessFormHandle = pf.Handle;
                if (pf.ShowDialog(this) == DialogResult.Abort)
                {
                    pf.CanClose = true;
                    t.Abort();
                }
                else
                {
                    t.Join();
                }
            }
            //this.TopMost = !this.TopMost;

            if (AutoStart)
            {
                AutoStarted = DateTime.Now;
                timer_RUN_5.Enabled = true;
            }
            else
                button_RUN_5.Image = imageList_Main.Images["start.png"];

            for (int iCounter = 0; iCounter < lvTemp.Items.Count; iCounter++)
            {
                ListViewItem item = new ListViewItem((iCounter + 1).ToString(), lvTemp.Items[iCounter].ImageIndex);
                item.SubItems.Add(lvTemp.Items[iCounter].SubItems[1].Text);
                item.SubItems.Add(lvTemp.Items[iCounter].SubItems[2].Text);
                item.SubItems.Add(lvTemp.Items[iCounter].SubItems[3].Text);
                if (item.ImageIndex == 1)
                {
                    item.ForeColor = Color.Black;
                    item.BackColor = Color.LemonChiffon;
                }
                if (item.ImageIndex == 2)
                {
                    item.ForeColor = Color.White;
                    item.BackColor = Color.Red;
                }
                listView_Events.Items.AddRange(new ListViewItem[] { item });
            }
            listView_Events.Items[listView_Events.Items.Count - 1].EnsureVisible();
            //listView_Events.Items[listView_Events.Items.Count - 1].Selected = true;
            listView_Events.Focus();
            Cursor = Cursors.Default;
        }

        private void ChangeAutoStart(object sender, EventArgs e)
        {
            AutoStart = !AutoStart;
            progressBar_RUN_5_AutoStart.Value = 0;
            label_RUN_5_AutoStart_Info.Text = "";
            AutoStarted = DateTime.Now;
            if (AutoStart)
            {
                toolStripStatusLabel_Info.Text = "Автоматический запуск включен.";
                button_RUN_5_AutoStart.Text = "Отключить.";
                button_RUN_5_AutoStart.Image = imageList_Main.Images["stop.png"];
                toolStripStatusLabel_Info.Image = imageList_Main.Images["apply.png"];
                timer_RUN_5.Enabled = true;
            }
            else
            {
                toolStripStatusLabel_Info.Text = "Автоматический запуск не включен.";
                button_RUN_5_AutoStart.Text = "Включить.";
                button_RUN_5_AutoStart.Image = imageList_Main.Images["bell.png"];
                toolStripStatusLabel_Info.Image = imageList_Main.Images["button_cancel.png"];
                AutoStarted = DateTime.Now;
                timer_RUN_5.Enabled = false;
            }
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            int WParam = (int)m.WParam;
            int LParam = (int)m.LParam;
            // Listen for operating system messages.
            switch (m.Msg)
            {
                // The WM_ACTIVATEAPP message occurs when the application
                // becomes the active application or becomes inactive.
                case WindowAPI.consts.WM_ACTIVATEAPP:

                    // The WParam value identifies what is occurring.
                    appActive = (((int)m.WParam != 0));

                    // Invalidate to get new text painted.
                    //this.Invalidate();

                    break;
                case WindowAPI.consts.WM_USER:
                    switch (WParam)
                    {
                        case 100:
                            this.Close();
                            break;
                        case 101:
                            // The WParam value identifies what is occurring.
                            this.Activate();
                            this.BringToFront();
                            this.TopMost = !this.TopMost;
                            this.TopMost = !this.TopMost;
                            break;
                    }
                    // Invalidate to get new text painted.
                    //this.Invalidate();
                    break;
            }
            base.WndProc(ref m);
        }

        private void dateTimePicker_StartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker_StartDate.Value > dateTimePicker_LastDate.Value)
                dateTimePicker_LastDate.Value = dateTimePicker_StartDate.Value;

            label_StartDate.ImageIndex = -1;
            label_StartDate.Text = label_StartDate.Text.TrimStart();
            if (dateTimePicker_StartDate.Value > DateTime.Now)
            {
                label_StartDate.ImageIndex = 1;
                label_StartDate.Text = "      " + label_StartDate.Text;
                notifyIcon_Main.ShowBalloonTip(2000, "Предупреждение", "Дата начала периода больше текущей!", ToolTipIcon.Warning);
            }
        }

        private void dateTimePicker_LastDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker_LastDate.Value < dateTimePicker_StartDate.Value)
                dateTimePicker_LastDate.Value = dateTimePicker_StartDate.Value;
        }

        private void listView_Events_SelectedIndexChanged(object sender, EventArgs e)
        {
    		ListView.SelectedIndexCollection indexes = 
	        this.listView_Events.SelectedIndices;

            if (indexes.Count > 0)
            {
        		
		        string Temp = String.Empty;
		        foreach ( int index in indexes )
		        {
                    Temp += this.listView_Events.Items[index].SubItems[1].Text;
                    Temp += " " + this.listView_Events.Items[index].SubItems[2].Text;
                    Temp += " " + this.listView_Events.Items[index].SubItems[3].Text;
                }
                textBox_SelectedInfo.Text = Temp;
            }
        }

        private void ToolStripMenuItem_OpenUserLog_Click(object sender, EventArgs e)
        {
            if (UserLogFile != String.Empty)
            {
                if (File.Exists(UserLogFile))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(@"c:/windows/notepad.exe", UserLogFile);
                    }
                    catch (Exception exc)
                    {
                        SaveLog("Ошибка запуска «" + exc.ToString() + "» файла «" + UserLogFile + "»", "RUN_5", "err", true, false, false, 0);
                    }
                }
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            String[] arguments = Environment.GetCommandLineArgs();
            MessageBox.Show(String.Join(", ", arguments));
              */
        }

        private void notifyIcon_Main_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void notifyIcon_Main_MouseMove(object sender, MouseEventArgs e)
        {
            //notifyIcon_Main.ShowBalloonTip(1000, "Информация", this.Text, ToolTipIcon.Info);
        }

        private void notifyIcon_Main_BalloonTipClicked(object sender, EventArgs e)
        {
            //notifyIcon_Main.Visible = false;
            //notifyIcon_Main.Visible = true;
        }

        private void notifyIcon_Main_BalloonTipClosed(object sender, EventArgs e)
        {

        }

        private void notifyIcon_Main_BalloonTipShown(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

    }
}
