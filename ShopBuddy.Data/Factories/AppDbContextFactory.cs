
using Microsoft.EntityFrameworkCore.Design;
using ShopBuddy.Services.Services;
using System;

namespace ShopBuddy.Data.Factories;
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>, IDisposable
{
    public AppDbContext CreateDbContext(string[] args = null)
    {
        var dataService = new DataService();
        var conString = dataService.GetConfigurationJson();
        var connStr = conString.ConnectionString;
        var options = new DbContextOptionsBuilder<AppDbContext>();

        options.UseNpgsql(connStr);

        return new AppDbContext(options.Options);

    }

    public void Dispose()
    {
        this.Dispose();
    }
}

