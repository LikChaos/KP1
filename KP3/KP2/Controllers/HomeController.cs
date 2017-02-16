using KP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KP2.Controllers
{
    public class HomeController : Controller
    {
        private TripDBEntities1 db = new TripDBEntities1();
        // GET: Home
        
        public ActionResult Index()
        {
            return View(db.Trip.ToList());
        }

        [Authorize]
        public ActionResult Users()
        {
            return View();
        }
    }
}