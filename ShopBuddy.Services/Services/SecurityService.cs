namespace ShopBuddy.Services.Services;
public class SecurityService : ISecurity
{
    public Guid CreateUserGuid()
    {
        return Guid.NewGuid();
    }

    public string GenerateSalt()
    {
        byte[] bytes = new byte[128/8];
        using var salt = RandomNumberGenerator.Create();
        salt.GetBytes(bytes);
        return BitConverter.ToString(bytes).Replace("-", "").ToLower(); 

    }

    public string Hash(string input, string salt)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(salt + input));
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            
    }
}

