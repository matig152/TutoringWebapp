using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.Application.Services
{
    public interface ITutorService
    {
        Guid Create(CreateTutorDto dto);
        List<TutorDto> GetAll();
        TutorDto GetById(Guid id);
        bool Update(Guid id, TutorDto dto);
        bool Delete(Guid id);
    }
}
