﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Product
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; }
    [Range(0.01, 10000.00)]
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    
}
