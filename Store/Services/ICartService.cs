using DataEntities;

namespace Store.Services;

public interface ICartService
{
    Task TransferCart(string anonymousId, string userName);
    Task AddItem(string username, int catalogItemId, decimal price, int quantity = 1);
    Task<Cart> SetQuantities(int cartId, Dictionary<string, int> quantities);
    Task DeleteCart(string cartId);
    Task<Cart?> GetCart(string cartId);
    IAsyncEnumerable<CartItem> GetCartItems(string username);

}
