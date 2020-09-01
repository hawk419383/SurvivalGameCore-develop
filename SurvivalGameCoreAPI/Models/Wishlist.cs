using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class Wishlist
    {
        public string Id { get; set; }
        public string MemberId { get; set; }
        public string ProductId { get; set; }

        public virtual Members Member { get; set; }
        public virtual Products Product { get; set; }
    }
}
