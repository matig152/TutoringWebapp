using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringWebapp.Domain.Models;

namespace TutoringWebapp.SharedKernel.Dto
{
    public class TutorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public decimal HourlyRate { get; set; }
        public List<SubjectDto> TaughtSubjects { get; set; } = new List<SubjectDto>();
    }
}
