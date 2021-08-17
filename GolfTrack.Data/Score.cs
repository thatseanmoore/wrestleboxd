using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Data
{
    public class Score
    {
        public int ScoreId { get; set; }
        public int TotalScore { get; set; }
        public DateTimeOffset RoundDate { get; set; }
        public int CourseId { get; set; }
        public Guid UserId { get; set; }

    }
}
