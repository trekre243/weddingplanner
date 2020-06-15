using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {   
        private MyContext dbContext;

        public WeddingController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("LoginReg", "User");
            }
            
            ViewBag.UserEmail = HttpContext.Session.GetString("Email");
            ViewBag.Weddings = dbContext.Weddings
                .Include(w => w.Attendees)
                .ThenInclude(a => a.Attendee)
                .Include(w => w.Creator)
                .ToList();
            return View();
        }

        [HttpGet("weddings/new")]
        public IActionResult NewWedding()
        {
            if(HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("LoginReg", "User");
            }
            return View();
        }

        [HttpPost("wedding")]
        public IActionResult Create(Wedding newWedding)
        {
            if(ModelState.IsValid)
            {
                if(newWedding.Date < DateTime.Now)
                {
                    ModelState.AddModelError("Date", "Wedding date must be in the future.");
                    return View("NewWedding");
                }

                User foundUser = dbContext.Users.FirstOrDefault(u => u.Email == HttpContext.Session.GetString("Email"));
                newWedding.UserId = foundUser.UserId;
                dbContext.Add(newWedding);
                dbContext.SaveChanges();

                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("NewWedding");
            }
        }

        [HttpGet("weddings/rsvp/{weddingId}")]
        public RedirectToActionResult RSVP(int weddingId)
        {
            if(HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("LoginReg", "User");
            }
            
            int userId = dbContext.Users.FirstOrDefault(u => u.Email == HttpContext.Session.GetString("Email")).UserId;
            Attending attending = new Attending();
            attending.UserId = userId;
            attending.WeddingId = weddingId;
            dbContext.Add(attending);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("weddings/unrsvp/{weddingId}")]
        public RedirectToActionResult UNRSVP(int weddingId)
        {
            if(HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("LoginReg", "User");
            }
            User currentUser = dbContext.Users.FirstOrDefault(u => u.Email == HttpContext.Session.GetString("Email"));
            Attending weddingAtt = dbContext.Attending.FirstOrDefault(a => a.UserId == currentUser.UserId && a.WeddingId == weddingId);

            if(currentUser == null | weddingAtt == null)
            {
                return RedirectToAction("Dashboard");
            }

            dbContext.Remove(weddingAtt);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("weddings/delete/{weddingId}")]
        public RedirectToActionResult CancelWedding(int weddingId)
        {
            if(HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("LoginReg", "User");
            }

            Wedding wedding = dbContext.Weddings
                .Include(w => w.Creator)
                .FirstOrDefault(w => w.WeddingId == weddingId);
            
            if(wedding == null || wedding.Creator.Email != HttpContext.Session.GetString("Email"))
            {
                return RedirectToAction("Dashboard");
            }

            dbContext.Remove(wedding);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("weddings/{weddingId}")]
        public IActionResult SpecWedding(int weddingId)
        {
            if(HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("LoginReg", "User");
            }
            Wedding wedding = dbContext.Weddings
                .Include(w => w.Attendees)
                .ThenInclude(a => a.Attendee)
                .FirstOrDefault(w => w.WeddingId == weddingId);

            if(wedding == null)
            {
                return RedirectToAction("Dashboard");
            }

            return View("SpecWedding", wedding);
        }

    }

    
}
