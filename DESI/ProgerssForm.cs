using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

public class ProgressForm : Form
{
    public bool CanClose = false;
    public bool Stopped = false;
    private SplitContainer splitContainer_Progress;
    private ProgressBar progressBar;
    private ListView listView_ProgressInfo;
    private ColumnHeader columnHeader_Status;
    private ColumnHeader columnHeader_Time;
    private ColumnHeader columnHeader_Msg;
    private ImageList imageList_Status;
    private IContainer components;
    private Label label_ProgressValue;
    private Button button_Close;

    public ProgressForm()
    {
        this.InitializeComponent();
        this.Width = 450;
        this.Height = 350;
        //this.MaximumSize = new System.Drawing.Size(this.Width, this.Height);
        //this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
        this.Text = "Выполнение";
        this.StartPosition = FormStartPosition.CenterParent;
        //this.TopMost = true;
        //this.ControlBox = false;
        //this.BackColor = Color.White;
        this.MinimizeBox = false;
        this.MaximizeBox = true;
        this.ShowInTaskbar = false;
        this.ShowIcon = false;
        //this.SizeGripStyle = SizeGripStyle.Hide;
        //Icon = this.ParentForm.Icon;
        this.Closing += new CancelEventHandler(this.Exit);

        //this.Opacity = 0.53;

        //this.WndProc
    }

