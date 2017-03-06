using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Request
{
    public class CreateAilmentRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
