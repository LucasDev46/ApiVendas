﻿namespace Loja.Dtos.ProductMapper;

public class PostProductDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int stock { get; set; }
    public long CategoryId { get; set; }
}
