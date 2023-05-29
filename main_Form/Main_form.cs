using AutoWindowsSize;
using Image_processing.Class;
using Image_processing.form.����ͷ;
using Image_processing.main_Form;
using Newtonsoft.Json;
using OpenCvSharp;
using Sunny.UI;
using System.Diagnostics;
using System.Windows.Forms;
using Point = OpenCvSharp.Point;

namespace Image_processing
{
    public partial class Main_form : UIForm
    {
        private new AutoAdaptWindowsSize? AutoSize;
        public linked_list link;
        public Mat img;
        public Mat mask;
        public static Mat? mat;//ͼƬ������
        public static Data_List? data_List;
        private bool camera_open = false;
        private VideoCapture? VideoCapture;
        private PictureBox pictureBox = new();//���ڴ���ͼƬ���ţ��Լ��Ŵ�
        private readonly Dictionary<string, del_process> Delegation_Deserialization;
        private readonly Dictionary<del_process, string> Delegation_Serialization;
        public static Public_Environment? public_Environment;

        #region �������

        public Main_form()
        {
            InitializeComponent();
            AutoSize = new AutoAdaptWindowsSize(this);
            link = new linked_list();//����ί������
            img = new Mat();
            mask = new Mat();
            mat = new Mat();
            data_List = new Data_List();
            public_Environment = new Public_Environment();
            pictureBox = pictureBox_small;
            Delegation_Deserialization = new Dictionary<string, del_process>()
            {
                {"colorto", OpenCV.colorto},
                {"medianBlur", OpenCV.medianBlur},
                {"boxFilter", OpenCV.boxFilter},
                {"Gaussian_Blur", OpenCV.Gaussian_Blur},
                {"Median_Blur", OpenCV.Median_Blur},
                {"Bilateral_Filter", OpenCV.Bilateral_Filter},
                {"X_Flip", OpenCV.X_Flip},
                {"Y_Flip", OpenCV.Y_Flip},
                {"XY_Flip", OpenCV.XY_Flip},
                {"ToBinary", OpenCV.ToBinary},
                {"AdaptiveThreshold", OpenCV.AdaptiveThreshold},
                {"Otsu", OpenCV.Otsu},
                {"Corrosion", OpenCV.Corrosion},
                {"Expansion", OpenCV.Expansion},
                {"Open_operation", OpenCV.Open_operation},
                {"Close_operation", OpenCV.Close_operation},
                {"Gradient_operation", OpenCV.Gradient_operation},
                {"Top_hat_operation", OpenCV.Top_hat_operation},
                {"Black_hat_operation", OpenCV.Black_hat_operation},
                {"Translation_rotation", OpenCV.Translation_rotation},
                {"Template_Match", OpenCV.Template_Match},
                {"Feature_Matching", OpenCV.Feature_Matching},
                { "Yolov5",OpenCV.Yolov5_Detect },
                { "Yolov5�������",OpenCV.Yolov5_Box_drawing }
            };
            Delegation_Serialization = Delegation_Deserialization.ToDictionary(pair => pair.Value, pair => pair.Key);
            this.Icon = Resource1.�����; // ������Դ�ļ��е�ͼ��
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void Main_form_SizeChanged(object sender, EventArgs e)
        {
            if (AutoSize != null)
            {
                AutoSize.FormSizeChanged();
            }
        }

        private void Main_form_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen != null)
            {
                // ���ô����λ��Ϊ��Ļ����
                this.Location = new System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                                       (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            }
            tree_add();//��״ͼ����
        }

        #endregion �������

        #region ������

