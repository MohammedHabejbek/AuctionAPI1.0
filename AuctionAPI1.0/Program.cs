using AuctionAPI1._0.Data;
using AuctionAPI1._0.Repositories;
using AuctionAPI1._0.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });


builder.Services.AddSingleton<AuctionAPI1._0.Data.DapperContext>();


builder.Services.AddScoped<AuctionAPI1._0.Repositories.IUserRepository, AuctionAPI1._0.Repositories.UserRepository>();
builder.Services.AddScoped<AuctionAPI1._0.Repositories.IAuctionRepository, AuctionAPI1._0.Repositories.AuctionRepository>();
builder.Services.AddScoped<AuctionAPI1._0.Repositories.IBidRepository, AuctionAPI1._0.Repositories.BidRepository>();

builder.Services.AddScoped<JwtService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
