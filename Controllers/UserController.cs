using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class UserController : Controller
    {   
        private MyContext dbContext;

        public UserController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult LoginReg()
        {
            if(HttpContext.Session.GetString("Email") != null)
            {
                return RedirectToAction("Dashboard", "Wedding");
            }
            return View();
        }

        [HttpPost("user")]
        public IActionResult Create(User newUser)
        {
            if(ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == newUser.Email);
                if(userInDb != null)
                {
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("LoginReg");
                }

                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                dbContext.Add(newUser);
                dbContext.SaveChanges();

                HttpContext.Session.SetString("FirstName", newUser.FirstName);
                HttpContext.Session.SetString("LastName", newUser.LastName);
                HttpContext.Session.SetString("Email", newUser.Email);

                return RedirectToAction("Dashboard", "Wedding");
            }
            else
            {
                return View("LoginReg");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser user)
        {
             if(ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == user.LoginEmail);

                if(userInDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("LoginReg");
                }

                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.LoginPassword);
                if(result == 0)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("LoginReg");
                }

                HttpContext.Session.SetString("FirstName", userInDb.FirstName);
                HttpContext.Session.SetString("LastName", userInDb.LastName);
                HttpContext.Session.SetString("Email", userInDb.Email);
                return RedirectToAction("Dashboard", "Wedding");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet("logout")]
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginReg");
        }

    }
}
