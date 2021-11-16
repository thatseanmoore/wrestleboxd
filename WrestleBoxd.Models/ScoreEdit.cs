using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Models
{
    public class ScoreEdit
    {
        public int ScoreId { get; set; }
        [Display(Name = "Total Score")]
        public int TotalScore { get; set; }
        [Display(Name = "Round Date")]
        public DateTimeOffset RoundDate { get; set; }
        [Display(Name = "Favorite Round")]
        public bool IsFavorited { get; set; }
    }
}
