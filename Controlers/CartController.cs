using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;
using System.Text.Json;
using WA_InfoShop.Models;

namespace WA_InfoShop.Controlers;

public class CartController : Controller
{
    private readonly ApplicationContext _context;

    public CartController(ApplicationContext context)
    {
        _context = context;
    }

    public IActionResult List()
    {
        return View();
    }

    public IActionResult Add(string id)
    {
        var cartItem = _context.Carts.Where(c => c.UserId == "43d6af2e-df5e-4a0a-9916-b2e45bb0b803" & c.ProductId == id).FirstOrDefault();

        if (cartItem == null)
        {
            _context.Carts.Add(new()
            {
                ProductId = id,
                UserId = "43d6af2e-df5e-4a0a-9916-b2e45bb0b803",
                Quantity = 1
            });
        }
        else
        {
            cartItem.Quantity += 1;
        }

        _context.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    public IActionResult AddToSession(string id)
    {
        var product = _context.Products.Find(id);

        if (product != null)
        {
            var sessionCart = HttpContext.Session.GetString("Cart");

            if (sessionCart != null) 
            {
                List<SessionCartModel> cartList = JsonSerializer.Deserialize<List<SessionCartModel>>(sessionCart);

                var cartItem = cartList.Find(p => p.ProductId == id);

                if (cartItem != null)
                {
                    cartItem.Quantity += 1;
                }
                else
                {
                    cartList.Add(new SessionCartModel 
                    {
                        ProductId = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = 1
                    });
                }

                string modifiedCart = JsonSerializer.Serialize(cartList);

                HttpContext.Session.SetString("Cart", modifiedCart);
            }
            else
            {
                List<SessionCartModel> newCartList = new();

                newCartList.Add(new() 
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });

                string newSessionCart = JsonSerializer.Serialize(newCartList);

                HttpContext.Session.SetString("Cart", newSessionCart);
            }
        }

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Delete()
    {
        return View();
    }
}
