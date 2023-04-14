using OpenCvSharp;

namespace Image_processing.Class
{
    public static class Data_List
    {
        public static List<Data_dic> data_list = new List<Data_dic>();
    }
    public class Data_dic

    {
        public  Dictionary<string, int>? int_dic ;
        public  Dictionary<string, Mat>? mat_dic ;
        public Dictionary<string, double>? dou_dic;
    }
}

