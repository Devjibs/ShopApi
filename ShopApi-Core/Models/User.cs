using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApi_Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
