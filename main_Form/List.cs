using Image_processing.Class;
using Image_processing.form;
using Image_processing.form.二值化;
using Image_processing.form.平移旋转;
using Image_processing.form.形态学操作;
using Image_processing.form.模板匹配;
using Image_processing.form.滤波;
using Image_processing.form.特征识别;
using OpenCvSharp;

namespace Image_processing
{
    public partial class Main_form
    {
        private void change_parameter()
        {
#pragma warning disable CS8602 // 解引用可能出现空引用。
            string? list = listBox1.SelectedItem.ToString();
            change_set_parameter(list, "修改", listBox1.SelectedIndex);
        }

        private void change_set_parameter(string? list, string mode, int index)
        {
            switch (list)
            {
                case "颜色空间变化": change_color("颜色空间", mode, index); break;
                case "均值滤波": change_Mean_filtering("均值滤波", mode, index); break;
                case "方框滤波": change_box_filtering("方框滤波", mode, index); break;
                case "高斯滤波": change_gaussian_blur("高斯滤波", mode, index); break;
                case "中值滤波": change_median_blur("中值滤波", mode, index); break;
                case "双边滤波": change_bilateral_filter("双边滤波", mode, index); break;
                case "上下翻转": change_x_axis_flip("双边滤波", mode, index); break;
                case "左右翻转": change_y_axis_flip("双边滤波", mode, index); break;
                case "全翻转": change_xy_axis_flip("双边滤波", mode, index); break;
                case "二值化": change_binarization("二值化", mode, index); break;
                case "自适应阈值": change_adaptivethreshold("自适应阈值", mode, index); break;
                case "Otsu算法": change_Otsu("Otsu算法", mode, index); break;
                case ("腐蚀"): change_corrosion("腐蚀", mode, index); break;
                case ("膨胀"): change_expansion("膨胀", mode, index); break;
                case ("开运算"): change_open_operation("开运算", mode, index); break;
                case ("闭运算"): change_close_operation("闭运算", mode, index); break;
                case ("梯度运算"): change_gradient_operation("梯度运算", mode, index); break;
                case ("顶帽运算"): change_top_hat_operation("顶帽运算", mode, index); break;
                case ("黑帽运算"): change_black_hat_operation("黑帽运算", mode, index); break;
                case ("平移旋转"): change_translation_rotation("平移旋转", mode, index); break;
                case ("模板匹配"): change_template_matching("模板匹配", mode, index); break;
                case ("特征匹配"): change_feature_matching("特征匹配", mode, index); break;
                default:
                    // Handle the case where the element is not of any expected type
                    break;
            }
        }

        private void change_feature_matching(string v, string mode, int index)
        {
            Feature feature_Matching = new Feature();
            feature_Matching.StartPosition = FormStartPosition.CenterScreen;
            feature_Matching.ShowDialog();
            if (mode == "修改")
            {
                data_List.Data_list[index].mat_dic["Template"] = feature_Matching.Template;
                data_List.Data_list[index].mat_dic["desc2"] = feature_Matching.desc2;
                data_List.Data_list[index].dou_dic["Threshold"] = feature_Matching.Threshold;

                data_List.Data_list[index].KeyPoint_dic["kp2"] = feature_Matching.kp2;
                data_List.Data_list[index].str_dic["mode"] = feature_Matching.Mode;
            }
            else if (mode == "插入")
            {
                Data_dic data = new Data_dic
                {
                    dou_dic = new Dictionary<string, double>() { { "Threshold", feature_Matching.Threshold } },
                    int_dic = new Dictionary<string, int>() { { "HessianThreshold", feature_Matching.HessianThreshold } },
                    str_dic = new Dictionary<string, string>() { { "mode", feature_Matching.Mode } },
                    KeyPoint_dic = new Dictionary<string, KeyPoint[]> { { "kp2", feature_Matching.kp2 } },
                    mat_dic = new Dictionary<string, Mat>
                    {
                        { "desc2", feature_Matching.desc2 },
                        { "Template", feature_Matching.Template }
                    }
                };
                data_List.Data_list.Insert(index, data);
            }
            textBox1.AppendText(v + mode + "成功！！！模式为：" + feature_Matching.Mode +
                    "模板为：" + feature_Matching.Pic_name + "，阈值为：" + feature_Matching.Threshold + "\r\n");
        }

