using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ShopApi_Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

    }
}
