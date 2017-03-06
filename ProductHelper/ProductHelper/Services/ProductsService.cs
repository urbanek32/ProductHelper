using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataModels.Database;
using DataModels.Request;
using DataModels.Response;
using ProductHelper.Database;

namespace ProductHelper.Services
{
    public interface IProductsService
    {
        Task<Product> GetById(int id);
        Task<List<ProductResponse>> GetListByAilmentsId(ProductRequest request);
        void CreateProduct(CreateProductRequest request);
    }

    public class ProductsService : IProductsService
    {
        public ProductsService()
        {
            
        }

        public async Task<Product> GetById(int id)
        {
            using (var db = new PhDbContext())
            {
                var product = await db.Products
                    .Include(p => p.Ailments)
                    .SingleOrDefaultAsync(p => p.Id == id);

                return product;
            }
        }

        public async Task<List<ProductResponse>> GetListByAilmentsId(ProductRequest request)
        {
            using (var db = new PhDbContext())
            {
                var products = await db.Products
                    .Include(p => p.Ailments)
                    .Where(p => p.Ailments.Any(a => request.AilmentsIds.Contains(a.Id)))
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

                if (request.AilmentsCollection != null && request.AilmentsCollection.Count > 0)
                {
                    var ailments = db.Ailments
                    .Where(a => request.AilmentsCollection.Contains(a.Id))
                    .ToList();

                    product.Ailments = ailments;
                }

                db.Products.Add(product);
                db.SaveChanges();
            }
        }
    }
}