using OpenCvSharp;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Image_processing.form.二值化
{
    public partial class Binarization : UIForm
    {
        public Binarization()
        {
            InitializeComponent();
        }
        public Binarization(string mode)
        {
            InitializeComponent();
            this.Text = mode;
        }


        public int Threshold { get; set; }
        public ThresholdTypes Binarization_mode { get; private set; }
        Dictionary<string, ThresholdTypes>? dic;
        private void Binarization_Load(object sender, EventArgs e)
        {
            uiRichTextBox1.Text = "Binary: 将像素值大于阈值的部分设置为最大值,其余部分设置为0\r\n" +
                "BinaryInv: 将像素值小于阈值的部分设置为最大值,其余部分设置为0\r\n" +
                "Trunc: 将像素值大于阈值的部分设置为阈值,其余部分不变\r\n" +
                "ToZero: 将像素值小于阈值的部分设置为0,其余部分不变\r\n" +
                "ToZeroInv: 将像素值大于阈值的部分设置为0,其余部分不变\r\n\r\n" +
                "当阈值为0的时候,阈值为图像平均值";
            dic = new();
            dic.TryAdd("Binary", ThresholdTypes.Binary);
            dic.TryAdd("BinaryInv", ThresholdTypes.BinaryInv);
            dic.TryAdd("Trunc", ThresholdTypes.Trunc);
            dic.TryAdd("ToZero", ThresholdTypes.Tozero);
            dic.TryAdd("ToZeroInv", ThresholdTypes.TozeroInv);
            foreach (var key in dic.Keys)
            {
                comboBox1.Items.Add(key);
                int index = uiRichTextBox1.Text.IndexOf(key);
                uiRichTextBox1.SelectionStart = index;
                uiRichTextBox1.SelectionLength = key.Length;
                uiRichTextBox1.SelectionColor = Color.Red;
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Threshold = (int)uiIntegerUpDown1.Value;
                string? key = comboBox1.SelectedItem.ToString();
                Binarization_mode = dic[key: key];
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
