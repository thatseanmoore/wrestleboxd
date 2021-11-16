using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Models
{
    public class HoleDetail
    {
        public int HoleId { get; set; }
        [Display(Name = "Hole Number")]
        public int HoleNumber { get; set; }
        public int Par { get; set; }
        public int Yards { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }

    }
}
