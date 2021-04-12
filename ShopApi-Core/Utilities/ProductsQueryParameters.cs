using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApi_Core.Utilities
{
    public class ProductsQueryParameters : QueryParameters
    {
        public string Sku { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
