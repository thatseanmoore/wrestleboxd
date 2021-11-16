using GolfTrack.Models;
using GolfTrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfTrack.WebMVC.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            var service = new CourseService();
            var model = service.GetCourses();

            return View(model);
        }

        // Get: Create Course
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            var service = new CourseService();

            if (service.CreateCourse(model)) 
            {
                TempData["SaveResult"] = "Your course was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Course could not be created.");

            return View(model);
        }

        public ActionResult Details (int id)
        {
            var service = new CourseService();
            var model = service.GetCourseById(id);

            return View(model);
        }

        public ActionResult Edit (int id)
        {
            var service = new CourseService();
            var detail = service.GetCourseById(id);
            var model =
                new CourseEdit
                {
                    CourseId = detail.CourseId,
                    Name = detail.Name,
                    Holes = detail.Holes,
                    TypeOfCourse = detail.TypeOfCourse,
                    Par = detail.Par
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourseEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CourseId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new CourseService();

            if (service.UpdateCourse(model))
            {
                TempData["SaveResult"] = "Your course was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your course could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = new CourseService();
            var model = svc.GetCourseById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCourse(int id)
        {
            var service = new CourseService();

            service.DeleteCourse(id);

            TempData["SaveResult"] = "Your course was deleted";

            return RedirectToAction("Index");
        }
    }
}