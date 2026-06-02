using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TutoringWebapp.Domain.Contracts;
using TutoringWebapp.Domain.Models;

namespace TutoringWebapp.Infrastructure.Repositories
{
    public class TutorRepository : Repository<Tutor>, ITutorRepository
    {
        private readonly TutoringDbContext _tutoringDbContext;

        public TutorRepository(TutoringDbContext tutoringDbContext) : base(tutoringDbContext) => _tutoringDbContext = tutoringDbContext;

        public override IList<Tutor> GetAll()
        {
            return _tutoringDbContext.Tutors
                .Include(t => t.TaughtSubjects)
                .ToList();
        }
    }
}
