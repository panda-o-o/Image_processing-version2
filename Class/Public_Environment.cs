using Image_processing.form.Yolov5;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_processing.Class
{
    public class Public_Environment
    {
        public List<Detection>? yolov5_output = new();
        public string? Yolov5_class;
        public List<string>? Yolov5_list_class = new();
        // 定义输出结果的结构体类
        public struct Detection
        {
            public int class_id;
            public float confidence;
            public Rect box;
        };
        //定义框体颜色
        public readonly List<Scalar>? colors = new()
        {
            new Scalar(255, 255, 0),
            new Scalar(0, 255, 0),
            new Scalar(0, 255, 255),
            new Scalar(255, 0, 0)
        };
    }
}
