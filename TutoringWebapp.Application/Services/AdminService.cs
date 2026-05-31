using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TutoringWebapp.Domain.Models;
using TutoringWebapp.Domain.Contracts;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly ITutoringUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(ITutoringUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Guid Create(CreateAdminDto dto)
        {
            var admin = _mapper.Map<Admin>(dto);
            admin.Id = Guid.NewGuid();
            admin.CreatedAt = DateTime.Now;
            _unitOfWork.AdminRepository.Insert(admin);
            _unitOfWork.Commit();
            return admin.Id;
        }

        public List<AdminDto> GetAll()
        {
            var admins = _unitOfWork.AdminRepository.GetAll();
            List<AdminDto> result = _mapper.Map<List<AdminDto>>(admins);
            return result;
        }

        public AdminDto GetById(Guid id)
        {
            var admins = _unitOfWork.AdminRepository.GetAll();
            var admin = admins.FirstOrDefault(a => a.Id == id);
            return _mapper.Map<AdminDto>(admin);
        }

        public bool Update(Guid id, AdminDto dto)
        {
            var admins = _unitOfWork.AdminRepository.GetAll().ToList();
            var admin = admins.FirstOrDefault(a => a.Id == id);
            if (admin == null) return false;

            admin.FirstName = dto.FirstName;
            admin.LastName = dto.LastName;
            admin.Email = dto.Email;
            admin.PasswordHash = dto.PasswordHash;

            _unitOfWork.AdminRepository.Insert(admin);
            _unitOfWork.Commit();
            return true;
        }

        public bool Delete(Guid id)
        {
            var admins = _unitOfWork.AdminRepository.GetAll().ToList();
            var admin = admins.FirstOrDefault(a => a.Id == id);
            if (admin == null) return false;

            _unitOfWork.AdminRepository.Delete(admin);
            _unitOfWork.Commit();
            return true;
        }
    }
}
