namespace Image_processing.form.特征识别
{
    partial class Feature
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
            uiComboBox1 = new Sunny.UI.UIComboBox();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            uiIntegerUpDown1 = new Sunny.UI.UIIntegerUpDown();
            uiLabel3 = new Sunny.UI.UILabel();
            uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            uiButton1 = new Sunny.UI.UIButton();
            uiDoubleUpDown1 = new Sunny.UI.UIDoubleUpDown();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // uiComboBox1
            // 
            uiComboBox1.DataSource = null;
            uiComboBox1.FillColor = Color.White;
            uiComboBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiComboBox1.Items.AddRange(new object[] { "SURF", "ORB" });
            uiComboBox1.Location = new Point(446, 82);
            uiComboBox1.Margin = new Padding(4, 5, 4, 5);
            uiComboBox1.MinimumSize = new Size(63, 0);
            uiComboBox1.Name = "uiComboBox1";
            uiComboBox1.Padding = new Padding(0, 0, 30, 2);
            uiComboBox1.Size = new Size(225, 44);
            uiComboBox1.TabIndex = 0;
            uiComboBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiComboBox1.Watermark = "";
            uiComboBox1.SelectedIndexChanged += uiComboBox1_SelectedIndexChanged;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.Location = new Point(369, 82);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(150, 34);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "模式";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel2.Location = new Point(353, 164);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(255, 55);
            uiLabel2.TabIndex = 2;
            uiLabel2.Text = "特征点阈值";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiIntegerUpDown1
            // 
            uiIntegerUpDown1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiIntegerUpDown1.Location = new Point(491, 174);
            uiIntegerUpDown1.Margin = new Padding(4, 5, 4, 5);
            uiIntegerUpDown1.MinimumSize = new Size(100, 0);
            uiIntegerUpDown1.Name = "uiIntegerUpDown1";
            uiIntegerUpDown1.ShowText = false;
            uiIntegerUpDown1.Size = new Size(174, 44);
            uiIntegerUpDown1.TabIndex = 3;
            uiIntegerUpDown1.Text = "uiIntegerUpDown1";
            uiIntegerUpDown1.TextAlignment = ContentAlignment.MiddleCenter;
            uiIntegerUpDown1.Value = 100;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel3.Location = new Point(353, 249);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(255, 55);
            uiLabel3.TabIndex = 2;
            uiLabel3.Text = "正确点阈值";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiRichTextBox1
            // 
            uiRichTextBox1.FillColor = Color.White;
            uiRichTextBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiRichTextBox1.Location = new Point(23, 69);
            uiRichTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiRichTextBox1.MinimumSize = new Size(1, 1);
            uiRichTextBox1.Name = "uiRichTextBox1";
            uiRichTextBox1.Padding = new Padding(2);
            uiRichTextBox1.ShowText = false;
            uiRichTextBox1.Size = new Size(323, 309);
            uiRichTextBox1.TabIndex = 4;
            uiRichTextBox1.Text = "uiRichTextBox1";
            uiRichTextBox1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiButton1.Location = new Point(446, 326);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(150, 52);
            uiButton1.TabIndex = 5;
            uiButton1.Text = "确定";
            uiButton1.Click += uiButton1_Click;
            // 
            // uiDoubleUpDown1
            // 
            uiDoubleUpDown1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiDoubleUpDown1.Location = new Point(491, 260);
            uiDoubleUpDown1.Margin = new Padding(4, 5, 4, 5);
            uiDoubleUpDown1.Maximum = 1D;
            uiDoubleUpDown1.Minimum = 0D;
            uiDoubleUpDown1.MinimumSize = new Size(100, 0);
            uiDoubleUpDown1.Name = "uiDoubleUpDown1";
            uiDoubleUpDown1.ShowText = false;
            uiDoubleUpDown1.Size = new Size(174, 44);
            uiDoubleUpDown1.TabIndex = 6;
            uiDoubleUpDown1.Text = "uiDoubleUpDown1";
            uiDoubleUpDown1.TextAlignment = ContentAlignment.MiddleCenter;
            uiDoubleUpDown1.Value = 0.8D;
            // 
            // label1
            // 
            label1.Location = new Point(731, 133);
            label1.Name = "label1";
            label1.Size = new Size(243, 184);
            label1.TabIndex = 8;
            label1.Text = "点击，打开一张模板图片";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(697, 82);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(315, 296);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Feature
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1043, 404);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(uiDoubleUpDown1);
            Controls.Add(uiButton1);
            Controls.Add(uiRichTextBox1);
            Controls.Add(uiIntegerUpDown1);
            Controls.Add(uiComboBox1);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel1);
            Controls.Add(uiLabel2);
            Name = "Feature";
            Text = "Feature";
            ZoomScaleRect = new Rectangle(22, 22, 800, 450);
            Load += Feature_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIIntegerUpDown uiIntegerUpDown1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIDoubleUpDown uiDoubleUpDown1;
        private Label label1;
        private PictureBox pictureBox1;
    }
}