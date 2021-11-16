using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Models
{
    public class ScoreDetail
    {
        public int ScoreId { get; set; }
        [Display(Name="Score")]
        public int TotalScore { get; set; }
        [Display(Name = "Round Date")]
        public DateTimeOffset RoundDate { get; set; }
        [Display(Name = "Course Name")]
        public string Name { get; set; }
        public int CourseId { get; set; }
    }
}
