using eCommerceApp.Data.Cart;
using eCommerceApp.Data.Services;
using eCommerceApp.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Controllers
{
	public class OrdersController : Controller
	{
		private readonly IMoviesService _moviesService;
		private readonly ShoppingCart _shoppingCart;
		private readonly IOrdersService _ordersService;

		public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart, IOrdersService ordersService)
		{
			_moviesService = moviesService;
			_shoppingCart = shoppingCart;
			_ordersService = ordersService;	
		}

		public async Task<IActionResult> Index()
        {
			string userId = "";
			var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
			return View(orders);
        }

		public IActionResult ShoppingCart()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			_shoppingCart.ShoppingCartItems = items;
			var resopnse = new ShoppingCartVM()
			{
				ShoppingCart = _shoppingCart,
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
			};

			return View(resopnse);
		}
		public async Task<IActionResult> AddItemToShoppingCart(int id)
		{
			var item = await _moviesService.GetMoviesByIdAsync(id);

			if(item != null)
			{
				_shoppingCart.AddItemToCart(item);
			}
			return RedirectToAction(nameof(ShoppingCart));
		}

		public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
		{
			var item = await _moviesService.GetMoviesByIdAsync(id);

			if (item != null)
			{
				_shoppingCart.RemoveItemFromCart(item);
			}
			return RedirectToAction(nameof(ShoppingCart));
		}

		public async Task<IActionResult> CompleteOrder()
        {
			var items = _shoppingCart.GetShoppingCartItems();
			string userId = "";
			string userEmailAdress = "";

			await _ordersService.StoreOrderAsync(items, userId, userEmailAdress);
			await _shoppingCart.ClearShoppingCartAsync();

			return View("OrderCompleted");
		}
	}
}
