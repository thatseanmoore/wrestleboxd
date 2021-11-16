using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Models
{
    public class ScoreListItem
    {
        public int ScoreId { get; set; }
        [Display(Name = "Total Score")]
        public int TotalScore { get; set; }
        [UIHint("Favorited")]
        [Display(Name = "Favorite Round")]
        public bool IsFavorited { get; set; }
        [Display(Name = "Course Name")]
        public string Name { get; set; }
        public int CourseId { get; set; }
    }
}
