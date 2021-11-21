namespace ShopBuddy.Data.Models;
public class ApplicationUser
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public Rank Rank { get; set; }
    public bool IsLoggedIn { get; set; }
}
