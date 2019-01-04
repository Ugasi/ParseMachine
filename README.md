# Usage

## Initialize
```C#
public class TestParser : Parser
{
    public override ParserProperties SetProperties()
    {
        return new ParserProperties()
        {
            StoreUrl = "https://store.com/",
            NextPageXpath = "//a[@class='next i-next']",
            ProductAreaXpath = "//div[@class='category-products']",
            CategoryXpath = ".//li[contains(@class, 'level') and contains(@class, 'level-top')]",
            ProductCodeAttribute = null,
            ProductCodeXpath = ".//tr[@class='product-sku']//span",
            ProductImageAttribute = "src",
            ProductImageXPath = ".//img",
            ProductItemXpath = ".//li[@class='item']",
            ProductNameAttribute = null,
            ProductNameXpath = ".//a[@class='product-name']",
            ProductPriceAttribute = null,
            ProductPriceXpath = ".//span[@class='price']",
            ProductUrlAttribute = "href",
            ProductUrlXpath = ".//a[@class='product-image']"
        };
    }
}
```

## Use
```C#
var parser = new TestParser();
parser.Parse();
var products = parser.Products;
```