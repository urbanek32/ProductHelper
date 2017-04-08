using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Database
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public ICollection<Ailment> Ailments { get; set; }
    }
}
