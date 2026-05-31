using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TutoringWebapp.Domain.Contracts;
using TutoringWebapp.Domain.Models;

namespace TutoringWebapp.Infrastructure.Repositories
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private readonly TutoringDbContext _tutoringDbContext;

        public SubjectRepository(TutoringDbContext tutoringDbContext) : base(tutoringDbContext) => _tutoringDbContext = tutoringDbContext;

    }
}