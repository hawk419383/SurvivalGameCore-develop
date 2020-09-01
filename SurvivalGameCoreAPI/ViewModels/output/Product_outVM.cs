using Newtonsoft.Json;
using SurvivalGameCoreAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurvivalGameCoreAPI.ViewModels.output
{
    public class Product_outVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Color_VM> Color { get; set; }
        public string ManufacturerName { get; set; }
        public string CatagoryName { get; set; }
        public string ClassName { get; set; }
        public decimal? Price { get; set; }
        public int? InvetoryQuantity { get; set; }
        public IEnumerable<string> ImgList { get; set; }
        public string Depiction { get; set; }
        public IEnumerable<Attr_VM> AttrList { get; set; }

        public Product_outVM(IEnumerable<ProductDTO> pDTO)
        {
            foreach (var p in pDTO.GroupBy(x => x.Id))
            {
                this.Id = p.Key;
                this.Name = p.FirstOrDefault().Name;
                this.ManufacturerName = p.FirstOrDefault().ManufacturerName;
                this.CatagoryName = p.FirstOrDefault().CatagoryName;
                this.ClassName = p.FirstOrDefault().ClassName;
                this.Price = p.FirstOrDefault().Price;
                this.InvetoryQuantity = p.FirstOrDefault().InvetoryQuantity;
                this.ImgList = p.Select(x => x.Img).Distinct();
                this.Color = JsonConvert.DeserializeObject<IEnumerable<Color_VM>>(p.FirstOrDefault().Color);

                this.AttrList = p.GroupBy(x => x.AttrName).Select(x => new Attr_VM() 
                {
                     Name = x.Key,
                     Value =x.FirstOrDefault().AttrValue
                });
                SetDescription(p.FirstOrDefault().Depiction);
            }
        }
        private void SetDescription(string queryDesc)
        {
            var result = JsonConvert.DeserializeObject<DescDTO>(queryDesc);
            this.AttrList = this.AttrList.Concat(result.Attr.Select(x => x.Split(':')).Select(x => new Attr_VM() 
            {
                 Name = x?[0],
                 Value = x?[1]
            }));

            this.Depiction = result.Depiction;
        }
    }
}
