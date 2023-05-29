using AutoWindowsSize;
using Image_processing.Class;
using Image_processing.form.摄像头;
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
        public static Mat? mat;//图片处理备份
        public static Data_List? data_List;
        private bool camera_open = false;
        private VideoCapture? VideoCapture;
        private PictureBox pictureBox = new();//用于处理图片播放，以及放大
        private readonly Dictionary<string, del_process> Delegation_Deserialization;
        private readonly Dictionary<del_process, string> Delegation_Serialization;
        public static Public_Environment? public_Environment;

        #region 窗体加载

        public Main_form()
        {
            InitializeComponent();
            AutoSize = new AutoAdaptWindowsSize(this);
            link = new linked_list();//加载委托链表
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
                { "Yolov5方框绘制",OpenCV.Yolov5_Box_drawing }
            };
            Delegation_Serialization = Delegation_Deserialization.ToDictionary(pair => pair.Value, pair => pair.Key);
            this.Icon = Resource1.摄像机; // 加载资源文件中的图标
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
                // 设置窗体的位置为屏幕中央
                this.Location = new System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                                       (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            }
            tree_add();//树状图加载
        }

        #endregion 窗体加载

        #region 工具栏

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
            //打开的文件选择对话框上的标题
            openFileDialog.Title = "请选择文件";
            //设置文件类型
            openFileDialog.Filter = "jpg图片|*.JPG|gif图片|*.GIF|png图片|*.PNG|jpeg图片|*.JPEG|BMP图片|*.BMP|MP4文件|*.mp4|所有文件|*.*";
            //设置默认文件类型显示顺序
            openFileDialog.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录
            openFileDialog.RestoreDirectory = false;
            //设置是否允许多选
            openFileDialog.Multiselect = false;
            //默认打开路径 
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
                        MessageBox.Show("打开图片文件错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            saveImageDialog.Title = "图片保存";
            saveImageDialog.Filter = "jpg图片|*.jpg|gif图片|*.gif|png图片|*.png|jpeg图片|*.jpeg|BMP图片|*.bmp";//文件类型过滤,只可选择图片的类型
            saveImageDialog.FilterIndex = 1;//设置默认文件类型显示顺序
            saveImageDialog.FileName = "图片保存"; //设置默认文件名,可为空
            saveImageDialog.RestoreDirectory = true; //OpenFileDialog与SaveFileDialog都有RestoreDirectory属性,这个属性默认是false,
                                                     //打开一个文件后,那么系统默认目录就会指向刚才打开的文件。如果设为true就会使用系统默认目录
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
                            #region 图片类型

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

                                #endregion 图片类型
                        }
                        MessageBox.Show("保存路径：" + fileName, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pictureBox_small.Image.Save(fileName, imgformat);
                    }
                }
            }
        }

        private void open_Configuration_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //打开的文件选择对话框上的标题
            openFileDialog.Title = "请选择文件";
            //设置文件类型
            openFileDialog.Filter = "Json文件|*.json";
            //设置默认文件类型显示顺序
            openFileDialog.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录
            openFileDialog.RestoreDirectory = false;
            //设置是否允许多选
            openFileDialog.Multiselect = false;
            //默认打开路径
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                using (var steamRead = new StreamReader(path))
                {
                    var settings = new JsonSerializerSettings();
                    settings.Converters.Add(new Data_ListJsonConverter());
                    string? str = steamRead.ReadLine();
                    data_List = JsonConvert.DeserializeObject<Data_List>(str, settings);
                    foreach (var item in data_List.Combobox_list)//加载listbox
                    {
                        listBox1.Items.Add(item.ToString());
                    }

                    foreach (var item in data_List.Serialization)//加载委托
                    {
                        link.AddDelegate(Delegation_Deserialization[item]);
                    }
                }
            }
        }

        private void save_Configuration_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveImageDialog = new SaveFileDialog();
            saveImageDialog.Title = "配置保存";
            saveImageDialog.Filter = "Json文件|*.json";//文件类型过滤,只可选择图片的类型
            saveImageDialog.FilterIndex = 1;//设置默认文件类型显示顺序
            saveImageDialog.FileName = "配置保存"; //设置默认文件名,可为空
            saveImageDialog.RestoreDirectory = true; //OpenFileDialog与SaveFileDialog都有RestoreDirectory属性,这个属性默认是false,
                                                     //打开一个文件后,那么系统默认目录就会指向刚才打开的文件。如果设为true就会使用系统默认目录
            if (saveImageDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveImageDialog.FileName;
                // 创建一个JsonSerializerSettings对象并添加CustomJsonConverter
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new Data_ListJsonConverter());

                foreach (var item in listBox1.Items)//将listbox里面的字符窜进行保存
                {
                    data_List.Combobox_list.Add(item.ToString());
                }
                foreach (del_process del in link.List?.GetInvocationList() ?? Enumerable.Empty<Delegate>())//将委托进行保存
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
        // 打开、关闭摄像头并启动、停止计时器以读取视频流并进行处理
        {
            if (camera_open == false)
            // 如果未打开相机
            {
                try
                {
                    Camera camera = new Camera();
                    // 创建相机对象
                    camera.StartPosition = FormStartPosition.CenterScreen;
                    // 设置相机窗口的起始位置为屏幕中央
                    camera.ShowDialog();
                    // 显示相机窗口
                    if (camera.DialogResult == DialogResult.OK)
                    // 如果用户点击了“确定”按钮
                    {
                        VideoCapture = new VideoCapture(camera.Cameras_Id);
                        // 创建 VideoCapture 对象，用于读取视频流
                        timer1.Interval = 1000 / 30;
                        // 设置 timer1 的间隔为 1/30 秒，即 33 毫秒
                        timer1.Start();
                        // 启动计时器 timer1，开始从视频流中读取图像并进行处理
                        timer2.Interval = 1000 / camera.Camers_Frame_rate;
                        // 设置 timer2 的间隔为相机的帧率
                        capture.Text = "关闭摄像头";
                        // 将按钮的文本设置为“关闭摄像头”
                        camera_open = true;
                        // 将相机打开标志设置为 true
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("摄像头打开失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // 显示错误提示框
                }
            }
            else
            // 如果已打开相机
            {
                VideoCapture.Dispose();
                VideoCapture = null;
                // 释放视频流资源
                if (timer1.Enabled)
                { timer1.Stop(); }
                // 停止计时器 timer1
                if (timer2.Enabled)
                { timer2.Stop(); }
                // 停止计时器 timer2
                capture.Text = "打开摄像头";
                // 将按钮的文本设置为“打开摄像头”
                camera_open = false;
                // 将相机打开标志设置为 false
            }
        }

        /// <summary>
        /// 刷新图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refresh_pic_Click(object sender, EventArgs e)
        // 刷新图片或启动视频流并进行处理
        {
            if (camera_open == false && img != null)
            // 如果未打开相机并且图片不为空
            {
                if (img.Empty())
                // 如果图片为空
                {
                    textBox1.AppendText("没有图片呀,处理什么呀！！！\r\n");
                    // 在文本框中输出提示信息
                    return;
                }
                Task.Run(() =>
                // 在后台线程中执行
                {
                    this.Invoke(new Action(() =>
                    // 在 UI 线程中执行
                    {
                        uiWaitingBar1.Visible = true;
                        // 显示等待条
                    }));
                    Stopwatch sw = Stopwatch.StartNew();
                    // 创建计时器对象，用于计算处理时间
                    mat = img.Clone();
                    // 将图片转换为 Mat 对象
                    int count = 0;
                    // 计数器，用于记录处理的帧数
                    link.InvokeDelegates(ref mat, ref mask, ref count);
                    // 调用链路处理函数对图像进行处理
                    pictureBox.Image?.Dispose();
                    // 释放原始图片的资源
                    pictureBox.Image = OpenCV.GetMat(mat);
                    // 将处理后的图像显示在 PictureBox 控件中
                    double time = sw.ElapsedMilliseconds;
                    // 计算处理时间
                    this.Invoke(new Action(() =>
                    // 在 UI 线程中执行
                    {
                        if (time / 1000 > 10)
                        {
                            time /= 1000.0;
                            toolStripStatusLabel1.Text = "图片处理用时：" + time.ToString() + " s";
                        }
                        else
                        {
                            toolStripStatusLabel1.Text = "图片处理用时：" + time.ToString() + " ms";
                        }
                        // 在状态栏中显示处理时间
                        uiWaitingBar1.Visible = false;
                        // 隐藏等待条
                    }));
                });
            }
            else
            // 如果已打开相机
            {
                timer1.Stop();
                timer2.Start();
                // 启动计时器 timer2，开始从视频流中读取图像并进行处理
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
        // 定时器触发事件
        {
            using (var frame = new Mat())
            // 创建一个 Mat 对象 frame，用于存储视频帧图像
            {
                if (VideoCapture == null) { return; }
                VideoCapture.Read(frame);
                // 从视频流中读取一帧图像，存储到 frame 中
                if (!frame.Empty())
                // 如果读取的图像不为空
                {
                    int count = 0;
                    // 计数器，用于记录处理的帧数
                    Mat img = frame.Clone();
                    // 复制一份图像，用于处理
                    if (link.InvokeDelegates(ref img, ref mask, ref count))
                    // 调用链路处理函数对图像进行处理
                    {
                        Number_of_runs++;
                        pictureBox.Image?.Dispose();
                        // 释放原始图片的资源
                        pictureBox.Image = OpenCV.GetMat(img);
                        // 将处理后的图像显示在 PictureBox 控件中
                        img.Dispose();
                        // 释放 Mat 对象的资源
                        img = null;
                        // 将 Mat 对象设置为 null，方便垃圾回收器回收资源
                        if (Number_of_runs >= 10)
                        {
                            GC.Collect();
                            Number_of_runs = 0;
                        }
                    }
                    else
                    {
                        timer2.Stop();
                        // 如果链路处理函数返回 false，停止定时器
                    }
                }
            }
        }
        #endregion 工具栏

        #region PictureBox

        private void 查看图片信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = pictureBox_small.Image;
            if (img != null)//需要判断图片是否为空，已经是否被实例化
            {
                Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)img);
                MessageBox.Show("图片宽度：" + mat.Cols + "，图片高度：" + mat.Rows +
                    "，图片通道数：" + mat.Channels(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private enum Graphics_
        {
            无, 矩形, 直线, 圆
        }

        private Graphics_ shape;

        public OpenCvSharp.Point ptStart = new OpenCvSharp.Point();
        public bool mouseDown = false;

        /// <summary>
        /// 计算PictyreBox中真实像素点位置
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private Point True_coordinate_calculation(MouseEventArgs e, Mat mat)
        // 将鼠标在 PictureBox 控件中的坐标转换为图片上的真实坐标
        {
            float pic_x;
            float pic_y;
            // 图片在控件中的位置
            if (mat.Width > mat.Height)
            // 如果图片的宽度大于高度
            {
                float a = pictureBox_small.Width / (float)mat.Width;
                // 计算控件宽度与图片宽度的比例
                pic_y = (e.Y - (pictureBox_small.Height - (float)mat.Height * a) / 2) * 1 / a;
                // 计算图片在控件中的纵坐标
                pic_x = e.X * 1 / a;
                // 计算图片在控件中的横坐标
            }
            else
            // 如果图片的高度大于宽度
            {
                float a = pictureBox_small.Height / (float)mat.Height;
                // 计算控件高度与图片高度的比例
                pic_x = (e.X - (pictureBox_small.Width - (float)mat.Width * a) / 2) * 1 / a;
                // 计算图片在控件中的横坐标
                pic_y = e.Y * 1 / a;
                // 计算图片在控件中的纵坐标
            }
            return new Point(pic_x, pic_y);
            // 返回图片上的真实坐标
        }

        private void 矩形绘制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = Graphics_.矩形;
        }
        private void 无ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = Graphics_.无;
        }
        private void 直线绘制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = Graphics_.直线;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (camera_open == false)
            {
                Image img = pictureBox_small.Image;
                // 获取 PictureBox 控件中的图片
                if (img != null)
                // 如果图片不为空
                {
                    if (e.Button == MouseButtons.Left)
                    // 如果鼠标左键被点击
                    {
                        mouseDown = true;
                        // 设置鼠标左键被按下的标志
                        Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)img);
                        // 将图片转换为 OpenCV 的 Mat 格式
                        Point location = new Point();
                        location = True_coordinate_calculation(e, mat);
                        // 将鼠标点击的坐标转换为图片上的真实坐标
                        if (location.X < 0 || location.Y < 0 || location.X > mat.Width || location.Y > mat.Height)
                        // 如果点击位置不在图片范围之内
                        {
                            return;
                        }
                        ptStart = True_coordinate_calculation(e, mat);
                        // 将鼠标点击的坐标转换为图片上的真实坐标，作为绘制图形时的起点
                        Vec3b bgr = mat.At<Vec3b>(ptStart.Y, ptStart.X);
                        // 获取鼠标点击位置的像素颜色信息
                        byte blue = bgr[0];   // 蓝色通道值
                        byte green = bgr[1];  // 绿色通道值
                        byte red = bgr[2];    // 红色通道值
                        toolStripStatusLabel1.Text = "红色通道值：" + red + "，绿色通道值：" + green + "，蓝色通道值：" + blue;
                        // 在状态栏中显示该像素的 RGB 值
                        mat.Dispose();
                        // 释放 Mat 对象的资源
                        mat = null;
                        // 将 Mat 对象设置为 null，方便垃圾回收器回收资源
                        GC.Collect();
                        // 手动调用垃圾回收，回收不再使用的资源
                    }
                }
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (camera_open == false)
            {
                if (mouseDown)
                // 如果鼠标左键被按下
                {
                    if (e.Button == MouseButtons.Left)
                    // 如果鼠标左键被点击
                    {
                        using Mat mat = Main_form.mat.Clone();
                        // 将原始图像拷贝一份，用于绘制图形
                        Point ptEnd = True_coordinate_calculation(e, mat);
                        // 将鼠标点击的坐标转换为图片上的真实坐标
                        if (shape == Graphics_.矩形)
                        // 如果用户选择了绘制矩形
                        {
                            Cv2.Rectangle(mat, ptStart, ptEnd, new Scalar(0, 0, 255), 2);
                            // 在图片上绘制一个矩形，颜色为红色
                        }
                        else if (shape == Graphics_.直线)
                        // 如果用户选择了绘制直线
                        {
                            Cv2.Line(mat, ptStart, ptEnd, new Scalar(0, 0, 255), 2);
                            // 在图片上绘制一条直线，颜色为红色
                            int distance = (int)Math.Sqrt(Math.Pow(ptEnd.X - ptStart.X, 2) + Math.Pow(ptEnd.Y - ptStart.Y, 2));
                            // 计算绘制的直线的两个端点之间的距离
                            toolStripStatusLabel1.Text = "两点距离为：" + distance;
                            // 在状态栏上显示距离信息
                        }
                        pictureBox_small.Image?.Dispose();
                        // 释放原始图片的资源
                        pictureBox_small.Image = OpenCV.GetMat(mat);
                        // 将绘制好的图片显示在 PictureBox 控件上
                        GC.Collect();
                        // 手动调用垃圾回收，回收不再使用的资源
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
           
            // 创建一个新的窗口来显示所选图片的全屏版本（也可以使用对话框）
            Form fullScreenForm = new Form();
            fullScreenForm.WindowState = FormWindowState.Maximized;

            // 设置新窗口的背景色
            fullScreenForm.BackColor = Color.Black;
            fullScreenForm.Icon = Resource1.放大;
            // 创建一个 PictureBox 控件并添加到新窗口中
            PictureBox pictureBox_big = new PictureBox();

            pictureBox_big.Dock = DockStyle.Fill;
            pictureBox_big.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_big.Image = pictureBox_small.Image;
            pictureBox = pictureBox_big;

            fullScreenForm.Controls.Add(pictureBox_big);

            // 显示新窗口
            fullScreenForm.ShowDialog();
            pictureBox_small.Image = pictureBox_big.Image;
            // 释放新窗口的资源
            pictureBox_big.Dispose();
            fullScreenForm.Dispose();
            pictureBox = pictureBox_small;

        }
        #endregion PictureBox

        #region ListBox

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    textBox1.AppendText(list + "删除成功\r\n");
                }
                GC.Collect();
            }
        }

        private void 插入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Insert insert = new Insert();
                insert.StartPosition = FormStartPosition.CenterScreen;
                insert.ShowDialog();
                if (insert.DialogResult == DialogResult.OK)
                {
                    link.InsertDelegateAtPosition(insert._Process, listBox1.SelectedIndex);
                    change_set_parameter(insert._Name, "插入", listBox1.SelectedIndex);
                    listBox1.Items.Insert(listBox1.SelectedIndex, insert._Name);
                }
            }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 选中 ListBox 控件中的所有项
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.SetSelected(i, true);
            }
        }

        /// <summary>
        /// 更改流程参数
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
        /// 右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && listBox1.SelectedItem != null)
            // 如果鼠标左键被点击，且列表框中有项目被选中
            {
                int index = listBox1.IndexFromPoint(e.Location);
                // 获取鼠标点击的位置在列表框中的索引
                if (index == ListBox.NoMatches)
                // 如果没有找到匹配的索引
                {
                    listBox1.ClearSelected();
                    // 取消所有选中的项目
                }
            }
            else if (e.Button == MouseButtons.Right && listBox1.SelectedItem != null)
            // 如果鼠标右键被点击，且列表框中有项目被选中
            {
                int index = listBox1.IndexFromPoint(e.Location);
                // 获取鼠标点击的位置在列表框中的索引
                if (index != ListBox.NoMatches)
                // 如果找到了匹配的索引
                {
                    listbox_MenuStrip.Show(listBox1, e.Location);
                    // 在鼠标点击的位置弹出一个菜单
                }
            }
        }






        #endregion ListBox

        #region tree

        private void 展开全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView1.ExpandAll();
        }

        private void 折叠全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView1.CollapseAll();
        }

        /// <summary>
        /// 选择方法
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