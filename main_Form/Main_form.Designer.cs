namespace Image_processing
{
    partial class Main_form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            treeView1 = new TreeView();
            tree_MenuStrip = new ContextMenuStrip(components);
            展开全部ToolStripMenuItem = new ToolStripMenuItem();
            折叠全部ToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            pic_MenuStrip = new ContextMenuStrip(components);
            查看图片信息ToolStripMenuItem = new ToolStripMenuItem();
            listBox1 = new ListBox();
            listbox_MenuStrip = new ContextMenuStrip(components);
            插入ToolStripMenuItem = new ToolStripMenuItem();
            删除ToolStripMenuItem = new ToolStripMenuItem();
            textBox1 = new TextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            uiNavBar1 = new Sunny.UI.UINavBar();
            refresh_pic = new Sunny.UI.UIButton();
            save_Configuration = new Sunny.UI.UIButton();
            open_Configuration = new Sunny.UI.UIButton();
            save_pic = new Sunny.UI.UIButton();
            open_pic = new Sunny.UI.UIButton();
            uiWaitingBar1 = new Sunny.UI.UIWaitingBar();
            tree_MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pic_MenuStrip.SuspendLayout();
            listbox_MenuStrip.SuspendLayout();
            statusStrip1.SuspendLayout();
            uiNavBar1.SuspendLayout();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.ContextMenuStrip = tree_MenuStrip;
            treeView1.Location = new Point(29, 99);
            treeView1.Name = "treeView1";
            treeView1.ShowNodeToolTips = true;
            treeView1.Size = new Size(220, 506);
            treeView1.TabIndex = 0;
            treeView1.NodeMouseDoubleClick += treeView1_NodeMouseDoubleClick;
            // 
            // tree_MenuStrip
            // 
            tree_MenuStrip.Items.AddRange(new ToolStripItem[] { 展开全部ToolStripMenuItem, 折叠全部ToolStripMenuItem });
            tree_MenuStrip.Name = "contextMenuStrip1";
            tree_MenuStrip.Size = new Size(125, 48);
            // 
            // 展开全部ToolStripMenuItem
            // 
            展开全部ToolStripMenuItem.Name = "展开全部ToolStripMenuItem";
            展开全部ToolStripMenuItem.Size = new Size(124, 22);
            展开全部ToolStripMenuItem.Text = "展开全部";
            展开全部ToolStripMenuItem.Click += 展开全部ToolStripMenuItem_Click;
            // 
            // 折叠全部ToolStripMenuItem
            // 
            折叠全部ToolStripMenuItem.Name = "折叠全部ToolStripMenuItem";
            折叠全部ToolStripMenuItem.Size = new Size(124, 22);
            折叠全部ToolStripMenuItem.Text = "折叠全部";
            折叠全部ToolStripMenuItem.Click += 折叠全部ToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.ContextMenuStrip = pic_MenuStrip;
            pictureBox1.Location = new Point(277, 102);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // pic_MenuStrip
            // 
            pic_MenuStrip.Items.AddRange(new ToolStripItem[] { 查看图片信息ToolStripMenuItem });
            pic_MenuStrip.Name = "pic_MenuStrip";
            pic_MenuStrip.Size = new Size(149, 26);
            // 
            // 查看图片信息ToolStripMenuItem
            // 
            查看图片信息ToolStripMenuItem.Name = "查看图片信息ToolStripMenuItem";
            查看图片信息ToolStripMenuItem.Size = new Size(148, 22);
            查看图片信息ToolStripMenuItem.Text = "查看图片信息";
            查看图片信息ToolStripMenuItem.Click += 查看图片信息ToolStripMenuItem_Click;
            // 
            // listBox1
            // 
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.ColumnWidth = 5;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 21;
            listBox1.Location = new Point(703, 99);
            listBox1.Margin = new Padding(8, 3, 3, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(218, 506);
            listBox1.TabIndex = 3;
            listBox1.MouseDoubleClick += listBox1_MouseDoubleClick;
            listBox1.MouseDown += listBox1_MouseDown;
            // 
            // listbox_MenuStrip
            // 
            listbox_MenuStrip.Items.AddRange(new ToolStripItem[] { 插入ToolStripMenuItem, 删除ToolStripMenuItem });
            listbox_MenuStrip.Name = "listbox_MenuStrip1";
            listbox_MenuStrip.Size = new Size(101, 48);
            // 
            // 插入ToolStripMenuItem
            // 
            插入ToolStripMenuItem.Name = "插入ToolStripMenuItem";
            插入ToolStripMenuItem.Size = new Size(100, 22);
            插入ToolStripMenuItem.Text = "插入";
            插入ToolStripMenuItem.Click += 插入ToolStripMenuItem_Click;
            // 
            // 删除ToolStripMenuItem
            // 
            删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            删除ToolStripMenuItem.Size = new Size(100, 22);
            删除ToolStripMenuItem.Text = "删除";
            删除ToolStripMenuItem.Click += 删除ToolStripMenuItem_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(275, 508);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(402, 97);
            textBox1.TabIndex = 4;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(2, 633);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(960, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // uiNavBar1
            // 
            uiNavBar1.BackColor = Color.White;
            uiNavBar1.Controls.Add(refresh_pic);
            uiNavBar1.Controls.Add(save_Configuration);
            uiNavBar1.Controls.Add(open_Configuration);
            uiNavBar1.Controls.Add(save_pic);
            uiNavBar1.Controls.Add(open_pic);
            uiNavBar1.Dock = DockStyle.Top;
            uiNavBar1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiNavBar1.Location = new Point(2, 29);
            uiNavBar1.MenuHoverColor = Color.White;
            uiNavBar1.MenuSelectedColor = Color.White;
            uiNavBar1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            uiNavBar1.Name = "uiNavBar1";
            uiNavBar1.Size = new Size(960, 67);
            uiNavBar1.Style = Sunny.UI.UIStyle.Custom;
            uiNavBar1.TabIndex = 6;
            uiNavBar1.Text = "uiNavBar1";
            uiNavBar1.ZoomScaleDisabled = true;
            // 
            // refresh_pic
            // 
            refresh_pic.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            refresh_pic.Location = new Point(712, 16);
            refresh_pic.MinimumSize = new Size(1, 1);
            refresh_pic.Name = "refresh_pic";
            refresh_pic.Size = new Size(100, 35);
            refresh_pic.Style = Sunny.UI.UIStyle.Custom;
            refresh_pic.TabIndex = 0;
            refresh_pic.Text = "刷新图片";
            refresh_pic.Click += refresh_pic_Click;
            // 
            // save_Configuration
            // 
            save_Configuration.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            save_Configuration.Location = new Point(577, 16);
            save_Configuration.MinimumSize = new Size(1, 1);
            save_Configuration.Name = "save_Configuration";
            save_Configuration.Size = new Size(100, 35);
            save_Configuration.Style = Sunny.UI.UIStyle.Custom;
            save_Configuration.TabIndex = 0;
            save_Configuration.Text = "保存配置文件";
            // 
            // open_Configuration
            // 
            open_Configuration.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            open_Configuration.Location = new Point(430, 16);
            open_Configuration.MinimumSize = new Size(1, 1);
            open_Configuration.Name = "open_Configuration";
            open_Configuration.Size = new Size(100, 35);
            open_Configuration.Style = Sunny.UI.UIStyle.Custom;
            open_Configuration.TabIndex = 0;
            open_Configuration.Text = "打开配置文件";
            // 
            // save_pic
            // 
            save_pic.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            save_pic.Location = new Point(275, 16);
            save_pic.MinimumSize = new Size(1, 1);
            save_pic.Name = "save_pic";
            save_pic.Size = new Size(100, 35);
            save_pic.Style = Sunny.UI.UIStyle.Custom;
            save_pic.TabIndex = 0;
            save_pic.Text = "保存图片";
            save_pic.Click += save_pic_Click;
            // 
            // open_pic
            // 
            open_pic.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            open_pic.Location = new Point(149, 16);
            open_pic.MinimumSize = new Size(1, 1);
            open_pic.Name = "open_pic";
            open_pic.Size = new Size(100, 35);
            open_pic.Style = Sunny.UI.UIStyle.Custom;
            open_pic.TabIndex = 0;
            open_pic.Text = "打开文件";
            open_pic.Click += open_pic_Click;
            // 
            // uiWaitingBar1
            // 
            uiWaitingBar1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiWaitingBar1.Location = new Point(329, 611);
            uiWaitingBar1.MinimumSize = new Size(70, 23);
            uiWaitingBar1.Name = "uiWaitingBar1";
            uiWaitingBar1.Size = new Size(300, 23);
            uiWaitingBar1.Style = Sunny.UI.UIStyle.Custom;
            uiWaitingBar1.TabIndex = 7;
            uiWaitingBar1.Text = "uiWaitingBar1";
            uiWaitingBar1.Visible = false;
            // 
            // Main_form
            // 
            AllowAddControlOnTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(964, 657);
            Controls.Add(uiWaitingBar1);
            Controls.Add(uiNavBar1);
            Controls.Add(statusStrip1);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Controls.Add(pictureBox1);
            Controls.Add(treeView1);
            ExtendBox = true;
            Name = "Main_form";
            Padding = new Padding(2, 29, 2, 2);
            ShowDragStretch = true;
            ShowRadius = false;
            Style = Sunny.UI.UIStyle.Custom;
            Text = "OpenCV";
            TitleHeight = 29;
            ZoomScaleRect = new Rectangle(15, 15, 951, 611);
            Load += Main_form_Load;
            SizeChanged += Main_form_SizeChanged;
            tree_MenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pic_MenuStrip.ResumeLayout(false);
            listbox_MenuStrip.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            uiNavBar1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private TreeView treeView1;
        private PictureBox pictureBox1;
        private ListBox listBox1;
        private TextBox textBox1;
        private ContextMenuStrip tree_MenuStrip;
        private ToolStripMenuItem 展开全部ToolStripMenuItem;
        private ToolStripMenuItem 折叠全部ToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ContextMenuStrip pic_MenuStrip;
        private ToolStripMenuItem 查看图片信息ToolStripMenuItem;
        private ContextMenuStrip listbox_MenuStrip;
        private ToolStripMenuItem 删除ToolStripMenuItem;
        private Sunny.UI.UINavBar uiNavBar1;
        private Sunny.UI.UIButton refresh_pic;
        private Sunny.UI.UIButton save_Configuration;
        private Sunny.UI.UIButton open_Configuration;
        private Sunny.UI.UIButton save_pic;
        private Sunny.UI.UIButton open_pic;
        private Sunny.UI.UIWaitingBar uiWaitingBar1;
        private ToolStripMenuItem 插入ToolStripMenuItem;
    }
}