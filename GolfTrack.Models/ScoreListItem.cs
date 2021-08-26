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
        public int TotalScore { get; set; }
        [UIHint("Favorited")]
        [Display(Name = "Favorite")]
        public bool IsFavorited { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
    }
}
