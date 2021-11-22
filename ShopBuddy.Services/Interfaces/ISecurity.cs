namespace ShopBuddy.Services.Interfaces;
public interface ISecurity
{
    string Hash(string input, string salt);
    string GenerateSalt();
    Guid CreateUserGuid();
}

