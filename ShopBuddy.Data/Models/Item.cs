namespace ShopBuddy.Data.Models;

public class Item
{
    [Key]
    public int Id { get; set; }
    [StringLength(50)]
    public string? Name { get; set; }
    [StringLength(500)]
    public string? Desc { get; set; }
    public decimal Price { get; set; }

}

