using Microsoft.EntityFrameworkCore;
using TutoringWebapp.Infrastructure;
using TutoringWebapp.Application.Services;
using TutoringWebapp.Domain.Contracts;
using TutoringWebapp.Infrastructure.Repositories;
using TutoringWebapp.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(TutoringWebappMappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TutoringDbContext>();

// Seed Data
builder.Services.AddScoped<DataSeeder>();

// Custom services
builder.Services.AddScoped<ITutoringUnitOfWork, TutoringUnitOfWork>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITutorService, TutorService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<ITutorAvailabilityService, TutorAvailabilityService>();


builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ITutorRepository, TutorRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ITutorAvailabilityRepository, TutorAvailabilityRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TutoringDbContext>();
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

    dbContext.Database.Migrate();
    dataSeeder.Seed();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
