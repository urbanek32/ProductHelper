using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DataModels.Database;

namespace ProductHelper.Database
{
    public class PhInitializer : DropCreateDatabaseIfModelChanges<PhDbContext>
    {
        protected override void Seed(PhDbContext context)
        {
            var ailment1 = new Ailment { Id = 1, Name = "Headache" };
            var ailment2 = new Ailment { Id = 2, Name = "Neck pain" };
            var ailment3 = new Ailment { Id = 3, Name = "Back pain" };

            context.Ailments.AddOrUpdate(a => a.Id,
                ailment1, 
                ailment2, 
                ailment3
            );

            var product1 = new Product { Id = 1, Name = "Apap", Ailments = new List<Ailment>() };
            var product2 = new Product { Id = 2, Name = "Gripex", Ailments = new List<Ailment>() };
            var product3 = new Product { Id = 3, Name = "Ibuprom", Ailments = new List<Ailment>() };
            var product4 = new Product { Id = 4, Name = "Fervex" };

            product1.Ailments.Add(ailment1);
            product1.Ailments.Add(ailment2);
            product2.Ailments.Add(ailment2);
            product3.Ailments.Add(ailment3);

            context.Products.AddOrUpdate(p => p.Id,
                product1,
                product2,
                product3,
                product4
            );

            context.SaveChanges();
        }
    }
}