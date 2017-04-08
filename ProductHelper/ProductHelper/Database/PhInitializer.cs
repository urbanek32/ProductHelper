using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DataModels.Database;

namespace ProductHelper.Database
{
    public class PhInitializer : DropCreateDatabaseAlways<PhDbContext>
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

            var ingredient1 = new Ingredient { Id = 1, Name = "Sugar", CureAilments = new List<Ailment>() };
            var ingredient2 = new Ingredient { Id = 2, Name = "Mint", CureAilments = new List<Ailment>() };
            var ingredient3 = new Ingredient { Id = 3, Name = "Water", CureAilments = new List<Ailment>() };
            var ingredient4 = new Ingredient { Id = 4, Name = "Calcium", CureAilments = new List<Ailment>() };

            ingredient1.CureAilments.Add(ailment1);

            ingredient2.CureAilments.Add(ailment2);

            ingredient3.CureAilments.Add(ailment2);
            ingredient3.CureAilments.Add(ailment3);

            ingredient4.CureAilments.Add(ailment3);

            context.Ingredients.AddOrUpdate(p => p.Id,
                ingredient1,
                ingredient2,
                ingredient3,
                ingredient4
            );

            var product1 = new Product { Id = 1, Name = "Apap", Ingredients = new List<Ingredient>(), Ailments = new List<Ailment>() };
            var product2 = new Product { Id = 2, Name = "Gripex", Ingredients = new List<Ingredient>(), Ailments = new List<Ailment>() };
            var product3 = new Product { Id = 3, Name = "Ibuprom", Ingredients = new List<Ingredient>(), Ailments = new List<Ailment>() };
            var product4 = new Product { Id = 4, Name = "Nurofen", Ingredients = new List<Ingredient>(), Ailments = new List<Ailment>() };

            product1.Ingredients.Add(ingredient1);
            product1.Ingredients.Add(ingredient2);
            product1.Ingredients.Add(ingredient3);
            product1.Ingredients.Add(ingredient4);
            UpdateAilments(product1);

            product2.Ingredients.Add(ingredient2);
            UpdateAilments(product2);

            product3.Ingredients.Add(ingredient2);
            product3.Ingredients.Add(ingredient3);
            UpdateAilments(product3);

            product4.Ingredients.Add(ingredient4);
            UpdateAilments(product4);

            context.Products.AddOrUpdate(p => p.Id,
                product1,
                product2,
                product3,
                product4
            );

            context.SaveChanges();
        }

        private void UpdateAilments(Product product)
        {
            product.Ailments = product.Ingredients
                .SelectMany(p => p.CureAilments)
                .Distinct()
                .ToList();
        }
    }
}