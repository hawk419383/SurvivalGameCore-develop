using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class OrderDetails
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
