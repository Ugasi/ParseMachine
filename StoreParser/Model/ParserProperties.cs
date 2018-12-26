namespace StoreParser
{
    /// <summary>
    /// Property class for containing varying information about locations to parse
    /// </summary>
    public class ParserProperties
    {
        /// <summary>
        /// URL of the store
        /// </summary>
        public string StoreUrl { get; set; }

        /// <summary>
        /// Xpath to element containing url and title for category
        /// </summary>
        public string CategoryXpath { get; set; }

        /// <summary>
        /// Xpath to element, usually div, containing product information
        /// </summary>
        public string ProductAreaXpath { get; set; }

        /// <summary>
        /// Xpath to element of single product
        /// </summary>
        public string ProductItemXpath { get; set; }

        /// <summary>
        /// Xpath to product name
        /// </summary>
        public string ProductNameXpath { get; set; }

        /// <summary>
        /// Xpath to product url
        /// </summary>
        public string ProductUrlXpath { get; set; }

        /// <summary>
        /// Xpath to product price
        /// </summary>
        public string ProductPriceXpath { get; set; }

        /// <summary>
        /// Xpath to product code (EAN or similiar)
        /// </summary>
        public string ProductCodeXpath { get; set; }

        /// <summary>
        /// Xpath to product image
        /// </summary>
        public string ProductImageXPath { get; set; }

        /// <summary>
        /// Optional name of attribute containing product name
        /// </summary>
        public string ProductNameAttribute { get; set; }

        /// <summary>
        /// Optional name of attribute containing product url
        /// </summary>
        public string ProductUrlAttribute { get; set; }

        /// <summary>
        /// Optional name of attribute containing product price
        /// </summary>
        public string ProductPriceAttribute { get; set; }

        /// <summary>
        /// Optional name of attribute containing product code
        /// </summary>
        public string ProductCodeAttribute { get; set; }

        /// <summary>
        /// Optional name of attribute containing product image
        /// </summary>
        public string ProductImageAttribute { get; set; }

        /// <summary>
        /// Optional xpath to next page button, if category has that
        /// </summary>
        public string NextPageXpath { get; set; }
    }
}