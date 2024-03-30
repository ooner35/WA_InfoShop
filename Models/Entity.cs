namespace WA_InfoShop.Models;

public abstract class Entity
{
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public Entity()
    {
        this.Id = Guid.NewGuid().ToString();
    }
}
