using System;
using TutoringWebapp.Domain.Models;

namespace TutoringWebapp.SharedKernel.Dto
{
    public class LessonDto
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }
        public Guid TutorId { get; set; }
        public int SubjectId { get; set; }

        public DateTime ScheduledTime { get; set; }
        public int DurationMinutes { get; set; }
        public decimal HourlyRate { get; set; }
        public string? Topic { get; set; }

        public LessonStatus Status { get; set; }
    }
}
