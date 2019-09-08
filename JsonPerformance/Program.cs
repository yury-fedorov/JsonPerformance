using System.Collections.Generic;
using System.IO;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Newtonsoft.Json;

namespace JsonPerformance
{
    class Program
    {
        static void Main(string[] args) => BenchmarkRunner.Run<JsonPerformanceTest>();
    }


    public class Quote
    {
        public string text { get; set; }
        public string from { get; set; }
    }


    public class JsonPerformanceTest
    {
        private readonly string _json;

        public JsonPerformanceTest() 
        {
            // load JSON file
            _json = Get("JsonPerformance.enterpreneur-quotes.json");
        }

        public string Get(string resource)
        {
            var assembly = typeof(Quote).Assembly;
            var resourceStream = assembly.GetManifestResourceStream(resource);
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        [Benchmark]
        public List<Quote> Newton()
            => new Newtonsoft.Json.JsonSerializer().Deserialize<List<Quote>>(
                new JsonTextReader(new StringReader(_json) ));

        [Benchmark]
        public List<Quote> Core3() => System.Text.Json.JsonSerializer.Deserialize<List<Quote>>(_json);
        
    }
}
