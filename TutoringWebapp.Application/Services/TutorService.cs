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
    public class TutorService : ITutorService
    {
        private readonly ITutoringUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TutorService(ITutoringUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Guid Create(CreateTutorDto dto)
        {
            var tutor = _mapper.Map<Tutor>(dto);
            tutor.Id = Guid.NewGuid();
            tutor.CreatedAt = DateTime.Now;
            _unitOfWork.TutorRepository.Insert(tutor);
            _unitOfWork.Commit();
            return tutor.Id;
        }

        public List<TutorDto> GetAll()
        {
            var tutors = _unitOfWork.TutorRepository.GetAll();
            List<TutorDto> result = _mapper.Map<List<TutorDto>>(tutors);
            return result;
        }

        public TutorDto GetById(Guid id)
        {
            var tutors = _unitOfWork.TutorRepository.GetAll();
            var tutor = tutors.FirstOrDefault(t => t.Id == id);
            return _mapper.Map<TutorDto>(tutor);
        }

        public bool Update(Guid id, TutorDto dto)
        {
            var tutors = _unitOfWork.TutorRepository.GetAll().ToList();
            var tutor = tutors.FirstOrDefault(t => t.Id == id);
            if (tutor == null) return false;

            tutor.FirstName = dto.FirstName;
            tutor.LastName = dto.LastName;
            tutor.Email = dto.Email;
            tutor.PasswordHash = dto.PasswordHash;
            tutor.Bio = dto.Bio;

            _unitOfWork.TutorRepository.Insert(tutor);
            _unitOfWork.Commit();
            return true;
        }

        public bool Delete(Guid id)
        {
            var tutors = _unitOfWork.TutorRepository.GetAll().ToList();
            var tutor = tutors.FirstOrDefault(t => t.Id == id);
            if (tutor == null) return false;

            _unitOfWork.TutorRepository.Delete(tutor);
            _unitOfWork.Commit();
            return true;
        }
    }
}
