using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NaturalisBackend.Database;
using NaturalisBackend.Models;
using NaturalisBackend.Services;
using Newtonsoft.Json;
using System.Text.Json;

namespace NaturalisBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly NaturalisContext _context;

        public ProductController(ProductService productService, NaturalisContext context)
        {
            _productService = productService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _productService.GetProducts();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> AddPurchase([FromBody] PurchaseDto purchaseData)
        {
            if (purchaseData == null)
            {
                return BadRequest("Invalid purchase data.");
            }

            List<CartItemDto> cartItems = purchaseData.Cart;

            var existingUser = await _context.Users
                                              .FirstOrDefaultAsync(u => u.Cpf == purchaseData.User.Cpf);

            User user;
            if (existingUser != null)
            {
                user = existingUser;
            }
            else
            {
                user = new User
                {
                    Name = purchaseData.User.Name,
                    Email = purchaseData.User.Email,
                    Cpf = purchaseData.User.Cpf
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            var delivery = new Delivery
            {
                Address = purchaseData.Delivery.Address,
                Zip = purchaseData.Delivery.Zip,
                UserId = user.UserId
            };

            var payment = new Payment
            {
                Method = purchaseData.Payment.Method,
                CardNumber = purchaseData.Payment.CardNumber,
                Expiry = purchaseData.Payment.Expiry,
                Cvv = purchaseData.Payment.Cvv,
                UserId = user.UserId
            };

            var purchase = new Purchase
            {
                UserId = user.UserId,
                DeliveryData = delivery,
                PaymentData = payment,
                CartItems = cartItems.Select(c => new CartItem
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    ProductName = c.ProductName,
                    ProductPrice = c.ProductPrice,
                    ProductDescription = c.ProductDescription,
                    ProductType = c.ProductType
                }).ToList()
            };

            _context.Purchases.Add(purchase);
            _context.Deliveries.Add(delivery);
            _context.Payments.Add(payment);  

            await _context.SaveChangesAsync();

            return Ok(new { message = "Purchase saved successfully" });
        }

        [HttpGet, Route("GetPurchasesByCpf/{cpf}")]
        public async Task<IActionResult> GetPurchasesByCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                return BadRequest("CPF is required.");
            }

            // Find the user with the given CPF
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Cpf == cpf);
            if (user == null)
            {
                return NotFound("User with the provided CPF not found.");
            }

            // Get the purchases for the user
            var purchases = await _context.Purchases
                .Where(p => p.UserId == user.UserId)
                .Include(p => p.CartItems)
                .ToListAsync();

            if (purchases == null || !purchases.Any())
            {
                return NotFound("No purchases found for the user.");
            }

            var response = purchases.Select(p => new
            {
                PurchaseId = p.Id,
                UserId = p.UserId,
                CartItems = p.CartItems.Select(c => new
                {
                    c.ProductId,
                    c.ProductName,
                    c.Quantity,
                    c.ProductPrice,
                    c.ProductDescription,
                    c.ProductType
                })
            });

            return Ok(response);

        }



    }
}
