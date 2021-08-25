using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Data
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Holes { get; set; }
        [Required]
        public string TypeOfCourse { get; set; }
        [Required]
        public int Par { get; set; }

        public virtual ICollection<Rating> ListOfRatings { get; set; } = new List<Rating>();

        public virtual ICollection<Score> ListOfScores { get; set; } = new List<Score>();

        public virtual ICollection<Hole> ListOfHoles { get; set; } = new List<Hole>();
    }
}
