using Image_processing.Class;
using OpenCvSharp;
using OpenCvSharp.Dnn;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Image_processing.form.Yolov5
{
    public partial class Yolov5 : UIForm
    {
        private string class_list;//加载的classes类
        private float input_width = 640.0f;//输入模型图片宽度
        private float input_height = 640.0f;//输入模型图片高度
        private float score_threshold = 0.2f;//类别得分阈值
        private float nms_threshold = 0.4f;//非极大值抑制阈值
        private float confidence_threshold = 0.4f;//置信度阈值
        private string? class_path;
        private string onnx_path;

        public string Class_list { get => class_list; set => class_list = value; }
        public float Input_width { get => input_width; set => input_width = value; }
        public float Input_height { get => input_height; set => input_height = value; }
        public float Score_threshold { get => score_threshold; set => score_threshold = value; }
        public float Nms_threshold { get => nms_threshold; set => nms_threshold = value; }
        public float Confidence_threshold { get => confidence_threshold; set => confidence_threshold = value; }
        public string Class_path { get => class_path; set => class_path = value; }
        public string Onnx_path { get => onnx_path; set => onnx_path = value; }

        public Yolov5()
        {
            InitializeComponent();
            model_site.Text = "请输入模型地址";
            model_site.ForeColor = Color.Gray;
        }
        public Yolov5(string v, string mode, int index)
        {
            InitializeComponent();
            model_site.Text = "请输入模型地址";
            model_site.ForeColor = Color.Gray;
            if (mode == "修改")
            {
                Class_path = Main_form.data_List.Data_list[index].str_dic["class_path"];
                if (Class_path != null)
                {
                    using StreamReader reader = new(Class_path);
                    classes.Text = reader.ReadToEnd();
                }
                else
                {
                    classes.Text = Main_form.public_Environment.Yolov5_class;
                }
                Onnx_path = Main_form.data_List.Data_list[index].str_dic["onnx_path"];
                image_width.Value = Main_form.data_List.Data_list[index].flo_dic["Input_width"];
                image_height.Value = Main_form.data_List.Data_list[index].flo_dic["Input_height"];
                classes_threshold.Value = Main_form.data_List.Data_list[index].flo_dic["Score_threshold"];
                nms_thres.Value = Main_form.data_List.Data_list[index].flo_dic["Nms_threshold"];
                confiden_thres.Value = Main_form.data_List.Data_list[index].flo_dic["Confidence_threshold"];
            }
        }
        private void model_site_Enter(object sender, EventArgs e)
        {
            if (model_site.Text == "请输入模型地址")
            {
                model_site.Text = "";
                model_site.ForeColor = Color.Black;
            }
        }

        private void model_site_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(model_site.Text))
            {
                model_site.Text = "请输入模型地址";
                model_site.ForeColor = Color.Gray;
            }


        }
        private void classes_Enter(object sender, EventArgs e)
        {
            if (classes.Text == "请在此输入模型类别，一行一个类")
            {
                classes.Text = "";
                classes.ForeColor = Color.Black;
            }
        }

        private void classes_Leave(object sender, EventArgs e)
        {
            if (uiRadioButton2.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(classes.Text))
                {
                    classes.Text = "请在此输入模型类别，一行一个类";
                    classes.ForeColor = Color.Gray;
                }
            }
        }

        private void uiRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (uiRadioButton1.Checked == true)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                //打开的文件选择对话框上的标题
                openFileDialog.Title = "请选择Classes文件";
                //设置文件类型
                openFileDialog.Filter = "txt文件|*.txt";
                //设置默认文件类型显示顺序
                openFileDialog.FilterIndex = 1;
                //保存对话框是否记忆上次打开的目录
                openFileDialog.RestoreDirectory = false;
                //设置是否允许多选
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    Class_path = path;
                    using StreamReader reader = new(path);
                    classes.Text = reader.ReadToEnd();
                }
            }
        }

        private void uiRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            classes.Text = "请在此输入模型类别，一行一个类";
            classes.ForeColor = Color.Gray;
            class_path = null;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //打开的文件选择对话框上的标题
            openFileDialog.Title = "请选择模型文件";
            //设置文件类型
            openFileDialog.Filter = "onnx文件|*.onnx";
            //设置默认文件类型显示顺序
            openFileDialog.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录
            openFileDialog.RestoreDirectory = false;
            //设置是否允许多选
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                Onnx_path = path;
                model_site.Text = path;
            }
        }

        private void Yolov5_Load(object sender, EventArgs e)
        {
            uiRichTextBox1.Text = "类别得分阈值：通常设置为一个比较小的数，比如0.1或0.3等。如果某个边界框的预测分数低于这个阈值，则认为该边界框对应的目标不存在，阈值越高，筛选出来的目标数量就越少。\r\n\r\n" +
                "非极大值抑制阈值：主要控制重叠的锚框保留数量，通常设置为一个比较小的数，比如0.5或0.6等。当不同锚框对应同一个物体时，非极大值抑制会过滤掉那些与其他框高重叠的框，从而减少误检。\r\n\r\n" +
                "置信度阈值：控制正样本的限制，需要对模型的输出结果进行过滤，通常设置为一个比较高的数，比如0.5或0.7等。如果锚框的置信度分数低于这个阈值，则认为该锚框没有预测到目标，从而减少虚警。\r\n\r\n" +
                "总结来说，类别得分阈值可以控制检测出来的目标数量，非极大值抑制阈值可以控制结果的重叠度，置信度阈值则可以减少虚警。在使用时需要根据具体场景进行调整，并综合考虑这三个阈值对结果的影响，以获得最优的检测效果。";
            string[] key = new string[] { "类别得分阈值", "非极大值抑制阈值", "置信度阈值" };
            foreach (var item in key)
            {
                int index = uiRichTextBox1.Text.IndexOf(item);
                uiRichTextBox1.SelectionStart = index;
                uiRichTextBox1.SelectionLength = item.Length;
                uiRichTextBox1.SelectionColor = Color.Red;
            }

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (class_path != null)
            {
                using StreamReader reader = new(class_path);
                Class_list = reader.ReadToEnd();
            }
            else if (!classes.Text.Contains("请在此输入模型类别，一行一个类"))
            {
                string originalString = classes.Text;// 将文件内容分割成行并存储到数组中
                Class_list = originalString;
                if (MessageBox.Show("是否保存Classes类，以便下次使用", "保存", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "文本文件|*.txt";
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // 保存文件
                        File.WriteAllText(saveDialog.FileName, originalString);
                    }
                }
            }
            else
            {
                MessageBox.Show("Classes类别为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (onnx_path != null)
            {
                using var net = CvDnn.ReadNetFromOnnx(onnx_path);
                if (net is null) // 添加非空判断
                {
                    MessageBox.Show("打开模型错误，请重新选择模型", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                net.SetPreferableBackend(Backend.DEFAULT);
                net.SetPreferableTarget(Target.CPU);
            }
            else
            {
                MessageBox.Show("请选择模型", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            Input_width = (float)image_width.Value;
            Input_height = (float)image_height.Value;
            Score_threshold = (float)classes_threshold.Value;
            Nms_threshold = (float)nms_thres.Value;
            Confidence_threshold = (float)confiden_thres.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
