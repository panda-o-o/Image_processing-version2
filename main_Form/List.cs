using Image_processing.Class;
using Image_processing.form;
using Image_processing.form.二值化;
using Image_processing.form.平移旋转;
using Image_processing.form.形态学操作;
using Image_processing.form.滤波;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OpenCvSharp.Stitcher;

namespace Image_processing
{
    public partial class Main_form
    {
        private void change_parameter()
        {
#pragma warning disable CS8602 // 解引用可能出现空引用。
            string? list = listBox1.SelectedItem.ToString();
            change_set_parameter(list);
        }

        private void change_set_parameter(string? list)
        {
            switch (list)
            {
                case "颜色空间变化": change_color(); break;
                case "均值滤波": change_Mean_filtering("均值滤波"); break;
                case "方框滤波": change_box_filtering("方框滤波"); break;
                case "高斯滤波": change_gaussian_blur("高斯滤波"); break;
                case "中值滤波": change_median_blur("高斯滤波"); break;
                case "双边滤波": change_bilateral_filter("双边滤波"); break;
                case "二值化": change_binarization("二值化"); break;
                case "自适应阈值": change_adaptivethreshold("自适应阈值"); break;
                case "Otsu算法": change_Otsu("Otsu算法"); break;
                case ("腐蚀"): change_corrosion("腐蚀"); break;
                case ("膨胀"): change_expansion("膨胀"); break;
                case ("开运算"): change_open_operation("开运算"); break;
                case ("闭运算"): change_close_operation("闭运算"); break;
                case ("梯度运算"): change_gradient_operation("梯度运算"); break;
                case ("顶帽运算"): change_top_hat_operation("顶帽运算"); break;
                case ("黑帽运算"): change_black_hat_operation("黑帽运算"); break;
                case ("平移旋转"): change_translation_rotation("平移旋转"); break;
                default:
                    // Handle the case where the element is not of any expected type
                    break;
            }
        }

        /// <summary>
        /// 平移旋转参数改变
        /// </summary>
        /// <param name="v"></param>
        private void change_translation_rotation(string v)
        {
            Translation_rotation translation_rotation = new Translation_rotation("平移旋转修改");
            translation_rotation.StartPosition = FormStartPosition.CenterScreen;
            translation_rotation.ShowDialog();
            if (translation_rotation.DialogResult == DialogResult.OK)
            {
                form_class.translation_rotation = translation_rotation;
                textBox1.AppendText(v + "修改成功！！！X平移" + form_class.translation_rotation.Translation_X.ToString() +
                    ",Y平移" + form_class.translation_rotation.Translation_Y.ToString() +
                    ",旋转" + form_class.translation_rotation.Rotation.ToString() + "°\r\n");
            }
        }

