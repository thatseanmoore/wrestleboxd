using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Data
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Holes { get; set; }
        public string TypeOfCourse { get; set; }
        public int Par { get; set; }
    }
}
