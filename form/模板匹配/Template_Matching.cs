using Image_processing.Class;
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

namespace Image_processing.form.模板匹配
{
    public partial class Template_Matching : UIForm
    {
        public Template_Matching(string v)
        {
            InitializeComponent();
            this.Text = v;
            addColorCode();
        }
        public Template_Matching(string v, string mode, int index)
        {
            InitializeComponent();
            this.Text = v;
            addColorCode();
            Template = new();
            if (mode == "修改")
            {
                Template = Main_form.data_List.Data_list[index].mat_dic["Template"];
                Template_Match_Modes = Main_form.data_List.Data_list[index].int_dic["Template_Match_Modes"];
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = OpenCV.GetMat(Template);
                label1.Visible = false;
            }

        }
        public Mat Template;
        private double threshold;
        private int template_Match_Modes;
        private string? pic_name;

        private Dictionary<string, TemplateMatchModes> MatchModes = new();
        private Dictionary<string, string> remind = new();



        public double Threshold { get => threshold; set => threshold = value; }
        public int Template_Match_Modes { get => template_Match_Modes; set => template_Match_Modes = value; }
        public string Pic_name { get => pic_name; set => pic_name = value; }

        private void addColorCode()
        {
            List<(string, string, TemplateMatchModes)> conversions = new List<(string, string, TemplateMatchModes)>
            {
                ("平方差匹配模式", "适用于源图像和模板图像之间存在较大差异的情况。例如，当模板图像是另一张图片的一部分，但是在形状、大小、旋转或者光照等方面与源图像存在较大差异时，可以使用该模式。",TemplateMatchModes.SqDiff),
                ("标准化平方差匹配模式", "适用于源图像和模板图像之间存在较小差异的情况。例如，当模板图像是另一张图片的一部分，并且在形状、大小、旋转或者光照等方面与源图像存在较小差异时，可以使用该模式。", TemplateMatchModes.SqDiffNormed),
                ("相关性匹配模式", "适用于在亮度和对比度方面相似但形状和纹理方面存在差异的情况。例如，当模板图像与源图像大致相似但是有些区域存在纹理或形状方面的差异，可以使用该模式。", TemplateMatchModes.CCorr),
                ("标准化相关性匹配模式", "适用于源图像和模板图像之间存在较小差异的情况，并且在形状和纹理方面存在较小的差异。例如，当模板图像与源图像大致相似但是有些区域存在轻微的纹理或形状方面的差异时，可以使用该模式。", TemplateMatchModes.CCorrNormed),
                ("相关系数匹配模式", "适用于在亮度、对比度、形状和纹理方面相似的情况。例如，当模板图像与源图像在各个方面都非常相似时，可以使用该模式。", TemplateMatchModes.CCoeff),
                ("标准化相关系数匹配模式", "适用于在亮度、对比度、形状和纹理方面相似的情况，并且源图像和模板图像之间存在较小差异。例如，当模板图像与源图像在各个方面都非常相似但是有些区域存在轻微的差异时，可以使用该模式。", TemplateMatchModes.CCoeffNormed)
            };
            foreach (var conversion in conversions)
            {
                uiComboBox1.Items.Add(conversion.Item1);
                remind.TryAdd(conversion.Item1, conversion.Item2);
                MatchModes.TryAdd(conversion.Item1, conversion.Item3);
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
                pictureBox1.Image = OpenCV.GetMat(Template);
                label1.Visible = false;
            }
            return;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Threshold = uiDoubleUpDown1.Value;
            Template_Match_Modes = uiComboBox1.SelectedIndex;
            if (!Template.Empty() && Threshold > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Template_Matching_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            toolStripStatusLabel1.BackColor = Color.Transparent;
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
                pictureBox1.Image = OpenCV.GetMat(Template);
                label1.Visible = false;
            }
            return;
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? mind = uiComboBox1.SelectedItem.ToString();
            if (mind != null)
            {

                string str = "例如";
                int endindex = remind[mind].IndexOf(str) - 1;
                toolStripStatusLabel1.Text = remind[mind][..endindex];
                statusStrip1.ShowItemToolTips = true;
                toolStripStatusLabel1.ToolTipText = remind[mind];
            }
        }
    }
}
