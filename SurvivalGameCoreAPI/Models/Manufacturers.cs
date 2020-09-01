using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class Manufacturers
    {
        public Manufacturers()
        {
            Products = new HashSet<Products>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Depiction { get; set; }
        public string Img { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
