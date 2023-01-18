using System.Linq;
using System.Web.Mvc;
using VehicleManagement.Core.Models;
using VehicleManagement.DataAccess;

namespace VehicleManagement.UI.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IRepository<Vehicle> _vehicles;

        public VehicleController(IRepository<Vehicle> vehicles)
        {
            _vehicles = vehicles;
        }

        public ActionResult Index()
        {
            var vehicleList = _vehicles.Collection().ToList();
            return View(vehicleList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid == false)
                return View(vehicle);

            _vehicles.Insert(vehicle);
            _vehicles.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var vehicle = _vehicles.Find(id);

            if (vehicle == null)
                return HttpNotFound();

            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehicle vehicle, int id)
        {
            if (ModelState.IsValid == false)
                return View(vehicle);

            var vehicleToEdit = _vehicles.Find(id);

            if (vehicleToEdit == null)
                return HttpNotFound();

            vehicleToEdit.Name = vehicle.Name;
            vehicleToEdit.Color = vehicle.Color;
            vehicleToEdit.Tag = vehicle.Tag;
            _vehicles.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var vehicle = _vehicles.Find(id);

            if (vehicle == null)
                return HttpNotFound();

            return View(vehicle);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var vehicle = _vehicles.Find(id);

            if (vehicle == null)
                return HttpNotFound();

            _vehicles.Delete(id);
            _vehicles.Commit();
            return RedirectToAction("Index");
        }

    }
}