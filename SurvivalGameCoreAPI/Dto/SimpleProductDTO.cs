using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurvivalGameCoreAPI.Dto
{
    public class SimpleProductDTO
    {
        public string PID { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public decimal Price { get; set; }
    }
}
