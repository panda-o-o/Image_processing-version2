using AutoWindowsSize;
using Image_processing.Class;
using Image_processing.main_Form;
using OpenCvSharp;
using Sunny.UI;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
using Point = OpenCvSharp.Point;
using System.Text.Json;
using OpenCvSharp.Extensions;
using Image_processing.form.����ͷ;

namespace Image_processing
{
    public partial class Main_form : UIForm
    {
        private new AutoAdaptWindowsSize? AutoSize;
        public linked_list link;
        public Mat img;
        public Mat mask;
        public static Mat? mat;//ͼƬ������
        public static Data_List data_List;
        private bool camera_open = false;
        private VideoCapture? VideoCapture;


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

        #endregion

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
            openFileDialog.Filter = "jpgͼƬ|*.JPG|gifͼƬ|*.GIF|pngͼƬ|*.PNG|jpegͼƬ|*.JPEG|BMPͼƬ|*.BMP";
            //����Ĭ���ļ�������ʾ˳��
            openFileDialog.FilterIndex = 1;
            //����Ի����Ƿ�����ϴδ򿪵�Ŀ¼
            openFileDialog.RestoreDirectory = true;
            //�����Ƿ������ѡ
            openFileDialog.Multiselect = false;
            //Ĭ�ϴ�·��
            openFileDialog.InitialDirectory = @"F:\user\Pictures\Saved Pictures";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(path);
                img = new Mat(path, ImreadModes.Color);
                if (img.Empty())
                {
                    MessageBox.Show("��ͼƬ�ļ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = OpenCV.GetMat(img);
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
                        pictureBox1.Image.Save(fileName, imgformat);
                    }
                }
            }
        }

        private void open_Configuration_Click(object sender, EventArgs e)
        {

        }

        private void save_Configuration_Click(object sender, EventArgs e)
        {

        }

        private void capture_Click(object sender, EventArgs e)
        {

            if (camera_open == false)
            {
                try
                {
                    Camera camera = new Camera();
                    camera.StartPosition = FormStartPosition.CenterScreen;
                    camera.ShowDialog();
                    if (camera.DialogResult == DialogResult.OK)
                    {
                        VideoCapture = new VideoCapture(camera.Cameras_Id);
                        timer1.Interval = 1000 / 30;
                        timer1.Start();
                        timer2.Interval = 1000 / camera.Camers_Frame_rate;
                        capture.Text = "�ر�����ͷ";
                        camera_open = true;
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("����ͷ��ʧ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                VideoCapture.Dispose();
                VideoCapture = null;
                if (timer1.Enabled)
                { timer1.Stop(); }
                if (timer2.Enabled)
                { timer2.Stop(); }
                capture.Text = "������ͷ";
                camera_open = false;
            }
        }

        /// <summary>
        /// ˢ��ͼƬ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refresh_pic_Click(object sender, EventArgs e)
        {
            if (camera_open == false)
            {
                if (img.Empty())
                {
                    textBox1.AppendText("û��ͼƬѽ,����ʲôѽ������\r\n");
                    return;
                }
                Task.Run(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        uiWaitingBar1.Visible = true;
                    }));
                    Stopwatch sw = Stopwatch.StartNew();
                    mat = img.Clone();
                    int count = 0;
                    link.InvokeDelegates(ref mat, ref mask, ref count);
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = OpenCV.GetMat(mat);
                    double time = sw.ElapsedMilliseconds;
                    this.Invoke(new Action(() =>
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
                        uiWaitingBar1.Visible = false;
                    }));
                });
            }
            else
            {
                if (timer1.Enabled)
                { timer1.Stop(); }
                if (timer2.Enabled)
                { timer2.Stop(); }
                timer2.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (var frame = new Mat())
            {
                VideoCapture.Read(frame);
                if (!frame.Empty())
                {
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = OpenCV.GetMat(frame);
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            using (var frame = new Mat())
            {
                VideoCapture.Read(frame);
                if (!frame.Empty())
                {
                    int count = 0;
                    Mat img = frame.Clone();
                    if (link.InvokeDelegates(ref img, ref mask, ref count))
                    {
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = OpenCV.GetMat(img);
                        img.Dispose();
                        img = null;
                    }
                    else
                    {
                        timer2.Stop();
                    }
                }
            }
        }
        #endregion

        #region PictureBox

        private void �鿴ͼƬ��ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            if (img != null)//��Ҫ�ж�ͼƬ�Ƿ�Ϊ��,�Ѿ��Ƿ�ʵ����
            {
                Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)img);
                MessageBox.Show("ͼƬ��ȣ�" + mat.Cols + ",ͼƬ�߶ȣ�" + mat.Rows +
                    ",ͼƬͨ������" + mat.Channels(), "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private Point start;//�����������,��Ӧ��mat����
        private System.Drawing.Point startPoint;
        private System.Drawing.Point endPoint;

        // ���廭��
        private Pen pen = new Pen(Color.Red, 2);


        /// <summary>
        /// ����PictyreBox����ʵ���ص�λ��
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private Point True_coordinate_calculation(MouseEventArgs e)
        {
            Image img = pictureBox1.Image;
            if (img != null)
            {
                float pic_x;//
                float pic_y;//ͼƬ�ڿؼ��е�λ��
                Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)img);
                if (mat.Width > mat.Height)
                {
                    float a = pictureBox1.Width / (float)mat.Width;
                    pic_y = (e.Y - (pictureBox1.Height - (float)mat.Height * a) / 2) * 1 / a;
                    pic_x = e.X * 1 / a;
                }
                else
                {
                    float a = pictureBox1.Height / (float)mat.Height;
                    pic_x = (e.X - (pictureBox1.Width - (float)mat.Width * a) / 2) * 1 / a;
                    pic_y = e.Y * 1 / a;
                }
                return new Point(pic_x, pic_y);
            }
            return new Point(0, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Image img = pictureBox1.Image;
            if (img != null)
            {
                if (e.Button == MouseButtons.Left)
                {

                    Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)img);
                    Point location = new Point();
                    location = True_coordinate_calculation(e);
                    if (location.X < 0 || location.Y < 0 || location.X > mat.Width || location.Y > mat.Height)
                    {
                        return;
                    }
                    start = True_coordinate_calculation(e);
                    Vec3b bgr = mat.At<Vec3b>(location.Y, location.X);
                    byte blue = bgr[0];   // ��ɫͨ��ֵ
                    byte green = bgr[1];  // ��ɫͨ��ֵ
                    byte red = bgr[2];    // ��ɫͨ��ֵ
                    toolStripStatusLabel1.Text = "��ɫͨ��ֵ��" + red + ",��ɫͨ��ֵ��" + green + ",��ɫͨ��ֵ��" + blue;
                    // ��¼��갴�µ���ʼ��
                    startPoint = e.Location;
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // ��ȡPictureBox��Graphics����
                Graphics g = pictureBox1.CreateGraphics();
                endPoint = e.Location;
                // ����ֱ��
                g.DrawLine(pen, startPoint, endPoint);

            }
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            // ����������Ƿ���
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                // ��ȡPictureBox��Graphics����
                Graphics g = pictureBox1.CreateGraphics();

                // ��ȡ�������Ļ����ϵ�е�λ��
                System.Drawing.Point screenPosition = Control.MousePosition;

                // ����Ļ����ת��Ϊ�����pictureBox1�ؼ�������
                System.Drawing.Point clientPosition = pictureBox1.PointToClient(screenPosition);
                endPoint = clientPosition;
                // ����ֱ��
                g.DrawLine(pen, startPoint, endPoint);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Image img = pictureBox1.Image;
                if (img != null)
                {
                    Point location = new Point();
                    location = True_coordinate_calculation(e);
                    int distance = (int)Math.Sqrt(Math.Pow(location.X - start.X, 2) + Math.Pow(location.Y - start.Y, 2));
                    toolStripStatusLabel1.Text = "�������Ϊ��" + distance;
                }
            }
        }


        #endregion

        #region ListBox
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string? list = listBox1.SelectedItem.ToString();
                link.RemoveDelegateAt(listBox1.SelectedIndex);
                data_List.Data_list.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
                textBox1.AppendText(list + "ɾ���ɹ�\r\n");
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
            {
                int index = listBox1.IndexFromPoint(e.Location);
                if (index == ListBox.NoMatches)
                {
                    listBox1.ClearSelected();
                }
            }
            else if (e.Button == MouseButtons.Right && listBox1.SelectedItem != null)
            {
                int index = listBox1.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    listbox_MenuStrip.Show(listBox1, e.Location);
                }
            }
        }
        #endregion

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

        #endregion






    }


}