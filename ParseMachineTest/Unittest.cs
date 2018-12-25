using Xunit;

namespace ParseMachineTest
{
    public class UnitTest
    {
        [Fact]
        public void TestParserProperties()
        {
            var parser = new TestParser();
            Assert.Equal("https://ekodinkoneet.fi/", parser.Properties.StoreUrl);
            Assert.Equal(".//li[contains(@class, 'level') and contains(@class, 'level-top')]", parser.Properties.CategoryXpath);
            Assert.Equal("//a[@class='next i-next']", parser.Properties.NextPageXpath);
            Assert.Equal("//div[@class='category-products']", parser.Properties.ProductAreaXpath);
            Assert.Null(parser.Properties.ProductCodeAttribute);
            Assert.Equal(".//tr[@class='product-sku']//span", parser.Properties.ProductCodeXpath);
            Assert.Equal("src", parser.Properties.ProductImageAttribute);
            Assert.Equal(".//img", parser.Properties.ProductImageXPath);
            Assert.Equal(".//li[@class='item']", parser.Properties.ProductItemXpath);
            Assert.Null(parser.Properties.ProductNameAttribute);
            Assert.Equal(".//a[@class='product-name']", parser.Properties.ProductNameXpath);
            Assert.Null(parser.Properties.ProductPriceAttribute);
            Assert.Equal(".//span[@class='price']", parser.Properties.ProductPriceXpath);
            Assert.Equal("href", parser.Properties.ProductUrlAttribute);
            Assert.Equal(".//a[@class='product-image']", parser.Properties.ProductUrlXpath);
        }
    }
}