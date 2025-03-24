using System.Collections;

namespace ProductAPI.Core;

public class ProductEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Price { get; set; }= String.Empty;



}