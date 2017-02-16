using KP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KP2.Controllers
{
    public class WorkerController : Controller
    {
        private TripDBEntities1 db = new TripDBEntities1();
        // GET: Home

        public ActionResult Index()
        {
            string userS=User.Identity.Name.ToString();
            int user = 0;
            foreach (var item in db.Users.ToList())
            {
                if (item.login== userS)
                {
                    user = item.Id;
                }
            }
            List<TripPlan> buff = db.TripPlan.ToList();
            List<TripPlan> answer = new List<TripPlan>();
            foreach (var item in buff)
            {
                if (item.Id_driver==user||item.Id_worker==user) {
                    answer.Add(item);
                }
            }
            return View(answer);
        }
    }
}