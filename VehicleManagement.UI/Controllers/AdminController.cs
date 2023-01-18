using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleManagement.Core.Models;
using VehicleManagement.DataAccess;

namespace VehicleManagement.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<Travel> _travels;

        public AdminController(IRepository<Travel> travels)
        {
            _travels = travels;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompleteTravel()
        {
            return View();
        }

    }
}