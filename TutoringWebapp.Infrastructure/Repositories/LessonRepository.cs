using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TutoringWebapp.Domain.Contracts;
using TutoringWebapp.Domain.Models;

namespace TutoringWebapp.Infrastructure.Repositories
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        private readonly TutoringDbContext _tutoringDbContext;

        public LessonRepository(TutoringDbContext tutoringDbContext) : base(tutoringDbContext) => _tutoringDbContext = tutoringDbContext;

    }
}
