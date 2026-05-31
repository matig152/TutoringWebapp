using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TutoringWebapp.Domain.Contracts;
using TutoringWebapp.Domain.Models;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly ITutoringUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(ITutoringUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Guid Create(CreateStudentDto dto)
        {
            var student = _mapper.Map<Student>(dto);
            student.Id = Guid.NewGuid();
            student.CreatedAt = DateTime.Now;
            _unitOfWork.StudentRepository.Insert(student);
            _unitOfWork.Commit();
            return student.Id;
        }

        public List<StudentDto> GetAll()
        {
            var students = _unitOfWork.StudentRepository.GetAll();
            List<StudentDto> result = _mapper.Map<List<StudentDto>>(students);
            return result;
        }

        public StudentDto GetById(Guid id)
        {
            var students = _unitOfWork.StudentRepository.GetAll();
            var student = students.FirstOrDefault(s => s.Id == id);
            return _mapper.Map<StudentDto>(student);
        }

        public bool Update(Guid id, StudentDto dto)
        {
            var students = _unitOfWork.StudentRepository.GetAll().ToList();
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return false;

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Email = dto.Email;
            student.PasswordHash = dto.PasswordHash;
            student.EducationLevel = dto.EducationLevel;

            _unitOfWork.StudentRepository.Insert(student);
            _unitOfWork.Commit();
            return true;
        }

        public bool Delete(Guid id)
        {
            var students = _unitOfWork.StudentRepository.GetAll().ToList();
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return false;

            _unitOfWork.StudentRepository.Delete(student);
            _unitOfWork.Commit();
            return true;
        }
    }
}
