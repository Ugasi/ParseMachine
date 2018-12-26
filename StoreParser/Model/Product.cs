namespace StoreParser
{
    /// <summary>
    /// Product class to be extracted from given store
    /// </summary>
    public class Product
    {
        /// <summary>
        /// String representation of product name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// String representation of product category
        /// </summary>
        public string ProductCategory { get; set; }

        /// <summary>
        /// String representation of product price
        /// </summary>
        public string ProductPrice { get; set; }

        /// <summary>
        /// String representation of product code
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// String representation of product url
        /// </summary>
        public string ProductUrl { get; set; }

        /// <summary>
        /// String representation of product image url
        /// </summary>
        public string ProductImage { get; set; }
    }
}