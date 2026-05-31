

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TutoringWebapp.Domain.Models;

namespace TutoringWebapp.Infrastructure
{
    public class TutoringDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TutorAvailability> Availabilities { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tutoring.db;Foreign Keys=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var timeOnlyConverter = new ValueConverter<TimeOnly, TimeSpan>(
                timeOnly => timeOnly.ToTimeSpan(),
                timeSpan => TimeOnly.FromTimeSpan(timeSpan)
            );

            modelBuilder.Entity<TutorAvailability>()
                .Property(a => a.StartTime)
                .HasConversion(timeOnlyConverter);

            modelBuilder.Entity<TutorAvailability>()
                .Property(a => a.EndTime)
                .HasConversion(timeOnlyConverter);

            modelBuilder.Entity<Lesson>()
                .Property(l => l.HourlyRate)
                .HasConversion<double>();

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Student)
                .WithMany(s => s.Lessons)
                .HasForeignKey(l => l.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Tutor)
                .WithMany(t => t.Lessons)
                .HasForeignKey(l => l.TutorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Subject)
                .WithMany(s => s.Lessons)
                .HasForeignKey(l => l.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TutorAvailability>()
                .HasOne(a => a.Tutor)
                .WithMany(t => t.Availabilities)
                .HasForeignKey(a => a.TutorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
