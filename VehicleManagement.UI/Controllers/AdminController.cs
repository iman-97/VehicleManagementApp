using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleManagement.Core;
using VehicleManagement.Core.Models;
using VehicleManagement.Core.ViewModels;
using VehicleManagement.DataAccess;
using VehicleManagement.UI.Models;

namespace VehicleManagement.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<Travel> _travels;
        private readonly IRepository<Driver> _drivers;
        private readonly IRepository<Vehicle> _vehicles;
        private readonly IRepository<CompleteTravel> _completeTravels;

        public AdminController(IRepository<Travel> travels,
            IRepository<Driver> drivers,
            IRepository<Vehicle> vehicles,
            IRepository<CompleteTravel> completeTravels)
        {
            _travels = travels;
            _drivers = drivers;
            _vehicles = vehicles;
            _completeTravels = completeTravels;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Assign(int id)
        {
            var travel = _travels.Find(id);

            if (travel == null)
                return HttpNotFound();

            var drivers = _drivers.Collection().Where(w => w.IsBusy == false);
            var vehicles = _vehicles.Collection().Where(w => w.IsBusy == false);

            var newCT = new CompleteTravel
            {
                TravelId = travel.Id,
            };

            var viewModel = new AssignTravelViewModel
            {
                CompleteTravel = newCT,
                Travel = travel,
                Drivers = drivers,
                Vehicles = vehicles
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assign(AssignTravelViewModel assignTravel)
        {
            _completeTravels.Insert(assignTravel.CompleteTravel);
            _completeTravels.Commit();

            var tId = assignTravel.CompleteTravel.TravelId;
            var travel = _travels.Find(tId);
            travel.TravelStatus = TravelStatus.Assign;
            _travels.Commit();

            var dId = assignTravel.CompleteTravel.DriverId;
            var driver = _drivers.Find(dId);
            driver.IsBusy = true;
            _drivers.Commit();

            var vId = assignTravel.CompleteTravel.VehicleId;
            var vehicle = _vehicles.Find(vId);
            vehicle.IsBusy = true;
            _vehicles.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Complete(int id)
        {
            var travel = _travels.Find(id);
            travel.TravelStatus = TravelStatus.Complete;
            _travels.Commit();

            var ct = _completeTravels.Collection()
                .Where(t => t.TravelId == id).FirstOrDefault();

            var driver = _drivers.Find(ct.DriverId);
            driver.IsBusy = false;
            _drivers.Commit();

            var vehicle = _vehicles.Find(ct.VehicleId);
            vehicle.IsBusy = false;
            _vehicles.Commit();

            return View();
        }

        public ActionResult PendingTravels()
        {
            var list = _travels.Collection()
                .Where(w => w.TravelStatus == TravelStatus.Pending)
                .ToList();

            return View(list);
        }

        public ActionResult AssignTravels()
        {
            var list = _travels.Collection()
                .Where(w => w.TravelStatus == TravelStatus.Assign)
                .ToList();

            return View(list);
        }

        public ActionResult CompleteTravels()
        {
            var list = _travels.Collection()
                .Where(w => w.TravelStatus == TravelStatus.Assign)
                .ToList();

            return View(list);
        }

        public ActionResult Test()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var userManager = HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            var dd = HttpContext.GetOwinContext().Get<ApplicationDbContext>();

            var roles = db.Roles.Where(w => w.Name == RoleNames.NotApprovedUser);
            if (roles.Any())
            {
                var roleId = roles.First().Id;
                var users = (from u in db.Users
                             where u.Roles.Any(r => r.RoleId == roleId)
                             select u);

                return View(users);
            }

            return HttpNotFound();
        }

    }
}