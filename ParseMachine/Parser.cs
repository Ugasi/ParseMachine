using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ParseMachine
{
    public abstract class Parser
    {
        private readonly ParserProperties _properties;
        private static readonly HtmlWeb _client = new HtmlWeb();
        public List<Product> Products { get; set; } = new List<Product>();
        public abstract ParserProperties SetProperties();

        protected Parser()
        {
            _properties = SetPropertyValues();
        }

        private ParserProperties SetPropertyValues()
        {
            return SetProperties();
        }

        public void Parse()
        {
            var page = _client.Load(_properties.Url);
            Parallel.ForEach(page.DocumentNode.SelectNodes(_properties.CategoryXpath), liElement =>
            {
                var categoryElement = liElement.SelectSingleNode(".//a");
                string categoryUrl = categoryElement.Attributes["href"]?.Value.Trim();
                string categoryName = categoryElement.InnerText?.Trim();
                ParseProducts(categoryUrl, categoryName);
            });
        }

        private void ParseProducts(string categoryUrl, string categoryName)
        {
            var productPage = _client.Load(categoryUrl);
            do
            {
                var productSection = productPage.DocumentNode.SelectSingleNode(_properties.ProductAreaXpath);
                if (productSection != null)
                {
                    Parallel.ForEach(productSection.SelectNodes(_properties.ProductItemXpath), item =>
                    {
                        string name = ParseItemAttribute(item, _properties.ProductNameXpath, _properties.ProductNameAttribute);
                        string price = ParseItemAttribute(item, _properties.ProductPriceXpath, _properties.ProductPriceAttribute);
                        string url = ParseItemAttribute(item, _properties.ProductUrlXpath, _properties.ProductUrlAttribute);
                        string code = ParseItemAttribute(item, _properties.ProductCodeXpath, _properties.ProductCodeAttribute);
                        string image = ParseItemAttribute(item, _properties.ProductImageXPath, _properties.ProductImageAttribute);
                        Products.Add(new Product()
                        {
                            ProductName = name,
                            ProductCategory = categoryName,
                            ProductCode = code,
                            ProductImage = image,
                            ProductPrice = price,
                            ProductUrl = url
                        });
                    });
                }
            } while ((productPage = NextPageExists(productPage)) != null);
        }

        private string ParseItemAttribute(HtmlNode item, string xpath, string attributeName = null)
        {
            var info = item.SelectSingleNode(xpath);
            return info?.InnerText ?? (attributeName != null ? info?.Attributes[attributeName].Value : null);
        }

        private HtmlDocument NextPageExists(HtmlDocument productPage)
        {
            var nextPageExists = productPage.DocumentNode.SelectSingleNode(_properties.NextPageXpath);
            if (nextPageExists != null)
            {
                return _client.Load(nextPageExists.Attributes["href"].Value);
            }
            return null;
        }
    }
}
