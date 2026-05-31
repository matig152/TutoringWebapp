using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.Application.Services
{
    public interface ILessonService
    {
        Guid Create(CreateLessonDto dto);
        List<LessonDto> GetAll();
        LessonDto GetById(Guid id);
        bool Update(Guid id, LessonDto dto);
        bool Delete(Guid id);
    }
}
