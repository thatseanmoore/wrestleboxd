using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Data
{
    public class Hole
    {
        public int HoleId { get; set; }
        public int HoleNumber { get; set; }
        public int Par { get; set; }
        public int Yards { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
