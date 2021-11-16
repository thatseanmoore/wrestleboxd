using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfTrack.Data
{
    public class Score
    {
        public int ScoreId { get; set; }
        public int TotalScore { get; set; }
        public DateTimeOffset RoundDate { get; set; }
        [DefaultValue(false)]
        public bool IsFavorited { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public Guid UserId { get; set; }

    }
}
