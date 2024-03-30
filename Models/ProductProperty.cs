namespace WA_InfoShop.Models;

public class ProductProperty : Entity
{
    public string ProductId { get; set; }
    public Product? Product { get; set; }
    public string PropertyId { get; set; }
    public Property? Property { get; set; }
    public string Name { get; set; }
}
