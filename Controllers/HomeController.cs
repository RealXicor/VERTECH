using Microsoft.AspNetCore.Mvc;

namespace VERTECH.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            
            return View();
        }

        public IActionResult Send(string fname, string lname, string email, int phnum, string genderr, string dep)
        {
            ViewBag.Message1 = "Your First Name is: " + fname;
            ViewBag.Message2 = "Your Last Name is: " + lname;
            ViewBag.Message3 = "Your Email is: " + email;
            ViewBag.Message4 = "Your Phone Number is: " + phnum;
            ViewBag.Message5 = "Gender: " + genderr;
            ViewBag.Message6 = "Your Dep is: " + dep;
            return View();
        }
    }
}
