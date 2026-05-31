using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.Application.Services
{
    public interface ITutorAvailabilityService
    {
        Guid Create(CreateTutorAvailabilityDto dto);
        List<TutorAvailabilityDto> GetAll();
        TutorAvailabilityDto GetById(Guid id);
        bool Update(Guid id, TutorAvailabilityDto dto);
        bool Delete(Guid id);
    }
}
