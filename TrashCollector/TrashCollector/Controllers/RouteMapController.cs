using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class RouteMapController : Controller
    {
        
        private ApplicationDbContext _context;

        public RouteMapController()
        {
            _context = new ApplicationDbContext();
        }

        
        public ActionResult Index()
        {
            IEnumerable<ApplicationUser> model = new List<ApplicationUser>();
            return View(model);
        }

        public ActionResult RouteByZipCode(string ZipCode)
        {
            string todaysDayName = DateTime.Now.DayOfWeek.ToString();
            DateTime todaysDate = DateTime.Now;
            var allClients = _context.Users.Where(a => a.StartDate != null);

            
            var uniqueZipCodes = allClients.Select(m => m.ZipCode).Distinct();
            ViewBag.ZipCodes = uniqueZipCodes;

            var currentZipRoutes = allClients.
                                    Where(m => (ZipCode == m.ZipCode.ToString() 
                                    && m.schedule.DefaultPickupDay == todaysDayName
                                    && ((m.schedule.VacationStartDate == null 
                                    && m.schedule.VacationEndDate == null) ||
                                    (m.schedule.VacationStartDate < todaysDate 
                                    && m.schedule.VacationEndDate > todaysDate))));
            return View(currentZipRoutes);
        }




        public ActionResult DisplayRouteMap(string ZipCode)
        {
            string todaysDayName = DateTime.Now.DayOfWeek.ToString();
            DateTime todaysDate = DateTime.Now;
            var allClients = _context.Users.Where(a => a.StartDate != null);
            var uniqueZipCodes = allClients.Select(m => m.ZipCode).Distinct();
            ViewBag.ZipCodes = uniqueZipCodes;

            var currentZipRoutes = allClients.
                                    Where(m => (ZipCode == m.ZipCode.ToString()
                                    && m.schedule.DefaultPickupDay == todaysDayName
                                    && ((m.schedule.VacationStartDate == null
                                    && m.schedule.VacationEndDate == null) ||
                                    (m.schedule.VacationStartDate < todaysDate
                                    && m.schedule.VacationEndDate > todaysDate))));

            return View(currentZipRoutes.ToList());
        }

        public ActionResult ChargeClient(string value)
        {
            if (value == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser currentUser = _context.Users.Find(value);
            if (currentUser == null)
            {
                return HttpNotFound();
            }
            currentUser.CurrentBill += 5;
            _context.Entry(currentUser).State = EntityState.Modified;
            _context.SaveChanges();
            return View("DisplayRouteMap");
        }












    }
}