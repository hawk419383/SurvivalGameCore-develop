using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class Procurement
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public DateTime PurchasingDay { get; set; }
        public int Quantity { get; set; }
        public decimal UintPrice { get; set; }

        public virtual Products Product { get; set; }
    }
}
