using AutoWindowsSize;
using Image_processing.Class;
using Image_processing.form;
using Image_processing.main_Form;
using OpenCvSharp;
using Sunny.UI;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Point = OpenCvSharp.Point;
//using Point = OpenCvSharp.Point;

namespace Image_processing
{
    public partial class Main_form : UIForm
    {
        private new AutoAdaptWindowsSize? AutoSize;
        public linked_list link;
        public Mat img;
        public Mat mask;
        public static Mat mat;//图片处理备份

        #region 窗体加载
        public Main_form()
        {
            InitializeComponent();
            AutoSize = new AutoAdaptWindowsSize(this);
            link = new linked_list();//加载委托链表
            img = new Mat();
            mask = new Mat();
            mat = new Mat();

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

        #endregion

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
            SaveFileDialog saveImageDialog = new SaveFileDialog();
            saveImageDialog.Title = "图片保存";
            saveImageDialog.Filter = "jpg图片|*.jpg|gif图片|*.gif|png图片|*.png|jpeg图片|*.jpeg|BMP图片|*.bmp";//文件类型过滤,只可选择图片的类型
            saveImageDialog.FilterIndex = 1;//设置默认文件类型显示顺序
            saveImageDialog.FileName = "图片保存"; //设置默认文件名,可为空
            saveImageDialog.RestoreDirectory = true; //OpenFileDialog与SaveFileDialog都有RestoreDirectory属性,这个属性默认是false,
                                                     //打开一个文件后,那么系统默认目录就会指向刚才打开的文件。如果设为true就会使用系统默认目录
            saveImageDialog.InitialDirectory = @"F:\user\Pictures\Saved Pictures";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(path);
                img = new Mat(path, ImreadModes.Color);
                if (img.Empty())
                {
                    MessageBox.Show("打开图片文件错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pictureBox1.Image = OpenCV.GetMat(img);
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
                        pictureBox1.Image.Save(fileName, imgformat);
                    }
                }
            }
        }

        /// <summary>
        /// 刷新图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refresh_pic_Click(object sender, EventArgs e)
        {
            if (img.Empty())
            {
                textBox1.AppendText("没有图片呀,处理什么呀！！！\r\n");
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
                pictureBox1.Image = OpenCV.GetMat(mat);
                double time = sw.ElapsedMilliseconds;
                if (time / 1000 > 10)
                {
                    time /= 1000.0;
                    toolStripStatusLabel1.Text = "图片处理用时：" + time.ToString() + " s";
                }
                else
                {
                    toolStripStatusLabel1.Text = "图片处理用时：" + time.ToString() + " ms";
                }
                this.Invoke(new Action(() =>
                {
                    uiWaitingBar1.Visible = false;
                }));
            });


        }
        #endregion

        #region PictureBox

        private void 查看图片信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            if (img != null)//需要判断图片是否为空,已经是否被实例化
            {
                Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)img);
                MessageBox.Show("图片宽度：" + mat.Cols + ",图片高度：" + mat.Rows +
                    ",图片通道数：" + mat.Channels(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private Point start;//按下鼠标的起点,对应的mat对象
        private System.Drawing.Point startPoint;
        private System.Drawing.Point endPoint;

        // 定义画笔
        private Pen pen = new Pen(Color.Red, 2);


        /// <summary>
        /// 计算PictyreBox中真实像素点位置
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private Point True_coordinate_calculation(MouseEventArgs e)
        {
            Image img = pictureBox1.Image;
            if (img != null)
            {
                float pic_x;//
                float pic_y;//图片在控件中的位置
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
                    byte blue = bgr[0];   // 蓝色通道值
                    byte green = bgr[1];  // 绿色通道值
                    byte red = bgr[2];    // 红色通道值
                    toolStripStatusLabel1.Text = "红色通道值：" + red + ",绿色通道值：" + green + ",蓝色通道值：" + blue;
                    // 记录鼠标按下的起始点
                    startPoint = e.Location;
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 获取PictureBox的Graphics对象
                Graphics g = pictureBox1.CreateGraphics();
                endPoint = e.Location;
                // 绘制直线
                g.DrawLine(pen, startPoint, endPoint);

            }
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            // 检查鼠标左键是否按下
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                // 获取PictureBox的Graphics对象
                Graphics g = pictureBox1.CreateGraphics();

                // 获取鼠标在屏幕坐标系中的位置
                System.Drawing.Point screenPosition = Control.MousePosition;

                // 将屏幕坐标转换为相对于pictureBox1控件的坐标
                System.Drawing.Point clientPosition = pictureBox1.PointToClient(screenPosition);
                endPoint = clientPosition;
                // 绘制直线
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
                    toolStripStatusLabel1.Text = "两点距离为：" + distance;
                }
            }
        }


        #endregion

        #region ListBox
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string? list = listBox1.SelectedItem.ToString();
                link.RemoveDelegateAt(listBox1.SelectedIndex);
                Data_List.data_list.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
                textBox1.AppendText(list + "删除成功\r\n");
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

        #endregion



    }

}