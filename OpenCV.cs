﻿using Image_processing.Class;
using OpenCvSharp;
using System.Drawing.Imaging;
using Point = OpenCvSharp.Point;
using Image_processing.main_Form;

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


            // 如果图像格式不是 24 位 RGB,则需要转换为 24 位 RGB 格式
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
        public static void colorto(ref Mat img, ref Mat mask, ref int count)
        {
            var ColorCode = Main_form.data_List.Data_list[count++].int_dic["ColorCode"];
            Cv2.CvtColor(img, img, (ColorConversionCodes)ColorCode);

        }

        /// <summary>
        /// 均值滤波
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void medianBlur(ref Mat img, ref Mat mask, ref int count)
        {
            var size = Main_form.data_List.Data_list[count++].int_dic["size"];
            Cv2.MedianBlur(img, img, size);
        }

        /// <summary>
        /// 方框滤波
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void boxFilter(ref Mat img, ref Mat mask, ref int count)
        {
            var size = Main_form.data_List.Data_list[count++].int_dic["size"];
            Cv2.BoxFilter(img, img, -1, new OpenCvSharp.Size(size, size));
        }

        /// <summary>
        /// 高斯滤波
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Gaussian_Blur(ref Mat img, ref Mat mask, ref int count)
        {
            var size = Main_form.data_List.Data_list[count++].int_dic["size"];
            Cv2.GaussianBlur(img, img, new OpenCvSharp.Size(size, size), 0);
        }

        /// <summary>
        /// 中值滤波
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Median_Blur(ref Mat img, ref Mat mask, ref int count)
        {
            var size = Main_form.data_List.Data_list[count++].int_dic["size"];
            Cv2.MedianBlur(img, img, size);
        }

        /// <summary>
        /// 双边滤波
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Bilateral_Filter(ref Mat img, ref Mat mask, ref int count)
        {
            Mat temp = new Mat();
            var SigmaColor = Main_form.data_List.Data_list[count].dou_dic["SigmaColor"];
            var SigmaSpace = Main_form.data_List.Data_list[count++].dou_dic["SigmaSpace"];
            Cv2.BilateralFilter(img, temp, -1, SigmaColor, SigmaSpace);
            img = temp.Clone();
        }

        /// <summary>
        /// 上下翻转
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void X_Flip(ref Mat img, ref Mat mask, ref int count)
        {
            var flip = Main_form.data_List.Data_list[count++].int_dic["Flip"];
            Cv2.Flip(img, img, (FlipMode)flip);
        }

        /// <summary>
        /// 左右都翻转
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Y_Flip(ref Mat img, ref Mat mask, ref int count)
        {
            var flip = Main_form.data_List.Data_list[count++].int_dic["Flip"];
            Cv2.Flip(img, img, (FlipMode)flip);
        }

        /// <summary>
        /// 上下左右都翻转
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void XY_Flip(ref Mat img, ref Mat mask, ref int count)
        {
            var flip = Main_form.data_List.Data_list[count++].int_dic["Flip"];
            Cv2.Flip(img, img, (FlipMode)flip);
        }

        /// <summary>
        /// 二值化
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void ToBinary(ref Mat img, ref Mat mask, ref int count)
        {
            var Threshold = Main_form.data_List.Data_list[count].int_dic["Threshold"];
            var Binarization_mode = Main_form.data_List.Data_list[count++].int_dic["Binarization_mode"];
            if (Threshold <= 0)
            {
                Scalar scalar = Cv2.Mean(img);
                Threshold = (int)scalar.Val0;
            }
            Cv2.Threshold(img, img, Threshold, 255, (ThresholdTypes)Binarization_mode);//二值化
        }

        /// <summary>
        /// 自适应阈值二值化
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void AdaptiveThreshold(ref Mat img, ref Mat mask, ref int count)
        {
            var Adaptive_Types = Main_form.data_List.Data_list[count].int_dic["Adaptive_Types"];
            var Threshold_Types = Main_form.data_List.Data_list[count++].int_dic["Threshold_Types"];
            Cv2.AdaptiveThreshold(img, img, 255, (AdaptiveThresholdTypes)Adaptive_Types, (ThresholdTypes)Threshold_Types, 5, 3);

        }

        /// <summary>
        /// Otsu算法
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Otsu(ref Mat img, ref Mat mask, ref int count)
        {
            var Binarization_mode = Main_form.data_List.Data_list[count++].int_dic["Binarization_mode"];
            Cv2.Threshold(img, img, 0, 255, ThresholdTypes.Otsu | (ThresholdTypes)Binarization_mode);//二值化
        }

        /// <summary>
        /// 腐蚀
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Corrosion(ref Mat img, ref Mat mask, ref int count)
        {
            var Kernel = Main_form.data_List.Data_list[count++].mat_dic["Kernel"];
            Cv2.MorphologyEx(img, img, MorphTypes.Erode, Kernel);
        }

        /// <summary>
        /// 膨胀
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Expansion(ref Mat img, ref Mat mask, ref int count)
        {
            var Kernel = Main_form.data_List.Data_list[count++].mat_dic["Kernel"];
            Cv2.MorphologyEx(img, img, MorphTypes.Dilate, Kernel);
        }

        /// <summary>
        /// 开运算
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Open_operation(ref Mat img, ref Mat mask, ref int count)
        {
            var Kernel = Main_form.data_List.Data_list[count++].mat_dic["Kernel"];
            Cv2.MorphologyEx(img, img, MorphTypes.Open, Kernel);
        }

        /// <summary>
        /// 闭运算
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Close_operation(ref Mat img, ref Mat mask, ref int count)
        {
            var Kernel = Main_form.data_List.Data_list[count++].mat_dic["Kernel"];
            Cv2.MorphologyEx(img, img, MorphTypes.Close, Kernel);
        }

        /// <summary>
        /// 梯度运算
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Gradient_operation(ref Mat img, ref Mat mask, ref int count)
        {
            var Kernel = Main_form.data_List.Data_list[count++].mat_dic["Kernel"];
            Cv2.MorphologyEx(img, img, MorphTypes.Gradient, Kernel);
        }

        /// <summary>
        /// 顶帽运算
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Top_hat_operation(ref Mat img, ref Mat mask, ref int count)
        {
            var Kernel = Main_form.data_List.Data_list[count++].mat_dic["Kernel"];
            Cv2.MorphologyEx(img, img, MorphTypes.TopHat, Kernel);
        }

        /// <summary>
        /// 黑帽运算
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        public static void Black_hat_operation(ref Mat img, ref Mat mask, ref int count)
        {
            var Kernel = Main_form.data_List.Data_list[count++].mat_dic["Kernel"];
            Cv2.MorphologyEx(img, img, MorphTypes.BlackHat, Kernel);
        }

        /// <summary>
        /// 仿射变换
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <param name="count"></param>
        public static void Translation_rotation(ref Mat img, ref Mat mask, ref int count)
        {

            var translation_M = Main_form.data_List.Data_list[count].mat_dic["translation_M"];
            var rotation_M = Main_form.data_List.Data_list[count++].mat_dic["rotation_M"];

            if (!translation_M.Empty())
            {
                Cv2.WarpAffine(img, img, translation_M, img.Size());
            }
            if (!rotation_M.Empty())
            {
                Cv2.WarpAffine(img, img, rotation_M, img.Size());
            }
        }

        public static void Template_Match(ref Mat img, ref Mat mask, ref int count)
        {
            // 获取模板图像、阈值和匹配模式
            var Template = Main_form.data_List.Data_list[count].mat_dic["Template"];
            var Threshold = Main_form.data_List.Data_list[count].dou_dic["Threshold"];
            var Template_Match_Modes = Main_form.data_List.Data_list[count++].int_dic["Template_Match_Modes"];

            // 定义结果图像，调用OpenCV的MatchTemplate函数进行模板匹配
            Mat result_img = new Mat();
            Cv2.MatchTemplate(img, Template, result_img, TemplateMatchModes.CCoeffNormed);
            // 对结果图像进行归一化处理
            Cv2.Normalize(result_img, result_img, 0, 1, NormTypes.MinMax, -1, null);

            // 定义一个存储匹配结果的列表
            var matches = new List<Point>();

            // 根据匹配模式进行匹配
            if ((TemplateMatchModes)Template_Match_Modes == TemplateMatchModes.SqDiff || (TemplateMatchModes)Template_Match_Modes == TemplateMatchModes.SqDiffNormed)
            {
                // 如果匹配模式为SqDiff或SqDiffNormed
                for (int i = 0; i < result_img.Rows; i++)
                {
                    for (int j = 0; j < result_img.Cols; j++)
                    {
                        MatType dataType = result_img.Depth();
                        // 获取当前像素值
                        var val = result_img.At<float>(i, j);
                        // 如果像素值小于等于1-Threshold，则认为匹配成功，将匹配结果加入列表
                        if (val <= 1 - Threshold)
                        {
                            matches.Add(new Point(j, i));
                        }
                    }
                }
            }
            else
            {
                // 如果匹配模式为其他模式
                for (int i = 0; i < result_img.Rows; i++)
                {
                    for (int j = 0; j < result_img.Cols; j++)
                    {
                        MatType dataType = result_img.Depth();
                        // 获取当前像素值
                        var val = result_img.At<float>(i, j);
                        // 如果像素值大于等于Threshold，则认为匹配成功，将匹配结果加入列表
                        if (val >= Threshold)
                        {
                            matches.Add(new Point(j, i));
                        }
                    }
                }
            }

            // 遍历匹配结果列表，将匹配区域用矩形框标注在原图像上
            foreach (var match in matches)
            {
                Cv2.Rectangle(img, new Rect(match.X, match.Y, Template.Cols, Template.Rows), Scalar.Red, 2);
            }
        }
    }
}
