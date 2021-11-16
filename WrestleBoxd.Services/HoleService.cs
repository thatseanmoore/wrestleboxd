using GolfTrack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GolfTrack.Models;

namespace GolfTrack.Services
{
    public class HoleService
    {
        public bool CreateHole(HoleCreate model)
        {
            var entity =
                new Hole()
                {
                    HoleNumber = model.HoleNumber,
                    Par = model.Par,
                    Yards = model.Yards,
                    CourseId = model.CourseId
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
                        .Select(
                            e =>
                                new HoleListItem
                                {
                                    HoleId = e.HoleId,
                                    HoleNumber = e.HoleNumber,
                                    Par = e.Par,
                                    Name = e.Course.Name
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<HoleDetail> GetHolesByCourseId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Holes
                        .Where(e => e.CourseId == id)
                        .Select(
                            e =>
                                new HoleDetail
                                {
                                    HoleId = e.HoleId,
                                    HoleNumber = e.HoleNumber,
                                    Par = e.Par,
                                    Yards = e.Yards,
                                    Name = e.Course.Name,
                                    CourseId = e.CourseId
                                }
                        );

                return query.ToArray();
            }
        }

        public HoleDetail GetHoleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Holes
                        .Single(e => e.HoleId == id);

                return
                new HoleDetail
                {
                    HoleId = entity.HoleId,
                    HoleNumber = entity.HoleNumber,
                    Par = entity.Par,
                    Yards = entity.Yards,
                    Name = entity.Course.Name,
                    CourseId = entity.CourseId
                };
            }
        }

        public bool UpdateHole(HoleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Holes
                        .Single(e => e.HoleId == model.HoleId);

                entity.HoleNumber = model.HoleNumber;
                entity.Par = model.Par;
                entity.Yards = model.Yards;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteHole(int holeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Holes
                        .Single(e => e.HoleId == holeId);

                ctx.Holes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
