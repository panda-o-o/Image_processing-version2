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

namespace Image_processing.form.摄像头
{
    public partial class Camera : UIForm
    {

        public int Cameras_Id { get; set; }
        public int Camers_Frame_rate { get; set; }
        public Camera()
        {
            InitializeComponent();
        }

        private void Camera_Load(object sender, EventArgs e)
        {
            var cameras = new List<string>();

            for (var i = 0; i < 10; i++)
            {
                var capture = new VideoCapture(i);
                if (capture.IsOpened())
                {
                    cameras.Add($"Camera {i}");
                    capture.Release();
                }
            }

            if (cameras.Count > 0)
            {
                uiComboBox1.DataSource = cameras;
                uiComboBox1.SelectedIndex = 0;
            }
            else
            {
                if (MessageBox.Show("没有找到可用的摄像头") == DialogResult.OK)
                    this.Close();
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedItem != null && uiIntegerUpDown1.Value != 0)
            {
                Cameras_Id = uiComboBox1.SelectedIndex;
                Camers_Frame_rate = uiIntegerUpDown1.Value;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
