using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Models
{
    public class RatingCreate
    {
        public int Stars { get; set; }
        public string Review { get; set; }
        public int CourseId { get; set; }
    }
}
