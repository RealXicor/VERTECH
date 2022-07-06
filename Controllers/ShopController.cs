using Microsoft.AspNetCore.Mvc;

namespace VERTECH.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult ShopNow()
        {
            return View();
        }
        public IActionResult InquireNow(string productName, string productPrice)
        {
            ViewBag.ProductName = productName;
            ViewBag.ProductPrice = productPrice;
            return View();
        }
    }
}
