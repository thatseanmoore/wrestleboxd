using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Models
{
    public class HoleListItem
    {
        public int HoleId { get; set; }
        public int HoleNumber { get; set; }
        public int Par { get; set; }
        public string Name { get; set; }
    }
}
