using OpenCvSharp;
using Sunny.UI;

namespace Image_processing.form
{
    public partial class colorTo : UIForm
    {
        public colorTo()
        {
            InitializeComponent();
            remind = new();
            color = new();
            addColorCode();
        }

        public ColorConversionCodes ColorCode { get; set; }
        private Dictionary<string, ColorConversionCodes> color;
        private Dictionary<string, string> remind;

        private void addColorCode()
        {
            List<(string, string, ColorConversionCodes)> conversions = new List<(string, string, ColorConversionCodes)>
            {
                ("BGR2GRAY", "将 BGR 彩色图像转换为灰度图像。", ColorConversionCodes.BGR2GRAY),
                ("GRAY2BGR", "将灰度图像转换为 BGR 彩色图像。", ColorConversionCodes.GRAY2BGR),
                ("BGR2RGB", "将BGR 彩色图像转化为 RGB 彩色图像。", ColorConversionCodes.BGR2RGB),
                ("RGB2BGR", "将RGB 彩色图像转化为 BGR 彩色图像。", ColorConversionCodes.RGB2BGR),
                ("BGR2HSV", "将 BGR 彩色图像转换为 HSV 彩色图像。", ColorConversionCodes.BGR2HSV),
                ("HSV2BGR", "将 HSV 彩色图像转换为 BGR 彩色图像。", ColorConversionCodes.HSV2BGR)
            };
            foreach (var conversion in conversions)
            {
                comboBox1.Items.Add(conversion.Item1);
                remind.TryAdd(conversion.Item1, conversion.Item2);
                color.TryAdd(conversion.Item1, conversion.Item3);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string? code = comboBox1.SelectedItem.ToString();
#pragma warning disable CS8604 // 引用类型参数可能为 null。
                ColorCode = color[key: code];
#pragma warning restore CS8604 // 引用类型参数可能为 null。
                this.DialogResult = DialogResult.OK;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? mind = comboBox1.SelectedItem.ToString();
            if (mind != null)
            {
                toolStripStatusLabel1.Text = remind[mind];
            }
        }
    }
}