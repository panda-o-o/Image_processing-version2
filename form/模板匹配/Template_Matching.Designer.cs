namespace Image_processing.form.模板匹配
{
    partial class Template_Matching
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            uiDoubleUpDown1 = new Sunny.UI.UIDoubleUpDown();
            uiButton1 = new Sunny.UI.UIButton();
            uiComboBox1 = new Sunny.UI.UIComboBox();
            label3 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(11, 60);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(236, 184);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.Location = new Point(45, 111);
            label1.Name = "label1";
            label1.Size = new Size(164, 72);
            label1.TabIndex = 1;
            label1.Text = "点击，打开一张模板图片";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(286, 91);
            label2.Name = "label2";
            label2.Size = new Size(42, 21);
            label2.TabIndex = 2;
            label2.Text = "阈值";
            // 
            // uiDoubleUpDown1
            // 
            uiDoubleUpDown1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiDoubleUpDown1.Location = new Point(328, 90);
            uiDoubleUpDown1.Margin = new Padding(4, 5, 4, 5);
            uiDoubleUpDown1.Maximum = 1D;
            uiDoubleUpDown1.Minimum = 0D;
            uiDoubleUpDown1.MinimumSize = new Size(100, 0);
            uiDoubleUpDown1.Name = "uiDoubleUpDown1";
            uiDoubleUpDown1.ShowText = false;
            uiDoubleUpDown1.Size = new Size(182, 29);
            uiDoubleUpDown1.TabIndex = 3;
            uiDoubleUpDown1.Text = "uiDoubleUpDown1";
            uiDoubleUpDown1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiButton1.Location = new Point(367, 190);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(100, 35);
            uiButton1.TabIndex = 4;
            uiButton1.Text = "确定";
            uiButton1.Click += uiButton1_Click;
            // 
            // uiComboBox1
            // 
            uiComboBox1.DataSource = null;
            uiComboBox1.FillColor = Color.White;
            uiComboBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiComboBox1.Location = new Point(328, 137);
            uiComboBox1.Margin = new Padding(4, 5, 4, 5);
            uiComboBox1.MinimumSize = new Size(63, 0);
            uiComboBox1.Name = "uiComboBox1";
            uiComboBox1.Padding = new Padding(0, 0, 30, 2);
            uiComboBox1.Size = new Size(182, 29);
            uiComboBox1.TabIndex = 5;
            uiComboBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiComboBox1.Watermark = "";
            uiComboBox1.SelectedIndexChanged += uiComboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(286, 138);
            label3.Name = "label3";
            label3.Size = new Size(42, 21);
            label3.TabIndex = 2;
            label3.Text = "模式";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(2, 263);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(562, 22);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(144, 17);
            toolStripStatusLabel1.Text = "                                  ";
            // 
            // Template_Matching
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(566, 287);
            Controls.Add(statusStrip1);
            Controls.Add(uiComboBox1);
            Controls.Add(uiButton1);
            Controls.Add(uiDoubleUpDown1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Template_Matching";
            Padding = new Padding(2, 36, 2, 2);
            ShowDragStretch = true;
            ShowInTaskbar = false;
            ShowRadius = false;
            Text = "Template_Matching";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += Template_Matching_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Sunny.UI.UIDoubleUpDown uiDoubleUpDown1;
        private Sunny.UI.UIButton uiButton1;
        public Sunny.UI.UIComboBox uiComboBox1;
        private Label label3;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}