using SurvivalGameCoreAPI.Repositories;
using SurvivalGameCoreAPI.ViewModels;
using SurvivalGameCoreAPI.ViewModels.output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurvivalGameCoreAPI.Services
{
    public class ProductService
    {
        private readonly ProductRepo _productRepo;

        public ProductService(ProductRepo productRepo)
        {
            this._productRepo = productRepo;
        }
        public APIResult<Product_outVM> GetProductById(string Id)
        {
            try
            {
                return new APIResult<Product_outVM>()
                {
                    IsSuccess = true,
                    Data = _productRepo.GetProductById(Id)
                };
            }
            catch (Exception e)
            {
                return new APIResult<Product_outVM>()
                {
                    IsSuccess = false,
                    Exception = e.Message
                };
            }
        }
        public APIResult<IEnumerable<SimpleProduct_outVM>> GetNewestSimpleProduct(int n)
        {
            try
            {
                return new APIResult<IEnumerable<SimpleProduct_outVM>>()
                {
                    IsSuccess = true,
                    Data = _productRepo.GetNewestSimpleProduct(n)
                };
            }
            catch (Exception e)
            {
                return new APIResult<IEnumerable<SimpleProduct_outVM>>()
                {
                    IsSuccess = false,
                    Exception = e.Message
                };
            }
        }
    }
}
