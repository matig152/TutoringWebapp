using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringWebapp.Domain.Models
{
    public enum LessonStatus {Scheduled, Completed, Cancelled}
    public class Lesson
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public Guid TutorId { get; set; }
        public Tutor Tutor { get; set; } = null!;

        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;

        public DateTime ScheduledTime { get; set; }
        public int DurationMinutes { get; set; }
        public decimal HourlyRate { get; set; }
        public string? Topic { get; set; }

        public LessonStatus Status { get; set; } = LessonStatus.Scheduled;
    }
}
