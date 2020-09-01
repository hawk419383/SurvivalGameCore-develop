using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class Imgs
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string Img { get; set; }

        public virtual Products Product { get; set; }
    }
}
