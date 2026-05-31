using System;
using TutoringWebapp.Domain.Models;

namespace TutoringWebapp.SharedKernel.Dto
{
    public class TutorAvailabilityDto
    {
        public Guid Id { get; set; }
        public Guid TutorId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
