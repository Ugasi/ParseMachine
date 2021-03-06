﻿using HtmlAgilityPack;
using StoreParser.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreParser
{
    /// <summary>
    /// Abstract parser. Contains base implementation to parse whole store
    /// </summary>
    public abstract class Parser
    {
        /// <summary>
        /// Properties of the parser. Containing xpaths to relevant information
        /// </summary>
        public readonly ParserProperties Properties;

        private static readonly HtmlWeb _client = new HtmlWeb();

        /// <summary>
        /// List of products parsed from store
        /// </summary>
        public List<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Override this to return custom properties
        /// </summary>
        /// <returns></returns>
        public abstract ParserProperties SetProperties();

        /// <summary>
        /// Calls SetPropertyValues to set properties
        /// </summary>
        protected Parser()
        {
            Properties = SetPropertyValues();
        }

        private ParserProperties SetPropertyValues()
        {
            return SetProperties();
        }

        /// <summary>
        /// Starts parsing store page with given properties. Output is recorded in Products list
        /// </summary>
        public void Parse()
        {
            var page = _client.Load(Properties.StoreUrl);
            Parallel.ForEach(page.DocumentNode.SelectNodes(Properties.CategoryXpath), liElement =>
            {
                var categoryElement = liElement.SelectSingleNode(".//a");
                string categoryUrl = categoryElement.Attributes["href"]?.Value.RemoveWhiteSpace();
                string categoryName = categoryElement.InnerText?.RemoveWhiteSpace();
                ParseProducts(categoryUrl, categoryName);
            });
        }

        private void ParseProducts(string categoryUrl, string categoryName)
        {
            var productPage = _client.Load(categoryUrl);
            do
            {
                var productSection = productPage.DocumentNode.SelectSingleNode(Properties.ProductAreaXpath);
                if (productSection != null)
                {
                    var singleItems = productSection.SelectNodes(Properties.ProductItemXpath);
                    if (singleItems != null)
                    {
                        Parallel.ForEach(productSection.SelectNodes(Properties.ProductItemXpath), item =>
                        {
                            string name = ParseItemAttribute(item, Properties.ProductNameXpath, Properties.ProductNameAttribute);
                            string price = ParseItemAttribute(item, Properties.ProductPriceXpath, Properties.ProductPriceAttribute);
                            string url = ParseItemAttribute(item, Properties.ProductUrlXpath, Properties.ProductUrlAttribute);
                            string code = ParseItemAttribute(item, Properties.ProductCodeXpath, Properties.ProductCodeAttribute);
                            string image = ParseItemAttribute(item, Properties.ProductImageXPath, Properties.ProductImageAttribute);
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
                }
            } while ((productPage = NextPageExists(productPage)) != null);
        }

        private string ParseItemAttribute(HtmlNode item, string xpath, string attributeName = null)
        {
            var info = item.SelectSingleNode(xpath);
            return attributeName != null ? info?.Attributes[attributeName].Value : info?.InnerText;
        }

        private HtmlDocument NextPageExists(HtmlDocument productPage)
        {
            var nextPageExists = productPage.DocumentNode.SelectSingleNode(Properties.NextPageXpath);
            if (nextPageExists != null)
            {
                return _client.Load(nextPageExists.Attributes["href"].Value);
            }
            return null;
        }
    }
}