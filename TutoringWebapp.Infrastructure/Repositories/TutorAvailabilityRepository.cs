using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TutoringWebapp.Domain.Contracts;
using TutoringWebapp.Domain.Models;

namespace TutoringWebapp.Infrastructure.Repositories
{
    public class TutorAvailabilityRepository : Repository<TutorAvailability>, ITutorAvailabilityRepository
    {
        private readonly TutoringDbContext _tutoringDbContext;

        public TutorAvailabilityRepository(TutoringDbContext tutoringDbContext) : base(tutoringDbContext) => _tutoringDbContext = tutoringDbContext;

    }
}