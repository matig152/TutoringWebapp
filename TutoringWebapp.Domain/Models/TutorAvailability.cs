using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringWebapp.Domain.Models
{
    public class TutorAvailability
    {
        public Guid Id { get; set; }
        public Guid TutorId { get; set; }
        public Tutor Tutor { get; set; } = null!;

        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

    }
}
