using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Database
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Ailment> CureAilments { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
