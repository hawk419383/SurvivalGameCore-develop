using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Orders = new HashSet<Orders>();
        }

        public string Id { get; set; }
        public string PaymentMethod1 { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
