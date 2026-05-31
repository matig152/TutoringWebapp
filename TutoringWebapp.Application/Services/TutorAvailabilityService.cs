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
    public class TutorAvailabilityService : ITutorAvailabilityService
    {
        private readonly ITutoringUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TutorAvailabilityService(ITutoringUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Guid Create(CreateTutorAvailabilityDto dto)
        {
            var availability = _mapper.Map<TutorAvailability>(dto);
            availability.Id = Guid.NewGuid();
            _unitOfWork.TutorAvailabilityRepository.Insert(availability);
            _unitOfWork.Commit();
            return availability.Id;
        }

        public List<TutorAvailabilityDto> GetAll()
        {
            var availabilities = _unitOfWork.TutorAvailabilityRepository.GetAll();
            List<TutorAvailabilityDto> result = _mapper.Map<List<TutorAvailabilityDto>>(availabilities);
            return result;
        }

        public TutorAvailabilityDto GetById(Guid id)
        {
            var availabilities = _unitOfWork.TutorAvailabilityRepository.GetAll();
            var availability = availabilities.FirstOrDefault(a => a.Id == id);
            return _mapper.Map<TutorAvailabilityDto>(availability);
        }

        public bool Update(Guid id, TutorAvailabilityDto dto)
        {
            var availabilities = _unitOfWork.TutorAvailabilityRepository.GetAll().ToList();
            var availability = availabilities.FirstOrDefault(a => a.Id == id);
            if (availability == null) return false;

            availability.TutorId = dto.TutorId;
            availability.DayOfWeek = dto.DayOfWeek;
            availability.StartTime = dto.StartTime;
            availability.EndTime = dto.EndTime;

            _unitOfWork.TutorAvailabilityRepository.Insert(availability);
            _unitOfWork.Commit();
            return true;
        }

        public bool Delete(Guid id)
        {
            var availabilities = _unitOfWork.TutorAvailabilityRepository.GetAll().ToList();
            var availability = availabilities.FirstOrDefault(a => a.Id == id);
            if (availability == null) return false;

            _unitOfWork.TutorAvailabilityRepository.Delete(availability);
            _unitOfWork.Commit();
            return true;
        }
    }
}
