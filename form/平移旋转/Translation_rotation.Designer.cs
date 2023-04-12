namespace Image_processing.form.平移旋转
{
    partial class Translation_rotation
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
            X = new Sunny.UI.UIIntegerUpDown();
            Y = new Sunny.UI.UIIntegerUpDown();
            rotation = new Sunny.UI.UIIntegerUpDown();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiButton1 = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // X
            // 
            X.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            X.Location = new Point(54, 71);
            X.Margin = new Padding(4, 5, 4, 5);
            X.MinimumSize = new Size(100, 0);
            X.Name = "X";
            X.ShowText = false;
            X.Size = new Size(116, 29);
            X.TabIndex = 0;
            X.Text = "uiIntegerUpDown1";
            X.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // Y
            // 
            Y.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Y.Location = new Point(243, 71);
            Y.Margin = new Padding(4, 5, 4, 5);
            Y.MinimumSize = new Size(100, 0);
            Y.Name = "Y";
            Y.ShowText = false;
            Y.Size = new Size(116, 29);
            Y.TabIndex = 0;
            Y.Text = "uiIntegerUpDown1";
            Y.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // rotation
            // 
            rotation.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rotation.Location = new Point(54, 148);
            rotation.Margin = new Padding(4, 5, 4, 5);
            rotation.MinimumSize = new Size(100, 0);
            rotation.Name = "rotation";
            rotation.ShowText = false;
            rotation.Size = new Size(116, 29);
            rotation.TabIndex = 0;
            rotation.Text = "uiIntegerUpDown1";
            rotation.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.Location = new Point(99, 105);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(21, 23);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "X";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel2.Location = new Point(288, 105);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(25, 23);
            uiLabel2.TabIndex = 1;
            uiLabel2.Text = "Y";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel3.Location = new Point(75, 182);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(72, 23);
            uiLabel3.TabIndex = 1;
            uiLabel3.Text = "rotation";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiButton1.Location = new Point(243, 148);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(100, 35);
            uiButton1.TabIndex = 2;
            uiButton1.Text = "确定";
            uiButton1.Click += uiButton1_Click;
            // 
            // Translation_rotation
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(401, 254);
            Controls.Add(uiButton1);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Controls.Add(rotation);
            Controls.Add(Y);
            Controls.Add(X);
            Name = "Translation_rotation";
            Text = "Translation_rotation";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIIntegerUpDown X;
        private Sunny.UI.UIIntegerUpDown Y;
        private Sunny.UI.UIIntegerUpDown rotation;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton uiButton1;
    }
}