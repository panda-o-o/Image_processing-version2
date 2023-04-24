using Image_processing.Class;
using Image_processing.form;
using Image_processing.form.二值化;
using Image_processing.form.平移旋转;
using Image_processing.form.形态学操作;
using Image_processing.form.模板匹配;
using Image_processing.form.滤波;
using Image_processing.form.特征识别;
using OpenCvSharp;
using Sunny.UI;

namespace Image_processing
{
    public partial class Main_form
    {
        /// <summary>
        /// 树状图添加节点
        /// </summary>
        private void tree_add()
        {
            TreeNode[] nodes =
           {
                new TreeNode("颜色空间", new[]
                {
                    new TreeNode("颜色空间变化") { ToolTipText = "将图像从一种颜色空间转换为另一种颜色空间" }
                }),
                new TreeNode("图像滤波", new[]
                {
                    new TreeNode("均值滤波") { ToolTipText = "去除噪声和细节,平滑图像" },
                    new TreeNode("方框滤波") { ToolTipText = "去除噪声和细节,平滑图像" },
                    new TreeNode("高斯滤波") { ToolTipText = "平滑图像并去除噪声,保留图像的整体结构信息和边缘信息" },
                    new TreeNode("中值滤波") { ToolTipText = "去除噪声和细节,平滑图像并保留边缘信息" },
                    new TreeNode("双边滤波") { ToolTipText = "平滑图像并保留边缘信息和细节信息" }
                }),
                new TreeNode("图像翻转", new[]
                {
                    new TreeNode("上下翻转") { ToolTipText = "将图像上下翻转,可用于镜像图像或纠正拍摄时的倒置问题" },
                    new TreeNode("左右翻转") { ToolTipText = "将图像左右翻转,可用于镜像图像或纠正拍摄时的倒置问题" },
                    new TreeNode("全翻转") { ToolTipText = "将图像上下左右翻转,可用于镜像图像或纠正拍摄时的倒置问题" }
                }),
                new TreeNode("图像阈值", new[]
                {
                    new TreeNode("二值化") { ToolTipText = "将图像根据阈值分成黑白两部分,可用于物体检测、文字识别等任务" },
                    new TreeNode("自适应阈值") { ToolTipText = "根据图像局部区域内的像素值动态调整阈值,可用于处理光照不均的图像" },
                    new TreeNode("Otsu算法") { ToolTipText = "根据图像灰度直方图自适应调整阈值,可用于分割目标和背景" }
                }),
                new TreeNode("形态学操作", new[]
                {
                    new TreeNode("腐蚀") { ToolTipText = "将图像中的前景物体缩小,可用于去除小物体或者分离相邻物体" },
                    new TreeNode("膨胀") { ToolTipText = "将图像中的前景物体扩大,可用于填充小孔洞或者合并相邻物体" },
                    new TreeNode("开运算") { ToolTipText = "先进行腐蚀操作,再进行膨胀操作,可用于去除小物体和毛刺" },
                    new TreeNode("闭运算") { ToolTipText = "先进行膨胀操作,再进行腐蚀操作,填充小孔洞" },
                    new TreeNode("梯度运算") { ToolTipText = "将膨胀后的图像减去腐蚀后的图像,得到前景物体的边缘轮廓" },
                    new TreeNode("顶帽运算") { ToolTipText = "将原图像减去开运算后的图像,得到小物体" },
                    new TreeNode("黑帽运算") { ToolTipText = "将闭运算后的图像减去原图像,得到小孔洞" }
                 }),
                new TreeNode("平移旋转",new []
                {
                    new TreeNode("平移旋转"){ ToolTipText = "将图像进行旋转平移" }
                }),
                new TreeNode("模板匹配",new []
                {
                    new TreeNode("模板匹配"){ ToolTipText = "选择一个模板，找出匹配位置" }
                }),
                new TreeNode("特征匹配",new []
                {
                    new TreeNode("特征匹配"){ ToolTipText = "选择一个模板，进行特征匹配" }
                })
            };

            TreeNode node = new TreeNode("OpenCVsharp", nodes);
            treeView1.Nodes.Add(node);
        }