        /// <summary>
        /// 黑帽运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_black_hat_operation(string mode)
        {
            Morphological_operation black_hat_operation = new Morphological_operation("黑帽运算");
            black_hat_operation.StartPosition = FormStartPosition.CenterScreen;
            black_hat_operation.ShowDialog();
            if (black_hat_operation.DialogResult == DialogResult.OK)
            {
                form_class.black_hat_operation = black_hat_operation;
                textBox1.AppendText(mode + "修改成功！！！核形状为为：" + form_class.black_hat_operation.kernel_shape.ToString() +
                    ",宽度为：" + form_class.black_hat_operation.kernel_width.ToString() +
                    ",高度为：" + form_class.black_hat_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 顶帽运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_top_hat_operation(string mode)
        {
            Morphological_operation top_hat_operation = new Morphological_operation("顶帽运算");
            top_hat_operation.StartPosition = FormStartPosition.CenterScreen;
            top_hat_operation.ShowDialog();
            if (top_hat_operation.DialogResult == DialogResult.OK)
            {
                form_class.top_hat_operation = top_hat_operation;
                textBox1.AppendText(mode + "修改成功！！！核形状为为：" + form_class.top_hat_operation.kernel_shape.ToString() +
                    ",宽度为：" + form_class.top_hat_operation.kernel_width.ToString() +
                    ",高度为：" + form_class.top_hat_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 梯度运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_gradient_operation(string mode)
        {
            Morphological_operation gradient_operation = new Morphological_operation("梯度运算");
            gradient_operation.StartPosition = FormStartPosition.CenterScreen;
            gradient_operation.ShowDialog();
            if (gradient_operation.DialogResult == DialogResult.OK)
            {
                form_class.gradient_operation = gradient_operation;
                textBox1.AppendText(mode + "修改成功！！！核形状为为：" + form_class.gradient_operation.kernel_shape.ToString() +
                    ",宽度为：" + form_class.gradient_operation.kernel_width.ToString() +
                    ",高度为：" + form_class.gradient_operation.kernel_height.ToString() + "\r\n");
            }
        }


        /// <summary>
        /// 闭运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_close_operation(string mode)
        {
            Morphological_operation close_operation = new Morphological_operation("闭运算");
            close_operation.StartPosition = FormStartPosition.CenterScreen;
            close_operation.ShowDialog();
            if (close_operation.DialogResult == DialogResult.OK)
            {
                form_class.close_operation = close_operation;
                textBox1.AppendText(mode + "修改成功！！！核形状为为：" + form_class.close_operation.kernel_shape.ToString() +
                    ",宽度为：" + form_class.close_operation.kernel_width.ToString() +
                    ",高度为：" + form_class.close_operation.kernel_height.ToString() + "\r\n");
            }
        }



        /// <summary>
        /// 开运算参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_open_operation(string mode)
        {
            Morphological_operation open_operation = new Morphological_operation("开运算");
            open_operation.StartPosition = FormStartPosition.CenterScreen;
            open_operation.ShowDialog();
            if (open_operation.DialogResult == DialogResult.OK)
            {
                form_class.open_operation = open_operation;
                textBox1.AppendText(mode + "修改成功！！！核形状为为：" + form_class.open_operation.kernel_shape.ToString() +
                    ",宽度为：" + form_class.open_operation.kernel_width.ToString() +
                    ",高度为：" + form_class.open_operation.kernel_height.ToString() + "\r\n");
            }
        }


        /// <summary>
        /// 膨胀参数修改
        /// </summary>
        /// <param name="mode"></param>
        private void change_expansion(string mode)
        {
            Morphological_operation expansion = new Morphological_operation("膨胀");
            expansion.StartPosition = FormStartPosition.CenterScreen;
            expansion.ShowDialog();
            if (expansion.DialogResult == DialogResult.OK)
            {
                form_class.expansion = expansion;
                textBox1.AppendText(mode + "修改成功！！！核形状为为：" + form_class.expansion.kernel_shape.ToString() +
                    ",宽度为：" + form_class.expansion.kernel_width.ToString() +
                    ",高度为：" + form_class.expansion.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 腐蚀参数修改
        /// </summary>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void change_corrosion(string mode)
        {
            Morphological_operation corrosion = new Morphological_operation("腐蚀操作");
            corrosion.StartPosition = FormStartPosition.CenterScreen;
            corrosion.ShowDialog();
            if (corrosion.DialogResult == DialogResult.OK)
            {
                form_class.corrosion = corrosion;
                textBox1.AppendText(mode + "修改成功！！！核形状为为：" + form_class.corrosion.kernel_shape.ToString() +
                    ",宽度为：" + form_class.corrosion.kernel_width.ToString() +
                    ",高度为：" + form_class.corrosion.kernel_height.ToString() + "\r\n");
            }
        }


        /// <summary>
        /// Otsu算法参数改变
        /// </summary>
        /// <param name=""></param>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void change_Otsu(string mode)
        {
            Otsu Otsu = new Otsu(mode);
            Otsu.StartPosition = FormStartPosition.CenterScreen;
            Otsu.ShowDialog();
            if (Otsu.DialogResult == DialogResult.OK)
            {
                form_class.otsu = Otsu;
                textBox1.AppendText(mode + "修改成功！！！模式为：" + form_class.otsu.Binarization_mode.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 自适应阈值参数改变
        /// </summary>
        /// <param name="mode"></param>
        private void change_adaptivethreshold(string mode)
        {
            Adaptive_Threshold adaptivethreshold = new Adaptive_Threshold();
            adaptivethreshold.StartPosition = FormStartPosition.CenterScreen;
            adaptivethreshold.ShowDialog();
            if (adaptivethreshold.DialogResult == DialogResult.OK)
            {
                form_class.adaptive_Threshold = adaptivethreshold;
                textBox1.AppendText(mode + "更改成功！！！自适应阈值算法为：" + form_class.adaptive_Threshold.Adaptive_Types.ToString() +
                    ",模式为：" + form_class.adaptive_Threshold.Threshold_Types.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 二值化参数修改
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void change_binarization(string mode)
        {
            Binarization binarization = new Binarization("二值化参数修改");
            binarization.StartPosition = FormStartPosition.CenterScreen;
            binarization.ShowDialog();
            if (binarization.DialogResult == DialogResult.OK)
            {
                form_class.binarization = binarization;
                textBox1.AppendText(mode + "修改成功！！！阈值为：" + form_class.binarization.Threshold.ToString() +
                    ",模式为：" + form_class.binarization.Binarization_mode.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 双边滤波参数修改
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void change_bilateral_filter(string mode)
        {
            Bilateral_Filter bilateral_Filter = new Bilateral_Filter();
            bilateral_Filter.StartPosition = FormStartPosition.CenterScreen;
            bilateral_Filter.ShowDialog();
            if (bilateral_Filter.DialogResult == DialogResult.OK)
            {
                form_class.bilateral_filter = bilateral_Filter;
                textBox1.AppendText(mode + "修改成功！！！sigmaColor为：" + form_class.bilateral_filter.SigmaColor.ToString() +
                    ",SigmaSpace：" + form_class.bilateral_filter.SigmaSpace.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 中值滤波参数更改
        /// </summary>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void change_median_blur(string mode)
        {
            Filtering median_Blur = new Filtering(Filtering.模式.奇数, new Filtering.Scope { min = 1, max = 50 }, mode);
            median_Blur.StartPosition = FormStartPosition.CenterScreen;
            median_Blur.ShowDialog();
            if (median_Blur.DialogResult == DialogResult.OK)
            {
                form_class.median_Blur = median_Blur;
                textBox1.AppendText(mode + "修改成功！！！核大小为：" + form_class.median_Blur.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 高斯滤波参数更改
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void change_gaussian_blur(string mode)
        {
            Filtering gaussian_Blur = new Filtering(Filtering.模式.奇数, new Filtering.Scope { min = 1, max = 50 }, mode);
            gaussian_Blur.StartPosition = FormStartPosition.CenterScreen;
            gaussian_Blur.ShowDialog();
            if (gaussian_Blur.DialogResult == DialogResult.OK)
            {
                form_class.gaussian_Blur = gaussian_Blur;
                textBox1.AppendText("高斯滤波修改成功！！！核大小为：" + form_class.gaussian_Blur.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        ///方框滤波参数更改
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void change_box_filtering(string mode)
        {
            Filtering filtering = new Filtering(Filtering.模式.无, new Filtering.Scope { min = 1, max = 50 }, mode);
            filtering.StartPosition = FormStartPosition.CenterScreen;
            filtering.ShowDialog();
            if (filtering.DialogResult == DialogResult.OK)
            {
                form_class.mean_filter = filtering;
                textBox1.AppendText("均值滤波修改成功！！！核大小为：" + form_class.mean_filter.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 改变颜色空间参数更改
        /// </summary>
        private void change_color()
        {
            colorTo colorto = new colorTo();
            colorto.StartPosition = FormStartPosition.CenterParent;
            colorto.ShowDialog();
            if (colorto.DialogResult == DialogResult.OK)
            {
                form_class.colorTo = colorto;
                textBox1.AppendText("颜色空间变化修改成功！！！图片处理为：" + form_class.colorTo.ColorCode.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 均值滤波参数更改
        /// </summary>
        void change_Mean_filtering(string mode)
        {
            Filtering filtering = new Filtering(Filtering.模式.无, new Filtering.Scope { min = 1, max = 50 }, mode);
            filtering.StartPosition = FormStartPosition.CenterScreen;
            filtering.ShowDialog();
            if (filtering.DialogResult == DialogResult.OK)
            {
                form_class.mean_filter = filtering;
                textBox1.AppendText("均值滤波修改成功！！！核大小为：" + form_class.mean_filter.Value.ToString() + "\r\n");
            }

        }
    }
}
