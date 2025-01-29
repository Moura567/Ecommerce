using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.ViewModels;

[Authorize]
public class CartController : Controller
{
    private readonly IUserRepo userRepo;
    private readonly ICartRepo cartRepo;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IProductRepo productRepo;
    private readonly ICategoryRepo categoryRepo;

    public CartController(IUserRepo userRepo,ICartRepo cartRepo, UserManager<ApplicationUser> userManager,IProductRepo productRepo,ICategoryRepo categoryRepo)
    {
        this.userRepo = userRepo;
        this.cartRepo = cartRepo;
        this.userManager = userManager;
        this.productRepo = productRepo;
        this.categoryRepo = categoryRepo;
    }


    public async Task<IActionResult> Index()
    {
        var claims=User.Claims.ToList();
        var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var user = await userManager.FindByEmailAsync(email);

        if (user == null || user.CartId == null)
        {
            return View("Index");
        }

        var cartId = user.CartId;
        var cartItems = cartRepo.GetCartItems(cartId);
        var items=new List<CartItemViewModel>();
        foreach (var cartItem in cartItems)
        {
            var product= productRepo.GetByID(cartItem.ProductId);
            items.Add(new CartItemViewModel() 
            {   Id=product.Id
                ,Name = product.Name,
                image = product.image,
                totalprice = cartItem.Quantity * product.price,
                Quantity=cartItem.Quantity,
                categoryName=categoryRepo.GetName(cartItem.product.categoryId) });
        }
        if (cartItems == null || !cartItems.Any())
        {
            return View("Index");
        }

        return View("Index", items);
    }
    [Authorize]
    [HttpGet]
    public JsonResult GetCartCount()
    {
        try
        {
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                var user = userRepo.GetByName(username);

                var cartID = user.CartId;
                var cart = cartRepo.GetByID(cartID);

                if (cart == null)
                {
                    return Json(new { totalItems = 0 });
                }

                int totalItems = cartRepo.GetTotalItemsInCart(cartID);
                return Json(new { totalItems });
            }
        }

        catch (Exception ex)
        {
            return Json(new { error = ex.Message });
        }
        return Json(new { error =User});
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<JsonResult> AddToCart(int productId, int quantity)
    {
        try
        {
            string username = User.Identity.Name;
            var user = userRepo.GetByName(username);

            var cartID = user.CartId;
            var cart = cartRepo.GetByID(cartID);

            if (cart == null)
            {
                throw new Exception("Unable to retrieve or create the cart.");
            }

            var product = productRepo.GetByID(productId);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            if (quantity > product.amount)
            {
                return Json(new { error = "Quantity exceeds available stock." });
            }

            var existingCartItem = cartRepo.GetCartItem(cart.Id, productId);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
                cartRepo.UpdateCartItem(existingCartItem);
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = quantity
                };
                cartRepo.AddToCart(cartItem);
            }

            product.amount -= quantity;
            productRepo.Update(product);
            productRepo.Save();

            cartRepo.save();

            int totalItems = cartRepo.GetTotalItemsInCart(cart.Id);
            return Json(new { totalItems, updatedAmount = product.amount, productId });
        }
        catch (Exception ex)
        {
            return Json(new { error = ex.Message });
        }
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<JsonResult> RemoveFromCart(int productId, int quantity)
    {
        try
        {
            string username = User.Identity.Name;
            var user = userRepo.GetByName(username);

            var cartID = user.CartId;
            var cart = cartRepo.GetByID(cartID);
            if (cart == null)
            {
                return Json(new { totalItems = 0, error = "Cart not found." });
            }

            var product = productRepo.GetByID(productId);
            var existingCartItem = cartRepo.GetCartItem(cart.Id, productId);

            if (existingCartItem != null)
            {
                if (quantity > existingCartItem.Quantity)
                {
                    return Json(new { totalItems = 0, error = "Quantity exceeds the quantity in the cart." });
                }

                existingCartItem.Quantity -= quantity;

                if (existingCartItem.Quantity <= 0)
                {
                    cartRepo.RemoveFromCart(existingCartItem);
                }
                else
                {
                    cartRepo.UpdateCartItem(existingCartItem);
                }

                product.amount += quantity;
                productRepo.Update(product);
                productRepo.Save();
                cartRepo.save();
            }

            int totalItems = cartRepo.GetTotalItemsInCart(cart.Id);
            return Json(new { totalItems, productId, updatedAmount = product.amount });
        }
        catch (Exception ex)
        {
            return Json(new { totalItems = 0, error = ex.Message });
        }
    }

    public IActionResult EmptyCart()
    {
        string username = User.Identity.Name;
        var user = userRepo.GetByName(username);

        var cartID = user.CartId;
        var cart = cartRepo.GetByID(cartID);
        var cartitems = cartRepo.GetCartItems(cartID);
        if (cart != null||cartitems.Any())
        {
            foreach (var item in cart.Items)
            {
                var product = productRepo.GetByID(item.ProductId);
                if (product != null)
                {
                    product.amount += item.Quantity;
                    productRepo.Update(product);
                }
            }

            cart.Items.Clear();
            cartRepo.save(); 
        }

        return RedirectToAction("Index","Home");
    }

}