using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Models
{
    public class CourseCreate
    {
        public string Name { get; set; }
        public int Holes { get; set; }
        [Display(Name = "Type Of Course")]
        public string TypeOfCourse { get; set; }
        public int Par { get; set; }
    }
}
