using OpenCvSharp;

namespace Image_processing.Class
{
    public static class Data_List
    {
        static List<Data> data_list = new List<Data>();
    }
    public class Data
    {
        static Dictionary<string, int> int_dic = new Dictionary<string, int>();
        static Dictionary<string, Mat> mat_dic = new Dictionary<string, Mat>();
    }
}

