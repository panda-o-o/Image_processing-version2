using OpenCvSharp;
using OpenCvSharp.XFeatures2D;
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

namespace Image_processing.form.特征识别
{
    public partial class Feature : UIForm
    {

        public string Mode { get; set; }
        public int HessianThreshold { get; set; }
        public double Threshold { get; set; }
        public KeyPoint[] kp2 { get; set; }
        public Mat desc2 = new();
        public Mat Template;
        public string v { get; set; }

        public string Pic_name { get; set; }

        public Feature()
        {
            InitializeComponent();
            Template = new();
        }
        public Feature(string v, string mode, int index)
        {
            InitializeComponent();
            this.Text = v;
            Template = new();
            if (mode == "修改")
            {
                Template = Main_form.data_List.Data_list[index].mat_dic["Template"];
                uiDoubleUpDown1.Value = 1-Main_form.data_List.Data_list[index].dou_dic["Threshold"];
                Mode = Main_form.data_List.Data_list[index].str_dic["mode"];
                if (Mode=="SURF")
                {
                    uiIntegerUpDown1.Value = Main_form.data_List.Data_list[index].int_dic["HessianThreshold"];
                }
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = OpenCV.GetMat(Template);
                label1.Visible = false;
            }

        }

        private void Feature_Load(object sender, EventArgs e)
        {
            uiRichTextBox1.Text = "模式：SURF特征点提取更多，ORB提取更少\r\n" +
                "特征点阈值：SURF的参数，关键点检测的阈值，越高监测的点越少\r\n" +
                "正确点阈值：检测出来之后，需要对点进行判断，越大，判断为正确点的点就越少";
            string[] keyword = { "模式", "特征点阈值", "正确点阈值" };
            foreach (string s in keyword)
            {
                int index = uiRichTextBox1.Text.IndexOf(s);
                uiRichTextBox1.SelectionStart = index;
                uiRichTextBox1.SelectionLength = s.Length;
                uiRichTextBox1.SelectionColor = Color.Red;
            }
            label1.BackColor = Color.Transparent;
            uiComboBox1.SelectedIndex = 0;
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedItem.ToString() == "SURF")
            {
                uiIntegerUpDown1.Visible = true;
                uiLabel2.Visible = true;
            }
            else
            {
                uiIntegerUpDown1.Visible = false;
                uiLabel2.Visible = false;
            }
        }



        private void uiButton1_Click(object sender, EventArgs e)
        {

            if (uiComboBox1.SelectedItem.ToString() == "SURF")
            {
                if (uiIntegerUpDown1.Value != 0 && uiDoubleUpDown1.Value != 0 && !Template.Empty())
                {
                    Mode = "SURF";
                    HessianThreshold = uiIntegerUpDown1.Value;
                    Threshold = uiDoubleUpDown1.Value;
                    using (var detector = SURF.Create(HessianThreshold))
                    {
                        detector.DetectAndCompute(Template, null, out KeyPoint[] kp2, desc2);
                        if (kp2.Length==0)
                        {
                            MessageBox.Show("检测不到特征点，请更换图片");
                            return;
                        }
                        this.kp2 = kp2;
                    }

                    this.DialogResult = DialogResult.OK;

                }
            }
            else
            {
                if (uiDoubleUpDown1.Value != 0 && !Template.Empty())
                {
                    Mode = "ORB";
                    Threshold = uiDoubleUpDown1.Value;
                    using (var detector = ORB.Create())
                    {
                        detector.DetectAndCompute(Template, null, out KeyPoint[] kp2, desc2);
                        this.kp2 = kp2;
                        desc2.ConvertTo(desc2, MatType.CV_32F);
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //打开的文件选择对话框上的标题
            openFileDialog.Title = "请选择文件";
            //设置文件类型
            openFileDialog.Filter = "jpg图片|*.JPG|gif图片|*.GIF|png图片|*.PNG|jpeg图片|*.JPEG|BMP图片|*.BMP";
            //设置默认文件类型显示顺序
            openFileDialog.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录
            openFileDialog.RestoreDirectory = true;
            //设置是否允许多选
            openFileDialog.Multiselect = false;
            //默认打开路径
            openFileDialog.InitialDirectory = @"F:\user\Pictures\Saved Pictures";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                Pic_name = Path.GetFileName(path);
                Template = new Mat(path, ImreadModes.Color);
                if (Template.Empty())
                {
                    MessageBox.Show("打开图片文件错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = OpenCV.GetMat(Template);
                label1.Visible = false;
            }
            return;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //打开的文件选择对话框上的标题
            openFileDialog.Title = "请选择文件";
            //设置文件类型
            openFileDialog.Filter = "jpg图片|*.JPG|gif图片|*.GIF|png图片|*.PNG|jpeg图片|*.JPEG|BMP图片|*.BMP";
            //设置默认文件类型显示顺序
            openFileDialog.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录
            openFileDialog.RestoreDirectory = true;
            //设置是否允许多选
            openFileDialog.Multiselect = false;
            //默认打开路径
            openFileDialog.InitialDirectory = @"F:\user\Pictures\Saved Pictures";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(path);
                Template = new Mat(path, ImreadModes.Color);
                if (Template.Empty())
                {
                    MessageBox.Show("打开图片文件错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = OpenCV.GetMat(Template);
                label1.Visible = false;
            }
            return;
        }
    }
}
