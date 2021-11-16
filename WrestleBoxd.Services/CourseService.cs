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
                        double averageRating = new double();
                        double countRating = 0;
                        double totalRating = 0;

                        double averageScore = new double();
                        double countScore = 0;
                        double totalScore = 0;

                        foreach ( var rating in entity.ListOfRatings)
                        {

                            totalRating += rating.Stars;
                            countRating += 1;
                        }
                        foreach ( var score in entity.ListOfScores)
                        {
                            totalScore += score.TotalScore;
                            countScore += 1;
                        }
                    averageRating = totalRating / countRating;
                    averageScore = totalScore / countScore;

                    return
                    new CourseDetail
                    {
                        CourseId = entity.CourseId,
                        Name = entity.Name,
                        Holes = entity.Holes,
                        TypeOfCourse = entity.TypeOfCourse,
                        Par = entity.Par,
                        AverageRating = averageRating,
                        AverageScore = averageScore
                    };
            }
        }

        public bool UpdateCourse(CourseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseId == model.CourseId);

                entity.Name = model.Name;
                entity.Holes = model.Holes;
                entity.TypeOfCourse = model.TypeOfCourse;
                entity.Par = model.Par;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCourse(int courseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseId == courseId);

                ctx.Courses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
