using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SurvivalGameCoreAPI.Dto;
using SurvivalGameCoreAPI.Models;
using SurvivalGameCoreAPI.ViewModels.output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurvivalGameCoreAPI.Repositories
{
    public class ProductRepo
    {
        private readonly SGDBContext _context;
        private readonly IConfiguration _configuration;

        public ProductRepo(SGDBContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }


        public Product_outVM GetProductById(string Id)
        {
            IEnumerable<ProductDTO> queryResult = null;
            var connStr = _configuration.GetConnectionString("SGDatabase");
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                queryResult = conn.Query<ProductDTO>(
                    @"
                        select p.ID ,p.Name ,p.Color ,p.Depiction ,p.InvetoryQuantity ,p.Price,
                        (
	                        select Name 
	                        from Class as in_cl
	                        where in_cl.ID = cl.ID
                        )as ClassName,
                        (
	                        select Name 
	                        from Catagory as in_ca
	                        where in_ca.ID = ca.ID
                        )as CatagoryName,
                        pa.Name as AttrName,
                        pa.Value as AttrValue,
                        img.Img,
                        m.Name as ManufacturerName
                        from Products as p
                        join class as cl on p.ClassID = cl.ID
                        join Catagory as ca on cl.CatagoryID = ca.ID
                        left outer join RelatedProducts as rp on p.ID = rp.ProductID
                        left outer join [Product Attributes] as pa on p.ID = pa.PID
                        left outer join Imgs as img on p.ID = img.ProductID
                        left outer join Manufacturers as m on p.ManufacturerID = m.ID
                        where p.ID = @PID
                    ", new { PID = Id });
            }
            return new Product_outVM(queryResult);
        }
        public IEnumerable<SimpleProduct_outVM> GetNewestSimpleProduct(int n)
        {
            IEnumerable<SimpleProductDTO> queryResult = null;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("SGDatabase")))
            {
                conn.Open();
                queryResult = conn.Query<SimpleProductDTO>(
                    @"
                        select top (@num) p.ID  as PID , p.Name ,p.Price ,i.Img 
                        from Products as p
                        left outer join Imgs as i on p.ID = i.ProductID
                        left outer join Procurement as pr on p.ID = pr.ProductID
                        order by case when pr.PurchasingDay is null then 1 else 0 end , pr.PurchasingDay desc
                     ", new { num = n });
            }
            return queryResult?.Select(r => new SimpleProduct_outVM()
            {
                PID = r.PID.Trim(),
                Name = r.Name,
                Img = r.Img,
                Price = r.Price
            });
        }
    }
}
