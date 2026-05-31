using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.Application.Services
{
    public interface ISubjectService
    {
        int Create(CreateSubjectDto dto);
        List<SubjectDto> GetAll();
        SubjectDto GetById(int id);
        bool Update(int id, SubjectDto dto);
        bool Delete(int id);
    }
}