        private void change_template_matching(string v, string mode, int index)
        {
            Template_Matching template_Matching = new Template_Matching("模板匹配");
            template_Matching.StartPosition = FormStartPosition.CenterScreen;
            template_Matching.ShowDialog();
            if (template_Matching.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].mat_dic["Template"] = template_Matching.Template;
                    data_List.Data_list[index].dou_dic["Threshold"] = template_Matching.Threshold;
                    data_List.Data_list[index].int_dic["Template_Match_Modes"] = template_Matching.Template_Match_Modes;
                }
                else if (mode == "插入")
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
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！模式为：" + template_Matching.uiComboBox1.SelectedText +
                    "模板为：" + template_Matching.Pic_name + "，置信度为：" + template_Matching.Threshold.ToString() + "\r\n");
            }
        }

        private void change_xy_axis_flip(string v, string mode, int index)
        {
            if (mode == "修改")
            {
                MessageBox.Show("这只能删除，不能修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (mode == "插入")
            {
                Data_dic data = new Data_dic
                {
                    int_dic = new Dictionary<string, int>() { { "Flip", (int)FlipMode.XY } }
                };
                data_List.Data_list.Insert(index, data);
                textBox1.AppendText(v + mode + "\r\n");
            }
        }

        private void change_y_axis_flip(string v, string mode, int index)
        {
            if (mode == "修改")
            {
                MessageBox.Show("这只能删除，不能修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (mode == "插入")
            {
                Data_dic data = new Data_dic
                {
                    int_dic = new Dictionary<string, int>() { { "Flip", (int)FlipMode.Y } }
                };
                data_List.Data_list.Insert(index, data);
                textBox1.AppendText(v + mode + "\r\n");
            }
        }

        private void change_x_axis_flip(string v, string mode, int index)
        {
            if (mode == "修改")
            {
                MessageBox.Show("这只能删除，不能修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (mode == "插入")
            {
                Data_dic data = new Data_dic
                {
                    int_dic = new Dictionary<string, int>() { { "Flip", (int)FlipMode.X } }
                };
                data_List.Data_list.Insert(index, data);
                textBox1.AppendText(v + mode + "\r\n");
            }
        }

        /// <summary>
        /// 平移旋转参数改变
        /// </summary>
        /// <param name="v"></param>
        private void change_translation_rotation(string v, string mode, int index)
        {
            Translation_rotation translation_rotation = new Translation_rotation(v);
            translation_rotation.StartPosition = FormStartPosition.CenterScreen;
            translation_rotation.ShowDialog();
            if (translation_rotation.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].mat_dic["translation_M"] = translation_rotation.translation_M;
                    data_List.Data_list[index].mat_dic["rotation_M"] = translation_rotation.rotation_M;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic();
                    data.mat_dic = new Dictionary<string, Mat>();
                    data.mat_dic.Add("translation_M", translation_rotation.translation_M);
                    data.mat_dic.Add("rotation_M", translation_rotation.rotation_M);
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "！！！X平移" + translation_rotation.Translation_X.ToString() +
                    ",Y平移" + translation_rotation.Translation_Y.ToString() +
                    ",旋转" + translation_rotation.Rotation.ToString() + "°\r\n");
            }
        }

        /// <summary>
        /// 黑帽运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_black_hat_operation(string v, string mode, int index)
        {
            Morphological_operation black_hat_operation = new Morphological_operation("黑帽运算");
            black_hat_operation.StartPosition = FormStartPosition.CenterScreen;
            black_hat_operation.ShowDialog();
            if (black_hat_operation.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = black_hat_operation.Kernel;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                        {
                            { "Kernel", black_hat_operation.Kernel }
                        }
                    };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + black_hat_operation.kernel_shape.ToString() +
                    ",宽度为：" + black_hat_operation.kernel_width.ToString() +
                    ",高度为：" + black_hat_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 顶帽运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_top_hat_operation(string v, string mode, int index)
        {
            Morphological_operation top_hat_operation = new Morphological_operation("顶帽运算");
            top_hat_operation.StartPosition = FormStartPosition.CenterScreen;
            top_hat_operation.ShowDialog();
            if (top_hat_operation.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = top_hat_operation.Kernel;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                        {
                            { "Kernel", top_hat_operation.Kernel }
                        }
                    };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + top_hat_operation.kernel_shape.ToString() +
                    ",宽度为：" + top_hat_operation.kernel_width.ToString() +
                    ",高度为：" + top_hat_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 梯度运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_gradient_operation(string v, string mode, int index)
        {
            Morphological_operation gradient_operation = new Morphological_operation("梯度运算");
            gradient_operation.StartPosition = FormStartPosition.CenterScreen;
            gradient_operation.ShowDialog();
            if (gradient_operation.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = gradient_operation.Kernel;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                        {
                            { "Kernel", gradient_operation.Kernel }
                        }
                    };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + gradient_operation.kernel_shape.ToString() +
                                    ",宽度为：" + gradient_operation.kernel_width.ToString() +
                                    ",高度为：" + gradient_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 闭运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_close_operation(string v, string mode, int index)
        {
            Morphological_operation close_operation = new Morphological_operation("闭运算");
            close_operation.StartPosition = FormStartPosition.CenterScreen;
            close_operation.ShowDialog();
            if (close_operation.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = close_operation.Kernel;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                        {
                            { "Kernel", close_operation.Kernel }
                        }
                    };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + close_operation.kernel_shape.ToString() +
                    ",宽度为：" + close_operation.kernel_width.ToString() +
                    ",高度为：" + close_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 开运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_open_operation(string v, string mode, int index)
        {
            Morphological_operation open_operation = new Morphological_operation("开运算");
            open_operation.StartPosition = FormStartPosition.CenterScreen;
            open_operation.ShowDialog();
            if (open_operation.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = open_operation.Kernel;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                        {
                            { "Kernel", open_operation.Kernel }
                        }
                    };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + open_operation.kernel_shape.ToString() +
                    ",宽度为：" + open_operation.kernel_width.ToString() +
                    ",高度为：" + open_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 膨胀参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_expansion(string v, string mode, int index)
        {
            Morphological_operation expansion = new Morphological_operation("膨胀");
            expansion.StartPosition = FormStartPosition.CenterScreen;
            expansion.ShowDialog();
            if (expansion.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = expansion.Kernel;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                        {
                            { "Kernel", expansion.Kernel }
                        }
                    };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + expansion.kernel_shape.ToString() +
                    ",宽度为：" + expansion.kernel_width.ToString() +
                    ",高度为：" + expansion.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 腐蚀参数修改
        /// </summary>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void change_corrosion(string v, string mode, int index)
        {
            Morphological_operation corrosion = new Morphological_operation("腐蚀操作");
            corrosion.StartPosition = FormStartPosition.CenterScreen;
            corrosion.ShowDialog();
            if (corrosion.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = corrosion.Kernel;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                        {
                            { "Kernel", corrosion.Kernel }
                        }
                    };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + corrosion.kernel_shape.ToString() +
                    ",宽度为：" + corrosion.kernel_width.ToString() +
                    ",高度为：" + corrosion.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// Otsu算法参数改变
        /// </summary>
        /// <param name=""></param>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void change_Otsu(string v, string mode, int index)
        {
            Otsu otsu = new Otsu(mode);
            otsu.StartPosition = FormStartPosition.CenterScreen;
            otsu.ShowDialog();
            if (otsu.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].int_dic["Binarization_mode"] = (int)otsu.Binarization_mode;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic
                    {
                        int_dic = new Dictionary<string, int>()
                        {
                            { "Binarization_mode", (int)otsu.Binarization_mode },
                        }
                    };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！模式为：" + otsu.Binarization_mode.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 自适应阈值参数改变
        /// </summary>
        /// <param name="mode"></param>
        private void change_adaptivethreshold(string v, string mode, int index)
        {
            Adaptive_Threshold adaptivethreshold = new Adaptive_Threshold();
            adaptivethreshold.StartPosition = FormStartPosition.CenterScreen;
            adaptivethreshold.ShowDialog();
            if (adaptivethreshold.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].int_dic["Adaptive_Types"] = (int)adaptivethreshold.Adaptive_Types;
                    data_List.Data_list[index].int_dic["Threshold_Types"] = (int)adaptivethreshold.Threshold_Types;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic
                    {
                        int_dic = new Dictionary<string, int>()
                        {
                            { "Adaptive_Types", (int)adaptivethreshold.Adaptive_Types },
                            { "Threshold_Types",(int)adaptivethreshold.Threshold_Types}
                        }
                    };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！自适应阈值算法为：" + adaptivethreshold.Adaptive_Types.ToString() +
                    ",模式为：" + adaptivethreshold.Threshold_Types.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 二值化参数修改
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void change_binarization(string v, string mode, int index)
        {
            Binarization binarization = new Binarization("二值化参数修改");
            binarization.StartPosition = FormStartPosition.CenterScreen;
            binarization.ShowDialog();
            if (binarization.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].int_dic["Threshold"] = binarization.Threshold;
                    data_List.Data_list[index].int_dic["Binarization_mode"] = (int)binarization.Binarization_mode;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic
                    {
                        int_dic = new Dictionary<string, int>()
                        {
                            { "Threshold", binarization.Threshold },
                            { "Binarization_mode",(int)binarization.Binarization_mode}
                        }
                    };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "修改成功！！！阈值为：" + binarization.Threshold.ToString() +
                    ",模式为：" + binarization.Binarization_mode.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 双边滤波参数修改
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void change_bilateral_filter(string v, string mode, int index)
        {
            Bilateral_Filter bilateral_Filter = new Bilateral_Filter();
            bilateral_Filter.StartPosition = FormStartPosition.CenterScreen;
            bilateral_Filter.ShowDialog();
            if (bilateral_Filter.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].dou_dic["SigmaColor"] = bilateral_Filter.SigmaColor;
                    data_List.Data_list[index].dou_dic["SigmaSpace"] = bilateral_Filter.SigmaSpace;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic
                    {
                        dou_dic = new Dictionary<string, double>()
                    {
                        { "SigmaColor", bilateral_Filter.SigmaColor},
                        { "SigmaSpace",bilateral_Filter.SigmaSpace}
                    }
                    };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "修改成功！！！sigmaColor为：" + bilateral_Filter.SigmaColor.ToString() +
                    ",SigmaSpace：" + bilateral_Filter.SigmaSpace.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 中值滤波参数更改
        /// </summary>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void change_median_blur(string v, string mode, int index)
        {
            Filtering median_Blur = new Filtering(Filtering.模式.奇数, new Filtering.Scope { min = 1, max = 50 }, mode);
            median_Blur.StartPosition = FormStartPosition.CenterScreen;
            median_Blur.ShowDialog();
            if (median_Blur.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].int_dic["size"] = median_Blur.Value;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic();
                    data.int_dic = new Dictionary<string, int>() { { "size", median_Blur.Value } };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！核大小为：" + median_Blur.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 高斯滤波参数更改
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void change_gaussian_blur(string v, string mode, int index)
        {
            Filtering gaussian_Blur = new Filtering(Filtering.模式.奇数, new Filtering.Scope { min = 1, max = 50 }, mode);
            gaussian_Blur.StartPosition = FormStartPosition.CenterScreen;
            gaussian_Blur.ShowDialog();
            if (gaussian_Blur.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].int_dic["size"] = gaussian_Blur.Value;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic();
                    data.int_dic = new Dictionary<string, int>() { { "size", gaussian_Blur.Value } };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！核大小为：" + gaussian_Blur.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        ///方框滤波参数更改
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void change_box_filtering(string v, string mode, int index)
        {
            Filtering box_filter = new Filtering(Filtering.模式.无, new Filtering.Scope { min = 1, max = 50 }, mode);
            box_filter.StartPosition = FormStartPosition.CenterScreen;
            box_filter.ShowDialog();
            if (box_filter.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].int_dic["size"] = box_filter.Value;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic();
                    data.int_dic = new Dictionary<string, int>() { { "size", box_filter.Value } };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！核大小为：" + box_filter.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 改变颜色空间参数更改
        /// </summary>
        private void change_color(string v, string mode, int index)
        {
            colorTo colorto = new colorTo();
            colorto.StartPosition = FormStartPosition.CenterParent;
            colorto.ShowDialog();
            if (colorto.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].int_dic["ColorCode"] = (int)colorto.ColorCode;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic();
                    data.int_dic = new Dictionary<string, int>();
                    data.int_dic.Add("ColorCode", (int)colorto.ColorCode);
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！图片处理为：" + colorto.ColorCode.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 均值滤波参数更改
        /// </summary>
        private void change_Mean_filtering(string v, string mode, int index)
        {
            Filtering mean_filter = new Filtering(Filtering.模式.无, new Filtering.Scope { min = 1, max = 50 }, mode);
            mean_filter.StartPosition = FormStartPosition.CenterScreen;
            mean_filter.ShowDialog();
            if (mean_filter.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    data_List.Data_list[index].int_dic["size"] = mean_filter.Value;
                }
                else if (mode == "插入")
                {
                    Data_dic data = new Data_dic();
                    data.int_dic = new Dictionary<string, int>() { { "size", mean_filter.Value } };
                    data_List.Data_list.Insert(index, data);
                }
                textBox1.AppendText(v + mode + "成功！！！图片处理为：" + mean_filter.Value.ToString() + "\r\n");
            }
        }
    }
}