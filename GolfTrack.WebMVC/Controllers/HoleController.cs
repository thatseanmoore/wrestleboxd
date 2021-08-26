using GolfTrack.Models;
using GolfTrack.Services;
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

        // GET: Holes By Course
        public ActionResult CourseDetails(int id)
        {
            var service = new HoleService();
            var model = service.GetHolesByCourseId(id);

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = new HoleService();
            var model = service.GetHoleById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new HoleService();
            var detail = service.GetHoleById(id);
            var model =
                new HoleEdit
                {
                    HoleId = detail.HoleId,
                    HoleNumber = detail.HoleNumber,
                    Par = detail.Par,
                    Yards = detail.Yards
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HoleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.HoleId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new HoleService();

            if (service.UpdateHole(model))
            {
                TempData["SaveResult"] = "Your hole was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your hole could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = new HoleService();
            var model = svc.GetHoleById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHole(int id)
        {
            var service = new HoleService();

            service.DeleteHole(id);

            TempData["SaveResult"] = "Your hole was deleted";

            return RedirectToAction("Index");
        }
    }
}