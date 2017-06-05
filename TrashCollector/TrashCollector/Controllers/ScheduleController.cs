using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class ScheduleController : Controller
    {

        private ApplicationDbContext _context;
        Schedule currentSchedule;

        public ScheduleController()
        {
            _context = new ApplicationDbContext();

            
        }

        

        // GET: Schedule
        public ActionResult Index()
        {

            string userId = User.Identity.GetUserId();
            currentSchedule = _context.Users.Find(userId).schedule;

            return View(currentSchedule);
        }
    }
}