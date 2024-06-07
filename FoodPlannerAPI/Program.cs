using System.Security.Cryptography.Xml;
using FoodPlannerAPI.Models;
using FoodPlannerAPI.Services;
using FoodPlannerAPI.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthentication();

builder.Services.AddSwaggerGen(c => 
{
    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
        },
        []
    }}
    );
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddTransient<IRecipeService, RecipeService>();
builder.Services.AddScoped<IUserContext, UserContext>();
builder.Services.AddHttpContextAccessor();

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityApiEndpoints<UserModel>().AddEntityFrameworkStores<AppDbContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<UserModel>();

app.UseAuthorization();

app.MapControllers();

app.Run();

