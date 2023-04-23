using OpenCvSharp;

namespace Image_processing.Class
{
    [Serializable]
    public class Data_List
    {
        private List<Data_dic> data_list = new List<Data_dic>();
        private List<string> combobox_list = new List<string>();

        public List<Data_dic> Data_list { get => data_list; set => data_list = value; }
        public List<string> Combobox_list { get => combobox_list; set => combobox_list = value; }
    }
    public class Data_dic

    {
        public Dictionary<string, int>? int_dic;
        public Dictionary<string, Mat>? mat_dic;
        public Dictionary<string, double>? dou_dic;
        public Dictionary<string, string>? str_dic;
        public Dictionary<string, KeyPoint[]>? KeyPoint_dic;
    }
}

