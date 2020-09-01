using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Orders>();
        }

        public string Id { get; set; }
        public string Status1 { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
