using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class Members
    {
        public Members()
        {
            Orders = new HashSet<Orders>();
            Wishlist = new HashSet<Wishlist>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public DateTime? Birthday { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? Memberlevel { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}
