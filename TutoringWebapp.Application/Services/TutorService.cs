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

            if (dto.SubjectIds != null && dto.SubjectIds.Any())
            {
                var allSubjects = _unitOfWork.SubjectRepository.GetAll();
                tutor.TaughtSubjects = allSubjects.Where(s => dto.SubjectIds.Contains(s.Id)).ToList();
            }

            _unitOfWork.TutorRepository.Insert(tutor);
            _unitOfWork.Commit();
            return tutor.Id;
        }

        public List<TutorDto> GetAll()
        {
            var tutors = _unitOfWork.TutorRepository.GetAll();
            return _mapper.Map<List<TutorDto>>(tutors);
        }

        public TutorDto GetById(Guid id)
        {
            var tutors = _unitOfWork.TutorRepository.GetAll();
            var tutor = tutors.FirstOrDefault(t => t.Id == id);
            var dto = _mapper.Map<TutorDto>(tutor);
            if (dto != null && dto.TaughtSubjects == null)
            {
                dto.TaughtSubjects = new List<SubjectDto>();
            }
            return dto;
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
            tutor.ImageUrl = dto.ImageUrl;
            tutor.HourlyRate = dto.HourlyRate;

            if (dto.TaughtSubjects != null)
            {
                var allSubjects = _unitOfWork.SubjectRepository.GetAll();
                var subjectIds = dto.TaughtSubjects.Select(s => s.Id).ToList();
                tutor.TaughtSubjects = allSubjects.Where(s => subjectIds.Contains(s.Id)).ToList();
            }

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
