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
            Feature feature_Matching = new Feature("特征匹配", mode, index);
            // 创建特征匹配窗口对象
            feature_Matching.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗口的起始位置为屏幕中央
            feature_Matching.ShowDialog();
            // 显示特征匹配窗口
            if (mode == "修改")
            // 如果是修改操作
            {
                data_List.Data_list[index].mat_dic["Template"] = feature_Matching.Template;
                // 将特征匹配窗口中选择的模板图像保存到数据列表中
                data_List.Data_list[index].mat_dic["desc2"] = feature_Matching.desc2;
                // 将特征匹配窗口中计算得到的特征描述子保存到数据列表中
                data_List.Data_list[index].dou_dic["Threshold"] = feature_Matching.Threshold;
                // 将特征匹配窗口中选择的阈值保存到数据列表中
                data_List.Data_list[index].KeyPoint_dic["kp2"] = feature_Matching.kp2;
                // 将特征匹配窗口中计算得到的特征点保存到数据列表中
                data_List.Data_list[index].str_dic["mode"] = feature_Matching.Mode;
                // 将特征匹配窗口中选择的匹配模式保存到数据列表中
            }
            else if (mode == "插入")
            // 如果是插入操作
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
                // 创建一个新的 Data_dic 对象，保存特征匹配窗口中选择的参数
                data_List.Data_list.Insert(index, data);
                // 将新的 Data_dic 对象插入到数据列表中
            }
            textBox1.AppendText(v + mode + "成功！！！模式为：" + feature_Matching.Mode +
                    "模板为：" + feature_Matching.Pic_name + "，阈值为：" + feature_Matching.Threshold + "\r\n");
            // 在文本框中输出特征匹配操作的结果和参数
        }

        private void change_template_matching(string v, string mode, int index)
        {
            Template_Matching template_Matching = new Template_Matching("模板匹配", mode, index);
            // 创建模板匹配窗口对象
            template_Matching.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗口的起始位置为屏幕中央
            template_Matching.ShowDialog();
            // 显示模板匹配窗口
            if (template_Matching.DialogResult == DialogResult.OK)
            // 如果用户点击了“确定”按钮
            {
                if (mode == "修改")
                // 如果是修改操作
                {
                    data_List.Data_list[index].mat_dic["Template"] = template_Matching.Template;
                    // 将模板匹配窗口中选择的模板图像保存到数据列表中
                    data_List.Data_list[index].dou_dic["Threshold"] = template_Matching.Threshold;
                    // 将模板匹配窗口中选择的阈值保存到数据列表中
                    data_List.Data_list[index].int_dic["Template_Match_Modes"] = template_Matching.Template_Match_Modes;
                    // 将模板匹配窗口中选择的匹配模式保存到数据列表中
                }
                else if (mode == "插入")
                // 如果是插入操作
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
                    // 创建一个新的 Data_dic 对象，保存模板匹配窗口中选择的参数
                    data_List.Data_list.Insert(index, data);
                    // 将新的 Data_dic 对象插入到数据列表中
                }
                textBox1.AppendText(v + mode + "成功！！！模式为：" + template_Matching.uiComboBox1.SelectedText +
                    "模板为：" + template_Matching.Pic_name + "，置信度为：" + template_Matching.Threshold.ToString() + "\r\n");
                // 在文本框中输出模板匹配操作的结果和参数
            }
        }

        private void change_xy_axis_flip(string v, string mode, int index)
        {
            if (mode == "修改")
            // 如果是修改操作
            {
                MessageBox.Show("这只能删除，不能修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 弹出提示框，提示用户该参数只能删除，不能修改
            }
            else if (mode == "插入")
            // 如果是插入操作
            {
                Data_dic data = new Data_dic
                {
                    int_dic = new Dictionary<string, int>() { { "Flip", (int)FlipMode.XY } }
                    // 创建一个新的 Data_dic 对象，保存翻转参数
                };
                data_List.Data_list.Insert(index, data);
                // 将新的 Data_dic 对象插入到数据列表中
                textBox1.AppendText(v + mode + "\r\n");
                // 在文本框中输出操作的结果和参数
            }
        }

        private void change_y_axis_flip(string v, string mode, int index)
        {
            if (mode == "修改")
            // 如果是修改操作
            {
                MessageBox.Show("这只能删除，不能修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 弹出提示框，提示用户该参数只能删除，不能修改
            }
            else if (mode == "插入")
            // 如果是插入操作
            {
                Data_dic data = new Data_dic
                {
                    int_dic = new Dictionary<string, int>() { { "Flip", (int)FlipMode.Y } }
                    // 创建一个新的 Data_dic 对象，保存翻转参数
                };
                data_List.Data_list.Insert(index, data);
                // 将新的 Data_dic 对象插入到数据列表中
                textBox1.AppendText(v + mode + "\r\n");
                // 在文本框中输出操作的结果和参数
            }
        }

        private void change_x_axis_flip(string v, string mode, int index)
        {
            if (mode == "修改")
            // 如果是修改操作
            {
                MessageBox.Show("这只能删除，不能修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 弹出提示框，提示用户该参数只能删除，不能修改
            }
            else if (mode == "插入")
            // 如果是插入操作
            {
                Data_dic data = new Data_dic
                {
                    int_dic = new Dictionary<string, int>() { { "Flip", (int)FlipMode.X } }
                    // 创建一个新的 Data_dic 对象，保存翻转参数
                };
                data_List.Data_list.Insert(index, data);
                // 将新的 Data_dic 对象插入到数据列表中
                textBox1.AppendText(v + mode + "\r\n");
                // 在文本框中输出操作的结果和参数
            }
        }

        /// <summary>
        /// 平移旋转参数改变
        /// </summary>
        /// <param name="v"></param>
        private void change_translation_rotation(string v, string mode, int index)
        {
            Translation_rotation translation_rotation = new Translation_rotation(v);
            // 创建平移旋转窗口对象
            translation_rotation.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗口的起始位置为屏幕中央
            translation_rotation.ShowDialog();
            // 显示平移旋转窗口
            if (translation_rotation.DialogResult == DialogResult.OK)
            // 如果用户点击了“确定”按钮
            {
                if (mode == "修改")
                // 如果是修改操作
                {
                    data_List.Data_list[index].mat_dic["translation_M"] = translation_rotation.translation_M;
                    // 将平移矩阵保存到数据列表中
                    data_List.Data_list[index].mat_dic["rotation_M"] = translation_rotation.rotation_M;
                    // 将旋转矩阵保存到数据列表中
                }
                else if (mode == "插入")
                // 如果是插入操作
                {
                    Data_dic data = new Data_dic();
                    data.mat_dic = new Dictionary<string, Mat>();
                    data.mat_dic.Add("translation_M", translation_rotation.translation_M);
                    data.mat_dic.Add("rotation_M", translation_rotation.rotation_M);
                    // 创建一个新的 Data_dic 对象，保存平移旋转参数
                    data_List.Data_list.Insert(index, data);
                    // 将新的 Data_dic 对象插入到数据列表中
                }
                textBox1.AppendText(v + mode + "！！！X平移" + translation_rotation.Translation_X.ToString() +
                    ",Y平移" + translation_rotation.Translation_Y.ToString() +
                    ",旋转" + translation_rotation.Rotation.ToString() + "°\r\n");
                // 在文本框中输出平移旋转操作的结果和参数
            }
        }

        /// <summary>
        /// 黑帽运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_black_hat_operation(string v, string mode, int index)
        {
            Morphological_operation black_hat_operation = new Morphological_operation("黑帽运算");
            // 创建形态学运算窗口对象，指定运算类型为黑帽运算
            black_hat_operation.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗口的起始位置为屏幕中央
            black_hat_operation.ShowDialog();
            // 显示形态学运算窗口
            if (black_hat_operation.DialogResult == DialogResult.OK)
            // 如果用户点击了“确定”按钮
            {
                if (mode == "修改")
                // 如果是修改操作
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = black_hat_operation.Kernel;
                    // 将核矩阵保存到数据列表中
                }
                else if (mode == "插入")
                // 如果是插入操作
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                {
                    { "Kernel", black_hat_operation.Kernel }
                }
                    };
                    // 创建一个新的 Data_dic 对象，保存黑帽运算参数
                    data_List.Data_list.Insert(index, data);
                    // 将新的 Data_dic 对象插入到数据列表中
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + black_hat_operation.kernel_shape.ToString() +
                    ",宽度为：" + black_hat_operation.kernel_width.ToString() +
                    ",高度为：" + black_hat_operation.kernel_height.ToString() + "\r\n");
                // 在文本框中输出黑帽运算操作的结果和参数
            }
        }

        /// <summary>
        /// 顶帽运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_top_hat_operation(string v, string mode, int index)
        {
            Morphological_operation top_hat_operation = new Morphological_operation("顶帽运算");
            // 创建形态学运算窗口对象，指定运算类型为顶帽运算
            top_hat_operation.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗口的起始位置为屏幕中央
            top_hat_operation.ShowDialog();
            // 显示形态学运算窗口
            if (top_hat_operation.DialogResult == DialogResult.OK)
            // 如果用户点击了“确定”按钮
            {
                if (mode == "修改")
                // 如果是修改操作
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = top_hat_operation.Kernel;
                    // 将核矩阵保存到数据列表中
                }
                else if (mode == "插入")
                // 如果是插入操作
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                {
                    { "Kernel", top_hat_operation.Kernel }
                }
                    };
                    // 创建一个新的 Data_dic 对象，保存顶帽运算参数
                    data_List.Data_list.Insert(index, data);
                    // 将新的 Data_dic 对象插入到数据列表中
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + top_hat_operation.kernel_shape.ToString() +
                    ",宽度为：" + top_hat_operation.kernel_width.ToString() +
                    ",高度为：" + top_hat_operation.kernel_height.ToString() + "\r\n");
                // 在文本框中输出顶帽运算操作的结果和参数
            }
        }

        /// <summary>
        /// 梯度运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_gradient_operation(string v, string mode, int index)
        {
            Morphological_operation gradient_operation = new Morphological_operation("梯度运算");
            // 创建形态学运算窗口对象，指定运算类型为梯度运算
            gradient_operation.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗口的起始位置为屏幕中央
            gradient_operation.ShowDialog();
            // 显示形态学运算窗口
            if (gradient_operation.DialogResult == DialogResult.OK)
            // 如果用户点击了“确定”按钮
            {
                if (mode == "修改")
                // 如果是修改操作
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = gradient_operation.Kernel;
                    // 将核矩阵保存到数据列表中
                }
                else if (mode == "插入")
                // 如果是插入操作
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                {
                    { "Kernel", gradient_operation.Kernel }
                }
                    };
                    // 创建一个新的 Data_dic 对象，保存梯度运算参数
                    data_List.Data_list.Insert(index, data);
                    // 将新的 Data_dic 对象插入到数据列表中
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + gradient_operation.kernel_shape.ToString() +
                    ",宽度为：" + gradient_operation.kernel_width.ToString() +
                    ",高度为：" + gradient_operation.kernel_height.ToString() + "\r\n");
                // 在文本框中输出梯度运算操作的结果和参数
            }
        }

        /// <summary>
        /// 闭运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_close_operation(string v, string mode, int index)
        {
            Morphological_operation close_operation = new Morphological_operation("闭运算");
            // 创建形态学运算窗口对象，指定运算类型为闭运算
            close_operation.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗口的起始位置为屏幕中央
            close_operation.ShowDialog();
            // 显示形态学运算窗口
            if (close_operation.DialogResult == DialogResult.OK)
            // 如果用户点击了“确定”按钮
            {
                if (mode == "修改")
                // 如果是修改操作
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = close_operation.Kernel;
                    // 将核矩阵保存到数据列表中
                }
                else if (mode == "插入")
                // 如果是插入操作
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                {
                    { "Kernel", close_operation.Kernel }
                }
                    };
                    // 创建一个新的 Data_dic 对象，保存闭运算参数
                    data_List.Data_list.Insert(index, data);
                    // 将新的 Data_dic 对象插入到数据列表中
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + close_operation.kernel_shape.ToString() +
                    ",宽度为：" + close_operation.kernel_width.ToString() +
                    ",高度为：" + close_operation.kernel_height.ToString() + "\r\n");
                // 在文本框中输出闭运算操作的结果和参数
            }
        }

        /// <summary>
        /// 开运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_open_operation(string v, string mode, int index)
        {
            Morphological_operation open_operation = new Morphological_operation("开运算");
            // 创建形态学运算窗口对象，指定运算类型为开运算
            open_operation.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗口的起始位置为屏幕中央
            open_operation.ShowDialog();
            // 显示形态学运算窗口
            if (open_operation.DialogResult == DialogResult.OK)
            // 如果用户点击了“确定”按钮
            {
                if (mode == "修改")
                // 如果是修改操作
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = open_operation.Kernel;
                    // 将核矩阵保存到数据列表中
                }
                else if (mode == "插入")
                // 如果是插入操作
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                        {
                            { "Kernel", open_operation.Kernel }
                        }
                    };
                    // 创建一个新的 Data_dic 对象，保存开运算参数
                    data_List.Data_list.Insert(index, data);
                    // 将新的 Data_dic 对象插入到数据列表中
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + open_operation.kernel_shape.ToString() +
                    ",宽度为：" + open_operation.kernel_width.ToString() +
                    ",高度为：" + open_operation.kernel_height.ToString() + "\r\n");
                // 在文本框中输出开运算操作的结果和参数
            }
        }

        /// <summary>
        /// 膨胀参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_expansion(string v, string mode, int index)
        {
            Morphological_operation expansion = new Morphological_operation("膨胀");
            // 创建形态学运算窗口对象，指定运算类型为膨胀
            expansion.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗口的起始位置为屏幕中央
            expansion.ShowDialog();
            // 显示形态学运算窗口
            if (expansion.DialogResult == DialogResult.OK)
            // 如果用户点击了“确定”按钮
            {
                if (mode == "修改")
                // 如果是修改操作
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = expansion.Kernel;
                    // 将核矩阵保存到数据列表中
                }
                else if (mode == "插入")
                // 如果是插入操作
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                        {
                            { "Kernel", expansion.Kernel }
                        }
                    };
                    // 创建一个新的 Data_dic 对象，保存膨胀操作参数
                    data_List.Data_list.Insert(index, data);
                    // 将新的 Data_dic 对象插入到数据列表中
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + expansion.kernel_shape.ToString() +
                    ",宽度为：" + expansion.kernel_width.ToString() +
                    ",高度为：" + expansion.kernel_height.ToString() + "\r\n");
                // 在文本框中输出膨胀操作的结果和参数
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
            // 创建形态学运算窗口对象，指定运算类型为腐蚀操作
            corrosion.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗口的起始位置为屏幕中央
            corrosion.ShowDialog();
            // 显示形态学运算窗口
            if (corrosion.DialogResult == DialogResult.OK)
            // 如果用户点击了“确定”按钮
            {
                if (mode == "修改")
                // 如果是修改操作
                {
                    data_List.Data_list[index].mat_dic["Kernel"] = corrosion.Kernel;
                    // 将核矩阵保存到数据列表中
                }
                else if (mode == "插入")
                // 如果是插入操作
                {
                    Data_dic data = new Data_dic
                    {
                        mat_dic = new Dictionary<string, Mat>()
                        {
                            { "Kernel", corrosion.Kernel }
                        }
                    };
                    // 创建一个新的 Data_dic 对象，保存腐蚀操作参数
                    data_List.Data_list.Insert(index, data);
                    // 将新的 Data_dic 对象插入到数据列表中
                }
                textBox1.AppendText(v + mode + "成功！！！核形状为为：" + corrosion.kernel_shape.ToString() +
                    ",宽度为：" + corrosion.kernel_width.ToString() +
                    ",高度为：" + corrosion.kernel_height.ToString() + "\r\n");
                // 在文本框中输出腐蚀操作的结果和参数
            }
        }

        /// <summary>
        /// Otsu算法参数改变
        /// </summary>
        /// <param name=""></param>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void change_Otsu(string v, string mode, int index)
        // 定义一个修改或插入二值化模式参数的函数，函数参数包括操作类型、数据列表中的索引位置
        {
            Otsu otsu = new Otsu(mode);
            // 创建 Otsu 对象，指定操作类型（修改或插入）
            otsu.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗口的起始位置为屏幕中央
            otsu.ShowDialog();
            // 显示二值化窗口
            if (otsu.DialogResult == DialogResult.OK)
            // 如果用户点击了“确定”按钮
            {
                if (mode == "修改")
                // 如果是修改操作
                {
                    data_List.Data_list[index].int_dic["Binarization_mode"] = (int)otsu.Binarization_mode;
                    // 将二值化模式参数保存到数据列表中
                }
                else if (mode == "插入")
                // 如果是插入操作
                {
                    Data_dic data = new Data_dic
                    {
                        int_dic = new Dictionary<string, int>()
                {
                    { "Binarization_mode", (int)otsu.Binarization_mode },
                }
                    };
                    // 创建一个新的 Data_dic 对象，保存二值化模式参数
                    data_List.Data_list.Insert(index, data);
                    // 将新的 Data_dic 对象插入到数据列表中
                }
                textBox1.AppendText(v + mode + "成功！！！模式为：" + otsu.Binarization_mode.ToString() + "\r\n");
                // 在文本框中输出操作的结果和参数
            }
        }

        /// <summary>
        /// 自适应阈值参数改变
        /// </summary>
        /// <param name="mode"></param>
        private void change_adaptivethreshold(string v, string mode, int index)
        {
            Adaptive_Threshold adaptivethreshold = new Adaptive_Threshold();
            // 创建自适应阈值窗口对象
            adaptivethreshold.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗口的起始位置为屏幕中央
            adaptivethreshold.ShowDialog();
            // 显示自适应阈值窗口
            if (adaptivethreshold.DialogResult == DialogResult.OK)
            // 如果用户点击了“确定”按钮
            {
                if (mode == "修改")
                // 如果是修改操作
                {
                    data_List.Data_list[index].int_dic["Adaptive_Types"] = (int)adaptivethreshold.Adaptive_Types;
                    data_List.Data_list[index].int_dic["Threshold_Types"] = (int)adaptivethreshold.Threshold_Types;
                    // 将自适应阈值算法和阈值模式保存到数据列表中
                }
                else if (mode == "插入")
                // 如果是插入操作
                {
                    Data_dic data = new Data_dic
                    {
                        int_dic = new Dictionary<string, int>()
            {
                { "Adaptive_Types", (int)adaptivethreshold.Adaptive_Types },
                { "Threshold_Types",(int)adaptivethreshold.Threshold_Types}
            }
                    };
                    // 创建一个新的 Data_dic 对象，保存自适应阈值算法和阈值模式参数
                    data_List.Data_list.Insert(index, data);
                    // 将新的 Data_dic 对象插入到数据列表中
                }
                textBox1.AppendText(v + mode + "成功！！！自适应阈值算法为：" + adaptivethreshold.Adaptive_Types.ToString() +
                    ",模式为：" + adaptivethreshold.Threshold_Types.ToString() + "\r\n");
                // 在文本框中输出操作的结果和参数
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
            // 创建二值化窗口对象，指定窗口的标题为“二值化参数修改”
            binarization.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗口的起始位置为屏幕中央
            binarization.ShowDialog();
            // 显示二值化窗口
            if (binarization.DialogResult == DialogResult.OK)
            // 如果用户点击了“确定”按钮
            {
                if (mode == "修改")
                // 如果是修改操作
                {
                    data_List.Data_list[index].int_dic["Threshold"] = binarization.Threshold;
                    data_List.Data_list[index].int_dic["Binarization_mode"] = (int)binarization.Binarization_mode;
                    // 将阈值和二值化模式保存到数据列表中
                }
                else if (mode == "插入")
                // 如果是插入操作
                {
                    Data_dic data = new Data_dic
                    {
                        int_dic = new Dictionary<string, int>()
            {
                { "Threshold", binarization.Threshold },
                { "Binarization_mode",(int)binarization.Binarization_mode}
            }
                    };
                    // 创建一个新的 Data_dic 对象，保存阈值和二值化模式参数
                    data_List.Data_list.Insert(index, data);
                    // 将新的 Data_dic 对象插入到数据列表中
                }
                textBox1.AppendText(v + mode + "修改成功！！！阈值为：" + binarization.Threshold.ToString() +
                    ",模式为：" + binarization.Binarization_mode.ToString() + "\r\n");
                // 在文本框中输出操作的结果和参数
            }
        }

        /// <summary>
        /// 双边滤波参数修改
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void change_bilateral_filter(string v, string mode, int index)
        {
            // 创建一个 Bilateral_Filter 类的实例
            Bilateral_Filter bilateral_Filter = new Bilateral_Filter();
            // 设置 Bilateral_Filter 窗口的启动位置为屏幕中央
            bilateral_Filter.StartPosition = FormStartPosition.CenterScreen;
            // 显示 Bilateral_Filter 窗口，并等待用户交互
            bilateral_Filter.ShowDialog();

            // 判断用户是否点击了 Bilateral_Filter 窗口的“确定”按钮
            if (bilateral_Filter.DialogResult == DialogResult.OK)
            {
                // 如果当前操作是“修改”
                if (mode == "修改")
                {
                    // 更新 data_List 列表中指定 index 位置的元素中的 "SigmaColor" 和 "SigmaSpace" 属性值
                    data_List.Data_list[index].dou_dic["SigmaColor"] = bilateral_Filter.SigmaColor;
                    data_List.Data_list[index].dou_dic["SigmaSpace"] = bilateral_Filter.SigmaSpace;
                }
                // 如果当前操作是“插入”
                else if (mode == "插入")
                {
                    // 创建一个新的 Data_dic 对象，并设置其 dou_dic 属性为包含 "SigmaColor" 和 "SigmaSpace" 两个键值对的字典
                    Data_dic data = new Data_dic
                    {
                        dou_dic = new Dictionary<string, double>()
                        {
                            { "SigmaColor", bilateral_Filter.SigmaColor},
                            { "SigmaSpace",bilateral_Filter.SigmaSpace}
                        }
                    };
                    // 将新创建的 Data_dic 对象插入到 data_List 列表的 index 位置
                    data_List.Data_list.Insert(index, data);
                }
                // 在 textBox1 控件中添加一行文本，提示用户修改成功，并显示修改后的 "SigmaColor" 和 "SigmaSpace" 属性值
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
            // 创建一个 Filtering 类的实例，使用奇数模式，核大小范围为 1 到 50，传入当前的 mode 变量
            Filtering median_Blur = new Filtering(Filtering.模式.奇数, new Filtering.Scope { min = 1, max = 50 }, mode);
            // 设置 Filtering 窗口的启动位置为屏幕中央
            median_Blur.StartPosition = FormStartPosition.CenterScreen;
            // 显示 Filtering 窗口，并等待用户交互
            median_Blur.ShowDialog();

            // 判断用户是否点击了 Filtering 窗口的“确定”按钮
            if (median_Blur.DialogResult == DialogResult.OK)
            {
                // 如果当前操作是“修改”
                if (mode == "修改")
                {
                    // 更新 data_List 列表中指定 index 位置的元素中的 "size" 属性值
                    data_List.Data_list[index].int_dic["size"] = median_Blur.Value;
                }
                // 如果当前操作是“插入”
                else if (mode == "插入")
                {
                    // 创建一个新的 Data_dic 对象，并设置其 int_dic 属性只包含一个键值对，即 "size" 和 median_Blur.Value
                    Data_dic data = new Data_dic();
                    data.int_dic = new Dictionary<string, int>() { { "size", median_Blur.Value } };
                    // 将新创建的 Data_dic 对象插入到 data_List 列表的 index 位置
                    data_List.Data_list.Insert(index, data);
                }
                // 在 textBox1 控件中添加一行文本，提示用户操作成功，并显示核大小
                textBox1.AppendText(v + mode + "成功！！！核大小为：" + median_Blur.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 高斯滤波参数更改
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void change_gaussian_blur(string v, string mode, int index)
        {
            // 创建一个 Filtering 类的实例，使用奇数模式，核大小范围为 1 到 50，传入当前的 mode 变量
            Filtering gaussian_Blur = new Filtering(Filtering.模式.奇数, new Filtering.Scope { min = 1, max = 50 }, mode);
            // 设置 Filtering 窗口的启动位置为屏幕中央
            gaussian_Blur.StartPosition = FormStartPosition.CenterScreen;
            // 显示 Filtering 窗口，并等待用户交互
            gaussian_Blur.ShowDialog();

            // 判断用户是否点击了 Filtering 窗口的“确定”按钮
            if (gaussian_Blur.DialogResult == DialogResult.OK)
            {
                // 如果当前操作是“修改”
                if (mode == "修改")
                {
                    // 更新 data_List 列表中指定 index 位置的元素中的 "size" 属性值
                    data_List.Data_list[index].int_dic["size"] = gaussian_Blur.Value;
                }
                // 如果当前操作是“插入”
                else if (mode == "插入")
                {
                    // 创建一个新的 Data_dic 对象，并设置其 int_dic 属性只包含一个键值对，即 "size" 和 gaussian_Blur.Value
                    Data_dic data = new Data_dic();
                    data.int_dic = new Dictionary<string, int>() { { "size", gaussian_Blur.Value } };
                    // 将新创建的 Data_dic 对象插入到 data_List 列表的 index 位置
                    data_List.Data_list.Insert(index, data);
                }
                // 在 textBox1 控件中添加一行文本，提示用户操作成功，并显示核大小
                textBox1.AppendText(v + mode + "成功！！！核大小为：" + gaussian_Blur.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        ///方框滤波参数更改
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void change_box_filtering(string v, string mode, int index)
        {
            // 创建一个滤波器实例
            Filtering box_filter = new Filtering(Filtering.模式.无, new Filtering.Scope { min = 1, max = 50 }, mode);
            // 设置窗口打开位置为屏幕中央并显示窗口
            box_filter.StartPosition = FormStartPosition.CenterScreen;
            box_filter.ShowDialog();
            // 判断对话框是否确认，如果确认则修改或插入数据项
            if (box_filter.DialogResult == DialogResult.OK)
            {
                if (mode == "修改")
                {
                    // 修改已有数据项
                    data_List.Data_list[index].int_dic["size"] = box_filter.Value;
                }
                else if (mode == "插入")
                {
                    // 插入新的数据项
                    Data_dic data = new Data_dic();
                    data.int_dic = new Dictionary<string,int>() { { "size", box_filter.Value } };
                    data_List.Data_list.Insert(index, data);
                }
                // 添加操作成功提示信息到文本框中
                textBox1.AppendText(v + mode + "成功！！！核大小为：" + box_filter.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 改变颜色空间参数更改
        /// </summary>
        private void change_color(string v, string mode, int index)
        {
            // 创建一个 colorTo 类的实例
            colorTo colorto = new colorTo();
            // 设置 colorTo 窗口的启动位置为父窗口中央
            colorto.StartPosition = FormStartPosition.CenterParent;
            // 显示 colorTo 窗口，并等待用户交互
            colorto.ShowDialog();

            // 判断用户是否点击了 colorTo 窗口的“确定”按钮
            if (colorto.DialogResult == DialogResult.OK)
            {
                // 如果当前操作是“修改”
                if (mode == "修改")
                {
                    // 更新 data_List 列表中指定 index 位置的元素中的 "ColorCode" 属性值，将 colorto.ColorCode 强制转换为整型
                    data_List.Data_list[index].int_dic["ColorCode"] = (int)colorto.ColorCode;
                }
                // 如果当前操作是“插入”
                else if (mode == "插入")
                {
                    // 创建一个新的 Data_dic 对象，并设置其 int_dic 属性只包含一个键值对，即 "ColorCode" 和 colorto.ColorCode 的整型值
                    Data_dic data = new Data_dic();
                    data.int_dic = new Dictionary<string, int>();
                    data.int_dic.Add("ColorCode", (int)colorto.ColorCode);
                    // 将新创建的 Data_dic 对象插入到 data_List 列表的 index 位置
                    data_List.Data_list.Insert(index, data);
                }
                // 在 textBox1 控件中添加一行文本，提示用户操作成功，并显示图片处理方式
                textBox1.AppendText(v + mode + "成功！！！图片处理为：" + colorto.ColorCode.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 均值滤波参数更改
        /// </summary>
        private void change_Mean_filtering(string v, string mode, int index)
        {
            // 创建一个 Filtering 类的实例，使用无模式，核大小范围为 1 到 50，传入当前的 mode 变量
            Filtering mean_filter = new Filtering(Filtering.模式.无, new Filtering.Scope { min = 1, max = 50 }, mode);
            // 设置 Filtering 窗口的启动位置为屏幕中央
            mean_filter.StartPosition = FormStartPosition.CenterScreen;
            // 显示 Filtering 窗口，并等待用户交互
            mean_filter.ShowDialog();

            // 判断用户是否点击了 Filtering 窗口的“确定”按钮
            if (mean_filter.DialogResult == DialogResult.OK)
            {
                // 如果当前操作是“修改”
                if (mode == "修改")
                {
                    // 更新 data_List 列表中指定 index 位置的元素中的 "size" 属性值
                    data_List.Data_list[index].int_dic["size"] = mean_filter.Value;
                }
                // 如果当前操作是“插入”
                else if (mode == "插入")
                {
                    // 创建一个新的 Data_dic 对象，并设置其 int_dic 属性只包含一个键值对，即 "size" 和 mean_filter.Value
                    Data_dic data = new Data_dic();
                    data.int_dic = new Dictionary<string, int>() { { "size", mean_filter.Value } };
                    // 将新创建的 Data_dic 对象插入到 data_List 列表的 index 位置
                    data_List.Data_list.Insert(index, data);
                }
                // 在 textBox1 控件中添加一行文本，提示用户操作成功，并显示图片处理方式
                textBox1.AppendText(v + mode + "成功！！！图片处理为：" + mean_filter.Value.ToString() + "\r\n");
            }
        }
    }
}