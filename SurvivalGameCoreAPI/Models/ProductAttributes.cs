using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class ProductAttributes
    {
        public string Id { get; set; }
        public string Pid { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Products P { get; set; }
    }
}
