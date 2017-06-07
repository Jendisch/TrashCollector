using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using static TrashCollector.Models.Schedule;

namespace TrashCollector.Controllers
{
    public class ScheduleController : Controller
    {

        private ApplicationDbContext _context;

        public ScheduleController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.Find(userId);
            if(currentUser.schedule.VacationStartDate == null || currentUser.schedule.VacationEndDate == null)
            {
                return View("Index", currentUser);
            }
            else
            {
                return View("AlreadyScheduledVacation", currentUser);
            }
        }

        public ActionResult ChangePickupDay(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser currentUser = _context.Users.Find(id);
            if (currentUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(_context.Users, "StartDate", currentUser.Id);
            return View("ChangePickupDay", currentUser);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePickupDay(string id, string StartDate)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = _context.Users.Find(id);
                currentUser.schedule.DefaultPickupDay = StartDate;
                currentUser.StartDate = StartDate;
                _context.Entry(currentUser).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("ConfirmEditWasSuccessful", "Schedule");
            }
            ViewBag.Id = new SelectList(_context.Users, "StartDate", id);
            return View("ChangePickupDay");
        }

        public ActionResult ConfirmEditWasSuccessful()
        {
            return View();
        }

        public ActionResult ScheduleVacation(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser currentUser = _context.Users.Find(id);
            Schedule schedule = currentUser.schedule;
            if (currentUser == null)
            {
                return HttpNotFound();
            }
            return View("ScheduleVacation", schedule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ScheduleVacation(string id, Schedule Schedule)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = _context.Users.Find(id);
                currentUser.schedule.VacationStartDate = Schedule.VacationStartDate;
                currentUser.schedule.VacationEndDate = Schedule.VacationEndDate;
                _context.Entry(currentUser).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("ConfirmEditWasSuccessful", "Schedule");
            }
            ViewBag.Id = new SelectList(_context.Users, "StartDate", id);
            return View("ScheduleVacation");
        }

        public ActionResult Billing()
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.Find(userId);
            return View("Billing", currentUser);
        }

        public PartialViewResult Load()
        {
            return PartialView("_LoadConfirm");
        }

        public ActionResult PayBill(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser currentUser = _context.Users.Find(id);
            if (currentUser == null)
            {
                return HttpNotFound();
            }
            currentUser.CurrentBill = 0;
            _context.Entry(currentUser).State = EntityState.Modified;
            _context.SaveChanges();
            return View("Billing", currentUser);
        }



    }
}