using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Request
{
    public class CreateProductRequest
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Select associated ailments")]
        public ICollection<int> AilmentsCollection { get; set; }
    }
}
