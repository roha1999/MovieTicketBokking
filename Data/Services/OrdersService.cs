using eCommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppdbContext _context;

        public OrdersService(AppdbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _context.Order.Include(n => n.OrderItems).ThenInclude(n => n.Movies).Where(n => n.UserId == userId).ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem>items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach(var item in items)
            {
                    var orderItem = new OrderItem()
                    {
                        Amount = item.Amount,
                        MovieId = item.Movie.Id,
                        OrderId = order.Id,
                        Price = item.Movie.Price
                    };
                    await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();  
        }
    }
}
