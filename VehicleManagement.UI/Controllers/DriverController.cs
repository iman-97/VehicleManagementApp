using System.Linq;
using System.Web.Mvc;
using VehicleManagement.Core.Models;
using VehicleManagement.DataAccess;

namespace VehicleManagement.UI.Controllers
{
    public class DriverController : Controller
    {
        private readonly IRepository<Driver> _drivers;

        public DriverController(IRepository<Driver> drivers)
        {
            _drivers = drivers;
        }

        public ActionResult Index()
        {
            var driverList = _drivers.Collection().ToList();
            return View(driverList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Driver driver)
        {
            if (ModelState.IsValid == false)
                return View(driver);

            _drivers.Insert(driver);
            _drivers.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var driver = _drivers.Find(id);

            if (driver == null)
                return HttpNotFound();

            return View(driver);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Driver driver, int id)
        {
            if (ModelState.IsValid == false)
                return View(driver);

            var driverToEdit = _drivers.Find(id);

            if (driverToEdit == null)
                return HttpNotFound();

            driverToEdit.FirstName = driver.FirstName;
            driverToEdit.LastName = driver.LastName;
            driverToEdit.IdentityNumber = driver.IdentityNumber;
            driverToEdit.NationalNumber = driver.NationalNumber;
            driverToEdit.PhoneNumber = driver.PhoneNumber;
            _drivers.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var driver = _drivers.Find(id);

            if (driver == null)
                return HttpNotFound();

            return View(driver);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var driver = _drivers.Find(id);

            if (driver == null)
                return HttpNotFound();

            _drivers.Delete(id);
            _drivers.Commit();
            return RedirectToAction("Index");
        }

    }
}