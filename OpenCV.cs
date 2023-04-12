using OpenCvSharp;
using Sunny.UI.Win32;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using Size = OpenCvSharp.Size;

namespace Image_processing
{
    internal class OpenCV
    {

        /// <summary>
        /// 将Mat转变为Bitmap类型
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static Bitmap? GetMat(Mat mat)
        {
            Bitmap bitmap;
            // 将 Mat 转换为 Bitmap
            try { bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat); } catch { return null; }


            // 如果图像格式不是 24 位 RGB，则需要转换为 24 位 RGB 格式
            if (bitmap.PixelFormat != PixelFormat.Format24bppRgb)
            {
                Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format24bppRgb);
                using (Graphics graphics = Graphics.FromImage(newBitmap))
                {
                    graphics.DrawImage(bitmap, 0, 0);
                }
                bitmap.Dispose();
                bitmap = newBitmap;
            }

            return bitmap;
        }

        /// <summary>
        /// 颜色空间转化
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void colorto(ref Mat img, ref Mat mask)
        {
#pragma warning disable CS8602 // 解引用可能出现空引用。
            Cv2.CvtColor(img, img, form_class.colorTo.ColorCode);
#pragma warning restore CS8602 // 解引用可能出现空引用。


        }

        /// <summary>
        /// 均值滤波
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void medianBlur(ref Mat img, ref Mat mask)
        {
            Cv2.MedianBlur(img, img, form_class.mean_filter.Value);
        }

        /// <summary>
        /// 方框滤波
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void boxFilter(ref Mat img, ref Mat mask)
        {
            Cv2.BoxFilter(img, img, -1, new OpenCvSharp.Size(form_class.mean_filter.Value, form_class.mean_filter.Value));
        }

        /// <summary>
        /// 高斯滤波
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Gaussian_Blur(ref Mat img, ref Mat mask)
        {
            Cv2.GaussianBlur(img, img, new OpenCvSharp.Size(form_class.gaussian_Blur.Value, form_class.gaussian_Blur.Value), 0);
        }

        /// <summary>
        /// 中值滤波
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Median_Blur(ref Mat img, ref Mat mask)
        {
            Cv2.MedianBlur(img, img, form_class.median_Blur.Value);
        }

        /// <summary>
        /// 双边滤波
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Bilateral_Filter(ref Mat img, ref Mat mask)
        {
            Mat temp = new Mat();
            Cv2.BilateralFilter(img, temp, -1, form_class.bilateral_filter.SigmaColor, form_class.bilateral_filter.SigmaSpace);
            img = temp.Clone();
        }

        /// <summary>
        /// 上下翻转
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void X_Flip(ref Mat img, ref Mat mask)
        {
            Cv2.Flip(img, img, form_class.x_flipMode);
        }

        /// <summary>
        /// 左右都翻转
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Y_Flip(ref Mat img, ref Mat mask)
        {
            Cv2.Flip(img, img, form_class.y_flipMode);
        }

        /// <summary>
        /// 上下左右都翻转
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void XY_Flip(ref Mat img, ref Mat mask)
        {
            Cv2.Flip(img, img, form_class.xy_flipMode);
        }

        /// <summary>
        /// 二值化
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void ToBinary(ref Mat img, ref Mat mask)
        {
            if (form_class.binarization.Threshold <= 0)
            {
                Scalar scalar = Cv2.Mean(img);
                form_class.binarization.Threshold = (int)scalar.Val0;
            }
            Cv2.Threshold(img, img, form_class.binarization.Threshold, 255, form_class.binarization.Binarization_mode);//二值化
        }

        /// <summary>
        /// 自适应阈值二值化
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void AdaptiveThreshold(ref Mat img, ref Mat mask)
        {

            Cv2.AdaptiveThreshold(img, img, 255, form_class.adaptive_Threshold.Adaptive_Types, form_class.adaptive_Threshold.Threshold_Types, 5, 3);

        }

        /// <summary>
        /// Otsu算法
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Otsu(ref Mat img, ref Mat mask)
        {
            Cv2.Threshold(img, img, 0, 255, ThresholdTypes.Otsu | form_class.otsu.Binarization_mode);//二值化
        }

        /// <summary>
        /// 腐蚀
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Corrosion(ref Mat img, ref Mat mask)
        {
            Mat kernel = Cv2.GetStructuringElement(form_class.corrosion.kernel_shape, new Size(form_class.corrosion.kernel_width,
                form_class.corrosion.kernel_height));
            Cv2.MorphologyEx(img, img, MorphTypes.Erode, kernel);
        }

        /// <summary>
        /// 膨胀
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Expansion(ref Mat img, ref Mat mask)
        {
            Mat kernel = Cv2.GetStructuringElement(form_class.expansion.kernel_shape, new Size(form_class.expansion.kernel_width,
                form_class.expansion.kernel_height));
            Cv2.MorphologyEx(img, img, MorphTypes.Dilate, kernel);
        }

        /// <summary>
        /// 开运算
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Open_operation(ref Mat img, ref Mat mask)
        {
            Mat kernel = Cv2.GetStructuringElement(form_class.open_operation.kernel_shape, new Size(form_class.open_operation.kernel_width,
                form_class.open_operation.kernel_height));
            Cv2.MorphologyEx(img, img, MorphTypes.Open, kernel);
        }

        /// <summary>
        /// 闭运算
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Close_operation(ref Mat img, ref Mat mask)
        {
            Mat kernel = Cv2.GetStructuringElement(form_class.close_operation.kernel_shape, new Size(form_class.close_operation.kernel_width,
                form_class.close_operation.kernel_height));
            Cv2.MorphologyEx(img, img, MorphTypes.Close, kernel);
        }

        /// <summary>
        /// 梯度运算
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Gradient_operation(ref Mat img, ref Mat mask)
        {
            Mat kernel = Cv2.GetStructuringElement(form_class.gradient_operation.kernel_shape, new Size(form_class.gradient_operation.kernel_width,
                form_class.gradient_operation.kernel_height));
            Cv2.MorphologyEx(img, img, MorphTypes.Gradient, kernel);
        }

        /// <summary>
        /// 顶帽运算
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Top_hat_operation(ref Mat img, ref Mat mask)
        {
            Mat kernel = Cv2.GetStructuringElement(form_class.top_hat_operation.kernel_shape, new Size(form_class.top_hat_operation.kernel_width,
                form_class.top_hat_operation.kernel_height));
            Cv2.MorphologyEx(img, img, MorphTypes.TopHat, kernel);
        }

        /// <summary>
        /// 黑帽运算
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Black_hat_operation(ref Mat img, ref Mat mask)
        {
            Mat kernel = Cv2.GetStructuringElement(form_class.black_hat_operation.kernel_shape, new Size(form_class.black_hat_operation.kernel_width,
                form_class.black_hat_operation.kernel_height));
            Cv2.MorphologyEx(img, img, MorphTypes.BlackHat, kernel);
        }


        public static void Translation_rotation(ref Mat img, ref Mat mask)
        {
            if (!form_class.translation_rotation.translation_M.Empty())
            {
                Cv2.WarpAffine(img, img, form_class.translation_rotation.translation_M, img.Size());
            }
            if (!form_class.translation_rotation.rotation_M.Empty())
            {
                Cv2.WarpAffine(img, img, form_class.translation_rotation.rotation_M, img.Size());
            }
        }
    }
}
