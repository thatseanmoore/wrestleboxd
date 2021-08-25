using GolfTrack.Data;
using GolfTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Services
{
    public class HoleService
    {
        private readonly Guid _userId;

        public HoleService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateHole(HoleCreate model)
        {
            var entity =
                new Hole()
                {
                    Stars = model.Stars,
                    Review = model.Review,
                    CourseId = model.CourseId,
                    UserId = _userId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Holes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<HoleListItem> GetHoles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Holes
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new HoleListItem
                                {
                                    RatingId = e.RatingId,
                                    Stars = e.Stars,
                                    Name = e.Course.Name,
                                    CourseId = e.CourseId
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
