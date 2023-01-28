using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleManagement.Core;
using VehicleManagement.Core.Models;
using VehicleManagement.DataAccess;

namespace VehicleManagement.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _users;

        public UserController(IRepository<User> users)
        {
            _users = users;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllUsers()
        {
            var users = _users.Collection().ToList();
            return View(users);
        }

        public ActionResult UserPendingTravels()
        {
            var identity = User.Identity.GetUserId();
            var travelList = _users.Collection()
                .Where(w => w.IdentityUserId == identity)
                .Include(c => c.Travels)
                .Select(s => s.Travels)
                .SingleOrDefault()
                .Where(d => d.TravelStatus == TravelStatus.Pending);

            return View(travelList);
        }

        public ActionResult UserAssignTravels()
        {
            var identity = User.Identity.GetUserId();
            var travelList = _users.Collection()
                .Where(w => w.IdentityUserId == identity)
                .Include(c => c.Travels)
                .Select(s => s.Travels)
                .SingleOrDefault()
                .Where(d => d.TravelStatus == TravelStatus.Assign);

            return View(travelList);
        }

        public ActionResult UserCompleteTravels()
        {
            var identity = User.Identity.GetUserId();
            var travelList = _users.Collection()
                .Where(w => w.IdentityUserId == identity)
                .Include(c => c.Travels)
                .Select(s => s.Travels)
                .SingleOrDefault()
                .Where(d => d.TravelStatus == TravelStatus.Complete);

            return View(travelList);
        }

    }
}