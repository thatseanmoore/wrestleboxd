using GolfTrack.Models;
using GolfTrack.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GolfTrack.WebMVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Score")]
    public class ScoreController : ApiController
    {
        private bool SetHeartState(int scoreId, bool newState)
        {
            //Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScoreService(userId);

            //Get the score
            var detail = service.GetScoreById(scoreId);

            // Create the ScoreEdit model instance with the new star state
            var updatedScore =
                new ScoreEdit
                {
                    ScoreId = detail.ScoreId,
                    TotalScore = detail.TotalScore,
                    RoundDate = detail.RoundDate,
                    IsFavorited = newState
                };

            //Return a value indicating whether the update succeeded
            return service.UpdateScore(updatedScore);
        }

        [Route("{id}/Heart")]
        [HttpPut]
        public bool ToggleHeartOn(int id) => SetHeartState(id, true);

        [Route("{id}/Heart")]
        [HttpDelete]
        public bool ToggleHeartOff(int id) => SetHeartState(id, false);
    }
}
