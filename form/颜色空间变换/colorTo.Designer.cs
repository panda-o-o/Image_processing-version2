using System.Windows.Forms;

namespace Image_processing.form
{
    partial class colorTo
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
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            comboBox1 = new Sunny.UI.UIComboBox();
            button1 = new Sunny.UI.UIButton();
            uiLabel1 = new Sunny.UI.UILabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Gainsboro;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 110);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(414, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BackColor = Color.Gainsboro;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(44, 17);
            toolStripStatusLabel1.Text = "         ";
            // 
            // comboBox1
            // 
            comboBox1.DataSource = null;
            comboBox1.FillColor = Color.White;
            comboBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.Location = new Point(105, 58);
            comboBox1.Margin = new Padding(4, 5, 4, 5);
            comboBox1.MinimumSize = new Size(63, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Padding = new Padding(0, 0, 30, 2);
            comboBox1.Size = new Size(150, 29);
            comboBox1.TabIndex = 3;
            comboBox1.TextAlignment = ContentAlignment.MiddleCenter;
            comboBox1.Watermark = "";
            comboBox1.ZoomScaleDisabled = true;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(280, 58);
            button1.MinimumSize = new Size(1, 1);
            button1.Name = "button1";
            button1.Size = new Size(95, 29);
            button1.TabIndex = 4;
            button1.Text = "确定";
            button1.ZoomScaleDisabled = true;
            button1.Click += button1_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.Location = new Point(55, 58);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(100, 29);
            uiLabel1.TabIndex = 5;
            uiLabel1.Text = "模式";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // colorTo
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(414, 132);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(statusStrip1);
            Controls.Add(uiLabel1);
            Name = "colorTo";
            ShowRadius = false;
            ShowRect = false;
            Text = "colorTo";
            ZoomScaleRect = new Rectangle(15, 15, 402, 114);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Sunny.UI.UIComboBox comboBox1;
        private Sunny.UI.UIButton button1;
        private Sunny.UI.UILabel uiLabel1;
    }
}