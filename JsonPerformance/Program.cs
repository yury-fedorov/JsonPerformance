using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text.Json;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;

namespace JsonPerformance
{
    class Program
    {
        static void Main(string[] args) => BenchmarkRunner.Run<JsonPerformanceTest>();
    }


    public class Quote
    {
        string Text { get; set; }
        string From { get; set; }
    }


    public class JsonPerformanceTest
    {
        private readonly string _json;

        public JsonPerformanceTest() 
        {
            // load JSON file
            _json = Get("JsonPerformance.enterpreneur-quotes.json").Result;
        }

        public async Task<string> Get(string resource)
        {
            var assembly = Assembly.GetEntryAssembly();
            var resourceStream = assembly.GetManifestResourceStream(resource);
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
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
