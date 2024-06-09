using System.Net.Http.Headers;
using FoodPlannerAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
// using System.IO;

public class AppDbContext : IdentityDbContext<UserModel>
{
    internal DbSet<UserModel> User {get; set;}

    public DbSet<RecipeListModel> RecipeList {get; set;}

    internal DbSet<ListDetailsModel> ListDetails {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext>options) : base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
    }

}