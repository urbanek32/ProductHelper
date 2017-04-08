using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using DataModels.Database;
using DataModels.Request;
using DataModels.Response;
using ProductHelper.Services;

namespace ProductHelper.Controllers.Api
{
    public class ProductController : ApiController
    {
        private readonly IProductsService _productService;

        public ProductController()
        {
            _productService = new ProductsService();    
        }

        public Task<List<ProductResponse>> Post(ProductRequest request)
        {
            return _productService.GetListByAilmentsId(request);
        }
    }
}
