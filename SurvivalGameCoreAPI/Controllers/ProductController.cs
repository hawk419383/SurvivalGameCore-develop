using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SurvivalGameCoreAPI.Services;
using SurvivalGameCoreAPI.ViewModels;
using SurvivalGameCoreAPI.ViewModels.output;

namespace SurvivalGameCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet("{Id}")]
        public APIResult<Product_outVM> Product(string Id)
        {
            return _productService.GetProductById(Id);
        }
        [HttpGet("{n}")]
        public APIResult<IEnumerable<SimpleProduct_outVM>> NewestSimpleProduct(int n)
        {
            return _productService.GetNewestSimpleProduct(n);
        }
    }
}
