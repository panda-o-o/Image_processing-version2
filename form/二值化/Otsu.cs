using OpenCvSharp;
using Sunny.UI;

namespace Image_processing.form.二值化
{
    public partial class Otsu : UIForm
    {
        public Otsu()
        {
            InitializeComponent();
        }
        public Otsu(string mode)
        {
            dic = new Dictionary<string, ThresholdTypes>();
            InitializeComponent();
            this.Text = mode;
        }
        public ThresholdTypes Binarization_mode { get; private set; }
        Dictionary<string, ThresholdTypes>? dic;

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedItem != null)
            {
                string? key = uiComboBox1.SelectedItem.ToString();
                Binarization_mode = dic[key: key];
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Otsu_Load(object sender, EventArgs e)
        {

            dic.TryAdd("Binary", ThresholdTypes.Binary);
            dic.TryAdd("BinaryInv", ThresholdTypes.BinaryInv);
            uiRichTextBox1.Text = "Binary: 将像素值大于阈值的部分设置为最大值,其余部分设置为0\r\n" +
                "BinaryInv: 将像素值小于阈值的部分设置为最大值,其余部分设置为0\r\n";
            foreach (var key in dic.Keys)
            {
                uiComboBox1.Items.Add(key);
                int index = uiRichTextBox1.Text.IndexOf(key);
                uiRichTextBox1.SelectionStart = index;
                uiRichTextBox1.SelectionLength = key.Length;
                uiRichTextBox1.SelectionColor = Color.Red;
            }
        }
    }
}
