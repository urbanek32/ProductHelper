using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Html;
using AutoMapper;
using DataModels.Database;
using DataModels.Request;
using DataModels.Response;
using ProductHelper.Database;

namespace ProductHelper.Services
{
    public interface IProductsService
    {
        Task<List<ProductResponse>> GetListByAilmentsId(ProductRequest request);
        void CreateProduct(CreateProductRequest request);
    }

    public class ProductsService : IProductsService
    {
        public ProductsService()
        {
            
        }

        public async Task<List<ProductResponse>> GetListByAilmentsId(ProductRequest request)
        {
            using (var db = new PhDbContext())
            {
                /*var products = await db.Products
                    .Include(p => p.Ingredients)
                    .Include(p => p.Ingredients.Select(i => i.CureAilments))
                    .Where(p => p.Ingredients.Any(i => i.CureAilments.Where(request.AilmentsIds.Contains(i.Id))))
                    .ToListAsync();

                return Mapper.Map<List<ProductResponse>>(products);*/

                var products = await db.Ingredients
                    .Include(i => i.CureAilments)
                    .Where(p => p.CureAilments.Any(a => request.AilmentsIds.Contains(a.Id)))
                    .SelectMany(i => i.Products)
                    .Include(p => p.Ingredients)
                    .Include(p => p.Ailments)
                    .Distinct()
                    .ToListAsync();

                return Mapper.Map<List<ProductResponse>>(products);
            }
        }

        public void CreateProduct(CreateProductRequest request)
        {
            using (var db = new PhDbContext())
            {
                var product = new Product
                {
                    Name = request.Name
                };

                if (request.SelectedAilments != null && request.SelectedAilments.Length > 0)
                {
                    var ailments = db.Ailments
                    .Where(a => request.SelectedAilments.Contains(a.Id))
                    .ToList();

                    //product.Ailments = ailments;
                }

                db.Products.Add(product);
                db.SaveChanges();
            }
        }
    }
}