        /// <summary>
        /// 选择对应的方法
        /// </summary>
        /// <param name="e"></param>
        public void switch_Method(TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count == 0) // 判断是否为子节点
            {
                switch (e.Node.Parent.Text)
                {
                    case "颜色空间":
                        switch (e.Node.Text)
                        {
                            case "颜色空间变化": color_add("颜色空间变化"); break;
                            default:
                                break;
                        }
                        break;

                    case "图像滤波":
                        switch (e.Node.Text)
                        {
                            case "均值滤波": Mean_Filter("均值滤波"); break;
                            case "方框滤波": Box_Filter("方框滤波"); break;
                            case "高斯滤波": Gaussian_Blur("高斯滤波"); break;
                            case "中值滤波": Median_Blur("中值滤波"); break;
                            case "双边滤波": Bilateral_Filter("双边滤波"); break;
                            default:
                                break;
                        }
                        break;

                    case "图像翻转":
                        switch (e.Node.Text)
                        {
                            case "上下翻转": X_axis_flip("上下翻转"); break;
                            case "左右翻转": Y_axis_flip("左右翻转"); break;
                            case "全翻转": XY_axis_flip("上下左右都翻转"); break;
                        }
                        break;

                    case "图像阈值":
                        switch (e.Node.Text)
                        {
                            case "二值化": Binarizate("二值化"); break;
                            case "自适应阈值": AdaptiveThreshold("自适应阈值"); break;
                            case "Otsu算法": Otsu("Otsu算法"); break;
                        }
                        break;

                    case "形态学操作":
                        switch (e.Node.Text)
                        {
                            case ("腐蚀"): Corrosion("腐蚀"); break;
                            case ("膨胀"): Expansion("膨胀"); break;
                            case ("开运算"): Open_operation("开运算"); break;
                            case ("闭运算"): Close_operation("闭运算"); break;
                            case ("梯度运算"): Gradient_operation("梯度运算"); break;
                            case ("顶帽运算"): Top_hat_operation("顶帽运算"); break;
                            case ("黑帽运算"): Black_hat_operation("黑帽运算"); break;
                        }
                        break;

                    case "平移旋转":
                        switch (e.Node.Text)
                        {
                            case ("平移旋转"): Translation_rotation("平移旋转"); break;
                        }
                        break;
                    case "模板匹配":
                        switch (e.Node.Text)
                        {
                            case ("模板匹配"): Template_matching("模板匹配"); break;
                        }
                        break;
                    case "特征匹配":
                        switch (e.Node.Text)
                        {
                            case ("特征匹配"): Feature_matching("特征匹配"); break;
                        }
                        break;
                }
            }
        }

