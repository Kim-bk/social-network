using SocialNetwork;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Models;

var builder = WebApplication.CreateBuilder(args);

var configurationBuilder = new ConfigurationBuilder()
                            .SetBasePath(builder.Environment.ContentRootPath)
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables();

builder.Configuration.AddConfiguration(configurationBuilder.Build());

// Add services to the container.


var defaultConnectionString = string.Empty;
defaultConnectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<SocialNetworkContext>(
    options =>
    {
        options.UseSqlServer(defaultConnectionString);
        options.UseLazyLoadingProxies();
    }
    );

var serviceProvider = builder.Services.BuildServiceProvider();

try
{
    var dbContext = serviceProvider.GetRequiredService<SocialNetworkContext>();
    dbContext.Database.Migrate();
}
catch
{
}

///----
var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(
      options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
  );

app.Run();