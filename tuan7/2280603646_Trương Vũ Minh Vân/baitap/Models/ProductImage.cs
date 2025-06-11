﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class ProductImage
{
    public int Id { get; set; }
    public string Url { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}