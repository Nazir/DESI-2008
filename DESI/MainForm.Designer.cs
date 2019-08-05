namespace DESI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Info = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_FormingExtraction = new System.Windows.Forms.TabPage();
            this.groupBox_RUN_5_Auto = new System.Windows.Forms.GroupBox();
            this.label_RUN_5_AutoStart_Info = new System.Windows.Forms.Label();
            this.imageList_Main = new System.Windows.Forms.ImageList(this.components);
            this.progressBar_RUN_5_AutoStart = new System.Windows.Forms.ProgressBar();
            this.button_RUN_5_AutoStart = new System.Windows.Forms.Button();
            this.groupBox_RUN_5_Manual = new System.Windows.Forms.GroupBox();
            this.button_RUN_5 = new System.Windows.Forms.Button();
            this.label_LastDate = new System.Windows.Forms.Label();
            this.label_StartDate = new System.Windows.Forms.Label();
            this.dateTimePicker_LastDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_AccountsList = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip_Events = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_OpenUserLog = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList_Status = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip_Main = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Main = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_Info = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Exit = new System.Windows.Forms.ToolStripButton();
            this.timer_RUN_5 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon_Main = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBox_SelectedInfo = new System.Windows.Forms.TextBox();
            this.listView_Events = new System.Windows.Forms.ListView();
            this.columnHeader_Status = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Date = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Time = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Msg = new System.Windows.Forms.ColumnHeader(4);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip_Main.SuspendLayout();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_FormingExtraction.SuspendLayout();
            this.groupBox_RUN_5_Auto.SuspendLayout();
            this.groupBox_RUN_5_Manual.SuspendLayout();
            this.contextMenuStrip_Events.SuspendLayout();
            this.menuStrip_Main.SuspendLayout();
            this.toolStrip_Main.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip_Main);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer_Main);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(782, 462);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(782, 533);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip_Main);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip_Main);
            // 
            // statusStrip_Main
            // 
            this.statusStrip_Main.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Info});
            this.statusStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.statusStrip_Main.Name = "statusStrip_Main";
            this.statusStrip_Main.Size = new System.Drawing.Size(782, 22);
            this.statusStrip_Main.TabIndex = 0;
            // 
            // toolStripStatusLabel_Info
            // 
            this.toolStripStatusLabel_Info.Name = "toolStripStatusLabel_Info";
            this.toolStripStatusLabel_Info.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabel_Info.Text = "Инфо";
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Main.Name = "splitContainer_Main";
            this.splitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer_Main.Size = new System.Drawing.Size(782, 462);
            this.splitContainer_Main.SplitterDistance = 167;
            this.splitContainer_Main.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_FormingExtraction);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList_Main;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 167);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage_FormingExtraction
            // 
            this.tabPage_FormingExtraction.Controls.Add(this.groupBox_RUN_5_Auto);
            this.tabPage_FormingExtraction.Controls.Add(this.groupBox_RUN_5_Manual);
            this.tabPage_FormingExtraction.ImageIndex = 9;
            this.tabPage_FormingExtraction.Location = new System.Drawing.Point(4, 23);
            this.tabPage_FormingExtraction.Name = "tabPage_FormingExtraction";
            this.tabPage_FormingExtraction.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_FormingExtraction.Size = new System.Drawing.Size(774, 140);
            this.tabPage_FormingExtraction.TabIndex = 0;
            this.tabPage_FormingExtraction.Text = "Формирования выписки";
            this.tabPage_FormingExtraction.ToolTipText = "Формирования выписки из MisysEquation в iBank";
            this.tabPage_FormingExtraction.UseVisualStyleBackColor = true;
            // 
            // groupBox_RUN_5_Auto
            // 
            this.groupBox_RUN_5_Auto.Controls.Add(this.label_RUN_5_AutoStart_Info);
            this.groupBox_RUN_5_Auto.Controls.Add(this.progressBar_RUN_5_AutoStart);
            this.groupBox_RUN_5_Auto.Controls.Add(this.button_RUN_5_AutoStart);
            this.groupBox_RUN_5_Auto.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_RUN_5_Auto.Location = new System.Drawing.Point(3, 63);
            this.groupBox_RUN_5_Auto.Name = "groupBox_RUN_5_Auto";
            this.groupBox_RUN_5_Auto.Size = new System.Drawing.Size(768, 60);
            this.groupBox_RUN_5_Auto.TabIndex = 1;
            this.groupBox_RUN_5_Auto.TabStop = false;
            this.groupBox_RUN_5_Auto.Text = "Автоматическая выгрузка из MisysEquation";
            // 
            // label_RUN_5_AutoStart_Info
            // 
            this.label_RUN_5_AutoStart_Info.AutoSize = true;
            this.label_RUN_5_AutoStart_Info.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_RUN_5_AutoStart_Info.ImageIndex = 11;
            this.label_RUN_5_AutoStart_Info.ImageList = this.imageList_Main;
            this.label_RUN_5_AutoStart_Info.Location = new System.Drawing.Point(6, 16);
            this.label_RUN_5_AutoStart_Info.Name = "label_RUN_5_AutoStart_Info";
            this.label_RUN_5_AutoStart_Info.Size = new System.Drawing.Size(56, 13);
            this.label_RUN_5_AutoStart_Info.TabIndex = 8;
            this.label_RUN_5_AutoStart_Info.Text = "       Инфо";
            // 
            // imageList_Main
            // 
            this.imageList_Main.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Main.ImageStream")));
            this.imageList_Main.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Main.Images.SetKeyName(0, "favicon_16x16.png");
            this.imageList_Main.Images.SetKeyName(1, "start.png");
            this.imageList_Main.Images.SetKeyName(2, "apply.png");
            this.imageList_Main.Images.SetKeyName(3, "cancel.png");
            this.imageList_Main.Images.SetKeyName(4, "advanced.png");
            this.imageList_Main.Images.SetKeyName(5, "spinner.gif");
            this.imageList_Main.Images.SetKeyName(6, "loader.gif");
            this.imageList_Main.Images.SetKeyName(7, "folder_icon.gif");
            this.imageList_Main.Images.SetKeyName(8, "fileprint.png");
            this.imageList_Main.Images.SetKeyName(9, "14_layer_novisible.png");
            this.imageList_Main.Images.SetKeyName(10, "agt_reload.png");
            this.imageList_Main.Images.SetKeyName(11, "bell.png");
            this.imageList_Main.Images.SetKeyName(12, "attach.png");
            this.imageList_Main.Images.SetKeyName(13, "exit.png");
            this.imageList_Main.Images.SetKeyName(14, "stop.png");
            this.imageList_Main.Images.SetKeyName(15, "button_cancel.png");
            this.imageList_Main.Images.SetKeyName(16, "list.png");
            this.imageList_Main.Images.SetKeyName(17, "shutdown.png");
            // 
            // progressBar_RUN_5_AutoStart
            // 
            this.progressBar_RUN_5_AutoStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_RUN_5_AutoStart.Location = new System.Drawing.Point(8, 34);
            this.progressBar_RUN_5_AutoStart.Name = "progressBar_RUN_5_AutoStart";
            this.progressBar_RUN_5_AutoStart.Size = new System.Drawing.Size(648, 20);
            this.progressBar_RUN_5_AutoStart.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar_RUN_5_AutoStart.TabIndex = 7;
            // 
            // button_RUN_5_AutoStart
            // 
            this.button_RUN_5_AutoStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_RUN_5_AutoStart.ImageIndex = 2;
            this.button_RUN_5_AutoStart.ImageList = this.imageList_Main;
            this.button_RUN_5_AutoStart.Location = new System.Drawing.Point(662, 29);
            this.button_RUN_5_AutoStart.Name = "button_RUN_5_AutoStart";
            this.button_RUN_5_AutoStart.Size = new System.Drawing.Size(100, 25);
            this.button_RUN_5_AutoStart.TabIndex = 6;
            this.button_RUN_5_AutoStart.Tag = "Manual";
            this.button_RUN_5_AutoStart.Text = "Включить";
            this.button_RUN_5_AutoStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_RUN_5_AutoStart.UseVisualStyleBackColor = true;
            this.button_RUN_5_AutoStart.Click += new System.EventHandler(this.ChangeAutoStart);
            // 
            // groupBox_RUN_5_Manual
            // 
            this.groupBox_RUN_5_Manual.Controls.Add(this.button_RUN_5);
            this.groupBox_RUN_5_Manual.Controls.Add(this.label_LastDate);
            this.groupBox_RUN_5_Manual.Controls.Add(this.label_StartDate);
            this.groupBox_RUN_5_Manual.Controls.Add(this.dateTimePicker_LastDate);
            this.groupBox_RUN_5_Manual.Controls.Add(this.dateTimePicker_StartDate);
            this.groupBox_RUN_5_Manual.Controls.Add(this.label1);
            this.groupBox_RUN_5_Manual.Controls.Add(this.comboBox_AccountsList);
            this.groupBox_RUN_5_Manual.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_RUN_5_Manual.Location = new System.Drawing.Point(3, 3);
            this.groupBox_RUN_5_Manual.Name = "groupBox_RUN_5_Manual";
            this.groupBox_RUN_5_Manual.Size = new System.Drawing.Size(768, 60);
            this.groupBox_RUN_5_Manual.TabIndex = 0;
            this.groupBox_RUN_5_Manual.TabStop = false;
            this.groupBox_RUN_5_Manual.Text = "Ручная выгрузка из MisysEquation";
            // 
            // button_RUN_5
            // 
            this.button_RUN_5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_RUN_5.ImageIndex = 1;
            this.button_RUN_5.ImageList = this.imageList_Main;
            this.button_RUN_5.Location = new System.Drawing.Point(662, 28);
            this.button_RUN_5.Name = "button_RUN_5";
            this.button_RUN_5.Size = new System.Drawing.Size(100, 25);
            this.button_RUN_5.TabIndex = 6;
            this.button_RUN_5.Tag = "Manual";
            this.button_RUN_5.Text = "Выполнить";
            this.button_RUN_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_RUN_5.UseVisualStyleBackColor = true;
            this.button_RUN_5.Click += new System.EventHandler(this.RUN_5_Click);
            // 
            // label_LastDate
            // 
            this.label_LastDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_LastDate.AutoSize = true;
            this.label_LastDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_LastDate.ImageList = this.imageList_Status;
            this.label_LastDate.Location = new System.Drawing.Point(510, 16);
            this.label_LastDate.Name = "label_LastDate";
            this.label_LastDate.Size = new System.Drawing.Size(134, 13);
            this.label_LastDate.TabIndex = 5;
            this.label_LastDate.Text = "Дата окончания периода";
            // 
            // label_StartDate
            // 
            this.label_StartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_StartDate.AutoSize = true;
            this.label_StartDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_StartDate.ImageKey = "(none)";
            this.label_StartDate.ImageList = this.imageList_Status;
            this.label_StartDate.Location = new System.Drawing.Point(362, 16);
            this.label_StartDate.Name = "label_StartDate";
            this.label_StartDate.Size = new System.Drawing.Size(116, 13);
            this.label_StartDate.TabIndex = 4;
            this.label_StartDate.Text = "Дата начала периода";
            // 
            // dateTimePicker_LastDate
            // 
            this.dateTimePicker_LastDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_LastDate.Location = new System.Drawing.Point(514, 33);
            this.dateTimePicker_LastDate.Name = "dateTimePicker_LastDate";
            this.dateTimePicker_LastDate.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker_LastDate.TabIndex = 3;
            this.dateTimePicker_LastDate.ValueChanged += new System.EventHandler(this.dateTimePicker_LastDate_ValueChanged);
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(365, 33);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker_StartDate.TabIndex = 2;
            this.dateTimePicker_StartDate.Value = new System.DateTime(2008, 11, 3, 0, 0, 0, 0);
            this.dateTimePicker_StartDate.ValueChanged += new System.EventHandler(this.dateTimePicker_StartDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.label1.AutoSize = true;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.ImageKey = "list.png";
            this.label1.ImageList = this.imageList_Main;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "       Список счетов";
            // 
            // comboBox_AccountsList
            // 
            this.comboBox_AccountsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_AccountsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AccountsList.FormattingEnabled = true;
            this.comboBox_AccountsList.Location = new System.Drawing.Point(9, 32);
            this.comboBox_AccountsList.Name = "comboBox_AccountsList";
            this.comboBox_AccountsList.Size = new System.Drawing.Size(350, 21);
            this.comboBox_AccountsList.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(774, 140);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Резерв";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip_Events
            // 
            this.contextMenuStrip_Events.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_OpenUserLog});
            this.contextMenuStrip_Events.Name = "contextMenuStrip_Events";
            this.contextMenuStrip_Events.Size = new System.Drawing.Size(192, 26);
            // 
            // ToolStripMenuItem_OpenUserLog
            // 
            this.ToolStripMenuItem_OpenUserLog.Image = global::DESI.Properties.Resources.notepad;
            this.ToolStripMenuItem_OpenUserLog.Name = "ToolStripMenuItem_OpenUserLog";
            this.ToolStripMenuItem_OpenUserLog.Size = new System.Drawing.Size(191, 22);
            this.ToolStripMenuItem_OpenUserLog.Text = "Открыть в блокноте";
            this.ToolStripMenuItem_OpenUserLog.Click += new System.EventHandler(this.ToolStripMenuItem_OpenUserLog_Click);
            // 
            // imageList_Status
            // 
            this.imageList_Status.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Status.ImageStream")));
            this.imageList_Status.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Status.Images.SetKeyName(0, "info.png");
            this.imageList_Status.Images.SetKeyName(1, "messagebox_warning.png");
            this.imageList_Status.Images.SetKeyName(2, "messagebox_critical.png");
            this.imageList_Status.Images.SetKeyName(3, "agt_action_success.png");
            this.imageList_Status.Images.SetKeyName(4, "messagebox_info.png");
            this.imageList_Status.Images.SetKeyName(5, "loader.gif");
            // 
            // menuStrip_Main
            // 
            this.menuStrip_Main.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip_Main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_File,
            this.toolStripMenuItem_Help});
            this.menuStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Main.Name = "menuStrip_Main";
            this.menuStrip_Main.Size = new System.Drawing.Size(782, 24);
            this.menuStrip_Main.TabIndex = 9;
            this.menuStrip_Main.Text = "Главное меню";
            // 
            // toolStripMenuItem_File
            // 
            this.toolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Exit});
            this.toolStripMenuItem_File.Name = "toolStripMenuItem_File";
            this.toolStripMenuItem_File.Size = new System.Drawing.Size(45, 20);
            this.toolStripMenuItem_File.Text = "&Файл";
            // 
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.Image = global::DESI.Properties.Resources.shutdown;
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.ShortcutKeyDisplayString = "";
            this.toolStripMenuItem_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem_Exit.Text = "В&ыход";
            this.toolStripMenuItem_Exit.ToolTipText = "Завершить работу программы.\r\nНе рекомендуется!!!";
            this.toolStripMenuItem_Exit.Click += new System.EventHandler(this.ExitClick);
            // 
            // toolStripMenuItem_Help
            // 
            this.toolStripMenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_About,
            this.testToolStripMenuItem});
            this.toolStripMenuItem_Help.Name = "toolStripMenuItem_Help";
            this.toolStripMenuItem_Help.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItem_Help.Text = "Помощь";
            // 
            // toolStripMenuItem_About
            // 
            this.toolStripMenuItem_About.Image = global::DESI.Properties.Resources.DESI_16x16;
            this.toolStripMenuItem_About.Name = "toolStripMenuItem_About";
            this.toolStripMenuItem_About.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem_About.Text = "О программе...";
            this.toolStripMenuItem_About.Click += new System.EventHandler(this.ToolStripMenuItem_About_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.testToolStripMenuItem.Text = "test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // toolStrip_Main
            // 
            this.toolStrip_Main.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_Info,
            this.toolStripSeparator1,
            this.toolStripButton_Exit});
            this.toolStrip_Main.Location = new System.Drawing.Point(3, 24);
            this.toolStrip_Main.Name = "toolStrip_Main";
            this.toolStrip_Main.Size = new System.Drawing.Size(328, 25);
            this.toolStrip_Main.TabIndex = 1;
            // 
            // toolStripLabel_Info
            // 
            this.toolStripLabel_Info.Name = "toolStripLabel_Info";
            this.toolStripLabel_Info.Size = new System.Drawing.Size(252, 22);
            this.toolStripLabel_Info.Text = "По вопросам работы с программой звоните 2571";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_Exit
            // 
            this.toolStripButton_Exit.Image = global::DESI.Properties.Resources.shutdown;
            this.toolStripButton_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Exit.Name = "toolStripButton_Exit";
            this.toolStripButton_Exit.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton_Exit.Text = "Выход";
            this.toolStripButton_Exit.ToolTipText = "Завершить работу прогрммы.\r\nНе рекомендуется!!!";
            this.toolStripButton_Exit.Click += new System.EventHandler(this.ExitClick);
            // 
            // timer_RUN_5
            // 
            this.timer_RUN_5.Interval = 10000;
            this.timer_RUN_5.Tick += new System.EventHandler(this.RUN_5_Click);
            // 
            // notifyIcon_Main
            // 
            this.notifyIcon_Main.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon_Main.BalloonTipTitle = "Информация";
            this.notifyIcon_Main.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_Main.Icon")));
            this.notifyIcon_Main.Visible = true;
            this.notifyIcon_Main.BalloonTipClosed += new System.EventHandler(this.notifyIcon_Main_BalloonTipClosed);
            this.notifyIcon_Main.BalloonTipClicked += new System.EventHandler(this.notifyIcon_Main_BalloonTipClicked);
            this.notifyIcon_Main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_Main_MouseMove);
            this.notifyIcon_Main.BalloonTipShown += new System.EventHandler(this.notifyIcon_Main_BalloonTipShown);
            this.notifyIcon_Main.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_Main_MouseDoubleClick);
            // 
            // textBox_SelectedInfo
            // 
            this.textBox_SelectedInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_SelectedInfo.Location = new System.Drawing.Point(3, 266);
            this.textBox_SelectedInfo.Multiline = true;
            this.textBox_SelectedInfo.Name = "textBox_SelectedInfo";
            this.textBox_SelectedInfo.Size = new System.Drawing.Size(776, 22);
            this.textBox_SelectedInfo.TabIndex = 3;
            // 
            // listView_Events
            // 
            this.listView_Events.AllowColumnReorder = true;
            this.listView_Events.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Status,
            this.columnHeader_Date,
            this.columnHeader_Time,
            this.columnHeader_Msg});
            this.listView_Events.ContextMenuStrip = this.contextMenuStrip_Events;
            this.listView_Events.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Events.FullRowSelect = true;
            this.listView_Events.GridLines = true;
            this.listView_Events.Location = new System.Drawing.Point(3, 3);
            this.listView_Events.MultiSelect = false;
            this.listView_Events.Name = "listView_Events";
            this.listView_Events.ShowGroups = false;
            this.listView_Events.Size = new System.Drawing.Size(776, 257);
            this.listView_Events.SmallImageList = this.imageList_Status;
            this.listView_Events.TabIndex = 2;
            this.listView_Events.UseCompatibleStateImageBehavior = false;
            this.listView_Events.View = System.Windows.Forms.View.Details;
            this.listView_Events.SelectedIndexChanged += new System.EventHandler(this.listView_Events_SelectedIndexChanged);
            // 
            // columnHeader_Status
            // 
            this.columnHeader_Status.Text = "Тип";
            this.columnHeader_Status.Width = 22;
            // 
            // columnHeader_Date
            // 
            this.columnHeader_Date.Text = "Дата";
            this.columnHeader_Date.Width = 70;
            // 
            // columnHeader_Time
            // 
            this.columnHeader_Time.Text = "Время";
            // 
            // columnHeader_Msg
            // 
            this.columnHeader_Msg.Text = "Текст сообщения";
            this.columnHeader_Msg.Width = 610;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.listView_Events, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_SelectedInfo, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.72165F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.278351F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 291);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 533);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip_Main.ResumeLayout(false);
            this.statusStrip_Main.PerformLayout();
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            this.splitContainer_Main.Panel2.ResumeLayout(false);
            this.splitContainer_Main.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_FormingExtraction.ResumeLayout(false);
            this.groupBox_RUN_5_Auto.ResumeLayout(false);
            this.groupBox_RUN_5_Auto.PerformLayout();
            this.groupBox_RUN_5_Manual.ResumeLayout(false);
            this.groupBox_RUN_5_Manual.PerformLayout();
            this.contextMenuStrip_Events.ResumeLayout(false);
            this.menuStrip_Main.ResumeLayout(false);
            this.menuStrip_Main.PerformLayout();
            this.toolStrip_Main.ResumeLayout(false);
            this.toolStrip_Main.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip_Main;
        private System.Windows.Forms.ToolStrip toolStrip_Main;
        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.ImageList imageList_Main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Info;
        private System.Windows.Forms.GroupBox groupBox_RUN_5_Manual;
        private System.Windows.Forms.ComboBox comboBox_AccountsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_LastDate;
        private System.Windows.Forms.Label label_LastDate;
        private System.Windows.Forms.Label label_StartDate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_FormingExtraction;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_RUN_5;
        private System.Windows.Forms.Timer timer_RUN_5;
        private System.Windows.Forms.ToolStripButton toolStripButton_Exit;
        private System.Windows.Forms.NotifyIcon notifyIcon_Main;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Info;
        private System.Windows.Forms.MenuStrip menuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_About;
        private System.Windows.Forms.ImageList imageList_Status;
        private System.Windows.Forms.GroupBox groupBox_RUN_5_Auto;
        private System.Windows.Forms.Button button_RUN_5_AutoStart;
        private System.Windows.Forms.ProgressBar progressBar_RUN_5_AutoStart;
        private System.Windows.Forms.Label label_RUN_5_AutoStart_Info;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Events;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_OpenUserLog;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView_Events;
        private System.Windows.Forms.ColumnHeader columnHeader_Status;
        private System.Windows.Forms.ColumnHeader columnHeader_Date;
        private System.Windows.Forms.ColumnHeader columnHeader_Time;
        private System.Windows.Forms.ColumnHeader columnHeader_Msg;
        private System.Windows.Forms.TextBox textBox_SelectedInfo;
    }
}

