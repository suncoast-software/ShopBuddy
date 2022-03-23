
namespace ShopBuddy.Services.Interfaces;
public interface IDataService
{
    Config GetConfigurationJson();
    Task<List<WebItem>> GetWebItemsByCategoryAsync(string category);
    Task<List<WebItem>> GetWebItemsByStyleAsync(string style);
    Task<WebOrder> GetOrderByIdAsync(string id);

}

