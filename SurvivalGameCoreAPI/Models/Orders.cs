using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public string Id { get; set; }
        public string MemberId { get; set; }
        public string PaymentMethodId { get; set; }
        public string Depiction { get; set; }
        public string ShipAddress { get; set; }
        public string StatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string DeliveryMethod { get; set; }

        public virtual Members Member { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
