using Image_processing.Class;
using OpenCvSharp;
using System.Drawing.Imaging;
using Point = OpenCvSharp.Point;
using Image_processing.main_Form;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using OpenCvSharp.XFeatures2D;
using Sunny.UI;
using OpenCvSharp.Dnn;
using Sunny.UI.Win32;
using Size = OpenCvSharp.Size;
using static Image_processing.Class.Public_Environment;
using Image_processing.form.Yolov5;
using System;

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
            //var matches = new List<Point>();

            // 定义一个存储匹配结果的列表
            var matches = new List<Rect>();

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
                            // matches.Add(new Point(j, i));
                            Rect rect = new Rect(j, i, Template.Cols, Template.Rows);
                            matches.Add(rect);
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
                            //matches.Add(new Point(j, i));
                            Rect rect = new Rect(j, i, Template.Cols, Template.Rows);
                            matches.Add(rect);
                        }
                    }
                }
            }
            List<Rect> nmsMatches = NonMaximumSuppression(matches, 0.3);
            //// 遍历匹配结果列表，将匹配区域用矩形框标注在原图像上
            foreach (var match in nmsMatches)
            {
                Cv2.Rectangle(img, match, Scalar.Red, 2);
            }
        }

        private static List<Rect> NonMaximumSuppression(List<Rect> rects, double overlapThreshold)
        {
            // 如果输入的矩形框列表为空，则直接返回该列表
            if (rects.Count == 0)
            {
                return rects;
            }

            // 按置信度降序排序
            // 排序函数使用矩形面积大小作为置信度的衡量标准
            rects.Sort((rect1, rect2) => (rect2.Width * rect2.Height).CompareTo((rect1.Width * rect1.Height)));

            // 创建一个空的输出矩形框列表和一个与输入矩形框个数相同的bool数组，用于记录每个矩形框是否被抑制
            List<Rect> resultRects = new List<Rect>();
            List<bool> isSuppressed = new List<bool>(new bool[rects.Count]);

            // 遍历排序后的矩形框列表
            for (int i = 0; i < rects.Count; i++)
            {
                // 如果当前矩形框已经被抑制，则跳过
                if (isSuppressed[i])
                {
                    continue;
                }

                // 将当前未被抑制的矩形框添加到输出矩形框列表中
                Rect currentRect = rects[i];
                resultRects.Add(currentRect);

                // 遍历剩余未被抑制的矩形框，计算其与当前矩形框的重叠度
                for (int j = i + 1; j < rects.Count; j++)
                {
                    // 如果当前矩形框已经被抑制，则跳过
                    if (isSuppressed[j])
                    {
                        continue;
                    }

                    // 计算当前矩形框与另一个未被抑制的矩形框的重叠区域
                    Rect otherRect = rects[j];
                    Rect intersection = currentRect & otherRect;

                    // 计算重叠区域的面积以及两个矩形框的面积和
                    double intersectionArea = intersection.Width * intersection.Height;
                    double unionArea = currentRect.Width * currentRect.Height + otherRect.Width * otherRect.Height - intersectionArea;

                    // 计算当前矩形框与另一个矩形框的重叠度
                    double overlapRatio = intersectionArea / unionArea;

                    // 如果重叠度大于设定的阈值，则将另一个矩形框标记为已被抑制
                    if (overlapRatio > overlapThreshold)
                    {
                        isSuppressed[j] = true;
                    }
                }
            }

            // 返回非极大值抑制处理后的矩形框列表
            return resultRects;
        }


        public static void Feature_Matching(ref Mat img, ref Mat mask, ref int count)
        {
            // 获取输入参数
            var threshold = Main_form.data_List.Data_list[count].dou_dic["Threshold"];  // 获取阈值
            var kp2 = Main_form.data_List.Data_list[count].KeyPoint_dic["kp2"];  // 获取模板的关键点
            var desc2 = Main_form.data_List.Data_list[count].mat_dic["desc2"];  // 获取模板的特征描述符
            var HessianThreshold = Main_form.data_List.Data_list[count].int_dic["HessianThreshold"];  // 获取SURF算法的Hessian阈值
            var template = Main_form.data_List.Data_list[count].mat_dic["Template"];  // 获取模板图像
            var mode = Main_form.data_List.Data_list[count++].str_dic["mode"];  // 获取特征检测算法的类型

            // 根据特征检测算法的类型选择对应的特征检测器
            Feature2D detector;
            if (mode == "SURF")
                detector = SURF.Create(HessianThreshold);
            else if (mode == "ORB")
                detector = ORB.Create();
            else
                throw new Exception("Invalid mode selected");

            // 创建FLANN匹配器
            using var matcher = new FlannBasedMatcher();

            // 进行特征匹配
            using (Mat desc1 = new())
            {
                detector.DetectAndCompute(img, null, out KeyPoint[] kp1, desc1);  // 检测输入图像的关键点和特征描述符
                if (mode == "ORB")
                    desc1.ConvertTo(desc1, MatType.CV_32F);
                var knnMatches = matcher.KnnMatch(desc1, desc2, 2);  // 使用FLANN匹配器进行特征匹配
                var goodMatches = knnMatches.Where(match => match[0].Distance < threshold * match[1].Distance).Select(m => m[0]).ToList();  // 选择好的匹配点

                // 计算单应性矩阵
                var dstPoints = goodMatches.Select(m => kp1[m.QueryIdx].Pt);  // 表示原图像点
                var srcPoints = goodMatches.Select(m => kp2[m.TrainIdx].Pt);  // 表示模板位置
                if (goodMatches.Count > 3)
                {
                    using var homography = Cv2.FindHomography(InputArray.Create(srcPoints), InputArray.Create(dstPoints), HomographyMethods.Ransac);
                    // 从原图像到处目标图像进行矩阵变化
                    // 对象图像的四个角点
                    Point2f[] objCorners = {
                    new Point2f(0, 0),
                    new Point2f(template.Width, 0),
                    new Point2f(template.Width, template.Height),
                    new Point2f(0, template.Height)
                    };
                    try
                    {
                        // 透视变换
                        Point2f[] sceneCorners = Cv2.PerspectiveTransform(objCorners, homography);
                        // 绘制匹配结果和目标区域
                        Mat result = new();  // 创建结果图像
                        Cv2.DrawMatches(img, kp1, template, kp2, goodMatches, result, flags: DrawMatchesFlags.NotDrawSinglePoints);  // 绘制匹配结果
                        Rect rect = Cv2.BoundingRect(sceneCorners);  // 计算目标区域的矩形边界
                        Cv2.Rectangle(result, rect, new Scalar(0, 255, 0), 2);  // 绘制目标区域的矩形边界
                        img = result.Clone();  // 将结果图像赋值给输入图像
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Yolov5图片输入格式化
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Mat FormatYolov5(Mat source)
        {
            int col = source.Cols;
            int row = source.Rows;
            int _max = Math.Max(col, row);
            Mat result = new Mat(_max, _max, MatType.CV_8UC3, Scalar.All(0));
            source.CopyTo(result[new Rect(0, 0, col, row)]);
            return result;
        }

        public static void Yolov5_Detect(ref Mat img, ref Mat mask, ref int count)
        {
            // 获取输入参数
            var Input_width = Main_form.data_List.Data_list[count].flo_dic["Input_width"];
            var Input_height = Main_form.data_List.Data_list[count].flo_dic["Input_height"];
            var Score_threshold = Main_form.data_List.Data_list[count].flo_dic["Score_threshold"];
            var Nms_threshold = Main_form.data_List.Data_list[count].flo_dic["Nms_threshold"];
            var Confidence_threshold = Main_form.data_List.Data_list[count].flo_dic["Confidence_threshold"];
            var Net = Main_form.data_List.Data_list[count++].net_dic["Net"];
            var input_image = FormatYolov5(img);

            using (Mat blob = CvDnn.BlobFromImage(input_image, 1.0 / 255.0, new Size(Input_width, Input_height), default, true, false))
            {
                Net.SetInput(blob);  // blob-[3,640,640] 三维RGB图像，以及图像的大小
            }

            var outNames = Net.GetUnconnectedOutLayersNames()[0].ToString();
            //网络计算到指定层（第二个参数指定的层），并返回该层的所有输出
            using var outputs = Net.Forward(outNames);
            using Mat detectionMat = new Mat(outputs.Size(1), outputs.Size(2), MatType.CV_32F, outputs.Data);
          

            //计算x_factor和y_factor，用于后面还原bounding box的位置和大小
            float x_factor = input_image.Cols / Input_width;
            float y_factor = input_image.Rows / Input_height;

            /*
            Yolov5s模型的输出大小为(1, 25200, 85)，其中：
            第一维是batch size，为1；
            第二维为每张输入图片生成的预测框数，即anchors数量 x (S1 x S1 + S2 x S2 + S3 x S3)，
                  这里的S1, S2, S3分别为输出层的三个特征图的大小，取值为{80, 40, 20}，anchors数量为3，因此总的预测框数为25200；
            第三维为每个预测框的信息，包括4个坐标信息、1个置信度信息和80个类别得分信息，共85个信息。
            */

            List<int> class_ids = new List<int>();
            List<float> confidences = new List<float>();
            List<Rect> boxes = new List<Rect>();

            for (int i = 0; i < detectionMat.Rows; ++i)
            {
                // 获取置信值
                float confidence = detectionMat.At<float>(i, 4);
                if (confidence < Confidence_threshold)
                {
                    continue;
                }
                using Mat scores = new Mat(1, 80, MatType.CV_32FC1, detectionMat.Data + i * detectionMat.Cols * sizeof(float) + 5 * sizeof(float));
                Point class_id;
                double max_class_score;
                Cv2.MinMaxLoc(scores, out _, out max_class_score, out _, out class_id);
                //通过阈值进行筛选，将符合要求的类别、置信度以及框体进行保存
                if (max_class_score > Score_threshold)
                {
                    confidences.Add(confidence);
                    class_ids.Add(class_id.X);
                    float x = detectionMat.At<float>(i, 0);
                    float y = detectionMat.At<float>(i, 1);
                    float w = detectionMat.At<float>(i, 2);
                    float h = detectionMat.At<float>(i, 3);
                    int left = (int)((x - 0.5 * w) * x_factor);
                    int top = (int)((y - 0.5 * h) * y_factor);
                    int width = (int)(w * x_factor);
                    int height = (int)(h * y_factor);
                    boxes.Add(new Rect(left, top, width, height));
                }
            }
            detectionMat.Dispose();
            List<int> nms_result = new List<int>();
            //极大值抑制
            CvDnn.NMSBoxes(boxes, confidences, Score_threshold, Nms_threshold, out var indices);
            nms_result.AddRange(indices);
            List<Detection> output = new();
            //将经过NMS处理后的结果加载到const vector<Detection> output中
            for (int i = 0; i < nms_result.Count(); i++)
            {
                int idx = nms_result[i];
                Detection result = new()
                {
                    class_id = class_ids[idx],
                    confidence = confidences[idx],
                    box = boxes[idx]
                };
                output.Add(result);
            }
            Main_form.public_Environment.yolov5_output = output;
        }

        public static void Yolov5_Box_drawing(ref Mat img, ref Mat mask, ref int count)
        {
            count++;
            List<Detection> output = Main_form.public_Environment.yolov5_output;
            //检测的边界框总数
            int detections = output.Count();

            for (int i = 0; i < detections; ++i)
            {
                var detection = output[i];
                var box = detection.box;
                var classId = detection.class_id;

                //通过取模运算为边界框选定颜色
                var color = Main_form.public_Environment.colors[classId % Main_form.public_Environment.colors.Count];
                //绘制边界框
                Cv2.Rectangle(img, box, color, 3);
                //绘制用于写类别的边框范围，一般就在边框的上面
                Cv2.Rectangle(img, new Point(box.X, box.Y - 20), new Point(box.X + box.Width, box.Y), color, Cv2.FILLED);
                //在上面绘制的框界内写出类别
                Cv2.PutText(img, Main_form.public_Environment.Yolov5_list_class[classId], new Point(box.X, box.Y - 5), HersheyFonts.HersheySimplex, 0.5, new Scalar(0, 0, 0));
            }
        }
    }
}

