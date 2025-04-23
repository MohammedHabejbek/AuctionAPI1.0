var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<AuctionAPI1._0.Data.DapperContext>();


builder.Services.AddScoped<AuctionAPI1._0.Repositories.IUserRepository, AuctionAPI1._0.Repositories.UserRepository>();
builder.Services.AddScoped<AuctionAPI1._0.Repositories.IAuctionRepository, AuctionAPI1._0.Repositories.AuctionRepository>();
builder.Services.AddScoped<AuctionAPI1._0.Repositories.IBidRepository, AuctionAPI1._0.Repositories.BidRepository>();

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

app.MapControllers();

app.Run();
