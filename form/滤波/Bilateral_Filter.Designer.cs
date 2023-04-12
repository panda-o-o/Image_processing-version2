namespace Image_processing.form.滤波
{
    partial class Bilateral_Filter
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
            sigmaSpace = new Sunny.UI.UIDoubleUpDown();
            sigmaColor = new Sunny.UI.UIDoubleUpDown();
            uiButton1 = new Sunny.UI.UIButton();
            uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.Location = new Point(191, 69);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(100, 23);
            uiLabel1.TabIndex = 4;
            uiLabel1.Text = "sigmaColor";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel2.Location = new Point(191, 140);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(100, 23);
            uiLabel2.TabIndex = 4;
            uiLabel2.Text = "sigmaSpace";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sigmaSpace
            // 
            sigmaSpace.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            sigmaSpace.Location = new Point(296, 134);
            sigmaSpace.Margin = new Padding(4, 5, 4, 5);
            sigmaSpace.MinimumSize = new Size(100, 0);
            sigmaSpace.Name = "sigmaSpace";
            sigmaSpace.ShowText = false;
            sigmaSpace.Size = new Size(125, 36);
            sigmaSpace.Step = 1D;
            sigmaSpace.TabIndex = 7;
            sigmaSpace.Text = "uiDoubleUpDown1";
            sigmaSpace.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // sigmaColor
            // 
            sigmaColor.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            sigmaColor.Location = new Point(296, 62);
            sigmaColor.Margin = new Padding(4, 5, 4, 5);
            sigmaColor.MinimumSize = new Size(100, 0);
            sigmaColor.Name = "sigmaColor";
            sigmaColor.ShowText = false;
            sigmaColor.Size = new Size(125, 36);
            sigmaColor.Step = 1D;
            sigmaColor.TabIndex = 8;
            sigmaColor.Text = "uiDoubleUpDown1";
            sigmaColor.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiButton1.Location = new Point(263, 198);
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
            uiRichTextBox1.Location = new Point(4, 53);
            uiRichTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiRichTextBox1.MinimumSize = new Size(1, 1);
            uiRichTextBox1.Name = "uiRichTextBox1";
            uiRichTextBox1.Padding = new Padding(2);
            uiRichTextBox1.ReadOnly = true;
            uiRichTextBox1.ShowText = false;
            uiRichTextBox1.Size = new Size(186, 205);
            uiRichTextBox1.TabIndex = 10;
            uiRichTextBox1.Text = "uiRichTextBox1";
            uiRichTextBox1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // Bilateral_Filter
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(458, 281);
            Controls.Add(uiRichTextBox1);
            Controls.Add(uiButton1);
            Controls.Add(sigmaColor);
            Controls.Add(sigmaSpace);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Name = "Bilateral_Filter";
            Text = "双边滤波";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += Bilateral_Filter_Load;
            KeyDown += Bilateral_Filter_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIDoubleUpDown sigmaSpace;
        private Sunny.UI.UIDoubleUpDown sigmaColor;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
    }
}