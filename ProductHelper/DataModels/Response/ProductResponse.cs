using System.Collections.Generic;

namespace DataModels.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<AilmentResponse> Ailments { get; set; }

        public List<IngredientResponse> Ingredients { get; set; }
    }
}
