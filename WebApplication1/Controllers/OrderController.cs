using Azure.Core;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Stripe.Climate;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUserRepo userRepo;
        private readonly ICartRepo cartRepo;
        private readonly IOrderRepo orderRepo;
        private readonly IProductRepo productRepo;
        private readonly ICategoryRepo categoryRepo;
        private readonly PaymentService paymentService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string ApiKey = "ZXlKaGJHY2lPaUpJVXpVeE1pSXNJblI1Y0NJNklrcFhWQ0o5LmV5SmpiR0Z6Y3lJNklrMWxjbU5vWVc1MElpd2ljSEp2Wm1sc1pWOXdheUk2TVRBeU1EQXpOaXdpYm1GdFpTSTZJbWx1YVhScFlXd2lmUS5BZFJCb2lFak80V1FpcE41ellmSmpiOHRrWGV3ZDNuVVVBS0ZOUnBHWHRpU2Ryc1NlcU5hZVJrRGlmT0paVjB5NGtBbWF0dnlMZXhsNm9sRFNHYVhpUQ==";
        private readonly string IntegrationId = "4936184";

        public OrderController(PaymentService paymentService,IHttpClientFactory httpClientFactory, IUserRepo userRepo,ICartRepo cartRepo,IOrderRepo orderRepo, IProductRepo productRepo, ICategoryRepo categoryRepo)
        {
            this.paymentService = paymentService;
            _httpClientFactory = httpClientFactory;
            this.userRepo = userRepo;
            this.cartRepo = cartRepo;
            this.orderRepo = orderRepo;
            this.productRepo = productRepo;
            this.categoryRepo = categoryRepo;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult AllOrders()
        {
            return View( orderRepo.GetOrders());
        }
        public IActionResult Index()
        {
            return Json(orderRepo.OrderList(User.Identity.GetUserId()));
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MakeOrder()
        {
            string username = User.Identity.Name;
            var user = userRepo.GetByName(username);

            var existingOrder = orderRepo.GetOrder(user.Id);

            if (existingOrder != null && existingOrder.OrderState == "Pending" && existingOrder.PaymentMethod==" ")
            {
                TempData["Success"] = "You already have a pending order. Please choose a payment method to proceed.";
                return RedirectToAction("OrderConfirmation", new { orderId = existingOrder.Id });
            }

            var cartItems = cartRepo.GetCartItems(user.CartId);

            if (cartItems == null || !cartItems.Any())
            {
                TempData["Error"] = "Your cart is empty. Please add items before making an order.";
                return RedirectToAction("Index", "Cart");
            }

            try
            {
                var orderitems = new List<OrderItem>();
                foreach (var item in cartItems)
                {
                    var orderItem = new OrderItem
                    {
                        CartId = user.CartId,
                        Quantity = item.Quantity,
                        Price = item.Quantity * productRepo.GetByID(item.ProductId).price
                    };

                    orderitems.Add(orderItem);
                }

                var newOrder = new Order
                {
                    CreateDate = DateTime.Now,
                    Email = user.Email,
                    IsPaid = false,
                    Items = orderitems,
                    IsDeleted = false,
                    OrderState = "Pending",
                    Address = user.address,
                    UserId = user.Id,
                    OrderPrice = orderitems.Sum(x => x.Price),
                    MobileNumber = user.PhoneNumber,
                    PaymentMethod = " "
                };

                orderRepo.MakeOrder(newOrder);
                orderRepo.Save();

                TempData["Success"] = "Your order has been placed successfully! Please select a payment method.";
                return RedirectToAction("OrderConfirmation", new { orderId = newOrder.Id });
            }
            catch (Exception ex)
            {
                TempData["Faild"] = "To Make order you have to complete this information";
                return RedirectToAction("Edit", "Profile");
            }
        }
        [HttpGet]
        public IActionResult OrderConfirmation(int orderId)
        {
            string username = User.Identity.Name;
            var user = userRepo.GetByName(username);
            ViewBag.PaymentMethods = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem { Text = "Pay using Visa", Value = "Visa" },
                    new SelectListItem { Text = "Cash on Delivery", Value = "Cash" }
                }, "Value", "Text");

            var order = orderRepo.GetOrder(orderId);

            if (order == null || order.UserId != user.Id)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderConfirmation(int id, string paymentMethod)
        {
            string username = User.Identity.Name;
            var user = userRepo.GetByName(username);
            var order = orderRepo.GetOrder(id);

            if (order == null || order.UserId != user.Id)
            {
                TempData["Error"] = "Order not found or unauthorized access.";
                return RedirectToAction("Index", "Home");
            }

            order.PaymentMethod = paymentMethod;
            if (order.PaymentMethod == "Cash")
            {
                orderRepo.update(order);
                orderRepo.Save();
                cartRepo.ClearCart(user.CartId);
                cartRepo.save();
                TempData["Success"] = "Your order has been confirmed successfully!";
                return RedirectToAction("Index", "Home");
            }
            else if (order.PaymentMethod == "Visa")
            {
                var paymentKey = await paymentService.CreatePaymentOrder(order);
                if (string.IsNullOrEmpty(paymentKey))
                {
                    TempData["Error"] = "Failed to initialize payment. Please try again.";
                    return RedirectToAction("OrderConfirmation", new { orderId = id });
                }

                var paymentUrl = $"https://accept.paymob.com/api/acceptance/iframes/896252?payment_token={paymentKey}";
                return Redirect(paymentUrl);
            }

            TempData["Error"] = "Invalid payment method.";
            return RedirectToAction("OrderConfirmation", new { orderId = id });
        }

        [HttpGet]
        public IActionResult GetOrder()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(orderRepo.OrderList(userId));
        }

        public IActionResult UpdateOrderState([FromBody] UpdateOrderStateRequest request)
        {
           
                var order = orderRepo.GetOrder(request.OrderId);
                if (order != null)
                {
                    order.OrderState = request.NewState;
                    orderRepo.Save();
                    return Json(new { success = true, message = "Order state updated successfully!" });
                }
                return Json(new { success = false, message = "Order not found." });
        }

        public IActionResult DeleteOrder(int orderId)
        {
            try
            {
                var order = orderRepo.GetOrder(orderId);
                if (order != null)
                {
                    orderRepo.CancelOrder(orderId);
                    orderRepo.Save();  // Ensure Save is functioning properly
                    return Json(new { success = true, message = "Order deleted successfully!" });
                }
                return Json(new { success = false, message = "Order not found." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }
        public IActionResult DeleteOrders([FromBody] List<int> orderIds)
        {
            foreach (var orderId in orderIds)
            {
                var order = orderRepo.GetOrder(orderId);
                if (order != null)
                {
                    orderRepo.CancelOrder(orderId);
                }
            }
            orderRepo.Save();
            return Json(new { success = true, message = "Selected orders deleted successfully!" });
        }


        public IActionResult SearchOrders(string searchTerm, string orderState)
        {
            var orders = orderRepo.GetOrders(); 

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                orders = orders.Where(o =>
                    userRepo.GetNameById(o.UserId).ToLower().Contains(searchTerm) ||
                    o.Email.ToLower().Contains(searchTerm) ||
                    o.MobileNumber.ToLower().Contains(searchTerm) ||
                    o.Address.ToLower().Contains(searchTerm)
                ).ToList();
            }

            if (!string.IsNullOrEmpty(orderState) && orderState != "All")
            {
                orders = orders.Where(o => o.OrderState == orderState).ToList();
            }

            return PartialView("_OrderTable", orders);
        }


              public IActionResult CancelOrder(int orderId)
      {
          var order = orderRepo.GetOrder(orderId);
          if (order != null)
          {
              if (order.OrderState == "Pending")
              {
                  TempData["Order"] = "Order Canceled";
                  orderRepo.CancelOrder(orderId);
              }

              else
              {
                  TempData["Order"] = "Sorry now we can't cancel the order";
                  return RedirectToAction("Index", "Home");
              }
          }
          return RedirectToAction("Index", "Home");
      }





    }

}
