using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using VehicleManagement.Core.Models;
using VehicleManagement.DataAccess;

namespace VehicleManagement.UI.Controllers
{
    [AllowAnonymous]
    public class TravelController : Controller
    {
        private readonly IRepository<Travel> _travels;
        private readonly IRepository<User> _users;

        public TravelController(IRepository<Travel> travels, IRepository<User> users)
        {
            _travels = travels;
            _users = users;
        }

        public ActionResult Index()
        {
            var list = _travels.Collection().ToList();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Travel travel)
        {
            if (ModelState.IsValid == false)
                return View(travel);

            var identity = User.Identity.GetUserId();
            var user = _users.Collection()
                .Where(w => w.IdentityUserId == identity)
                .FirstOrDefault();

            travel.UserId = user.Id;
            _travels.Insert(travel);
            _travels.Commit();

            ViewBag.TravelStatus = "Travel Created";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            var travel = _travels.Find(id);

            if (travel == null)
                return HttpNotFound();

            return View(travel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Travel travel)
        {
            if (ModelState.IsValid == false)
                return View(travel);

            var travelToEdit = _travels.Find(id);

            if (travelToEdit == null)
                return HttpNotFound();

            travelToEdit.Origin = travel.Origin;
            travelToEdit.Destination = travel.Destination;
            travelToEdit.StartDate = travel.StartDate;
            travelToEdit.Address = travel.Address;
            travelToEdit.Details = travel.Details;
            travelToEdit.PassengersCount = travel.PassengersCount;
            travelToEdit.PassengerFirstName = travel.PassengerFirstName;
            travelToEdit.PassengerLastName = travel.PassengerLastName;
            travelToEdit.PhoneNumber = travel.PhoneNumber;
            _travels.Commit();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            var travel = _travels.Find(id);

            if (travel == null)
                return HttpNotFound();

            return View(travel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var travel = _travels.Find(id);

            if (travel == null)
                return HttpNotFound();

            _travels.Delete(id);
            _travels.Commit();

            return RedirectToAction("Index", "Home");
        }

    }
}
