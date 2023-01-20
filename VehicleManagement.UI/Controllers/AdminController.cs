using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleManagement.Core.Models;
using VehicleManagement.Core.ViewModels;
using VehicleManagement.DataAccess;

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
            var travelList = _travels.Collection().ToList();
            return View(travelList);
        }

        public ActionResult CompleteTravel()
        {
            return View();
        }

        public ActionResult Assign(int id)
        {
            var travel = _travels.Find(id);

            if (travel == null)
                return HttpNotFound();

            var drivers = _drivers.Collection();
            var vehicles = _vehicles.Collection();
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

            return RedirectToAction("Index");
        }

    }
}