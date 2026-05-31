using System;
using TutoringWebapp.Domain.Models;

namespace TutoringWebapp.SharedKernel.Dto
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
