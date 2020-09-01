using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurvivalGameCoreAPI.Dto
{
    public class ProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Depiction { get; set; }
        public string ManufacturerName{ get; set; }
        public string CatagoryName { get; set; }
        public string ClassName { get; set; }
        public decimal? Price { get; set; }
        public int? InvetoryQuantity { get; set; }
        public string Img { get; set; }
        public string AttrName { get; set; }
        public string AttrValue { get; set; }
    }
}
