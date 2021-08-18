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
    }
}