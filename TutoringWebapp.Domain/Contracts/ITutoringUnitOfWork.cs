using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringWebapp.Domain.Contracts
{
    public interface ITutoringUnitOfWork : IDisposable
    {
        ILessonRepository LessonRepository { get; }
        IStudentRepository StudentRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        ITutorRepository TutorRepository { get; }
        IAdminRepository AdminRepository { get; }
        ITutorAvailabilityRepository TutorAvailabilityRepository { get; }

        void Commit();
    }
}
