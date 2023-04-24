namespace Image_processing.form.摄像头
{
    partial class Camera
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
            uiIntegerUpDown1 = new Sunny.UI.UIIntegerUpDown();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            uiButton1 = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // uiComboBox1
            // 
            uiComboBox1.DataSource = null;
            uiComboBox1.FillColor = Color.White;
            uiComboBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiComboBox1.Location = new Point(223, 93);
            uiComboBox1.Margin = new Padding(4, 5, 4, 5);
            uiComboBox1.MinimumSize = new Size(63, 0);
            uiComboBox1.Name = "uiComboBox1";
            uiComboBox1.Padding = new Padding(0, 0, 30, 2);
            uiComboBox1.Size = new Size(196, 42);
            uiComboBox1.TabIndex = 0;
            uiComboBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiComboBox1.Watermark = "";
            // 
            // uiIntegerUpDown1
            // 
            uiIntegerUpDown1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiIntegerUpDown1.Location = new Point(221, 166);
            uiIntegerUpDown1.Margin = new Padding(4, 5, 4, 5);
            uiIntegerUpDown1.MinimumSize = new Size(100, 0);
            uiIntegerUpDown1.Name = "uiIntegerUpDown1";
            uiIntegerUpDown1.ShowText = false;
            uiIntegerUpDown1.Size = new Size(196, 37);
            uiIntegerUpDown1.TabIndex = 1;
            uiIntegerUpDown1.Text = "uiIntegerUpDown1";
            uiIntegerUpDown1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.Location = new Point(90, 95);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(100, 32);
            uiLabel1.TabIndex = 2;
            uiLabel1.Text = "摄像头选择";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel2.Location = new Point(90, 163);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(100, 39);
            uiLabel2.TabIndex = 2;
            uiLabel2.Text = "视频帧率";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiButton1.Location = new Point(206, 235);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(100, 38);
            uiButton1.TabIndex = 3;
            uiButton1.Text = "确定";
            uiButton1.Click += uiButton1_Click;
            // 
            // Camera
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(537, 299);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Controls.Add(uiButton1);
            Controls.Add(uiIntegerUpDown1);
            Controls.Add(uiComboBox1);
            Name = "Camera";
            Text = "Camera";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += Camera_Load;
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UIIntegerUpDown uiIntegerUpDown1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton uiButton1;
    }
}