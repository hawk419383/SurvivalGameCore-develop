using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class RelatedProducts
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string RelationPid { get; set; }

        public virtual Products Product { get; set; }
    }
}
