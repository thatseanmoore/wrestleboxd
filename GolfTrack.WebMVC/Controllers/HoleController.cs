using GolfTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfTrack.WebMVC.Controllers
{
    [Authorize]
    public class HoleController : Controller
    {
        // GET: Hole
        public ActionResult Index()
        {
            var service = new HoleService();
            var model = service.GetHoles();

            return View(model);
        }

        // Get: Create Course
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HoleCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            var service = new HoleService();

            if (service.CreateHole(model))
            {
                TempData["SaveResult"] = "Your Hole was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Hole could not be created.");

            return View(model);
        }
    }
}