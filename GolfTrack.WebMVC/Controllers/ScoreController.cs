using GolfTrack.Models;
using GolfTrack.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfTrack.WebMVC.Controllers
{
    [Authorize]
    public class ScoreController : Controller
    {
        // GET: Score
        public ActionResult Index()
        {
            var service = CreateScoreService();
            var model = service.GetScores();

            return View(model);
        }

        // Get: Create Rating
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScoreCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            var service = CreateScoreService();

            if (service.CreateScore(model))
            {
                TempData["SaveResult"] = "Your Score was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Score could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateScoreService();
            var model = service.GetScoreById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateScoreService();
            var detail = service.GetScoreById(id);
            var model =
                new ScoreEdit
                {
                    ScoreId = detail.ScoreId,
                    TotalScore = detail.TotalScore,
                    RoundDate = detail.RoundDate
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ScoreEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ScoreId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateScoreService();

            if (service.UpdateScore(model))
            {
                TempData["SaveResult"] = "Your score was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your score could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateScoreService();
            var model = svc.GetScoreById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteScore(int id)
        {
            var service = CreateScoreService();

            service.DeleteScore(id);

            TempData["SaveResult"] = "Your score was deleted";

            return RedirectToAction("Index");
        }

        private ScoreService CreateScoreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScoreService(userId);
            return service;
        }
    }
}