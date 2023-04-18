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

namespace Image_processing.main_Form
{
    public partial class Insert : UIForm
    {
        public Insert()
        {
            InitializeComponent();
            dic = new Dictionary<string, del_process>();
        }
        Dictionary<string, del_process> dic;

        public del_process? _Process { get; set; }
        public string? _Name { get; set; }

        private void Insert_Load(object sender, EventArgs e)
        {
            (string, del_process)[] tupes = new[]
            {
                ("颜色空间变化", new del_process(OpenCV.colorto)),
                ("均值滤波",new del_process(OpenCV.medianBlur)),
                ("方框滤波",new del_process(OpenCV.boxFilter)),
                ("高斯滤波",new del_process(OpenCV.Gaussian_Blur)),
                ("中值滤波",new del_process(OpenCV.Median_Blur)),
                ("双边滤波",new del_process(OpenCV.Bilateral_Filter)),
                ("上下翻转",new del_process(OpenCV.X_Flip)),
                ("左右翻转",new del_process(OpenCV.Y_Flip)),
                ("全翻转",new del_process(OpenCV.XY_Flip)),
                ("二值化",new del_process(OpenCV.ToBinary)),
                ("自适应阈值",new del_process(OpenCV.AdaptiveThreshold)),
                ("Otsu算法",new del_process(OpenCV.Otsu)),
                ("腐蚀",new del_process(OpenCV.Corrosion)),
                ("膨胀",new del_process(OpenCV.Expansion)),
                ("开运算",new del_process(OpenCV.Open_operation)),
                ("闭运算", new del_process(OpenCV.Close_operation)),
                ("梯度运算", new del_process(OpenCV.Gradient_operation)),
                ("顶帽运算", new del_process(OpenCV.Top_hat_operation)),
                ("黑帽运算", new del_process(OpenCV.Black_hat_operation)),
                ("平移旋转",new del_process(OpenCV.Translation_rotation)),
                ("模板匹配",new del_process(OpenCV.Template_Match))
            };
            foreach (var tupe in tupes)
            {
                dic.Add(tupe.Item1, tupe.Item2);
                uiComboBox1.Items.Add(tupe.Item1);
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedItem != null)
            {
#pragma warning disable CS8604 // 引用类型参数可能为 null。
                _Process = dic[uiComboBox1.SelectedItem.ToString()];
                _Name = uiComboBox1.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
