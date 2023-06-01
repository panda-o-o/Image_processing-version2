using Image_processing.Class;
using Image_processing.form;
using Image_processing.form.Yolov5;
using Image_processing.form.��ֵ��;
using Image_processing.form.ƽ����ת;
using Image_processing.form.��̬ѧ����;
using Image_processing.form.ģ��ƥ��;
using Image_processing.form.�˲�;
using Image_processing.form.����ʶ��;
using OpenCvSharp;
using OpenCvSharp.Dnn;
using Sunny.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Image_processing
{
    public partial class Main_form
    {
        /// <summary>
        /// ��״ͼ��ӽڵ�
        /// </summary>
        private void tree_add()
        {
            TreeNode[] nodes =
            {
                new TreeNode("��ɫ�ռ�", new[]
                {
                    new TreeNode("��ɫ�ռ�仯") { ToolTipText = "��ͼ���һ����ɫ�ռ�ת��Ϊ��һ����ɫ�ռ�" }
                }),
                new TreeNode("ͼ���˲�", new[]
                {
                    new TreeNode("��ֵ�˲�") { ToolTipText = "ȥ��������ϸ��,ƽ��ͼ��" },
                    new TreeNode("�����˲�") { ToolTipText = "ȥ��������ϸ��,ƽ��ͼ��" },
                    new TreeNode("��˹�˲�") { ToolTipText = "ƽ��ͼ��ȥ������,����ͼ�������ṹ��Ϣ�ͱ�Ե��Ϣ" },
                    new TreeNode("��ֵ�˲�") { ToolTipText = "ȥ��������ϸ��,ƽ��ͼ�񲢱�����Ե��Ϣ" },
                    new TreeNode("˫���˲�") { ToolTipText = "ƽ��ͼ�񲢱�����Ե��Ϣ��ϸ����Ϣ" }
                }),
                new TreeNode("ͼ��ת", new[]
                {
                    new TreeNode("���·�ת") { ToolTipText = "��ͼ�����·�ת,�����ھ���ͼ����������ʱ�ĵ�������" },
                    new TreeNode("���ҷ�ת") { ToolTipText = "��ͼ�����ҷ�ת,�����ھ���ͼ����������ʱ�ĵ�������" },
                    new TreeNode("ȫ��ת") { ToolTipText = "��ͼ���������ҷ�ת,�����ھ���ͼ����������ʱ�ĵ�������" }
                }),
                new TreeNode("ͼ����ֵ", new[]
                {
                    new TreeNode("��ֵ��") { ToolTipText = "��ͼ�������ֵ�ֳɺڰ�������,�����������⡢����ʶ�������" },
                    new TreeNode("����Ӧ��ֵ") { ToolTipText = "����ͼ��ֲ������ڵ�����ֵ��̬������ֵ,�����ڴ�����ղ�����ͼ��" },
                    new TreeNode("Otsu�㷨") { ToolTipText = "����ͼ��Ҷ�ֱ��ͼ����Ӧ������ֵ,�����ڷָ�Ŀ��ͱ���" }
                }),
                new TreeNode("��̬ѧ����", new[]
                {
                    new TreeNode("��ʴ") { ToolTipText = "��ͼ���е�ǰ��������С,������ȥ��С������߷�����������" },
                    new TreeNode("����") { ToolTipText = "��ͼ���е�ǰ����������,���������С�׶����ߺϲ���������" },
                    new TreeNode("������") { ToolTipText = "�Ƚ��и�ʴ����,�ٽ������Ͳ���,������ȥ��С�����ë��" },
                    new TreeNode("������") { ToolTipText = "�Ƚ������Ͳ���,�ٽ��и�ʴ����,���С�׶�" },
                    new TreeNode("�ݶ�����") { ToolTipText = "�����ͺ��ͼ���ȥ��ʴ���ͼ��,�õ�ǰ������ı�Ե����" },
                    new TreeNode("��ñ����") { ToolTipText = "��ԭͼ���ȥ��������ͼ��,�õ�С����" },
                    new TreeNode("��ñ����") { ToolTipText = "����������ͼ���ȥԭͼ��,�õ�С�׶�" }
                 }),
                new TreeNode("ƽ����ת",new []
                {
                    new TreeNode("ƽ����ת"){ ToolTipText = "��ͼ�������תƽ��" }
                }),
                new TreeNode("ģ��ƥ��",new []
                {
                    new TreeNode("ģ��ƥ��"){ ToolTipText = "ѡ��һ��ģ�壬�ҳ�ƥ��λ��" }
                }),
                new TreeNode("����ƥ��",new []
                {
                    new TreeNode("����ƥ��"){ ToolTipText = "ѡ��һ��ģ�壬��������ƥ��" }
                }),
                new TreeNode("Yolov5",new []
                {
                    new TreeNode("Yolov5"){ ToolTipText = "ѡ��һ��Yolov5.onnxģ�ͣ���������ʶ��" },
                    new TreeNode("Yolov5�������"){ ToolTipText = "����Yolov5ʶ��֮�󣬻���ͼ�񷽿�" }
                })
            };

            TreeNode node = new TreeNode("OpenCVsharp", nodes);
            treeView1.Nodes.Add(node);
        }

        /// <summary>
        /// ѡ���Ӧ�ķ���
        /// </summary>
        /// <param name="e"></param>
        public void switch_Method(TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count == 0) // �ж��Ƿ�Ϊ�ӽڵ�
            {
                switch (e.Node.Parent.Text)
                {
                    case "��ɫ�ռ�":
                        switch (e.Node.Text)
                        {
                            case "��ɫ�ռ�仯": color_add("��ɫ�ռ�仯"); break;
                            default:
                                break;
                        }
                        break;

                    case "ͼ���˲�":
                        switch (e.Node.Text)
                        {
                            case "��ֵ�˲�": Mean_Filter("��ֵ�˲�"); break;
                            case "�����˲�": Box_Filter("�����˲�"); break;
                            case "��˹�˲�": Gaussian_Blur("��˹�˲�"); break;
                            case "��ֵ�˲�": Median_Blur("��ֵ�˲�"); break;
                            case "˫���˲�": Bilateral_Filter("˫���˲�"); break;
                            default:
                                break;
                        }
                        break;

                    case "ͼ��ת":
                        switch (e.Node.Text)
                        {
                            case "���·�ת": X_axis_flip("���·�ת"); break;
                            case "���ҷ�ת": Y_axis_flip("���ҷ�ת"); break;
                            case "ȫ��ת": XY_axis_flip("�������Ҷ���ת"); break;
                        }
                        break;

                    case "ͼ����ֵ":
                        switch (e.Node.Text)
                        {
                            case "��ֵ��": Binarizate("��ֵ��"); break;
                            case "����Ӧ��ֵ": AdaptiveThreshold("����Ӧ��ֵ"); break;
                            case "Otsu�㷨": Otsu("Otsu�㷨"); break;
                        }
                        break;

                    case "��̬ѧ����":
                        switch (e.Node.Text)
                        {
                            case ("��ʴ"): Corrosion("��ʴ"); break;
                            case ("����"): Expansion("����"); break;
                            case ("������"): Open_operation("������"); break;
                            case ("������"): Close_operation("������"); break;
                            case ("�ݶ�����"): Gradient_operation("�ݶ�����"); break;
                            case ("��ñ����"): Top_hat_operation("��ñ����"); break;
                            case ("��ñ����"): Black_hat_operation("��ñ����"); break;
                        }
                        break;

                    case "ƽ����ת":
                        switch (e.Node.Text)
                        {
                            case ("ƽ����ת"): Translation_rotation("ƽ����ת"); break;
                        }
                        break;
                    case "ģ��ƥ��":
                        switch (e.Node.Text)
                        {
                            case ("ģ��ƥ��"): Template_matching("ģ��ƥ��"); break;
                        }
                        break;
                    case "����ƥ��":
                        switch (e.Node.Text)
                        {
                            case ("����ƥ��"): Feature_matching("����ƥ��"); break;
                        }
                        break;
                    case "Yolov5":
                        switch (e.Node.Text)
                        {
                            case ("Yolov5"): Yolov5_matching("Yolov5"); break;
                            case ("Yolov5�������"): Yolov5_Draw("Yolov5�������"); break;
                        }
                        break;
                }
            }
        }



        #region Yolov5
        private void Yolov5_Draw(string v)
        {
            if (!listBox1.Items.Contains("Yolov5"))
            {
                MessageBox.Show("�������Yolov5����Ӹò���");
                return;
            }
            var str = public_Environment.Yolov5_class.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            public_Environment.Yolov5_list_class.AddRange(str);
            Data_dic data = new();
            data_List.Data_list.Add(data);
            listBox1.Items.Add(v);
            del_process Yolov5_Box_drawing = OpenCV.Yolov5_Box_drawing;
            link.AddDelegate(Yolov5_Box_drawing);
            textBox1.AppendText("Yolov5���߿����");
        }

        private void Yolov5_matching(string v)
        {
            Yolov5 yolov5 = new Yolov5();
            yolov5.StartPosition = FormStartPosition.CenterScreen;
            yolov5.ShowDialog();
            if (yolov5.DialogResult == DialogResult.OK)
            {
                var onnx_path = yolov5.Onnx_path;
                var Net = CvDnn.ReadNetFromOnnx(onnx_path);
                Net.SetPreferableBackend(Backend.DEFAULT);
                Net.SetPreferableTarget(Target.CPU);
                Data_dic data = new()
                {
                    flo_dic = new Dictionary<string, float>()
                    {
                        { "Input_width" , yolov5.Input_width},
                        { "Input_height" ,yolov5.Input_height },
                        { "Score_threshold" ,yolov5.Score_threshold },
                        { "Nms_threshold" ,yolov5.Nms_threshold },
                        { "Confidence_threshold",yolov5.Confidence_threshold }
                    },
                    str_dic = new Dictionary<string, string>()
                    {
                        {"class_path",yolov5.Class_path },
                        {"onnx_path",yolov5.Onnx_path }
                    },
                    net_dic = new Dictionary<string, Net>()
                    {
                        {"Net",Net }
                    }
                };
                public_Environment.Yolov5_class = yolov5.Class_list;
                data_List.Data_list.Add(data);

                listBox1.Items.Add(v);
                del_process yolov5_Detect = OpenCV.Yolov5_Detect;
                link.AddDelegate(yolov5_Detect);
                textBox1.AppendText(v + "��ӳɹ����������÷���ֵΪ��" + yolov5.Score_threshold +
                    "�Ǽ���ֵ������ֵ��" + yolov5.Nms_threshold + "�����Ŷ���ֵΪ��" + yolov5.Confidence_threshold + "\r\n");
            }
        }
        #endregion


        #region ����ƥ��
        /// <summary>
        /// ����ƥ��
        /// </summary>
        /// <param name="v"></param>
        private void Feature_matching(string v)
        {
            Feature feature_Matching = new Feature();
            feature_Matching.StartPosition = FormStartPosition.CenterScreen;
            feature_Matching.ShowDialog();
            if (feature_Matching.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    dou_dic = new Dictionary<string, double>() { { "Threshold", 1 - feature_Matching.Threshold } },
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

                textBox1.AppendText(v + "��ӳɹ�������ģʽΪ��" + feature_Matching.Mode +
                    "ģ��Ϊ��" + feature_Matching.Pic_name + "����ֵΪ��" + feature_Matching.Threshold + "\r\n");
            }
        }

        #endregion

        #region ģ��ƥ��
        /// <summary>
        /// ģ��ƥ��
        /// </summary>
        /// <param name="v"></param>
        private void Template_matching(string v)
        {
            Template_Matching template_Matching = new Template_Matching("ģ��ƥ��");
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

                textBox1.AppendText(v + "��ӳɹ�������ģʽΪ��" + template_Matching.uiComboBox1.SelectedText +
                    "ģ��Ϊ��" + template_Matching.Pic_name + "�����Ŷ�Ϊ��" + template_Matching.Threshold.ToString() + "\r\n");
            }
        }
        #endregion

        #region ƽ����ת
        /// <summary>
        /// ƽ����ת
        /// </summary>
        /// <param name="v"></param>
        private void Translation_rotation(string v)
        {
            Translation_rotation translation_rotation = new Translation_rotation("ƽ����ת");
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

                textBox1.AppendText(v + "��ӳɹ�������Xƽ��" + translation_rotation.Translation_X.ToString() +
                    ",Yƽ��" + translation_rotation.Translation_Y.ToString() +
                    ",��ת" + translation_rotation.Rotation.ToString() + "��\r\n");
            }
        }
        #endregion

        #region ��̬ѧ����

        /// <summary>
        /// ��ñ����
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Black_hat_operation(string mode)
        {
            Morphological_operation black_hat_operation = new Morphological_operation("��ñ����");
            black_hat_operation.StartPosition = FormStartPosition.CenterScreen;
            black_hat_operation.ShowDialog();
            if (black_hat_operation.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", black_hat_operation.Kernel }
                    },
                    int_dic = new Dictionary<string, int>()
                    {
                        { "kernel_shape",(int)black_hat_operation.kernel_shape},
                        { "kernel_width",black_hat_operation.kernel_width},
                        { "kernel_height",(int)black_hat_operation.kernel_height},
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Black_hat_operation);
                textBox1.AppendText(mode + "��ӳɹ�����������״ΪΪ��" + black_hat_operation.kernel_shape.ToString() +
                    ",���Ϊ��" + black_hat_operation.kernel_width.ToString() +
                    ",�߶�Ϊ��" + black_hat_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// ��ñ����
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Top_hat_operation(string mode)
        {
            Morphological_operation top_hat_operation = new Morphological_operation("��ñ����");
            top_hat_operation.StartPosition = FormStartPosition.CenterScreen;
            top_hat_operation.ShowDialog();
            if (top_hat_operation.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", top_hat_operation.Kernel }
                    },
                    int_dic = new Dictionary<string, int>()
                    {
                        { "kernel_shape",(int)top_hat_operation.kernel_shape},
                        { "kernel_width",top_hat_operation.kernel_width},
                        { "kernel_height",(int)top_hat_operation.kernel_height},
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Top_hat_operation);
                textBox1.AppendText(mode + "��ӳɹ�����������״ΪΪ��" + top_hat_operation.kernel_shape.ToString() +
                    ",���Ϊ��" + top_hat_operation.kernel_width.ToString() +
                    ",�߶�Ϊ��" + top_hat_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// �ݶ�����
        /// </summary>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Gradient_operation(string mode)
        {
            Morphological_operation gradient_operation = new Morphological_operation("�ݶ�����");
            gradient_operation.StartPosition = FormStartPosition.CenterScreen;
            gradient_operation.ShowDialog();
            if (gradient_operation.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", gradient_operation.Kernel }
                    },
                    int_dic = new Dictionary<string, int>()
                    {
                        { "kernel_shape",(int)gradient_operation.kernel_shape},
                        { "kernel_width",gradient_operation.kernel_width},
                        { "kernel_height",(int)gradient_operation.kernel_height},
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Gradient_operation);
                textBox1.AppendText(mode + "��ӳɹ�����������״ΪΪ��" + gradient_operation.kernel_shape.ToString() +
                    ",���Ϊ��" + gradient_operation.kernel_width.ToString() +
                    ",�߶�Ϊ��" + gradient_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Close_operation(string mode)
        {
            Morphological_operation close_operation = new Morphological_operation("������");
            close_operation.StartPosition = FormStartPosition.CenterScreen;
            close_operation.ShowDialog();
            if (close_operation.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", close_operation.Kernel }
                    },
                    int_dic = new Dictionary<string, int>()
                    {
                        { "kernel_shape",(int)close_operation.kernel_shape},
                        { "kernel_width",close_operation.kernel_width},
                        { "kernel_height",(int)close_operation.kernel_height},
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Close_operation);
                textBox1.AppendText(mode + "��ӳɹ�����������״ΪΪ��" + close_operation.kernel_shape.ToString() +
                    ",���Ϊ��" + close_operation.kernel_width.ToString() +
                    ",�߶�Ϊ��" + close_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Open_operation(string mode)
        {
            Morphological_operation open_operation = new Morphological_operation("������");
            open_operation.StartPosition = FormStartPosition.CenterScreen;
            open_operation.ShowDialog();
            if (open_operation.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", open_operation.Kernel }
                    },
                    int_dic = new Dictionary<string, int>()
                    {
                        { "kernel_shape",(int)open_operation.kernel_shape},
                        { "kernel_width",open_operation.kernel_width},
                        { "kernel_height",(int)open_operation.kernel_height},
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Open_operation);
                textBox1.AppendText(mode + "��ӳɹ�����������״ΪΪ��" + open_operation.kernel_shape.ToString() +
                    ",���Ϊ��" + open_operation.kernel_width.ToString() +
                    ",�߶�Ϊ��" + open_operation.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Expansion(string mode)
        {
            Morphological_operation expansion = new Morphological_operation("����");
            expansion.StartPosition = FormStartPosition.CenterScreen;
            expansion.ShowDialog();
            if (expansion.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", expansion.Kernel }
                    },
                    int_dic = new Dictionary<string, int>()
                    {
                        { "kernel_shape",(int)expansion.kernel_shape},
                        { "kernel_width",expansion.kernel_width},
                        { "kernel_height",(int)expansion.kernel_height},
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Expansion);
                textBox1.AppendText(mode + "��ӳɹ�����������״ΪΪ��" + expansion.kernel_shape.ToString() +
                    ",���Ϊ��" + expansion.kernel_width.ToString() +
                    ",�߶�Ϊ��" + expansion.kernel_height.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// ��ʴ����
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Corrosion(string mode)
        {
            Morphological_operation corrosion = new Morphological_operation("��ʴ����");
            corrosion.StartPosition = FormStartPosition.CenterScreen;
            corrosion.ShowDialog();
            if (corrosion.DialogResult == DialogResult.OK)
            {
                Data_dic data = new Data_dic
                {
                    mat_dic = new Dictionary<string, Mat>()
                    {
                        { "Kernel", corrosion.Kernel }
                    },
                    int_dic = new Dictionary<string, int>()
                    {
                        { "kernel_shape",(int)corrosion.kernel_shape},
                        { "kernel_width",corrosion.kernel_width},
                        { "kernel_height",(int)corrosion.kernel_height},
                    }
                };
                data_List.Data_list.Add(data);

                listBox1.Items.Add(mode);
                link.AddDelegate(OpenCV.Corrosion);
                textBox1.AppendText(mode + "��ӳɹ�����������״ΪΪ��" + corrosion.kernel_shape.ToString() +
                    ",���Ϊ��" + corrosion.kernel_width.ToString() +
                    ",�߶�Ϊ��" + corrosion.kernel_height.ToString() + "\r\n");
            }
        }

        #endregion ��̬ѧ����

        #region ͼ����ֵ����

        /// <summary>
        /// OTsu�㷨
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
                textBox1.AppendText(mode + "��ӳɹ�������ģʽΪ��" + otsu.Binarization_mode.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// ����Ӧ��ֵ
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
                textBox1.AppendText(mode + "��ӳɹ�����������Ӧ��ֵ�㷨Ϊ��" + adaptivethreshold.Adaptive_Types.ToString() +
                    ",ģʽΪ��" + adaptivethreshold.Threshold_Types.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// ��ֵ��
        /// </summary>
        /// <param name="mode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Binarizate(string mode)
        {
            Binarization binarization = new Binarization("��ֵ��");
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
                textBox1.AppendText(mode + "��ӳɹ���������ֵΪ��" + binarization.Threshold.ToString() +
                    ",ģʽΪ��" + binarization.Binarization_mode.ToString() + "\r\n");
            }
        }

        #endregion ͼ����ֵ����

        #region ͼ��ת

        /// <summary>
        /// �������Ҷ���ת
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
        /// ���ҷ�ת
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
        /// ���·�ת
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

        #endregion ͼ��ת

        #region �˲�

        /// <summary>
        /// ˫���˲�
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
                textBox1.AppendText(mode + "��ӳɹ�������sigmaColorΪ��" + bilateral_Filter.SigmaColor.ToString() +
                    ",SigmaSpace��" + bilateral_Filter.SigmaSpace.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// ��ֵ�˲�
        /// </summary>
        /// <param name="v"></param>
        private void Median_Blur(string mode)
        {
            Filtering median_Blur = new Filtering(Filtering.ģʽ.����, new Filtering.Scope { min = 1, max = 50 }, mode);
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
                textBox1.AppendText(mode + "��ӳɹ��������˴�СΪ��" + median_Blur.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// ��ֵ�˲�
        /// </summary>
        private void Mean_Filter(string mode)
        {
            Filtering mean_filter = new Filtering(Filtering.ģʽ.����, new Filtering.Scope { min = 1, max = 50 }, mode);
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
                textBox1.AppendText(mode + "��ӳɹ��������˴�СΪ��" + mean_filter.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// �����˲�
        /// </summary>
        /// <param name="mode"></param>
        private void Box_Filter(string mode)
        {
            Filtering box_filter = new Filtering(Filtering.ģʽ.��, new Filtering.Scope { min = 1, max = 50 }, mode);
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
                textBox1.AppendText(mode + "��ӳɹ��������˴�СΪ��" + box_filter.Value.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// ��˹�˲�
        /// </summary>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Gaussian_Blur(string mode)
        {
            Filtering gaussian_Blur = new Filtering(Filtering.ģʽ.����, new Filtering.Scope { min = 1, max = 50 }, mode);
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
                textBox1.AppendText(mode + "��ӳɹ��������˴�СΪ��" + gaussian_Blur.Value.ToString() + "\r\n");
            }
        }

        #endregion �˲�

        #region ��ɫ�ռ�仯

        /// <summary>
        /// ��ɫ�任
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

                textBox1.AppendText("��ɫ�ռ�仯��ӳɹ�������ͼƬ����Ϊ��" + colorto.ColorCode.ToString() + "\r\n");
            }
        }

        #endregion ��ɫ�ռ�仯
    }
}