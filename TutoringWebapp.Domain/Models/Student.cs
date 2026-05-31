using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringWebapp.Domain.Models
{
    public enum EducationLevel { Elementary, HighSchool, College}
    public class Student : User
    {
        public EducationLevel EducationLevel { get; set; }

        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
