using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Models
{
    public class HoleCreate
    {
        [Required]
        public int HoleNumber { get; set; }
        public int Par { get; set; }
        public int Yards { get; set; }
        [Required]
        public int CourseId { get; set; }
    }
}
