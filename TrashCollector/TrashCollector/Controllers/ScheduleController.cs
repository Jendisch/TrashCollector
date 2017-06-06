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
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;
        ApplicationUser currentUser;

        public ScheduleController()
        {
            _context = new ApplicationDbContext();
        }

        public ScheduleController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _context = new ApplicationDbContext();
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        public ActionResult Index()
        {

            string userId = User.Identity.GetUserId();
            currentUser = _context.Users.Find(userId);

            return View(currentUser);
        }

        //public ActionResult ChangePickupDay()
        //{
        //    return View("EditPickupDay");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ChangePickupDay(ChangePickupDayViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var result = await UserManager..ChangePickupDayAsync(model.DefaultPickupDay);
        //    if (result.Succeeded)
        //    {
        //        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //        if (user != null)
        //        {
        //            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //        }
        //        return RedirectToAction("ConfirmEditWasSuccessful");
        //    }
        //    AddErrors(result);
        //    return View("EditPickupDay", model);
        //}

        //private void AddErrors(IdentityResult result)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //}









        // GET: ScheduleModels/Edit/5
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
            return View("EditPickupDay", currentUser);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePickupDay(string Id, string StartDate)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = _context.Users.Find(Id);
                user.schedule.DefaultPickupDay = StartDate;
                user.StartDate = StartDate;
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("ConfirmEditWasSuccessful", "Schedule");
            }
            ViewBag.Id = new SelectList(_context.Users, "StartDate", currentUser.Id);
            return View("EditPickupDay");
        }




        public ActionResult ConfirmEditWasSuccessful()
        {
            return View();
        }



    }
}