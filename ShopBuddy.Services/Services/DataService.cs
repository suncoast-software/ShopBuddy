namespace ShopBuddy.Services.Services;
public class DataService : IDataService
{
    public Config GetConfigurationJson()
    {
        var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", "config.json");
        using var fs = File.OpenRead(configFile);
        using var sr = new StreamReader(fs, new UTF8Encoding(false));
        var json = sr.ReadToEnd();

        var configJson = JsonConvert.DeserializeObject<Config>(json);

        return configJson;
    }

    public async Task<List<WebItem>> GetWebItemsByCategoryAsync(string category)
    {
        var items = new List<WebItem>();
        var httpClient = new HttpClient();
        var tshirtInventory = await httpClient.GetAsync($"https://api.ssactivewear.com/v2/categories/{category}");
        tshirtInventory.EnsureSuccessStatusCode();

        var json = await tshirtInventory.Content.ReadAsStringAsync();
        items = JsonConvert.DeserializeObject<List<WebItem>>(json);
        return items;
    }

    public async Task<List<WebItem>> GetWebItemsByStyleAsync(string style)
    {
        var items = new List<WebItem>();
        var httpClient = new HttpClient();
        var tshirtInventory = await httpClient.GetAsync($"https://api.ssactivewear.com/v2/style/{style}");
        tshirtInventory.EnsureSuccessStatusCode();

        var json = await tshirtInventory.Content.ReadAsStringAsync();
        items = JsonConvert.DeserializeObject<List<WebItem>>(json);
        return items;
    }

    public async Task<WebOrder> GetOrderByIdAsync(string id)
    {
        return null;
    }
}

