using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Models
{
    public class HoleListItem
    {
        public int HoleId { get; set; }
        [Display(Name = "Hole Number")]
        public int HoleNumber { get; set; }
        public int Par { get; set; }
        public string Name { get; set; }
    }
}
