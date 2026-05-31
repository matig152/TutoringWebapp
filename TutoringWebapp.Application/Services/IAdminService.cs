using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.Application.Services
{
    public interface IAdminService
    {
        Guid Create(CreateAdminDto dto);
        List<AdminDto> GetAll();
        AdminDto GetById(Guid id);
        bool Update(Guid id, AdminDto dto);
        bool Delete(Guid id);
    }
}
