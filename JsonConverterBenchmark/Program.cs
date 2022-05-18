using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using JsonConverterBenchmark;

//DataContractJsonConverter.TrialRunWithModel();
//DataContractJsonConverter.TrialRunWithDataContractModel();

BenchmarkRunner.Run<JsonStringConvertBenchmark>();
//|                              Method |     Mean |     Error |    StdDev |
//|------------------------------------ |---------:|----------:|----------:|
//| DataContractJsonConverter_Serialize | 3.108 us | 0.0614 us | 0.1373 us |
//|            JsonSerializer_Serialize | 1.253 us | 0.0278 us | 0.0788 us |
//|     NewtonsoftJsonConvert_Serialize | 2.791 us | 0.0719 us | 0.1933 us |
BenchmarkRunner.Run<JsonObjectConvertBenchmark>();
//|                                Method |      Mean |     Error |    StdDev |    Median |
//|-------------------------------------- |----------:|----------:|----------:|----------:|
//| DataContractJsonConverter_Deserialize | 12.378 us | 0.4570 us | 1.1959 us | 11.971 us |
//|            JsonSerializer_Deserialize |  2.338 us | 0.0467 us | 0.1015 us |  2.320 us |
//|     NewtonsoftJsonConvert_Deserialize |  4.466 us | 0.0886 us | 0.2089 us |  4.399 us |


public class JsonStringConvertBenchmark
{
    private Model demoObject = new Model
    {
        StringProperty = "string",
        IntProperty = 123,
        ListProperty = new List<string> { "A", "B", "C" },
        ObjectProperty = new Person { ID = 11, Name = "Poy Chang" }
    };

    [Benchmark]
    public string DataContractJsonConverter_Serialize() => DataContractJsonConverter.Serialize(demoObject);

    [Benchmark]
    public string JsonSerializer_Serialize() => System.Text.Json.JsonSerializer.Serialize(demoObject);

    [Benchmark]
    public string NewtonsoftJsonConvert_Serialize() => Newtonsoft.Json.JsonConvert.SerializeObject(demoObject);
}

public class JsonObjectConvertBenchmark
{
    private string jsonString =
        """
        {
            "StringProperty": "string",
            "IntProperty": 123,
            "ListProperty": [ "A", "B", "C" ],
            "ObjectProperty": { "ID": 11, "Name": "Poy Chang" }
        }
        """;

    [Benchmark]
    public object DataContractJsonConverter_Deserialize() => DataContractJsonConverter.Deserialize<Model>(jsonString);

    [Benchmark]
    public object JsonSerializer_Deserialize() => System.Text.Json.JsonSerializer.Deserialize<Model>(jsonString);

    [Benchmark]
    public object NewtonsoftJsonConvert_Deserialize() => Newtonsoft.Json.JsonConvert.DeserializeObject<Model>(jsonString);
}

