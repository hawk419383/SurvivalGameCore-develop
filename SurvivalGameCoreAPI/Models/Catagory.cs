using System;
using System.Collections.Generic;

namespace SurvivalGameCoreAPI.Models
{
    public partial class Catagory
    {
        public Catagory()
        {
            Class = new HashSet<Class>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Class> Class { get; set; }
    }
}
