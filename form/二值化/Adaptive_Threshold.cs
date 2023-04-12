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

namespace Image_processing.form.二值化
{
    public partial class Adaptive_Threshold : UIForm
    {
        public Adaptive_Threshold()
        {
            InitializeComponent();
        }

        public AdaptiveThresholdTypes Adaptive_Types { get; private set; }
        public ThresholdTypes Threshold_Types { get; private set; }

        private void Adaptive_Threshold_Load(object sender, EventArgs e)
        {
            uiComboBox1.Items.Add("局部邻域块均值");
            uiComboBox1.Items.Add("局部邻域块高斯加权和");
            uiComboBox2.Items.Add("二值化阈值处理");
            uiComboBox2.Items.Add("反二值化阈值处理");
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedItem != null && uiComboBox2.SelectedItem != null)
            {
                Adaptive_Types = (AdaptiveThresholdTypes)uiComboBox1.SelectedIndex;
                Threshold_Types = (ThresholdTypes)uiComboBox2.SelectedIndex;
                this.DialogResult = DialogResult.OK;
            }

        }
    }
}
