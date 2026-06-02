using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringWebapp.Domain.Models
{
    public class Tutor : User
    {
        public string Bio { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }

        public ICollection<Subject> TaughtSubjects { get; set; } = new List<Subject>();
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        public ICollection<TutorAvailability> Availabilities { get; set; } = new List<TutorAvailability>();
    }
}
