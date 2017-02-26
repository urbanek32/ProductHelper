﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Database
{
    public class Ailment
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
