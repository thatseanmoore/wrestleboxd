using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Models
{
    public class ScoreEdit
    {
        public int ScoreId { get; set; }
        public int TotalScore { get; set; }
        public DateTimeOffset RoundDate { get; set; }
        public bool IsFavorited { get; set; }
    }
}
