using DataEntities;
using StackExchange.Redis;

namespace Carts.Endpoints;

public static class CartEndpoints
{
    public static void MapCartEndpoints(this IEndpointRouteBuilder routes, IConnectionMultiplexer connectionMultiplexer)
    {
        var group = routes.MapGroup("/api/Cart");
        IDatabase RedisDb = connectionMultiplexer.GetDatabase();

        group.MapGet("/", async () =>
        {
            return new List<CartItem>();
        })
        .WithName("GetAllProducts")
        .Produces<List<CartItem>>(StatusCodes.Status200OK);
    }
}
