namespace Image_processing.form.滤波
{
    partial class Filtering
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
            size = new Sunny.UI.UIIntegerUpDown();
            uiButton1 = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.Location = new Point(109, 140);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(44, 23);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "内核";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // size
            // 
            size.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            size.Location = new Point(69, 84);
            size.Margin = new Padding(4, 5, 4, 5);
            size.Maximum = 100;
            size.Minimum = 1;
            size.MinimumSize = new Size(100, 0);
            size.Name = "size";
            size.ShowText = false;
            size.Size = new Size(125, 38);
            size.TabIndex = 1;
            size.Text = "uiIntegerUpDown1";
            size.TextAlignment = ContentAlignment.MiddleCenter;
            size.Value = 1;
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiButton1.Location = new Point(258, 87);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(100, 35);
            uiButton1.TabIndex = 2;
            uiButton1.Text = "确定";
            uiButton1.Click += uiButton1_Click;
            // 
            // Filtering
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(441, 188);
            Controls.Add(uiButton1);
            Controls.Add(size);
            Controls.Add(uiLabel1);
            Name = "Filtering";
            Text = "Filtering";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIIntegerUpDown size;
        private Sunny.UI.UIButton uiButton1;
    }
}