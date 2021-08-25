using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Models
{
    public class ScoreListItem
    {
        public int ScoreId { get; set; }
        public int TotalScore { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
    }
}
