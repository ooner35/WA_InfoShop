using Microsoft.AspNetCore.Mvc;

namespace WA_InfoShop.Controlers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
