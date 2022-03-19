using KonusarakOgrenProject.Business.Abstract;
using KonusarakOgrenProject.DataAccess.Data;
using KonusarakOgrenProject.Entity.Concrete;
using KonusarakOgrenProject.Web.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgrenProject.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly DatabaseContext _db;

        public AuthController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (_db.Users.Any(x => x.Username.Equals(user.Username)))
                {
                    ModelState.AddModelError("", "There is already a person has same Username");
                }
                else
                {
                    var newUser = new User() { Username = user.Username, Password = user.Password };
                    _db.Users.Add(newUser);
                    _db.SaveChanges();
                    TempData["message"] = "Register was succesful";
                    return RedirectToAction("Login", "Auth");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login(string yonlen)
        {
            ViewBag.yonlen = yonlen;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model, string yonlen)
        {

            var user = _db.Users.FirstOrDefault(x => x.Username.Equals(model.Username) && x.Password.Equals(model.Password));

            if (user != null)
            {
                HttpContext.Session.SetString("userId", user.Id.ToString());
                HttpContext.Session.SetString("username", user.Username.ToString());

                if (string.IsNullOrEmpty(yonlen))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(yonlen);
                }
            }
            else
            {
                ModelState.AddModelError("", "User name or password is wrong");
                return View();
            }

            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login", "Auth");
        }
    }
}
