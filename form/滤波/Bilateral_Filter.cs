using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_processing.form.滤波
{
    public partial class Bilateral_Filter : UIForm
    {
        public double SigmaColor { get; set; }
        public double SigmaSpace { get; set; }

        public Bilateral_Filter()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            SigmaColor = sigmaColor.Value;
            SigmaSpace = sigmaSpace.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void Bilateral_Filter_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; // 启用快捷键
            this.KeyDown += new KeyEventHandler(Bilateral_Filter_KeyDown); // 绑定按键事件
            uiRichTextBox1.Text = "sigmaColor：颜色空间滤波器的sigma值。这个参数的值越大，就表明该像素邻域内有更宽广的颜色会被混合到一起，产生较大的半相等颜色区域。\r\n" +
                "sigmaSpace：坐标空间中滤波器的sigma值，坐标空间的标注方差。他的数值越大，意味着越远的像素会相互影响，从而使更大的区域足够相似的颜色获取相同的颜色。";
            string[] keyword = { "sigmaColor", "sigmaSpace" };
            foreach (string s in keyword)
            {
                int index = uiRichTextBox1.Text.IndexOf(s);
                uiRichTextBox1.SelectionStart = index;
                uiRichTextBox1.SelectionLength = s.Length;
                uiRichTextBox1.SelectionColor = Color.Red;
            }
        }

        private void Bilateral_Filter_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // 检查按键是否为 Enter
            {
                // 执行按下操作
                uiButton1.PerformClick();
                e.SuppressKeyPress = true; // 防止按键发出声音
            }
        }
    }
}
