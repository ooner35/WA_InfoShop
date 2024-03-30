namespace WA_InfoShop.Models;

public class Cart : Entity
{
    public string UserId { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }

    public ApplicationUser? User { get; set; }
    public Product? Product { get; set; }
}
