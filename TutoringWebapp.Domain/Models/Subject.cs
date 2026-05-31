using System;
using System.Collections.Generic;

namespace TutoringWebapp.Domain.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
