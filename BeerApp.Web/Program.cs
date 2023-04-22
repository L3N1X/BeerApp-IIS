using BeerApp.Dao.Services.Implementation;
using BeerApp.Dao.Services.Interface;
using BeerApp.Web.Authentication.Configuration;
using BeerApp.Web.Authentication.Services.Implementations;
using BeerApp.Web.Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Jwt
var jwtConfiguration = builder.Configuration
    .GetSection("Jwt")
    .Get<JwtConfiguration>() ?? throw new ArgumentNullException("No JWT configuration");
builder.Services.AddSingleton(jwtConfiguration!);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfiguration!.Issuer,
            ValidAudience = jwtConfiguration!.Audience,
            IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key!))
        };
    });

// Add custom services to the container
builder.Services.AddTransient<IXmlValidationService, XmlValidationService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Beer}/{action=ValidateBeer}/{id?}");

app.Run();
