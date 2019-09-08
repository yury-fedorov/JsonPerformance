using System.Linq;
using JsonPerformance;
using Xunit;

namespace JsonTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
			var b = new JsonPerformanceTest();
            var c = b.Core3();
            Assert.NotEmpty(c);
            Assert.Equal(c.First().from, "Ilka Chase");
            Assert.Equal(b.Newton(), c);
		}
    }
}
