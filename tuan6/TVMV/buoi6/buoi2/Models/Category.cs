﻿using System.ComponentModel.DataAnnotations;

namespace buoi2.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
