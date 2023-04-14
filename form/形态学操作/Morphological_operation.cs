using OpenCvSharp;
using Sunny.UI;
using Size = OpenCvSharp.Size;

namespace Image_processing.form.形态学操作
{
    public partial class Morphological_operation : UIForm
    {
        public Morphological_operation()
        {
            InitializeComponent();
        }

        public Morphological_operation(string v)
        {
            InitializeComponent();
            this.Text = v;
        }

        public int kernel_width { get; set; }
        public int kernel_height { get; set; }
        public MorphShapes kernel_shape { get; set; }
        public Mat Kernel { get; set; }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedItem != null && (shapewidth.Value != 0) && (shapeheight.Value != 0))
            {
                kernel_width = shapewidth.Value;
                kernel_height = shapeheight.Value;
                kernel_shape = (MorphShapes)uiComboBox1.SelectedIndex;

                Kernel = Cv2.GetStructuringElement(kernel_shape, new Size(kernel_width, kernel_height));

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