    private void Exit(Object sender, CancelEventArgs e)
    {
        e.Cancel = true;
        if (!CanClose)
        {
            if (MessageBox.Show("Прекратить выполнение задачи?", "Закрыть",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  == DialogResult.Yes)
            {
                Stopped = true;
                DialogResult = DialogResult.Abort;
                e.Cancel = false;
            }
        }
        else
        {
            Stopped = true;
            DialogResult = DialogResult.Abort;
            e.Cancel = false;
        }
    }

    private void button_Close_Click(object sender, EventArgs e)
    {
        Close();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Paint a string in different styles depending on whether the
        // application is active.
        /*
        if (appActive)
        {
            e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, 20, 20, 260, 50);
            e.Graphics.DrawString("Application is active", this.Font, SystemBrushes.ActiveCaptionText, 20, 20);
        }
        else
        {
            e.Graphics.FillRectangle(SystemBrushes.InactiveCaption, 20, 20, 260, 50);
            e.Graphics.DrawString("Application is Inactive", this.Font, SystemBrushes.ActiveCaptionText, 20, 20);
        }
         // */
    }

    protected void SetValue(int Value, bool Inc)
    {
        int Temp = 0;
        Temp = Value;
        if (Inc)
            Temp = progressBar.Value + Value;
        if (Temp < progressBar.Minimum)
            progressBar.Value = progressBar.Minimum;
        else
            if (Temp > progressBar.Maximum)
                progressBar.Value = progressBar.Maximum;
            else
                progressBar.Value = Temp;

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
                //appActive = (((int)m.WParam != 0));

                // Invalidate to get new text painted.
                //this.Invalidate();

                break;
            case WindowAPI.consts.WM_USER:
                switch (WParam)
                {
                    case 1:
                        SetValue(LParam, true);
                        ListViewItem item = new ListViewItem("", WindowAPI.vars.CurrentStatus);
                        item.SubItems.Add(DateTime.Now.ToLongTimeString());
                        item.SubItems.Add(WindowAPI.vars.CurrentMessage);
                        listView_ProgressInfo.Items.AddRange(new ListViewItem[] { item });
                        listView_ProgressInfo.Items[listView_ProgressInfo.Items.Count - 1].EnsureVisible();
                        listView_ProgressInfo.Items[listView_ProgressInfo.Items.Count - 1].Selected = true;
                        listView_ProgressInfo.Focus();
                        break;
                    case 2:
                        SetValue(LParam, true);
                        break;
                    case 3:
                        progressBar.Maximum = LParam;
                        break;
                    case 4:
                        SetValue(LParam, false);
                        break;
                    case 100:
                        if (LParam == 0)
                            CanClose = true;
                        break;
                }
                label_ProgressValue.Text = "      " + progressBar.Value.ToString() + " из " + progressBar.Maximum.ToString();

                break;
        }
        base.WndProc(ref m);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressForm));
        this.splitContainer_Progress = new System.Windows.Forms.SplitContainer();
        this.listView_ProgressInfo = new System.Windows.Forms.ListView();
        this.columnHeader_Status = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_Time = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_Msg = new System.Windows.Forms.ColumnHeader(4);
        this.imageList_Status = new System.Windows.Forms.ImageList(this.components);
        this.button_Close = new System.Windows.Forms.Button();
        this.label_ProgressValue = new System.Windows.Forms.Label();
        this.progressBar = new System.Windows.Forms.ProgressBar();
        this.splitContainer_Progress.Panel1.SuspendLayout();
        this.splitContainer_Progress.Panel2.SuspendLayout();
        this.splitContainer_Progress.SuspendLayout();
        this.SuspendLayout();
        // 
        // splitContainer_Progress
        // 
        this.splitContainer_Progress.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitContainer_Progress.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.splitContainer_Progress.Location = new System.Drawing.Point(0, 0);
        this.splitContainer_Progress.Name = "splitContainer_Progress";
        this.splitContainer_Progress.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer_Progress.Panel1
        // 
        this.splitContainer_Progress.Panel1.Controls.Add(this.listView_ProgressInfo);
        // 
        // splitContainer_Progress.Panel2
        // 
        this.splitContainer_Progress.Panel2.Controls.Add(this.button_Close);
        this.splitContainer_Progress.Panel2.Controls.Add(this.label_ProgressValue);
        this.splitContainer_Progress.Panel2.Controls.Add(this.progressBar);
        this.splitContainer_Progress.Size = new System.Drawing.Size(442, 323);
        this.splitContainer_Progress.SplitterDistance = 267;
        this.splitContainer_Progress.TabIndex = 0;
        // 
        // listView_ProgressInfo
        // 
        this.listView_ProgressInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.listView_ProgressInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Status,
            this.columnHeader_Time,
            this.columnHeader_Msg});
        this.listView_ProgressInfo.Dock = System.Windows.Forms.DockStyle.Fill;
        this.listView_ProgressInfo.FullRowSelect = true;
        this.listView_ProgressInfo.GridLines = true;
        this.listView_ProgressInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        this.listView_ProgressInfo.HideSelection = false;
        this.listView_ProgressInfo.Location = new System.Drawing.Point(0, 0);
        this.listView_ProgressInfo.MultiSelect = false;
        this.listView_ProgressInfo.Name = "listView_ProgressInfo";
        this.listView_ProgressInfo.ShowGroups = false;
        this.listView_ProgressInfo.Size = new System.Drawing.Size(442, 267);
        this.listView_ProgressInfo.SmallImageList = this.imageList_Status;
        this.listView_ProgressInfo.TabIndex = 0;
        this.listView_ProgressInfo.UseCompatibleStateImageBehavior = false;
        this.listView_ProgressInfo.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader_Status
        // 
        this.columnHeader_Status.Text = "Тип";
        this.columnHeader_Status.Width = 22;
        // 
        // columnHeader_Time
        // 
        this.columnHeader_Time.Text = "Время";
        this.columnHeader_Time.Width = 55;
        // 
        // columnHeader_Msg
        // 
        this.columnHeader_Msg.Text = "Текст сообщения";
        this.columnHeader_Msg.Width = 350;
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
        // button_Close
        // 
        this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.button_Close.Location = new System.Drawing.Point(355, 17);
        this.button_Close.Name = "button_Close";
        this.button_Close.Size = new System.Drawing.Size(75, 23);
        this.button_Close.TabIndex = 4;
        this.button_Close.Text = "Отмена";
        this.button_Close.UseVisualStyleBackColor = true;
        this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
        // 
        // label_ProgressValue
        // 
        this.label_ProgressValue.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
        this.label_ProgressValue.AutoEllipsis = true;
        this.label_ProgressValue.AutoSize = true;
        this.label_ProgressValue.BackColor = System.Drawing.SystemColors.Control;
        this.label_ProgressValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label_ProgressValue.Image = global::DESI.Properties.Resources.loader;
        this.label_ProgressValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.label_ProgressValue.Location = new System.Drawing.Point(12, 9);
        this.label_ProgressValue.Name = "label_ProgressValue";
        this.label_ProgressValue.Size = new System.Drawing.Size(30, 13);
        this.label_ProgressValue.TabIndex = 3;
        this.label_ProgressValue.Text = "    0";
        // 
        // progressBar
        // 
        this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.progressBar.Location = new System.Drawing.Point(10, 25);
        this.progressBar.Name = "progressBar";
        this.progressBar.Size = new System.Drawing.Size(339, 15);
        this.progressBar.Step = 1;
        this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        this.progressBar.TabIndex = 0;
        this.progressBar.UseWaitCursor = true;
        // 
        // ProgressForm
        // 
        this.ClientSize = new System.Drawing.Size(442, 323);
        this.Controls.Add(this.splitContainer_Progress);
        this.Name = "ProgressForm";
        this.splitContainer_Progress.Panel1.ResumeLayout(false);
        this.splitContainer_Progress.Panel2.ResumeLayout(false);
        this.splitContainer_Progress.Panel2.PerformLayout();
        this.splitContainer_Progress.ResumeLayout(false);
        this.ResumeLayout(false);

    }
}

