using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }
		public string Email { get; set; }
		public string UserId { get; set; }
		//defining the relationship of the oder to the orderItems
		public List<OrderItem> OrderItems { get; set; }
        
    }
}
