namespace ShopBuddy.Data.Models;
public class ApplicationUser
{
    [Key]
    public int Id { get; set; }
    [StringLength(500)]
    public Guid UserGuid { get; set; }
    [StringLength(50)]
    public string? Username { get; set; }
    [StringLength(500)]
    public string? PasswordHash { get; set; }
    [StringLength(100)]
    public string? Email { get; set; }
    [StringLength(500)]
    public string? Salt { get; set; }
    [StringLength(50)]
    public Rank Rank { get; set; }
    public bool IsLoggedIn { get; set; }
}