        private void Feature_matching(string v)
        {
            Feature feature_Matching = new Feature();
            feature_Matching.StartPosition = FormStartPosition.CenterScreen;
            feature_Matching.ShowDialog();
            if (feature_Matching.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    dou_dic = new Dictionary<string, double>() { { "Threshold", 1-feature_Matching.Threshold } },
                    int_dic = new Dictionary<string, int>() { { "HessianThreshold", feature_Matching.HessianThreshold } },
                    str_dic = new Dictionary<string, string>() { { "mode", feature_Matching.Mode } },
                    KeyPoint_dic = new Dictionary<string, KeyPoint[]> { { "kp2", feature_Matching.kp2 } },
                    mat_dic = new Dictionary<string, Mat>
                    {
                        { "desc2", feature_Matching.desc2 },
                        { "Template", feature_Matching.Template }
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(v);
                del_process Feature_Matching = OpenCV.Feature_Matching;
                link.AddDelegate(Feature_Matching);

                textBox1.AppendText(v + "添加成功！！！模式为：" + feature_Matching.Mode +
                    "模板为：" + feature_Matching.Pic_name + "，阈值为：" + feature_Matching.Threshold + "\r\n");
            }
        }

        #region 模板匹配
        /// <summary>
        /// 模板匹配
        /// </summary>
        /// <param name="v"></param>
        private void Template_matching(string v)
        {
            Template_Matching template_Matching = new Template_Matching("模板匹配");
            template_Matching.StartPosition = FormStartPosition.CenterScreen;
            template_Matching.ShowDialog();
            if (template_Matching.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                         { "Template", template_Matching.Template}
                    },
                    dou_dic = new Dictionary<string, double>()
                    {
                        {"Threshold", template_Matching.Threshold}
                    },
                    int_dic = new Dictionary<string, int>()
                    {
                        { "Template_Match_Modes",template_Matching.Template_Match_Modes }
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(v);
                del_process Template_Match = OpenCV.Template_Match;
                link.AddDelegate(Template_Match);

                textBox1.AppendText(v + "添加成功！！！模式为：" + template_Matching.uiComboBox1.SelectedText +
                    "模板为：" + template_Matching.Pic_name + "，置信度为：" + template_Matching.Threshold.ToString() + "\r\n");
            }
        }
        #endregion

        #region 平移旋转
        /// <summary>
        /// 平移旋转
        /// </summary>
        /// <param name="v"></param>
        private void Translation_rotation(string v)
        {
            Translation_rotation translation_rotation = new Translation_rotation("平移旋转");
            translation_rotation.StartPosition = FormStartPosition.CenterScreen;
            translation_rotation.ShowDialog();
            if (translation_rotation.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                         { "translation_M", translation_rotation.translation_M},
                         { "rotation_M", translation_rotation.rotation_M }
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(v);
                del_process Translation_rotation = OpenCV.Translation_rotation;
                link.AddDelegate(Translation_rotation);

                textBox1.AppendText(v + "添加成功！！！X平移" + translation_rotation.Translation_X.ToString() +
                    ",Y平移" + translation_rotation.Translation_Y.ToString() +
                    ",旋转" + translation_rotation.Rotation.ToString() + "°\r\n");
            }
        }
        #endregion

        #region 形态学操作

        /// <summary>
        /// 黑帽运算
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Black_hat_operation(string mode)
        {
            Morphological_operation black_hat_operation = new Morphological_operation("黑帽运算");
            black_hat_operation.StartPosition = FormStartPosition.CenterScreen;
            black_hat_operation.ShowDialog();
            if (black_hat_operation.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", black_hat_operation.Kernel }
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Black_hat_operation);
                textBox1.AppendText(mode + "添加成功！！！核形状为为：" + black_hat_operation.kernel_shape.ToString() +
                    ",宽度为：" + black_hat_operation.kernel_width.ToString() +
                    ",高度为：" + black_hat_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 顶帽运算
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Top_hat_operation(string mode)
        {
            Morphological_operation top_hat_operation = new Morphological_operation("顶帽运算");
            top_hat_operation.StartPosition = FormStartPosition.CenterScreen;
            top_hat_operation.ShowDialog();
            if (top_hat_operation.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", top_hat_operation.Kernel }
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Top_hat_operation);
                textBox1.AppendText(mode + "添加成功！！！核形状为为：" + top_hat_operation.kernel_shape.ToString() +
                    ",宽度为：" + top_hat_operation.kernel_width.ToString() +
                    ",高度为：" + top_hat_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 梯度运算
        /// </summary>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Gradient_operation(string mode)
        {
            Morphological_operation gradient_operation = new Morphological_operation("梯度运算");
            gradient_operation.StartPosition = FormStartPosition.CenterScreen;
            gradient_operation.ShowDialog();
            if (gradient_operation.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", gradient_operation.Kernel }
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Gradient_operation);
                textBox1.AppendText(mode + "添加成功！！！核形状为为：" + gradient_operation.kernel_shape.ToString() +
                    ",宽度为：" + gradient_operation.kernel_width.ToString() +
                    ",高度为：" + gradient_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 闭运算
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Close_operation(string mode)
        {
            Morphological_operation close_operation = new Morphological_operation("闭运算");
            close_operation.StartPosition = FormStartPosition.CenterScreen;
            close_operation.ShowDialog();
            if (close_operation.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", close_operation.Kernel }
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Close_operation);
                textBox1.AppendText(mode + "添加成功！！！核形状为为：" + close_operation.kernel_shape.ToString() +
                    ",宽度为：" + close_operation.kernel_width.ToString() +
                    ",高度为：" + close_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 开运算
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Open_operation(string mode)
        {
            Morphological_operation open_operation = new Morphological_operation("开运算");
            open_operation.StartPosition = FormStartPosition.CenterScreen;
            open_operation.ShowDialog();
            if (open_operation.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", open_operation.Kernel }
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Open_operation);
                textBox1.AppendText(mode + "添加成功！！！核形状为为：" + open_operation.kernel_shape.ToString() +
                    ",宽度为：" + open_operation.kernel_width.ToString() +
                    ",高度为：" + open_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 膨胀
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Expansion(string mode)
        {
            Morphological_operation expansion = new Morphological_operation("膨胀");
            expansion.StartPosition = FormStartPosition.CenterScreen;
            expansion.ShowDialog();
            if (expansion.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", expansion.Kernel }
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Expansion);
                textBox1.AppendText(mode + "添加成功！！！核形状为为：" + expansion.kernel_shape.ToString() +
                    ",宽度为：" + expansion.kernel_width.ToString() +
                    ",高度为：" + expansion.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 腐蚀操作
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Corrosion(string mode)
        {
            Morphological_operation corrosion = new Morphological_operation("腐蚀操作");
            corrosion.StartPosition = FormStartPosition.CenterScreen;
            corrosion.ShowDialog();
            if (corrosion.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", corrosion.Kernel }
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Corrosion);
                textBox1.AppendText(mode + "添加成功！！！核形状为为：" + corrosion.kernel_shape.ToString() +
                    ",宽度为：" + corrosion.kernel_width.ToString() +
                    ",高度为：" + corrosion.kernel_height.ToString() + "\r\n");
            }
        }

        #endregion 形态学操作

        #region 图像阈值操作

        /// <summary>
        /// OTsu算法
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Otsu(string mode)
        {
            Otsu otsu = new Otsu(mode);
            otsu.StartPosition = FormStartPosition.CenterScreen;
            otsu.ShowDialog();
            if (otsu.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    int_dic = new Dictionary<string, int>()
                    {
                        { "Binarization_mode", (int)otsu.Binarization_mode },
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Otsu);
                textBox1.AppendText(mode + "添加成功！！！模式为：" + otsu.Binarization_mode.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 自适应阈值
        /// </summary>
        /// <param name="mode"></param>
        private void AdaptiveThreshold(string mode)
        {
            Adaptive_Threshold adaptivethreshold = new Adaptive_Threshold();
            adaptivethreshold.StartPosition = FormStartPosition.CenterScreen;
            adaptivethreshold.ShowDialog();
            if (adaptivethreshold.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    int_dic = new Dictionary<string, int>()
                    {
                        { "Adaptive_Types", (int)adaptivethreshold.Adaptive_Types },
                        { "Threshold_Types",(int)adaptivethreshold.Threshold_Types}
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.AdaptiveThreshold);
                textBox1.AppendText(mode + "添加成功！！！自适应阈值算法为：" + adaptivethreshold.Adaptive_Types.ToString() +
                    ",模式为：" + adaptivethreshold.Threshold_Types.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 二值化
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Binarizate(string mode)
        {
            Binarization binarization = new Binarization("二值化");
            binarization.StartPosition = FormStartPosition.CenterScreen;
            binarization.ShowDialog();
            if (binarization.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    int_dic = new Dictionary<string, int>()
                    {
                        { "Threshold", binarization.Threshold },
                        { "Binarization_mode",(int)binarization.Binarization_mode}
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.ToBinary);
                textBox1.AppendText(mode + "添加成功！！！阈值为：" + binarization.Threshold.ToString() +
                    ",模式为：" + binarization.Binarization_mode.ToString() + "\r\n");
            }
        }

        #endregion 图像阈值操作

        #region 图像翻转

        /// <summary>
        /// 上下左右都翻转
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void XY_axis_flip(string mode)
        {
            Data_dic data = new Data_dic
            {
                int_dic = new Dictionary<string, int>() { { "Flip", (int)FlipMode.XY } }
            };
            data_List.Data_list.Add(data);

            listBox1.Items.Add(mode);
            link.AddDelegate(OpenCV.XY_Flip);

            textBox1.AppendText(mode + "\r\n");
        }

        /// <summary>
        /// 左右翻转
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Y_axis_flip(string mode)
        {
            Data_dic data = new Data_dic
            {
                int_dic = new Dictionary<string, int>() { { "Flip", (int)FlipMode.Y } }
            };
            data_List.Data_list.Add(data);

            listBox1.Items.Add(mode);
            link.AddDelegate(OpenCV.Y_Flip);
            textBox1.AppendText(mode + "\r\n");
        }

        /// <summary>
        /// 上下翻转
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void X_axis_flip(string mode)
        {
            Data_dic data = new Data_dic
            {
                int_dic = new Dictionary<string, int>() { { "Flip", (int)FlipMode.X } }
            };
            data_List.Data_list.Add(data);

            listBox1.Items.Add(mode);
            link.AddDelegate(OpenCV.Y_Flip);
            textBox1.AppendText(mode + "\r\n");
        }

        #endregion 图像翻转

        #region 滤波

        /// <summary>
        /// 双边滤波
        /// </summary>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Bilateral_Filter(string mode)
        {
            Bilateral_Filter bilateral_Filter = new Bilateral_Filter();
            bilateral_Filter.StartPosition = FormStartPosition.CenterScreen;
            bilateral_Filter.ShowDialog();
            if (bilateral_Filter.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    dou_dic = new Dictionary<string, double>()
                    {
                        { "SigmaColor", bilateral_Filter.SigmaColor },
                        {  "SigmaSpace",bilateral_Filter.SigmaSpace}
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                del_process Bilateral_Filter = OpenCV.Bilateral_Filter;
                link.AddDelegate(Bilateral_Filter);
                textBox1.AppendText(mode + "添加成功！！！sigmaColor为：" + bilateral_Filter.SigmaColor.ToString() +
                    ",SigmaSpace：" + bilateral_Filter.SigmaSpace.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 中值滤波
        /// </summary>
        /// <param name="v"></param>
        private void Median_Blur(string mode)
        {
            Filtering median_Blur = new Filtering(Filtering.模式.奇数, new Filtering.Scope { min = 1, max = 50 }, mode);
            median_Blur.StartPosition = FormStartPosition.CenterScreen;
            median_Blur.ShowDialog();
            if (median_Blur.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    int_dic = new Dictionary<string, int>() { { "size", median_Blur.Value } }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Median_Blur);
                textBox1.AppendText(mode + "添加成功！！！核大小为：" + median_Blur.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 均值滤波
        /// </summary>
        private void Mean_Filter(string mode)
        {
            Filtering mean_filter = new Filtering(Filtering.模式.奇数, new Filtering.Scope { min = 1, max = 50 }, mode);
            mean_filter.StartPosition = FormStartPosition.CenterScreen;
            mean_filter.ShowDialog();
            if (mean_filter.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    int_dic = new Dictionary<string, int>() { { "size", mean_filter.Value } }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                del_process medianBlur = OpenCV.medianBlur;
                link.AddDelegate(medianBlur);
                textBox1.AppendText(mode + "添加成功！！！核大小为：" + mean_filter.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 方框滤波
        /// </summary>
        /// <param name="mode"></param>
        private void Box_Filter(string mode)
        {
            Filtering box_filter = new Filtering(Filtering.模式.无, new Filtering.Scope { min = 1, max = 50 }, mode);
            box_filter.StartPosition = FormStartPosition.CenterScreen;
            box_filter.ShowDialog();
            if (box_filter.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    int_dic = new Dictionary<string, int>() { { "size", box_filter.Value } }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                del_process boxFilter = OpenCV.boxFilter;
                link.AddDelegate(boxFilter);
                textBox1.AppendText(mode + "添加成功！！！核大小为：" + box_filter.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 高斯滤波
        /// </summary>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Gaussian_Blur(string mode)
        {
            Filtering gaussian_Blur = new Filtering(Filtering.模式.奇数, new Filtering.Scope { min = 1, max = 50 }, mode);
            gaussian_Blur.StartPosition = FormStartPosition.CenterScreen;
            gaussian_Blur.ShowDialog();
            if (gaussian_Blur.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    int_dic = new Dictionary<string, int>() { { "size", gaussian_Blur.Value } }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                del_process Gaussian_Blur = OpenCV.Gaussian_Blur;
                link.AddDelegate(Gaussian_Blur);
                textBox1.AppendText(mode + "添加成功！！！核大小为：" + gaussian_Blur.Value.ToString() + "\r\n");
            }
        }

        #endregion 滤波

        #region 颜色空间变化

        /// <summary>
        /// 颜色变换
        /// </summary>
        ///
        private void color_add(string mode)
        {
            colorTo colorto = new colorTo();
            colorto.StartPosition = FormStartPosition.CenterScreen;
            colorto.ShowDialog();
            if (colorto.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic();
                data.int_dic = new Dictionary<string, int>();
                data.int_dic.Add("ColorCode", (int)colorto.ColorCode);
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                del_process tocolor = OpenCV.colorto;
                link.AddDelegate(tocolor);

                textBox1.AppendText("颜色空间变化添加成功！！！图片处理为：" + colorto.ColorCode.ToString() + "\r\n");
            }
        }

        #endregion 颜色空间变化
    }
}