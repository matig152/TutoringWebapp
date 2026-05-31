using System;
using TutoringWebapp.Domain.Models;

namespace TutoringWebapp.SharedKernel.Dto
{
    public class CreateStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public EducationLevel EducationLevel { get; set; }
    }
}
