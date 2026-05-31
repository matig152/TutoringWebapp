using TutoringWebapp.Domain.Contracts;

namespace TutoringWebapp.Infrastructure
{
    public class TutoringUnitOfWork : ITutoringUnitOfWork
    {
        private readonly TutoringDbContext _context;

        public ILessonRepository LessonRepository { get; }
        public IStudentRepository StudentRepository { get; }
        public ISubjectRepository SubjectRepository { get; }
        public ITutorRepository TutorRepository { get; }
        public IAdminRepository AdminRepository { get; }
        public ITutorAvailabilityRepository TutorAvailabilityRepository { get; }

        public TutoringUnitOfWork(
            TutoringDbContext context,
            ILessonRepository lessonRepository,
            IStudentRepository studentRepository,
            ISubjectRepository subjectRepository,
            ITutorRepository tutorRepository,
            IAdminRepository adminRepository,
            ITutorAvailabilityRepository tutorAvailabilityRepository
        )
        {
            this._context = context;
            this.LessonRepository = lessonRepository;
            this.StudentRepository = studentRepository;
            this.SubjectRepository = subjectRepository;
            this.TutorRepository = tutorRepository;
            this.AdminRepository = adminRepository;
            this.TutorAvailabilityRepository = tutorAvailabilityRepository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
