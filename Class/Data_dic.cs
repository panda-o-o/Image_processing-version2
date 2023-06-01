using Image_processing.form.Yolov5;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenCvSharp;
using OpenCvSharp.Dnn;

namespace Image_processing.Class
{

    public class Data_List
    {
        private List<Data_dic> data_list = new List<Data_dic>();
        private List<string> combobox_list = new List<string>();
        private List<string> serialization = new List<string>();

        public List<Data_dic> Data_list { get => data_list; set => data_list = value; }
        public List<string> Combobox_list { get => combobox_list; set => combobox_list = value; }
        public List<string> Serialization { get => serialization; set => serialization = value; }
    }
    public class Data_dic
    {
        public Dictionary<string, int>? int_dic;
        public Dictionary<string, Mat>? mat_dic;
        public Dictionary<string, double>? dou_dic;
        public Dictionary<string, float>? flo_dic;
        public Dictionary<string, string>? str_dic;
        public Dictionary<string, KeyPoint[]>? KeyPoint_dic;
        public Dictionary<string, Net>? net_dic;
    }

    public class Data_ListJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Data_List);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            // 检查 JSON 数据是否为 null
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            // 读取 JSON 数据到 JObject 中
            var Jobj_parent = JObject.Load(reader);

            // 创建一个新的 data 对象
            var data_list = new Data_List();
            string onnx_path, class_path;
            // 从 JObject 中读取 Data_list 列表并遍历它
            var array_data_list = Jobj_parent["Data_list"] as JArray;
            if (array_data_list != null)
            {
                foreach (var Data_dic in array_data_list)
                {
                    // 创建一个新的 Data_dic 对象
                    var data_dic = new Data_dic();
                    bool 形态学处理 = false;
                    // 从 JObject 中读取 mat_dic 字典并遍历它
                    if (Data_dic["mat_dic"] is JObject mat_obj)
                    {
                        data_dic.mat_dic = new Dictionary<string, Mat>();
                        foreach (KeyValuePair<string, JToken?> item in mat_obj)
                        {
                            // 从 JObject 中读取字符串和字节数组，并使用 OpenCV 的 ImDecode 方法将字节数组解码为 Mat 对象
                            string str = item.Key;
                            try
                            {
                                byte[] buf = item.Value.ToObject<byte[]>();
                                Mat mat = Cv2.ImDecode(buf, ImreadModes.Color);
                                // 将 Mat 对象添加到 mat_data 中的 data_dic 字典中
                                data_dic.mat_dic.Add(str, mat);
                                if (str== "Kernel")
                                {
                                    形态学处理 = true;
                                }
                            }
                            catch (Exception)
                            {

                            }

                        }
                    }

                    // 从 JObject 中读取 KeyPoint_dic 字典并遍历它
                    if (Data_dic["KeyPoint_dic"] is JObject keypoint_obj)
                    {
                        data_dic.KeyPoint_dic = new Dictionary<string, KeyPoint[]>();
                        foreach (var item in keypoint_obj)
                        {
                            try
                            {
                                // 从 JObject 中读取字符串和 KeyPoint 数组，并将 KeyPoint 数组反序列化为对象
                                string str = item.Key;
                                KeyPoint[]? keypoints = item.Value.ToObject<KeyPoint[]>();

                                // 将 KeyPoint 数组添加到 mat_data 中的 KeyPoint_dic 字典中
                                data_dic.KeyPoint_dic.Add(str, keypoints);

                            }
                            catch (Exception)
                            {

                            }

                        }
                    }

                    // 从 JObject 中读取 KeyPoint_dic 字典并遍历它
                    if (Data_dic["int_dic"] is JObject int_dic_obj)
                    {
                        data_dic.int_dic = new Dictionary<string, int>();
                        foreach (var item in int_dic_obj)
                        {
                            try
                            {
                                int value = item.Value.ToObject<int>();
                                data_dic.int_dic.Add(item.Key, value);
                            }
                            catch (Exception){}
                        }
                        if (形态学处理==true)
                        {
                            data_dic.mat_dic["Kernel"]= Cv2.GetStructuringElement((MorphShapes)data_dic.int_dic["kernel_shape"], new OpenCvSharp.Size(data_dic.int_dic["kernel_width"], data_dic.int_dic["kernel_height"]));
                            形态学处理 = false;
                        }
                    }
                    // 从 JObject 中读取 dou_dic 字典并遍历它
                    if (Data_dic["dou_dic"] is JObject dou_dic_obj)
                    {
                        data_dic.dou_dic = new Dictionary<string, double>();
                        foreach (var item in dou_dic_obj)
                        {
                            try
                            {
                                double value = item.Value.ToObject<double>();
                                // 将 KeyPoint 数组添加到 mat_data 中的 KeyPoint_dic 字典中
                                data_dic.dou_dic.Add(item.Key, value);

                            }
                            catch (Exception)
                            {

                            }

                        }
                    }
                    if (Data_dic["flo_dic"] is JObject flo_dic_obj)
                    {
                        data_dic.flo_dic = new Dictionary<string, float>();
                        foreach (var item in flo_dic_obj)
                        {
                            try
                            {
                                float value = item.Value.ToObject<float>();
                                // 将 KeyPoint 数组添加到 mat_data 中的 KeyPoint_dic 字典中
                                data_dic.flo_dic.Add(item.Key, value);

                            }
                            catch (Exception)
                            {

                            }

                        }
                    }

                    // 从 JObject 中读取 str_dic 字典并遍历它
                    if (Data_dic["str_dic"] is JObject str_dic_obj)
                    {
                        data_dic.str_dic = new Dictionary<string, string>();
                        foreach (var item in str_dic_obj)
                        {
                            try
                            {
                                string value = item.Value.ToObject<string>();
                                if(item.Key== "onnx_path")
                                {
                                    var Net = CvDnn.ReadNetFromOnnx(value);
                                    Net.SetPreferableBackend(Backend.DEFAULT);
                                    Net.SetPreferableTarget(Target.CPU);
                                    data_dic.net_dic = new Dictionary<string, Net>() { { "Net", Net } };
                                }
                                else if (item.Key == "class_path")
                                {
                                    using StreamReader streamReader = new(value);
                                    Main_form.public_Environment.Yolov5_class = streamReader.ReadToEnd();
                                    var str = Main_form.public_Environment.Yolov5_class.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                                    Main_form.public_Environment.Yolov5_list_class.AddRange(str);
                                }
                                data_dic.str_dic.Add(item.Key, value);

                            }
                            catch (Exception)
                            {

                            }

                        }
                    }

                    data_list.Data_list.Add(data_dic);
                }
            }

            // 从 JObject 中读取 combobox_list 列表并遍历它
            var array_combobox_list = Jobj_parent["combobox_list"] as JArray;
            if (array_combobox_list != null)
            {
                foreach (var item in array_combobox_list)
                {
                    data_list.Combobox_list.Add((string)item);
                }
            }

            // 从 JObject 中读取 combobox_list 列表并遍历它
            var array_Delegation_list = Jobj_parent["Delegation_list"] as JArray;
            if (array_Delegation_list != null)
            {
                foreach (var item in array_Delegation_list)
                {
                    data_list.Serialization.Add((string)item);
                }
            }
            return data_list;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            // 检查要序列化的对象是否为 null
            if (value == null)
            {
                return;
            }
            // 将对象强制转换为 data 类型
            var data = (Data_List)value;

            // 创建一个新的 JObject
            var Jobj_parent = new JObject();

            // 创建一个新的 Data_list 数组
            var Data_list = new JArray();

            // 遍历 data 中的 Data_list 列表
            foreach (var item in data.Data_list)
            {
                // 创建一个新的 Data_list 对象
                var data_list = new JObject();

                // 创建一个新的 mat_dic 对象
                var mat_dic = new JObject();

                // 创建一个新的 KeyPoint_dic 字典
                var KeyPoint_dic = new JObject();

                // 创建一个新的 int_dic 对象
                var int_dic = new JObject();

                // 创建一个新的 dou_dic 字典
                var dou_dic = new JObject();

                // 创建一个新的 str_dic 字典
                var str_dic = new JObject();

                // 创建一个新的 flo_dic 字典
                var flo_dic = new JObject();


                if (item.mat_dic != null)
                {
                    // 遍历 Data_list 中的 mat_dic 字典
                    foreach (var mat_dic_dic in item.mat_dic)
                    {
                        // 将 Mat 对象编码为字节数组，并将字符串和字节数组添加到 mat_obj 字典中
                        Cv2.ImEncode(".jpg", mat_dic_dic.Value, out byte[]? buf);
                        mat_dic.Add(mat_dic_dic.Key, JToken.FromObject(buf));
                    }
                }
                if (item.KeyPoint_dic != null)
                {
                    // 遍历 Data_list 中的 KeyPoint_dic 字典
                    foreach (var KeyPoint_dic_dic in item.KeyPoint_dic)
                    {
                        // 将 KeyPoint 数组序列化为 JToken，并将字符串和 JToken 添加到 keypoint_obj 字典中
                        KeyPoint_dic.Add(KeyPoint_dic_dic.Key, JToken.FromObject(KeyPoint_dic_dic.Value));
                    }
                }
                if (item.int_dic != null)
                {
                    // 遍历 Data_list 中的 KeyPoint_dic 字典
                    foreach (var int_dic_dic in item.int_dic)
                    {
                        // 将 KeyPoint 数组序列化为 JToken，并将字符串和 JToken 添加到 keypoint_obj 字典中
                        int_dic.Add(int_dic_dic.Key, int_dic_dic.Value);
                    }
                }
                if (item.dou_dic != null)
                {
                    // 遍历 Data_list 中的 dou_dic 字典
                    foreach (var dou_dic_dic in item.dou_dic)
                    {
                        // 将 KeyPoint 数组序列化为 JToken，并将字符串和 JToken 添加到 keypoint_obj 字典中
                        dou_dic.Add(dou_dic_dic.Key, dou_dic_dic.Value);
                    }
                }
                if (item.flo_dic != null)
                {
                    // 遍历 Data_list 中的 dou_dic 字典
                    foreach (var flo_dic_dic in item.flo_dic)
                    {
                        // 将 KeyPoint 数组序列化为 JToken，并将字符串和 JToken 添加到 keypoint_obj 字典中
                        flo_dic.Add(flo_dic_dic.Key, flo_dic_dic.Value);
                    }
                }
                if (item.str_dic != null)
                {
                    foreach (var str_dic_dic in item.str_dic)
                    {
                        // 将 KeyPoint 数组序列化为 JToken，并将字符串和 JToken 添加到 keypoint_obj 字典中
                        str_dic.Add(str_dic_dic.Key, str_dic_dic.Value);
                    }
                }
                //将所有的字典合成一个类
                data_list.Add("mat_dic", mat_dic);
                data_list.Add("KeyPoint_dic", KeyPoint_dic);
                data_list.Add("int_dic", int_dic);
                data_list.Add("dou_dic", dou_dic);
                data_list.Add("str_dic", str_dic);
                data_list.Add("flo_dic", flo_dic);

                //将这个类添加到Data_list类中的Data_list列表中
                Data_list.Add(data_list);
            }

            // 遍历 data 中的 Combobox_list 列表
            var combobox_list = new JArray();
            foreach (var item in data.Combobox_list)
            {
                combobox_list.Add(item);
            }

            // 遍历 data 中的 Serialization 列表
            var Delegation_list = new JArray();
            foreach (var item in data.Serialization)
            {
                Delegation_list.Add(item);
            }


            Jobj_parent.Add("Data_list", Data_list);
            Jobj_parent.Add("combobox_list", combobox_list);
            Jobj_parent.Add("Delegation_list", Delegation_list);
            Jobj_parent.WriteTo(writer);
        }
    }
}

