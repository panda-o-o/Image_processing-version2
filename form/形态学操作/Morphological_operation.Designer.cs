namespace Image_processing.form.形态学操作
{
    partial class Morphological_operation
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
            shapewidth = new Sunny.UI.UIIntegerUpDown();
            shapeheight = new Sunny.UI.UIIntegerUpDown();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiButton1 = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // uiComboBox1
            // 
            uiComboBox1.DataSource = null;
            uiComboBox1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            uiComboBox1.FillColor = Color.White;
            uiComboBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiComboBox1.Items.AddRange(new object[] { "矩形", "十字形（以矩形的锚点为中心的十字架）", "椭圆（矩形的内切圆）" });
            uiComboBox1.Location = new Point(20, 83);
            uiComboBox1.Margin = new Padding(4, 5, 4, 5);
            uiComboBox1.MinimumSize = new Size(63, 0);
            uiComboBox1.Name = "uiComboBox1";
            uiComboBox1.Padding = new Padding(0, 0, 30, 2);
            uiComboBox1.Size = new Size(125, 29);
            uiComboBox1.TabIndex = 0;
            uiComboBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiComboBox1.Watermark = "";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.Location = new Point(45, 117);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(75, 23);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "核的形状";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // shapewidth
            // 
            shapewidth.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            shapewidth.Location = new Point(238, 59);
            shapewidth.Margin = new Padding(4, 5, 4, 5);
            shapewidth.MinimumSize = new Size(100, 0);
            shapewidth.Name = "shapewidth";
            shapewidth.ShowText = false;
            shapewidth.Size = new Size(116, 29);
            shapewidth.TabIndex = 2;
            shapewidth.Text = "uiIntegerUpDown1";
            shapewidth.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // shapeheight
            // 
            shapeheight.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            shapeheight.Location = new Point(238, 111);
            shapeheight.Margin = new Padding(4, 5, 4, 5);
            shapeheight.MinimumSize = new Size(100, 0);
            shapeheight.Name = "shapeheight";
            shapeheight.ShowText = false;
            shapeheight.Size = new Size(116, 29);
            shapeheight.TabIndex = 2;
            shapeheight.Text = "uiIntegerUpDown1";
            shapeheight.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel2.Location = new Point(160, 59);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(100, 23);
            uiLabel2.TabIndex = 1;
            uiLabel2.Text = "核的高度：";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel3.Location = new Point(158, 113);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(100, 23);
            uiLabel3.TabIndex = 1;
            uiLabel3.Text = "核的宽度：";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiButton1.Location = new Point(117, 157);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(100, 35);
            uiButton1.TabIndex = 3;
            uiButton1.Text = "确定";
            uiButton1.Click += uiButton1_Click;
            // 
            // Morphological_operation
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(394, 217);
            Controls.Add(uiButton1);
            Controls.Add(shapeheight);
            Controls.Add(shapewidth);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Controls.Add(uiComboBox1);
            Name = "Morphological_operation";
            Text = "Corrosion";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIIntegerUpDown shapewidth;
        private Sunny.UI.UIIntegerUpDown shapeheight;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton uiButton1;
    }
}