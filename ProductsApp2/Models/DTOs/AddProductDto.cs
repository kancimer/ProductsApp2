﻿namespace ProductsApp2.Models.DTOs
{
    public class AddProductDto
    {
        
        public string? ProductImageUrl { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
    }
}
