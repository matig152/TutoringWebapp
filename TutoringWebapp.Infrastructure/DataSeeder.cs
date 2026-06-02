using TutoringWebapp.Domain.Models;

namespace TutoringWebapp.Infrastructure
{
    public class DataSeeder
    {
        private readonly TutoringDbContext _dbContext;

        public DataSeeder(TutoringDbContext context)
        {
            this._dbContext = context;
        }

        public void Seed()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Database.CanConnect())
            {
                // Seed Students
                if (!_dbContext.Students.Any())
                {
                    var students = new List<Student>
                    {
                        new Student()
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "John",
                            LastName = "Doe",
                            Email = "example.john@example.com",
                            CreatedAt = DateTime.Now,
                            EducationLevel = EducationLevel.Elementary,
                            ImageUrl = "https://i.pravatar.cc/300?img=1"
                        },
                        new Student()
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            Email = "example.jan@example.com",
                            CreatedAt = DateTime.Now,
                            EducationLevel = EducationLevel.HighSchool,
                            ImageUrl = "https://i.pravatar.cc/300?img=2"
                        },
                        new Student()
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Alice",
                            LastName = "Smith",
                            Email = "alice.smith@example.com",
                            CreatedAt = DateTime.Now,
                            EducationLevel = EducationLevel.College,
                            ImageUrl = "https://i.pravatar.cc/300?img=3"
                        },
                    };
                    _dbContext.Students.AddRange(students);
                    _dbContext.SaveChanges();
                }

                // Seed Tutors
                if (!_dbContext.Tutors.Any())
                {
                    var tutors = new List<Tutor>
                    {
                        new Tutor()
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Maria",
                            LastName = "Garcia",
                            Email = "maria.garcia@example.com",
                            PasswordHash = "hashed_password_1",
                            CreatedAt = DateTime.Now,
                            Bio = "Experienced math and physics tutor with 5 years of experience",
                            ImageUrl = "https://i.pravatar.cc/300?img=5",
                            HourlyRate = 60.00m
                        },
                        new Tutor()
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Peter",
                            LastName = "Johnson",
                            Email = "peter.johnson@example.com",
                            PasswordHash = "hashed_password_2",
                            CreatedAt = DateTime.Now,
                            Bio = "English language specialist, passionate about literature and writing",
                            ImageUrl = "https://i.pravatar.cc/300?img=6",
                            HourlyRate = 50.00m
                        },
                        new Tutor()
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Emma",
                            LastName = "Wilson",
                            Email = "emma.wilson@example.com",
                            PasswordHash = "hashed_password_3",
                            CreatedAt = DateTime.Now,
                            Bio = "Chemistry expert with focus on exam preparation",
                            ImageUrl = "https://i.pravatar.cc/300?img=7",
                            HourlyRate = 55.00m
                        },
                    };
                    _dbContext.Tutors.AddRange(tutors);
                    _dbContext.SaveChanges();
                }

                // Seed Admins
                if (!_dbContext.Admins.Any())
                {
                    var admins = new List<Admin>
                    {
                        new Admin()
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Robert",
                            LastName = "Brown",
                            Email = "robert.brown@example.com",
                            PasswordHash = "admin_hashed_password_1",
                            CreatedAt = DateTime.Now,
                            ImageUrl = "https://i.pravatar.cc/300?img=8"
                        },
                        new Admin()
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Sarah",
                            LastName = "Miller",
                            Email = "sarah.miller@example.com",
                            PasswordHash = "admin_hashed_password_2",
                            CreatedAt = DateTime.Now,
                            ImageUrl = "https://i.pravatar.cc/300?img=9"
                        },
                    };
                    _dbContext.Admins.AddRange(admins);
                    _dbContext.SaveChanges();
                }

                // Seed Subjects
                if (!_dbContext.Subjects.Any())
                {
                    var subjects = new List<Subject>
                    {
                        new Subject()
                        {
                            Name = "Mathematics",
                            Description = "Algebra, geometry, calculus, and advanced mathematical concepts",
                        },
                        new Subject()
                        {
                            Name = "English",
                            Description = "Literature, writing, grammar, and communication skills",
                        },
                        new Subject()
                        {
                            Name = "Chemistry",
                            Description = "Organic and inorganic chemistry with laboratory concepts",
                        },
                        new Subject()
                        {
                            Name = "Physics",
                            Description = "Mechanics, thermodynamics, and modern physics",
                        },
                        new Subject()
                        {
                            Name = "History",
                            Description = "World history, ancient civilizations, and modern era",
                        },
                    };
                    _dbContext.Subjects.AddRange(subjects);
                    _dbContext.SaveChanges();
                }

                // Seed Lessons
                if (!_dbContext.Lessons.Any())
                {
                    var students = _dbContext.Students.ToList();
                    var tutors = _dbContext.Tutors.ToList();
                    var subjects = _dbContext.Subjects.ToList();

                    if (students.Any() && tutors.Any() && subjects.Any())
                    {
                        var lessons = new List<Lesson>
                        {
                            new Lesson()
                            {
                                Id = Guid.NewGuid(),
                                StudentId = students[0].Id,
                                TutorId = tutors[0].Id,
                                SubjectId = subjects[0].Id, // Mathematics
                                ScheduledTime = DateTime.Now.AddDays(1),
                                DurationMinutes = 60,
                                HourlyRate = 50.00m,
                                Topic = "Algebra basics",
                                Status = LessonStatus.Scheduled,
                            },
                            new Lesson()
                            {
                                Id = Guid.NewGuid(),
                                StudentId = students[1].Id,
                                TutorId = tutors[1].Id,
                                SubjectId = subjects[1].Id, // English
                                ScheduledTime = DateTime.Now.AddDays(2),
                                DurationMinutes = 90,
                                HourlyRate = 45.00m,
                                Topic = "Shakespeare interpretation",
                                Status = LessonStatus.Scheduled,
                            },
                            new Lesson()
                            {
                                Id = Guid.NewGuid(),
                                StudentId = students[2].Id,
                                TutorId = tutors[2].Id,
                                SubjectId = subjects[2].Id, // Chemistry
                                ScheduledTime = DateTime.Now.AddDays(3),
                                DurationMinutes = 75,
                                HourlyRate = 55.00m,
                                Topic = "Periodic table and reactions",
                                Status = LessonStatus.Scheduled,
                            },
                            new Lesson()
                            {
                                Id = Guid.NewGuid(),
                                StudentId = students[0].Id,
                                TutorId = tutors[1].Id,
                                SubjectId = subjects[3].Id, // Physics
                                ScheduledTime = DateTime.Now.AddDays(4),
                                DurationMinutes = 60,
                                HourlyRate = 50.00m,
                                Topic = "Newton's laws",
                                Status = LessonStatus.Completed,
                            },
                        };
                        _dbContext.Lessons.AddRange(lessons);
                        _dbContext.SaveChanges();
                    }
                }

                // Seed TutorAvailabilities
                if (!_dbContext.Availabilities.Any())
                {
                    var tutors = _dbContext.Tutors.ToList();

                    if (tutors.Any())
                    {
                        var availabilities = new List<TutorAvailability>
                        {
                            new TutorAvailability()
                            {
                                Id = Guid.NewGuid(),
                                TutorId = tutors[0].Id,
                                DayOfWeek = DayOfWeek.Monday,
                                StartTime = new TimeOnly(9, 0),
                                EndTime = new TimeOnly(17, 0),
                            },
                            new TutorAvailability()
                            {
                                Id = Guid.NewGuid(),
                                TutorId = tutors[0].Id,
                                DayOfWeek = DayOfWeek.Wednesday,
                                StartTime = new TimeOnly(10, 0),
                                EndTime = new TimeOnly(18, 0),
                            },
                            new TutorAvailability()
                            {
                                Id = Guid.NewGuid(),
                                TutorId = tutors[1].Id,
                                DayOfWeek = DayOfWeek.Tuesday,
                                StartTime = new TimeOnly(14, 0),
                                EndTime = new TimeOnly(20, 0),
                            },
                            new TutorAvailability()
                            {
                                Id = Guid.NewGuid(),
                                TutorId = tutors[1].Id,
                                DayOfWeek = DayOfWeek.Thursday,
                                StartTime = new TimeOnly(14, 0),
                                EndTime = new TimeOnly(20, 0),
                            },
                            new TutorAvailability()
                            {
                                Id = Guid.NewGuid(),
                                TutorId = tutors[2].Id,
                                DayOfWeek = DayOfWeek.Saturday,
                                StartTime = new TimeOnly(10, 0),
                                EndTime = new TimeOnly(16, 0),
                            },
                            new TutorAvailability()
                            {
                                Id = Guid.NewGuid(),
                                TutorId = tutors[2].Id,
                                DayOfWeek = DayOfWeek.Sunday,
                                StartTime = new TimeOnly(10, 0),
                                EndTime = new TimeOnly(16, 0),
                            },
                        };
                        _dbContext.Availabilities.AddRange(availabilities);
                        _dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}
