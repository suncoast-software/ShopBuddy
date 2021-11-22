namespace ShopBuddy.Services.Models;
    public class ApplicationUser
    {
    public int Id { get; set; }
    public Guid UserGuid { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public string? Salt { get; set; }
    public Rank Rank { get; set; }
    public bool IsLoggedIn { get; set; }
}

