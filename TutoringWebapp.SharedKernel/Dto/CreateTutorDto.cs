using System;
using TutoringWebapp.Domain.Models;

namespace TutoringWebapp.SharedKernel.Dto
{
    public class CreateTutorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public decimal HourlyRate { get; set; }
        public List<int> SubjectIds { get; set; } = new List<int>();
    }
}
