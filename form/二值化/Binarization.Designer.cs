namespace Image_processing.form.二值化
{
    partial class Binarization
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
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            uiIntegerUpDown1 = new Sunny.UI.UIIntegerUpDown();
            uiButton1 = new Sunny.UI.UIButton();
            uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            comboBox1 = new Sunny.UI.UIComboBox();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.Location = new Point(261, 68);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(100, 23);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "阈值";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel2.Location = new Point(261, 131);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(100, 23);
            uiLabel2.TabIndex = 0;
            uiLabel2.Text = "模式";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiIntegerUpDown1
            // 
            uiIntegerUpDown1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiIntegerUpDown1.Location = new Point(317, 66);
            uiIntegerUpDown1.Margin = new Padding(4, 5, 4, 5);
            uiIntegerUpDown1.MinimumSize = new Size(100, 0);
            uiIntegerUpDown1.Name = "uiIntegerUpDown1";
            uiIntegerUpDown1.ShowText = false;
            uiIntegerUpDown1.Size = new Size(116, 29);
            uiIntegerUpDown1.TabIndex = 1;
            uiIntegerUpDown1.Text = "uiIntegerUpDown1";
            uiIntegerUpDown1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiButton1.Location = new Point(314, 214);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(100, 35);
            uiButton1.TabIndex = 9;
            uiButton1.Text = "确定";
            uiButton1.Click += uiButton1_Click;
            // 
            // uiRichTextBox1
            // 
            uiRichTextBox1.FillColor = Color.White;
            uiRichTextBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiRichTextBox1.Location = new Point(4, 50);
            uiRichTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiRichTextBox1.MinimumSize = new Size(1, 1);
            uiRichTextBox1.Name = "uiRichTextBox1";
            uiRichTextBox1.Padding = new Padding(2);
            uiRichTextBox1.ReadOnly = true;
            uiRichTextBox1.ShowText = false;
            uiRichTextBox1.Size = new Size(250, 199);
            uiRichTextBox1.TabIndex = 10;
            uiRichTextBox1.Text = "uiRichTextBox1";
            uiRichTextBox1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.DataSource = null;
            comboBox1.FillColor = Color.White;
            comboBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.Location = new Point(314, 131);
            comboBox1.Margin = new Padding(4, 5, 4, 5);
            comboBox1.MinimumSize = new Size(63, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Padding = new Padding(0, 0, 30, 2);
            comboBox1.Size = new Size(136, 29);
            comboBox1.TabIndex = 4;
            comboBox1.TextAlignment = ContentAlignment.MiddleCenter;
            comboBox1.Watermark = "";
            comboBox1.ZoomScaleDisabled = true;
            // 
            // Binarization
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(479, 282);
            Controls.Add(comboBox1);
            Controls.Add(uiRichTextBox1);
            Controls.Add(uiButton1);
            Controls.Add(uiIntegerUpDown1);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Name = "Binarization";
            Text = "二值化";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += Binarization_Load;
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIIntegerUpDown uiIntegerUpDown1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
        private Sunny.UI.UIComboBox comboBox1;
    }
}