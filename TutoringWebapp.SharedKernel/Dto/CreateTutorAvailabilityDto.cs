using System;

namespace TutoringWebapp.SharedKernel.Dto
{
    public class CreateTutorAvailabilityDto
    {
        public Guid TutorId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
