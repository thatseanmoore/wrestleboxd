using GolfTrack.Data;
using GolfTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Services
{
    public class CourseService
    {
        public bool CreateCourse (CourseCreate model)
        {
            var entity =
                new Course()
                {
                    Name = model.Name,
                    Holes = model.Holes,
                    TypeOfCourse = model.TypeOfCourse,
                    Par = model.Par
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Courses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CourseListItem> GetCourses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Courses
                        .Select(
                            e =>
                                new CourseListItem
                                {
                                    CourseId = e.CourseId,
                                    Name = e.Name,
                                    Holes = e.Holes
                                }
                        );

                return query.ToArray();
            }
        }

        public CourseDetail GetCourseById (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseId == id);
                return
                    new CourseDetail
                    {
                        CourseId = entity.CourseId,
                        Name = entity.Name,
                        Holes = entity.Holes,
                        TypeOfCourse = entity.TypeOfCourse,
                        Par = entity.Par
                    };
            }
        }
    }
}
