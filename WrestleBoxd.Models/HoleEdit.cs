﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Models
{
    public class HoleEdit
    {
        public int HoleId { get; set; }
        public int HoleNumber { get; set; }
        public int Par { get; set; }
        public int Yards { get; set; }
    }
}
