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
    public class LessonService : ILessonService
    {
        private readonly ITutoringUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LessonService(ITutoringUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Guid Create(CreateLessonDto dto)
        {
            var lesson = _mapper.Map<Lesson>(dto);
            lesson.Id = Guid.NewGuid();
            _unitOfWork.LessonRepository.Insert(lesson);
            _unitOfWork.Commit();
            return lesson.Id;
        }

        public List<LessonDto> GetAll()
        {
            var lessons = _unitOfWork.LessonRepository.GetAll();
            List<LessonDto> result = _mapper.Map<List<LessonDto>>(lessons);
            return result;
        }

        public LessonDto GetById(Guid id)
        {
            var lessons = _unitOfWork.LessonRepository.GetAll();
            var lesson = lessons.FirstOrDefault(l => l.Id == id);
            return _mapper.Map<LessonDto>(lesson);
        }

        public bool Update(Guid id, LessonDto dto)
        {
            var lessons = _unitOfWork.LessonRepository.GetAll().ToList();
            var lesson = lessons.FirstOrDefault(l => l.Id == id);
            if (lesson == null) return false;

            lesson.StudentId = dto.StudentId;
            lesson.TutorId = dto.TutorId;
            lesson.SubjectId = dto.SubjectId;
            lesson.ScheduledTime = dto.ScheduledTime;
            lesson.DurationMinutes = dto.DurationMinutes;
            lesson.HourlyRate = dto.HourlyRate;
            lesson.Topic = dto.Topic;
            lesson.Status = dto.Status;

            _unitOfWork.LessonRepository.Insert(lesson);
            _unitOfWork.Commit();
            return true;
        }

        public bool Delete(Guid id)
        {
            var lessons = _unitOfWork.LessonRepository.GetAll().ToList();
            var lesson = lessons.FirstOrDefault(l => l.Id == id);
            if (lesson == null) return false;

            _unitOfWork.LessonRepository.Delete(lesson);
            _unitOfWork.Commit();
            return true;
        }
    }
}
