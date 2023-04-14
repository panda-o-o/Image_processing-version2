using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image_processing.form;
using Image_processing.form.二值化;
using Image_processing.form.平移旋转;
using Image_processing.form.形态学操作;
using Image_processing.form.滤波;
using OpenCvSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Image_processing
{
    public class form_class
    {
        public static colorTo? colorTo;

        public static Filtering? mean_filter, box_filter, gaussian_Blur, median_Blur;
        public static Bilateral_Filter? bilateral_filter;
        public static FlipMode x_flipMode, y_flipMode, xy_flipMode;
        public static Binarization? binarization;
        public static Adaptive_Threshold? adaptive_Threshold;
        public static Otsu? otsu;
        public static Morphological_operation? corrosion, expansion, open_operation, 
            close_operation, gradient_operation, top_hat_operation, black_hat_operation;
        //腐蚀,膨胀,开运算,闭运算,梯度运算,顶帽运算,黑帽运算
        public static Translation_rotation? translation_rotation;
    }
}
