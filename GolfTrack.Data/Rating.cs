using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Data
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int Stars { get; set; }
        public string Review { get; set; }
        public int CourseId { get; set; }
        public Guid UserId { get; set; }
    }
}
