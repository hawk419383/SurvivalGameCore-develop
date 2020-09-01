using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class Products
    {
        public Products()
        {
            Imgs = new HashSet<Imgs>();
            OrderDetails = new HashSet<OrderDetails>();
            Procurement = new HashSet<Procurement>();
            ProductAttributes = new HashSet<ProductAttributes>();
            RelatedProducts = new HashSet<RelatedProducts>();
            Wishlist = new HashSet<Wishlist>();
        }

        public string Id { get; set; }
        public string ClassId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Depiction { get; set; }
        public string ManufacturerId { get; set; }
        public decimal? Price { get; set; }
        public int? InvetoryQuantity { get; set; }

        public virtual Class Class { get; set; }
        public virtual Manufacturers Manufacturer { get; set; }
        public virtual ICollection<Imgs> Imgs { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Procurement> Procurement { get; set; }
        public virtual ICollection<ProductAttributes> ProductAttributes { get; set; }
        public virtual ICollection<RelatedProducts> RelatedProducts { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}
