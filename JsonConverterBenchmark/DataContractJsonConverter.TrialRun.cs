namespace JsonConverterBenchmark
{
    public static partial class DataContractJsonConverter
    {
        public static void TrialRunWithModel()
        {
            var demoObject = new Model
            {
                StringProperty = "string",
                IntProperty = 123,
                ListProperty = new List<string> { "A", "B", "C" },
                ObjectProperty = new Person { ID = 11, Name = "Poy Chang" }
            };
            Console.WriteLine(Serialize(demoObject));

            var jsonString =
            """
            {
                "StringProperty": "string",
                "IntProperty": 123,
                "ListProperty": [ "A", "B", "C" ],
                "ObjectProperty": { "ID": 11, "Name": "Poy Chang" }
            }
            """;
            Console.WriteLine(Deserialize<Model>(jsonString));
        }

        public static void TrialRunWithDataContractModel()
        {
            var demoObject = new DataContractModel
            {
                StringProperty = "string",
                IntProperty = 123,
                ListProperty = new List<string> { "A", "B", "C" },
                ObjectProperty = new Person { ID = 11, Name = "Poy Chang" }
            };
            Console.WriteLine(Serialize(demoObject));

            var jsonString =
            """
            {
                "StringProperty": "string",
                "IntProperty": 123,
                "ListProperty": [ "A", "B", "C" ],
                "ObjectProperty": { "ID": 11, "Name": "Poy Chang" }
            }
            """;
            Console.WriteLine(Deserialize<DataContractModel>(jsonString));
        }
    }
}
