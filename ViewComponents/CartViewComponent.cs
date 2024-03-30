using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WA_InfoShop.Models;

namespace WA_InfoShop.ViewComponents;

public class CartViewComponent : ViewComponent
{
    private readonly ApplicationContext _context;
    //private readonly UserManager<ApplicationUser> _userManager;
    public CartViewComponent(ApplicationContext context)
    {
        _context = context;
        //_userManager = userManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        // Giriş Yapmış Kullanıcıyı Bulmamızı Sağlar
        //var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
        
        var data = await _context.Carts.Where(c => c.UserId == "43d6af2e-df5e-4a0a-9916-b2e45bb0b803").ToListAsync();

        return View(data);
    }
}
