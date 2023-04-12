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
using static OpenCvSharp.Stitcher;
using static System.Formats.Asn1.AsnWriter;

namespace Image_processing.form.滤波
{
    public partial class Filtering : UIForm
    {
        public Filtering()
        {
            InitializeComponent();
        }

        public Filtering(模式 mode, Scope range = default(Scope),string title="滤波")
        {
            Mode = mode;
            InitializeComponent();
            if (!range.Equals(default(Scope)))
            {
                size.Minimum = range.min;
                size.Maximum = range.max;
            }
            this.Text = title;
        }
        public enum 模式
        {
            无, 奇数, 偶数
        }

        public struct Scope
        {
            public int min;
            public int max;
        }

        public int Value { get; set; }
        public 模式 Mode { get; set; }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Refresh_Picture();
            this.DialogResult = DialogResult.OK;
        }

        private void Refresh_Picture()
        {
            Value = (int)size.Value;
            switch (Mode)
            {
                case 模式.奇数: if (Value % 2 == 0) Value--; break;
                case 模式.偶数: if (Value % 2 != 0) Value--; break;
                default:
                    break;
            }
        }
    }
}
