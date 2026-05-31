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
    public class SubjectService : ISubjectService
    {
        private readonly ITutoringUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectService(ITutoringUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public int Create(CreateSubjectDto dto)
        {
            var subject = _mapper.Map<Subject>(dto);
            _unitOfWork.SubjectRepository.Insert(subject);
            _unitOfWork.Commit();
            var subjects = _unitOfWork.SubjectRepository.GetAll();
            return subjects.FirstOrDefault(s => s.Name == subject.Name)?.Id ?? 0;
        }

        public List<SubjectDto> GetAll()
        {
            var subjects = _unitOfWork.SubjectRepository.GetAll();
            List<SubjectDto> result = _mapper.Map<List<SubjectDto>>(subjects);
            return result;
        }

        public SubjectDto GetById(int id)
        {
            var subjects = _unitOfWork.SubjectRepository.GetAll();
            var subject = subjects.FirstOrDefault(s => s.Id == id);
            return _mapper.Map<SubjectDto>(subject);
        }

        public bool Update(int id, SubjectDto dto)
        {
            var subjects = _unitOfWork.SubjectRepository.GetAll().ToList();
            var subject = subjects.FirstOrDefault(s => s.Id == id);
            if (subject == null) return false;

            subject.Name = dto.Name;
            subject.Description = dto.Description;

            _unitOfWork.SubjectRepository.Insert(subject);
            _unitOfWork.Commit();
            return true;
        }

        public bool Delete(int id)
        {
            var subjects = _unitOfWork.SubjectRepository.GetAll().ToList();
            var subject = subjects.FirstOrDefault(s => s.Id == id);
            if (subject == null) return false;

            _unitOfWork.SubjectRepository.Delete(subject);
            _unitOfWork.Commit();
            return true;
        }
    }
}
