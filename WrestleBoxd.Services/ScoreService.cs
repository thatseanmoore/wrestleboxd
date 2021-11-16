using GolfTrack.Data;
using GolfTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Services
{
    public class ScoreService
    {
        private readonly Guid _userId;

        public ScoreService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateScore(ScoreCreate model)
        {
            var entity =
                new Score()
                {
                    TotalScore = model.TotalScore,
                    RoundDate = model.RoundDate,
                    CourseId = model.CourseId,
                    UserId = _userId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Scores.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ScoreListItem> GetScores()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Scores
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new ScoreListItem
                                {
                                    ScoreId = e.ScoreId,
                                    TotalScore = e.TotalScore,
                                    IsFavorited = e.IsFavorited,
                                    Name = e.Course.Name,
                                    CourseId = e.CourseId
                                }
                        );

                return query.ToArray();
            }
        }

        public ScoreDetail GetScoreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Scores
                        .Single(e => e.ScoreId == id && e.UserId == _userId);
                return
                    new ScoreDetail
                    {
                        ScoreId = entity.ScoreId,
                        TotalScore = entity.TotalScore,
                        RoundDate = entity.RoundDate,
                        Name = entity.Course.Name,
                        CourseId = entity.CourseId
                    };
            }
        }

        public bool UpdateScore(ScoreEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Scores
                        .Single(e => e.ScoreId == model.ScoreId && e.UserId == _userId);

                entity.TotalScore = model.TotalScore;
                entity.RoundDate = model.RoundDate;
                entity.IsFavorited = model.IsFavorited;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteScore(int scoreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Scores
                        .Single(e => e.ScoreId == scoreId && e.UserId == _userId);

                ctx.Scores.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
