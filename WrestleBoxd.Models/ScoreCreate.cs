using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Models
{
    public class ScoreCreate
    {
        [Required]
        [Display(Name = "Total Score")]
        public int TotalScore { get; set; }
        [Display(Name = "Round Date")]
        public DateTimeOffset RoundDate { get; set; }
        public int CourseId { get; set; }
    }
}
