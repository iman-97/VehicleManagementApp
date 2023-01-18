using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleManagement.Core.Models;
using VehicleManagement.DataAccess;

namespace VehicleManagement.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<Travel> _travel;
        private readonly IRepository<User> _users;

        public UserController(IRepository<Travel> travel,IRepository<User> users)
        {
            _travel = travel;
            _users = users;
        }

        public ActionResult Index()
        {
            var identity = User.Identity.GetUserId();
            var travelList = _users.Collection()
                .Where(w => w.IdentityUserId == identity)
                .Include(c => c.Travels)
                .Select(s => s.Travels).SingleOrDefault();

            return View(travelList);
        }
    }
}