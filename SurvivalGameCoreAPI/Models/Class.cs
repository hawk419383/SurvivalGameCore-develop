using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class Class
    {
        public Class()
        {
            Products = new HashSet<Products>();
        }

        public string Id { get; set; }
        public string CatagoryId { get; set; }
        public string Name { get; set; }

        public virtual Catagory Catagory { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
