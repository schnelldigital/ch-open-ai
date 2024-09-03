# Role

You are responsible for implementing the documentation of a software project. Based on program code, you anticipate the functionalities and create documentation.

## Goal

Use the following code, which was implemented in **C#**. Utilize the available information and references to anticipate the functionalities provided by this program module.

The format should be a technical documentation that helps:

- Introduce new employees to the project
- Improve error analysis and debugging
- Clarify and explain the flow and properties of the program

## Code

```C#
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// Modell-Klassen
public class User
{
    public Guid ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Address Address { get; set; }
}

public class Product
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool Availability { get; set; }
}

public class Order
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public Guid ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatus Status { get; set; }
}

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

public class Address
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}

// Interface für den Order Service
public interface IOrderService
{
    Task<Guid> PlaceOrderAsync(Guid userId, Guid productId, int quantity);
    Task<bool> SetOrderStatusAsync(Guid orderId, OrderStatus status);
    Task<bool> CancelOrderAsync(Guid orderId);
}

// Implementierung des Order Services
public class OrderService : IOrderService
{
    private readonly YourDbContext _dbContext;

    public OrderService(YourDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> PlaceOrderAsync(Guid userId, Guid productId, int quantity)
    {
        // Validate input parameters
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        var product = await _dbContext.Products.FindAsync(productId);
        if (product == null || !product.Availability)
            throw new ArgumentException("Product not available.");

        var user = await _dbContext.Users
            .Include(u => u.Address)
            .FirstOrDefaultAsync(u => u.ID == userId);
        if (user == null)
            throw new ArgumentException("User not found.");

        // Calculate total price
        decimal totalPrice = product.Price * quantity;

        // Create new order
        var order = new Order
        {
            ID = Guid.NewGuid(),
            UserID = userId,
            ProductID = productId,
            Quantity = quantity,
            TotalPrice = totalPrice,
            Status = OrderStatus.Pending
        };

        // Add order to database
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();

        return order.ID;
    }

    public async Task<bool> SetOrderStatusAsync(Guid orderId, OrderStatus status)
    {
        var order = await _dbContext.Orders.FindAsync(orderId);
        if (order == null)
            return false;

        order.Status = status;
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> CancelOrderAsync(Guid orderId)
    {
        var order = await _dbContext.Orders.FindAsync(orderId);
        if (order == null)
            return false;

        // Only cancel orders that are not yet shipped or delivered
        if (order.Status == OrderStatus.Pending || order.Status == OrderStatus.Processing)
        {
            order.Status = OrderStatus.Cancelled;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false; // Cannot cancel orders that are already shipped or delivered
    }
}

// Beispiel für die Verwendung des OrderService
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("placeorder")]
    public async Task<IActionResult> PlaceOrder(Guid userId, Guid productId, int quantity)
    {
        try
        {
            var orderId = await _orderService.PlaceOrderAsync(userId, productId, quantity);
            return Ok($"Order placed successfully with ID: {orderId}");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to place order: {ex.Message}");
        }
    }

    [HttpPut("setorderstatus")]
    public async Task<IActionResult> SetOrderStatus(Guid orderId, OrderStatus status)
    {
        try
        {
            var success = await _orderService.SetOrderStatusAsync(orderId, status);
            if (success)
                return Ok($"Order status updated successfully.");
            else
                return NotFound($"Order with ID {orderId} not found.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to update order status: {ex.Message}");
        }
    }

    [HttpDelete("cancelorder")]
    public async Task<IActionResult> CancelOrder(Guid orderId)
    {
        try
        {
            var success = await _orderService.CancelOrderAsync(orderId);
            if (success)
                return Ok($"Order cancelled successfully.");
            else
                return NotFound($"Order with ID {orderId} not found or cannot be cancelled.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to cancel order: {ex.Message}");
        }
    }
}

```
