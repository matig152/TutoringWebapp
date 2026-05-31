using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TutoringWebapp.Domain.Contracts;
using TutoringWebapp.Domain.Models;

namespace TutoringWebapp.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly TutoringDbContext _tutoringDbContext;

        public StudentRepository(TutoringDbContext tutoringDbContext) : base(tutoringDbContext) => _tutoringDbContext = tutoringDbContext;

    }
}
