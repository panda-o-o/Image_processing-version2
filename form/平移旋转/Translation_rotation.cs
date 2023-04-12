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

namespace Image_processing.form.平移旋转
{
    public partial class Translation_rotation : UIForm
    {
        public Translation_rotation()
        {
            InitializeComponent();
        }
        public Translation_rotation(string mode)
        {
            InitializeComponent();
            this.Text = mode;
            if (mode== "平移旋转修改")
            {
                X.Value = form_class.translation_rotation.Translation_X;
                Y.Value = form_class.translation_rotation.Translation_Y;
                rotation.Value= form_class.translation_rotation.Rotation;
            }
        }

        public int Translation_X { get; set; }
        public int Translation_Y { get; set; }
        public int Rotation { get; set; }

        public Mat translation_M = new();
        public Mat rotation_M = new();

        public Mat Translation_M { get => translation_M; set => translation_M = value; }
        public Mat Rotation_M { get => rotation_M; set => rotation_M = value; }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Translation_X = X.Value;
            Translation_Y = Y.Value;
            Rotation = rotation.Value;
            Point2f[] old = new Point2f[] { new Point2f(0, 0), new Point2f(0, 1), new Point2f(1, 1) };
            Point2f[] New = new Point2f[] { new Point2f(Translation_X, Translation_Y),
                new Point2f(Translation_X,1 + Translation_Y),
                new Point2f(1 + Translation_X, 1 + Translation_Y) };
            Translation_M = Cv2.GetAffineTransform(old, New);
            Rotation_M = Cv2.GetRotationMatrix2D(new Point2f(Main_form.mat.Width / 2, Main_form.mat.Height / 2), Rotation, 1);

            this.DialogResult = DialogResult.OK;
        }
    }
}
