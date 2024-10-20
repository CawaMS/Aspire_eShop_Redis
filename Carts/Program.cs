using StackExchange.Redis;
using Carts.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddRedisClient("cache");

var app = builder.Build();

app.MapDefaultEndpoints();

// Get Redis connection
var _redisConnectionMultiplexer = app.Services.GetRequiredService<IConnectionMultiplexer>();

// Configure the HTTP request pipeline.
app.MapCartEndpoints(_redisConnectionMultiplexer);

app.UseStaticFiles();

app.Run();

