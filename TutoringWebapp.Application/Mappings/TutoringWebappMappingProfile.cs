using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TutoringWebapp.Domain.Models;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.Application.Mappings
{
    public class TutoringWebappMappingProfile : Profile
    {
        public TutoringWebappMappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentDto, Student>();

            CreateMap<Tutor, TutorDto>();
            CreateMap<CreateTutorDto, Tutor>();

            CreateMap<Admin, AdminDto>();
            CreateMap<CreateAdminDto, Admin>();

            CreateMap<Subject, SubjectDto>();
            CreateMap<CreateSubjectDto, Subject>();

            CreateMap<Lesson, LessonDto>();
            CreateMap<CreateLessonDto, Lesson>();

            CreateMap<TutorAvailability, TutorAvailabilityDto>();
            CreateMap<CreateTutorAvailabilityDto, TutorAvailability>();
        }
    }
}
