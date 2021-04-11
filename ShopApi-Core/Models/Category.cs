using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApi_Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}
