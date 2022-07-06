using Microsoft.AspNetCore.Mvc;
using VERTECH.Models;

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
        [HttpPost]
        public IActionResult InquireData(Inquiry obj,string f, string l, string e, string pn, string pp, string m)
        {
            obj.FirstName = f;
            obj.LastName = l;
            obj.UserEmail = e;
            obj.ProductName = pn;
            obj.ProductPrice = pp;
            obj.UserMsg = m;
            return View();
        }
    }
}
