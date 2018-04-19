
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Wedding_Planner.Models;

namespace Wedding_Planner.Controllers
{
    public class WeddingController : Controller
    {

        // DATABASE

        private readonly WeddingContext _context;
 
        public WeddingController(WeddingContext context)
        {
            _context = context;
        }

        // PRIVATE METHODS

        private bool UserLoggedIn()
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [Route("/Weddings")]
        public IActionResult Index()
        {
            if(!UserLoggedIn())
            {
                return RedirectToAction("Index","User");
            }
            int UserId = (int)HttpContext.Session.GetInt32("UserId");
            ViewBag.User = _context.Users.SingleOrDefault(x => x.UserId == UserId);
            ViewBag.Weddings = _context.Weddings.OrderBy(x => x.WeddingDate);
            ViewBag.RSVPs = _context.RSVPs.Where(x => x.UserId == UserId);
            ViewBag.AllRSVPs = _context.RSVPs.ToList();

            return View();
        }

        [Route("/Wedding/{WeddingId}/Delete")]
        public IActionResult Delete(int WeddingId)
        {
            if(!UserLoggedIn())
            {
                return RedirectToAction("Index","User");
            }
            var Wedding = _context.Weddings.SingleOrDefault(x => x.WeddingId == WeddingId);
            if(Wedding != null)
            {
                _context.Weddings.Remove(Wedding);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Route("/Wedding/{WeddingId}",Name="View Wedding")]
        public IActionResult Show(int WeddingId)
        {
            ViewBag.Wedding = _context.Weddings.SingleOrDefault(x => x.WeddingId == WeddingId);
            ViewBag.RSVPs = _context.RSVPs.Where(x => x.WeddingId == WeddingId);
            ViewBag.WeddingGuests = _context.Weddings.Include(g => g.Guests).ThenInclude(h => h.User).Where(g => g.WeddingId == WeddingId).SingleOrDefault();
            return View();
        }

        [Route("/Wedding/New")]
        public IActionResult New()
        {
            if(!UserLoggedIn())
            {
                return RedirectToAction("Index","User");
            }
            ViewBag.UserId = (int)HttpContext.Session.GetInt32("UserId");
            return View();
        }

        [Route("/Wedding/Create")]
        public IActionResult Create(Wedding wedding)
        {
            if(!UserLoggedIn())
            {
                return RedirectToAction("Index","User");
            }
            if(ModelState.IsValid)
            {
                _context.Add(wedding);
                _context.SaveChanges();
                return RedirectToRoute("View Wedding",new { WeddingId = wedding.WeddingId });
            }
            return View("New");
        }

        [Route("/Wedding/{WeddingId}/RSVP/Create")]
        public IActionResult RSVP(int WeddingId)
        {
            if(!UserLoggedIn())
            {
                return RedirectToAction("Index","User");
            }
            int UserId = (int)HttpContext.Session.GetInt32("UserId");
            RSVP newRSVP = new RSVP{
                WeddingId = WeddingId,
                UserId = UserId
            };
            _context.RSVPs.Add(newRSVP);
            _context.SaveChanges();
            return RedirectToAction("Index","Wedding");
        }

        [Route("/Wedding/{WeddingId}/RSVP/Delete")]

        public IActionResult UNRSVP(int WeddingId)
        {
            if(!UserLoggedIn())
            {
                return RedirectToAction("Index","User");
            }
            int UserId = (int)HttpContext.Session.GetInt32("UserId");
            var RSVP = _context.RSVPs.Where(x => x.UserId == UserId && x.WeddingId == WeddingId).SingleOrDefault();
            _context.RSVPs.Remove(RSVP);
            _context.SaveChanges();
            return RedirectToAction("Index","Wedding");
        }
    }
}