        private void open_pic_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i] != this)
                {
                    Application.OpenForms[i]?.Close();
                }
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            //�򿪵��ļ�ѡ��Ի����ϵı���
            openFileDialog.Title = "��ѡ���ļ�";
            //�����ļ�����
            openFileDialog.Filter = "jpgͼƬ|*.JPG|gifͼƬ|*.GIF|pngͼƬ|*.PNG|jpegͼƬ|*.JPEG|BMPͼƬ|*.BMP|MP4�ļ�|*.mp4|�����ļ�|*.*";
            //����Ĭ���ļ�������ʾ˳��
            openFileDialog.FilterIndex = 1;
            //����Ի����Ƿ�����ϴδ򿪵�Ŀ¼
            openFileDialog.RestoreDirectory = false;
            //�����Ƿ������ѡ
            openFileDialog.Multiselect = false;
            //Ĭ�ϴ�·�� 
            //openFileDialog.InitialDirectory = @"F:\user\Pictures\Saved Pictures";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                GC.Collect();
                camera_open = false;
                if (VideoCapture != null)
                {
                    VideoCapture.Dispose();
                    VideoCapture = null;
                }
                if (img != null)
                {
                    img.Dispose();
                }
                string path = openFileDialog.FileName;
                string ext = Path.GetExtension(path);
                if (ext == ".mp4" || ext == ".avi" || ext == ".mov")
                {
                    VideoCapture = new VideoCapture(path);
                    camera_open = true;
                    if (timer1.Enabled)
                    { timer1.Stop(); }
                    if (timer2.Enabled)
                    { timer2.Stop(); }
                    timer1.Interval = 1000 / 30;
                    timer2.Interval = 1000 / 1;
                    timer1.Start();
                }
                else
                {
                    img = new Mat(path, ImreadModes.Color);
                    if (img.Empty())
                    {
                        MessageBox.Show("��ͼƬ�ļ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    pictureBox2.Image = OpenCV.GetMat(img);
                }
            }
            return;
        }

        private void save_pic_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveImageDialog = new SaveFileDialog();
            saveImageDialog.Title = "ͼƬ����";
            saveImageDialog.Filter = "jpgͼƬ|*.jpg|gifͼƬ|*.gif|pngͼƬ|*.png|jpegͼƬ|*.jpeg|BMPͼƬ|*.bmp";//�ļ����͹���,ֻ��ѡ��ͼƬ������
            saveImageDialog.FilterIndex = 1;//����Ĭ���ļ�������ʾ˳��
            saveImageDialog.FileName = "ͼƬ����"; //����Ĭ���ļ���,��Ϊ��
            saveImageDialog.RestoreDirectory = true; //OpenFileDialog��SaveFileDialog����RestoreDirectory����,�������Ĭ����false,
                                                     //��һ���ļ���,��ôϵͳĬ��Ŀ¼�ͻ�ָ��ղŴ򿪵��ļ��������Ϊtrue�ͻ�ʹ��ϵͳĬ��Ŀ¼
            saveImageDialog.InitialDirectory = @"F:\Pictures\Saved Pictures";
            if (saveImageDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveImageDialog.FileName.ToString();
                if (fileName != "" && fileName != null)
                {
                    string fileExtName = fileName.Substring(fileName.LastIndexOf(".") + 1).ToString();
                    System.Drawing.Imaging.ImageFormat? imgformat = null;
                    if (fileExtName != "")
                    {
                        switch (fileExtName)
                        {
                            #region ͼƬ����

                            case "jpg":
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;

                            case "png":
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;

                            case "gif":
                                imgformat = System.Drawing.Imaging.ImageFormat.Gif;
                                break;

                            case "bmp":
                                imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;

                            default:
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;

                                #endregion ͼƬ����
                        }
                        MessageBox.Show("����·����" + fileName, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pictureBox_small.Image.Save(fileName, imgformat);
                    }
                }
            }
        }

        private void open_Configuration_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //�򿪵��ļ�ѡ��Ի����ϵı���
            openFileDialog.Title = "��ѡ���ļ�";
            //�����ļ�����
            openFileDialog.Filter = "Json�ļ�|*.json";
            //����Ĭ���ļ�������ʾ˳��
            openFileDialog.FilterIndex = 1;
            //����Ի����Ƿ�����ϴδ򿪵�Ŀ¼
            openFileDialog.RestoreDirectory = false;
            //�����Ƿ������ѡ
            openFileDialog.Multiselect = false;
            //Ĭ�ϴ�·��
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                using (var steamRead = new StreamReader(path))
                {
                    var settings = new JsonSerializerSettings();
                    settings.Converters.Add(new Data_ListJsonConverter());
                    string? str = steamRead.ReadLine();
                    data_List = JsonConvert.DeserializeObject<Data_List>(str, settings);
                    foreach (var item in data_List.Combobox_list)//����listbox
                    {
                        listBox1.Items.Add(item.ToString());
                    }

                    foreach (var item in data_List.Serialization)//����ί��
                    {
                        link.AddDelegate(Delegation_Deserialization[item]);
                    }
                }
            }
        }

        private void save_Configuration_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveImageDialog = new SaveFileDialog();
            saveImageDialog.Title = "���ñ���";
            saveImageDialog.Filter = "Json�ļ�|*.json";//�ļ����͹���,ֻ��ѡ��ͼƬ������
            saveImageDialog.FilterIndex = 1;//����Ĭ���ļ�������ʾ˳��
            saveImageDialog.FileName = "���ñ���"; //����Ĭ���ļ���,��Ϊ��
            saveImageDialog.RestoreDirectory = true; //OpenFileDialog��SaveFileDialog����RestoreDirectory����,�������Ĭ����false,
                                                     //��һ���ļ���,��ôϵͳĬ��Ŀ¼�ͻ�ָ��ղŴ򿪵��ļ��������Ϊtrue�ͻ�ʹ��ϵͳĬ��Ŀ¼
            if (saveImageDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveImageDialog.FileName;
                // ����һ��JsonSerializerSettings�������CustomJsonConverter
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new Data_ListJsonConverter());

                foreach (var item in listBox1.Items)//��listbox������ַ��ܽ��б���
                {
                    data_List.Combobox_list.Add(item.ToString());
                }
                foreach (del_process del in link.List?.GetInvocationList() ?? Enumerable.Empty<Delegate>())//��ί�н��б���
                {
                    data_List.Serialization.Add(Delegation_Serialization[del]);
                }

                var json = JsonConvert.SerializeObject(data_List, settings);

                using (var steamwrite = new StreamWriter(fileName))
                {
                    steamwrite.WriteLine(json);
                }
            }
        }

        private void capture_Click(object sender, EventArgs e)
        // �򿪡��ر�����ͷ��������ֹͣ��ʱ���Զ�ȡ��Ƶ�������д���
        {
            if (camera_open == false)
            // ���δ�����
            {
                try
                {
                    Camera camera = new Camera();
                    // �����������
                    camera.StartPosition = FormStartPosition.CenterScreen;
                    // ����������ڵ���ʼλ��Ϊ��Ļ����
                    camera.ShowDialog();
                    // ��ʾ�������
                    if (camera.DialogResult == DialogResult.OK)
                    // ����û�����ˡ�ȷ������ť
                    {
                        VideoCapture = new VideoCapture(camera.Cameras_Id);
                        // ���� VideoCapture �������ڶ�ȡ��Ƶ��
                        timer1.Interval = 1000 / 30;
                        // ���� timer1 �ļ��Ϊ 1/30 �룬�� 33 ����
                        timer1.Start();
                        // ������ʱ�� timer1����ʼ����Ƶ���ж�ȡͼ�񲢽��д���
                        timer2.Interval = 1000 / camera.Camers_Frame_rate;
                        // ���� timer2 �ļ��Ϊ�����֡��
                        capture.Text = "�ر�����ͷ";
                        // ����ť���ı�����Ϊ���ر�����ͷ��
                        camera_open = true;
                        // ������򿪱�־����Ϊ true
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("����ͷ��ʧ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // ��ʾ������ʾ��
                }
            }
            else
            // ����Ѵ����
            {
                VideoCapture.Dispose();
                VideoCapture = null;
                // �ͷ���Ƶ����Դ
                if (timer1.Enabled)
                { timer1.Stop(); }
                // ֹͣ��ʱ�� timer1
                if (timer2.Enabled)
                { timer2.Stop(); }
                // ֹͣ��ʱ�� timer2
                capture.Text = "������ͷ";
                // ����ť���ı�����Ϊ��������ͷ��
                camera_open = false;
                // ������򿪱�־����Ϊ false
            }
        }

        /// <summary>
        /// ˢ��ͼƬ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refresh_pic_Click(object sender, EventArgs e)
        // ˢ��ͼƬ��������Ƶ�������д���
        {
            if (camera_open == false && img != null)
            // ���δ���������ͼƬ��Ϊ��
            {
                if (img.Empty())
                // ���ͼƬΪ��
                {
                    textBox1.AppendText("û��ͼƬѽ,����ʲôѽ������\r\n");
                    // ���ı����������ʾ��Ϣ
                    return;
                }
                Task.Run(() =>
                // �ں�̨�߳���ִ��
                {
                    this.Invoke(new Action(() =>
                    // �� UI �߳���ִ��
                    {
                        uiWaitingBar1.Visible = true;
                        // ��ʾ�ȴ���
                    }));
                    Stopwatch sw = Stopwatch.StartNew();
                    // ������ʱ���������ڼ��㴦��ʱ��
                    mat = img.Clone();
                    // ��ͼƬת��Ϊ Mat ����
                    int count = 0;
                    // �����������ڼ�¼�����֡��
                    link.InvokeDelegates(ref mat, ref mask, ref count);
                    // ������·��������ͼ����д���
                    pictureBox.Image?.Dispose();
                    // �ͷ�ԭʼͼƬ����Դ
                    pictureBox.Image = OpenCV.GetMat(mat);
                    // ��������ͼ����ʾ�� PictureBox �ؼ���
                    double time = sw.ElapsedMilliseconds;
                    // ���㴦��ʱ��
                    this.Invoke(new Action(() =>
                    // �� UI �߳���ִ��
                    {
                        if (time / 1000 > 10)
                        {
                            time /= 1000.0;
                            toolStripStatusLabel1.Text = "ͼƬ������ʱ��" + time.ToString() + " s";
                        }
                        else
                        {
                            toolStripStatusLabel1.Text = "ͼƬ������ʱ��" + time.ToString() + " ms";
                        }
                        // ��״̬������ʾ����ʱ��
                        uiWaitingBar1.Visible = false;
                        // ���صȴ���
                    }));
                });
            }
            else
            // ����Ѵ����
            {
                timer1.Stop();
                timer2.Start();
                // ������ʱ�� timer2����ʼ����Ƶ���ж�ȡͼ�񲢽��д���
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (var frame = new Mat())
            {
                if (VideoCapture == null) { return; }
                VideoCapture.Read(frame);
                if (!frame.Empty())
                {
                    pictureBox2.Image?.Dispose();
                    pictureBox2.Image = OpenCV.GetMat(frame);
                }
            }
        }
        int Number_of_runs = 0;
        private void timer2_Tick(object sender, EventArgs e)
        // ��ʱ�������¼�
        {
            using (var frame = new Mat())
            // ����һ�� Mat ���� frame�����ڴ洢��Ƶ֡ͼ��
            {
                if (VideoCapture == null) { return; }
                VideoCapture.Read(frame);
                // ����Ƶ���ж�ȡһ֡ͼ�񣬴洢�� frame ��
                if (!frame.Empty())
                // �����ȡ��ͼ��Ϊ��
                {
                    int count = 0;
                    // �����������ڼ�¼�����֡��
                    Mat img = frame.Clone();
                    // ����һ��ͼ�����ڴ���
                    if (link.InvokeDelegates(ref img, ref mask, ref count))
                    // ������·��������ͼ����д���
                    {
                        Number_of_runs++;
                        pictureBox.Image?.Dispose();
                        // �ͷ�ԭʼͼƬ����Դ
                        pictureBox.Image = OpenCV.GetMat(img);
                        // ��������ͼ����ʾ�� PictureBox �ؼ���
                        img.Dispose();
                        // �ͷ� Mat �������Դ
                        img = null;
                        // �� Mat ��������Ϊ null����������������������Դ
                        if (Number_of_runs >= 10)
                        {
                            GC.Collect();
                            Number_of_runs = 0;
                        }
                    }
                    else
                    {
                        timer2.Stop();
                        // �����·���������� false��ֹͣ��ʱ��
                    }
                }
            }
        }
        #endregion ������

        #region PictureBox

        private void �鿴ͼƬ��ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = pictureBox_small.Image;
            if (img != null)//��Ҫ�ж�ͼƬ�Ƿ�Ϊ�գ��Ѿ��Ƿ�ʵ����
            {
                Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)img);
                MessageBox.Show("ͼƬ��ȣ�" + mat.Cols + "��ͼƬ�߶ȣ�" + mat.Rows +
                    "��ͼƬͨ������" + mat.Channels(), "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private enum Graphics_
        {
            ��, ����, ֱ��, Բ
        }

        private Graphics_ shape;

        public OpenCvSharp.Point ptStart = new OpenCvSharp.Point();
        public bool mouseDown = false;

        /// <summary>
        /// ����PictyreBox����ʵ���ص�λ��
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private Point True_coordinate_calculation(MouseEventArgs e, Mat mat)
        // ������� PictureBox �ؼ��е�����ת��ΪͼƬ�ϵ���ʵ����
        {
            float pic_x;
            float pic_y;
            // ͼƬ�ڿؼ��е�λ��
            if (mat.Width > mat.Height)
            // ���ͼƬ�Ŀ�ȴ��ڸ߶�
            {
                float a = pictureBox_small.Width / (float)mat.Width;
                // ����ؼ������ͼƬ��ȵı���
                pic_y = (e.Y - (pictureBox_small.Height - (float)mat.Height * a) / 2) * 1 / a;
                // ����ͼƬ�ڿؼ��е�������
                pic_x = e.X * 1 / a;
                // ����ͼƬ�ڿؼ��еĺ�����
            }
            else
            // ���ͼƬ�ĸ߶ȴ��ڿ��
            {
                float a = pictureBox_small.Height / (float)mat.Height;
                // ����ؼ��߶���ͼƬ�߶ȵı���
                pic_x = (e.X - (pictureBox_small.Width - (float)mat.Width * a) / 2) * 1 / a;
                // ����ͼƬ�ڿؼ��еĺ�����
                pic_y = e.Y * 1 / a;
                // ����ͼƬ�ڿؼ��е�������
            }
            return new Point(pic_x, pic_y);
            // ����ͼƬ�ϵ���ʵ����
        }

        private void ���λ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = Graphics_.����;
        }
        private void ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = Graphics_.��;
        }
        private void ֱ�߻���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = Graphics_.ֱ��;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (camera_open == false)
            {
                Image img = pictureBox_small.Image;
                // ��ȡ PictureBox �ؼ��е�ͼƬ
                if (img != null)
                // ���ͼƬ��Ϊ��
                {
                    if (e.Button == MouseButtons.Left)
                    // ��������������
                    {
                        mouseDown = true;
                        // ���������������µı�־
                        Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)img);
                        // ��ͼƬת��Ϊ OpenCV �� Mat ��ʽ
                        Point location = new Point();
                        location = True_coordinate_calculation(e, mat);
                        // �������������ת��ΪͼƬ�ϵ���ʵ����
                        if (location.X < 0 || location.Y < 0 || location.X > mat.Width || location.Y > mat.Height)
                        // ������λ�ò���ͼƬ��Χ֮��
                        {
                            return;
                        }
                        ptStart = True_coordinate_calculation(e, mat);
                        // �������������ת��ΪͼƬ�ϵ���ʵ���꣬��Ϊ����ͼ��ʱ�����
                        Vec3b bgr = mat.At<Vec3b>(ptStart.Y, ptStart.X);
                        // ��ȡ�����λ�õ�������ɫ��Ϣ
                        byte blue = bgr[0];   // ��ɫͨ��ֵ
                        byte green = bgr[1];  // ��ɫͨ��ֵ
                        byte red = bgr[2];    // ��ɫͨ��ֵ
                        toolStripStatusLabel1.Text = "��ɫͨ��ֵ��" + red + "����ɫͨ��ֵ��" + green + "����ɫͨ��ֵ��" + blue;
                        // ��״̬������ʾ�����ص� RGB ֵ
                        mat.Dispose();
                        // �ͷ� Mat �������Դ
                        mat = null;
                        // �� Mat ��������Ϊ null����������������������Դ
                        GC.Collect();
                        // �ֶ������������գ����ղ���ʹ�õ���Դ
                    }
                }
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (camera_open == false)
            {
                if (mouseDown)
                // ���������������
                {
                    if (e.Button == MouseButtons.Left)
                    // ��������������
                    {
                        using Mat mat = Main_form.mat.Clone();
                        // ��ԭʼͼ�񿽱�һ�ݣ����ڻ���ͼ��
                        Point ptEnd = True_coordinate_calculation(e, mat);
                        // �������������ת��ΪͼƬ�ϵ���ʵ����
                        if (shape == Graphics_.����)
                        // ����û�ѡ���˻��ƾ���
                        {
                            Cv2.Rectangle(mat, ptStart, ptEnd, new Scalar(0, 0, 255), 2);
                            // ��ͼƬ�ϻ���һ�����Σ���ɫΪ��ɫ
                        }
                        else if (shape == Graphics_.ֱ��)
                        // ����û�ѡ���˻���ֱ��
                        {
                            Cv2.Line(mat, ptStart, ptEnd, new Scalar(0, 0, 255), 2);
                            // ��ͼƬ�ϻ���һ��ֱ�ߣ���ɫΪ��ɫ
                            int distance = (int)Math.Sqrt(Math.Pow(ptEnd.X - ptStart.X, 2) + Math.Pow(ptEnd.Y - ptStart.Y, 2));
                            // ������Ƶ�ֱ�ߵ������˵�֮��ľ���
                            toolStripStatusLabel1.Text = "�������Ϊ��" + distance;
                            // ��״̬������ʾ������Ϣ
                        }
                        pictureBox_small.Image?.Dispose();
                        // �ͷ�ԭʼͼƬ����Դ
                        pictureBox_small.Image = OpenCV.GetMat(mat);
                        // �����ƺõ�ͼƬ��ʾ�� PictureBox �ؼ���
                        GC.Collect();
                        // �ֶ������������գ����ղ���ʹ�õ���Դ
                    }
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = false;
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
           
            // ����һ���µĴ�������ʾ��ѡͼƬ��ȫ���汾��Ҳ����ʹ�öԻ���
            Form fullScreenForm = new Form();
            fullScreenForm.WindowState = FormWindowState.Maximized;

            // �����´��ڵı���ɫ
            fullScreenForm.BackColor = Color.Black;
            fullScreenForm.Icon = Resource1.�Ŵ�;
            // ����һ�� PictureBox �ؼ�����ӵ��´�����
            PictureBox pictureBox_big = new PictureBox();

            pictureBox_big.Dock = DockStyle.Fill;
            pictureBox_big.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_big.Image = pictureBox_small.Image;
            pictureBox = pictureBox_big;

            fullScreenForm.Controls.Add(pictureBox_big);

            // ��ʾ�´���
            fullScreenForm.ShowDialog();
            pictureBox_small.Image = pictureBox_big.Image;
            // �ͷ��´��ڵ���Դ
            pictureBox_big.Dispose();
            fullScreenForm.Dispose();
            pictureBox = pictureBox_small;

        }
        #endregion PictureBox

        #region ListBox

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                while (listBox1.SelectedItems.Count > 0)
                {
                    object item = listBox1.SelectedItems[0];
                    string? list = item.ToString();
                    link.RemoveDelegateAt(listBox1.Items.IndexOf(item));
                    data_List.Data_list.RemoveAt(listBox1.Items.IndexOf(item));
                    listBox1.Items.Remove(item);
                    textBox1.AppendText(list + "ɾ���ɹ�\r\n");
                }
                GC.Collect();
            }
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Insert insert = new Insert();
                insert.StartPosition = FormStartPosition.CenterScreen;
                insert.ShowDialog();
                if (insert.DialogResult == DialogResult.OK)
                {
                    link.InsertDelegateAtPosition(insert._Process, listBox1.SelectedIndex);
                    change_set_parameter(insert._Name, "����", listBox1.SelectedIndex);
                    listBox1.Items.Insert(listBox1.SelectedIndex, insert._Name);
                }
            }
        }

        private void ȫѡToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ѡ�� ListBox �ؼ��е�������
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.SetSelected(i, true);
            }
        }

        /// <summary>
        /// �������̲���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                change_parameter();
            }
        }

        /// <summary>
        /// �Ҽ��˵�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && listBox1.SelectedItem != null)
            // �������������������б��������Ŀ��ѡ��
            {
                int index = listBox1.IndexFromPoint(e.Location);
                // ��ȡ�������λ�����б���е�����
                if (index == ListBox.NoMatches)
                // ���û���ҵ�ƥ�������
                {
                    listBox1.ClearSelected();
                    // ȡ������ѡ�е���Ŀ
                }
            }
            else if (e.Button == MouseButtons.Right && listBox1.SelectedItem != null)
            // �������Ҽ�����������б��������Ŀ��ѡ��
            {
                int index = listBox1.IndexFromPoint(e.Location);
                // ��ȡ�������λ�����б���е�����
                if (index != ListBox.NoMatches)
                // ����ҵ���ƥ�������
                {
                    listbox_MenuStrip.Show(listBox1, e.Location);
                    // ���������λ�õ���һ���˵�
                }
            }
        }






        #endregion ListBox

        #region tree

        private void չ��ȫ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView1.ExpandAll();
        }

        private void �۵�ȫ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView1.CollapseAll();
        }

        /// <summary>
        /// ѡ�񷽷�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch_Method(e);
        }

        #endregion tree
    }
}