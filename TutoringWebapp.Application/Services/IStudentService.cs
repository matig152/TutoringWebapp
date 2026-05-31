using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.Application.Services
{
    public interface IStudentService
    {
        Guid Create(CreateStudentDto dto);
        List<StudentDto> GetAll();
        StudentDto GetById(Guid id);
        bool Update(Guid id, StudentDto dto);
        bool Delete(Guid id);
    }
}
