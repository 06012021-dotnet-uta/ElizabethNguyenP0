using System;
using System.Collections.Generic;

#nullable disable

namespace P0DbContext.Models
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            OrderedProducts = new HashSet<OrderedProduct>();
            ProductTags = new HashSet<ProductTag>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
