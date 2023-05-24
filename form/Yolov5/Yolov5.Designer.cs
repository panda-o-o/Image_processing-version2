namespace Image_processing.form.Yolov5
{
    partial class Yolov5
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
            uiRadioButton1 = new Sunny.UI.UIRadioButton();
            uiRadioButtonGroup1 = new Sunny.UI.UIRadioButtonGroup();
            uiTextBox1 = new Sunny.UI.UITextBox();
            uiRadioButton2 = new Sunny.UI.UIRadioButton();
            model_site = new Sunny.UI.UITextBox();
            uiButton1 = new Sunny.UI.UIButton();
            classes_threshold = new Sunny.UI.UIDoubleUpDown();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            image_width = new Sunny.UI.UIDoubleUpDown();
            image_height = new Sunny.UI.UIDoubleUpDown();
            uiLabel3 = new Sunny.UI.UILabel();
            nms_thres = new Sunny.UI.UIDoubleUpDown();
            uiLabel4 = new Sunny.UI.UILabel();
            confiden_thres = new Sunny.UI.UIDoubleUpDown();
            uiLabel5 = new Sunny.UI.UILabel();
            uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            uiButton2 = new Sunny.UI.UIButton();
            classes = new Sunny.UI.UIRichTextBox();
            uiRadioButtonGroup1.SuspendLayout();
            SuspendLayout();
            // 
            // uiRadioButton1
            // 
            uiRadioButton1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiRadioButton1.Location = new Point(23, 35);
            uiRadioButton1.MinimumSize = new Size(1, 1);
            uiRadioButton1.Name = "uiRadioButton1";
            uiRadioButton1.Padding = new Padding(22, 0, 0, 0);
            uiRadioButton1.Size = new Size(244, 29);
            uiRadioButton1.TabIndex = 0;
            uiRadioButton1.Text = "从文件中读取Classes物体种类";
            uiRadioButton1.CheckedChanged += uiRadioButton1_CheckedChanged;
            // 
            // uiRadioButtonGroup1
            // 
            uiRadioButtonGroup1.Controls.Add(uiTextBox1);
            uiRadioButtonGroup1.Controls.Add(uiRadioButton2);
            uiRadioButtonGroup1.Controls.Add(uiRadioButton1);
            uiRadioButtonGroup1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiRadioButtonGroup1.Location = new Point(4, 40);
            uiRadioButtonGroup1.Margin = new Padding(4, 5, 4, 5);
            uiRadioButtonGroup1.MinimumSize = new Size(1, 1);
            uiRadioButtonGroup1.Name = "uiRadioButtonGroup1";
            uiRadioButtonGroup1.Padding = new Padding(0, 32, 0, 0);
            uiRadioButtonGroup1.Size = new Size(307, 108);
            uiRadioButtonGroup1.TabIndex = 1;
            uiRadioButtonGroup1.Text = "Classes";
            uiRadioButtonGroup1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiTextBox1
            // 
            uiTextBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiTextBox1.Location = new Point(0, 0);
            uiTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new Size(150, 29);
            uiTextBox1.TabIndex = 2;
            uiTextBox1.Text = "Classes";
            uiTextBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "";
            // 
            // uiRadioButton2
            // 
            uiRadioButton2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiRadioButton2.Location = new Point(23, 70);
            uiRadioButton2.MinimumSize = new Size(1, 1);
            uiRadioButton2.Name = "uiRadioButton2";
            uiRadioButton2.Padding = new Padding(22, 0, 0, 0);
            uiRadioButton2.Size = new Size(244, 29);
            uiRadioButton2.TabIndex = 1;
            uiRadioButton2.Text = "手动输入Classes物体种类";
            uiRadioButton2.CheckedChanged += uiRadioButton2_CheckedChanged;
            // 
            // model_site
            // 
            model_site.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            model_site.Location = new Point(4, 158);
            model_site.Margin = new Padding(4, 5, 4, 5);
            model_site.MinimumSize = new Size(1, 16);
            model_site.Name = "model_site";
            model_site.ShowText = false;
            model_site.Size = new Size(433, 29);
            model_site.TabIndex = 5;
            model_site.TextAlignment = ContentAlignment.MiddleLeft;
            model_site.Watermark = "";
            model_site.Leave += model_site_Leave;
            model_site.Enter += model_site_Enter;
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiButton1.Location = new Point(444, 158);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(105, 29);
            uiButton1.TabIndex = 6;
            uiButton1.Text = "选择模型地址";
            uiButton1.Click += uiButton1_Click;
            // 
            // classes_threshold
            // 
            classes_threshold.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            classes_threshold.Location = new Point(273, 263);
            classes_threshold.Margin = new Padding(4, 5, 4, 5);
            classes_threshold.Maximum = 1D;
            classes_threshold.Minimum = 0D;
            classes_threshold.MinimumSize = new Size(100, 0);
            classes_threshold.Name = "classes_threshold";
            classes_threshold.ShowText = false;
            classes_threshold.Size = new Size(116, 29);
            classes_threshold.TabIndex = 7;
            classes_threshold.Text = "uiDoubleUpDown1";
            classes_threshold.TextAlignment = ContentAlignment.MiddleCenter;
            classes_threshold.Value = 0.2D;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.Location = new Point(263, 231);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(141, 23);
            uiLabel1.TabIndex = 9;
            uiLabel1.Text = "模型输入图片宽度";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel2.Location = new Point(421, 231);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(141, 23);
            uiLabel2.TabIndex = 9;
            uiLabel2.Text = "模型输入图片高度";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // image_width
            // 
            image_width.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            image_width.Location = new Point(273, 197);
            image_width.Margin = new Padding(4, 5, 4, 5);
            image_width.MinimumSize = new Size(100, 0);
            image_width.Name = "image_width";
            image_width.ShowText = false;
            image_width.Size = new Size(116, 29);
            image_width.TabIndex = 7;
            image_width.Text = "uiDoubleUpDown1";
            image_width.TextAlignment = ContentAlignment.MiddleCenter;
            image_width.Value = 640D;
            // 
            // image_height
            // 
            image_height.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            image_height.Location = new Point(433, 197);
            image_height.Margin = new Padding(4, 5, 4, 5);
            image_height.MinimumSize = new Size(100, 0);
            image_height.Name = "image_height";
            image_height.ShowText = false;
            image_height.Size = new Size(116, 29);
            image_height.TabIndex = 7;
            image_height.Text = "uiDoubleUpDown1";
            image_height.TextAlignment = ContentAlignment.MiddleCenter;
            image_height.Value = 640D;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel3.Location = new Point(283, 297);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(114, 23);
            uiLabel3.TabIndex = 9;
            uiLabel3.Text = "类别得分阈值";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nms_thres
            // 
            nms_thres.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nms_thres.Location = new Point(273, 331);
            nms_thres.Margin = new Padding(4, 5, 4, 5);
            nms_thres.Maximum = 1D;
            nms_thres.Minimum = 0D;
            nms_thres.MinimumSize = new Size(100, 0);
            nms_thres.Name = "nms_thres";
            nms_thres.ShowText = false;
            nms_thres.Size = new Size(116, 29);
            nms_thres.TabIndex = 7;
            nms_thres.Text = "uiDoubleUpDown1";
            nms_thres.TextAlignment = ContentAlignment.MiddleCenter;
            nms_thres.Value = 0.4D;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel4.Location = new Point(275, 365);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(114, 23);
            uiLabel4.TabIndex = 9;
            uiLabel4.Text = "非极大值抑制阈值";
            uiLabel4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // confiden_thres
            // 
            confiden_thres.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            confiden_thres.Location = new Point(433, 263);
            confiden_thres.Margin = new Padding(4, 5, 4, 5);
            confiden_thres.Maximum = 1D;
            confiden_thres.Minimum = 0D;
            confiden_thres.MinimumSize = new Size(100, 0);
            confiden_thres.Name = "confiden_thres";
            confiden_thres.ShowText = false;
            confiden_thres.Size = new Size(116, 29);
            confiden_thres.TabIndex = 7;
            confiden_thres.Text = "uiDoubleUpDown1";
            confiden_thres.TextAlignment = ContentAlignment.MiddleCenter;
            confiden_thres.Value = 0.4D;
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel5.Location = new Point(444, 297);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(94, 23);
            uiLabel5.TabIndex = 9;
            uiLabel5.Text = "置信度阈值";
            uiLabel5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiRichTextBox1
            // 
            uiRichTextBox1.FillColor = Color.White;
            uiRichTextBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiRichTextBox1.Location = new Point(6, 197);
            uiRichTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiRichTextBox1.MinimumSize = new Size(1, 1);
            uiRichTextBox1.Name = "uiRichTextBox1";
            uiRichTextBox1.Padding = new Padding(2);
            uiRichTextBox1.ShowText = false;
            uiRichTextBox1.Size = new Size(250, 186);
            uiRichTextBox1.TabIndex = 10;
            uiRichTextBox1.Text = "uiRichTextBox1";
            uiRichTextBox1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiButton2
            // 
            uiButton2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiButton2.Location = new Point(438, 331);
            uiButton2.MinimumSize = new Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.Size = new Size(100, 35);
            uiButton2.TabIndex = 11;
            uiButton2.Text = "确定";
            uiButton2.Click += uiButton2_Click;
            // 
            // classes
            // 
            classes.FillColor = Color.White;
            classes.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            classes.Location = new Point(319, 57);
            classes.Margin = new Padding(4, 5, 4, 5);
            classes.MinimumSize = new Size(1, 1);
            classes.Name = "classes";
            classes.Padding = new Padding(2);
            classes.ShowText = false;
            classes.Size = new Size(230, 91);
            classes.TabIndex = 12;
            classes.TextAlignment = ContentAlignment.MiddleCenter;
            classes.Leave += classes_Leave;
            classes.Enter += classes_Enter;
            // 
            // Yolov5
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(563, 433);
            Controls.Add(classes);
            Controls.Add(uiButton2);
            Controls.Add(uiRichTextBox1);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel5);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel1);
            Controls.Add(image_height);
            Controls.Add(image_width);
            Controls.Add(confiden_thres);
            Controls.Add(nms_thres);
            Controls.Add(classes_threshold);
            Controls.Add(uiButton1);
            Controls.Add(model_site);
            Controls.Add(uiRadioButtonGroup1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Yolov5";
            Text = "Yolov5";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += Yolov5_Load;
            uiRadioButtonGroup1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIRadioButton uiRadioButton1;
        private Sunny.UI.UIRadioButtonGroup uiRadioButtonGroup1;
        private Sunny.UI.UIRadioButton uiRadioButton2;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UITextBox model_site;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIDoubleUpDown classes_threshold;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIDoubleUpDown image_width;
        private Sunny.UI.UIDoubleUpDown image_height;
        private Sunny.UI.UIDoubleUpDown nms_thres;
        private Sunny.UI.UIDoubleUpDown confiden_thres;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIRichTextBox classes;
    }
}