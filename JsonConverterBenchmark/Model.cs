using System.Runtime.Serialization;

namespace JsonConverterBenchmark
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Model
    {
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }
        public List<string> ListProperty { get; set; }
        // 若屬性為物件，必須是明確型別才能被序列化，不支援 object 和 dynamic 型別
        public Person ObjectProperty { get; set; }
    }

    // 若有掛 DataContract 在類別上時，屬性也必須掛上 DataMember 才會被序列化
    [DataContract]
    public class DataContractModel
    {
        [DataMember(Name = "other_name")]
        public string StringProperty { get; set; }
        [DataMember]
        public int IntProperty { get; set; }
        [DataMember]
        public List<string> ListProperty { get; set; }
        [DataMember]
        public Person ObjectProperty { get; set; }
    }
}
