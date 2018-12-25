using Xunit;

namespace ParseMachineTest
{
    public class IntegrationTest
    {
        [Fact]
        public void TestRealScenario()
        {
            var parser = new TestParser();
            parser.Parse();
            var products = parser.Products;
            Assert.True(products.Count > 0);
        }
    }
}