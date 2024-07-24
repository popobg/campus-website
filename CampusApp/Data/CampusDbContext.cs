using CampusApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusApp.Data
{
    public class CampusDbContext : DbContext
    {
        // ctor + double tab
        // constructor with dependancy injection --> create in program.cs
        public CampusDbContext(DbContextOptions options) : base(options) { }

        // DbSet: all the models that will be into the DB
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        //OnModelCreating: create tables during migration
        // always protected
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base method (from DbContext)
            // without override
            base.OnModelCreating(modelBuilder);

            // navigation properties are used for foreign keys

            // Add data to the Student table
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Name = "Ragnar",
                    LastName = "The Red",
                    Birthdate = new DateTime(1022, 12, 12),
                    Email = "ragnartheboss@gmail.com",
                    IsEnrolled = false
                },
                new Student()
                {
                    Id = 2,
                    Name = "Mjoll",
                    LastName = "The Lioness",
                    Birthdate = new DateTime(1492, 07, 13),
                    Email = "TheLioness78@gmail.com",
                    IsEnrolled = true
                },
                new Student()
                {
                    Id = 3,
                    Name = "Delphine",
                    LastName = "The Blade",
                    Birthdate = new DateTime(1485, 01, 05),
                    Email = "SecretBlade@yahoo.com",
                    IsEnrolled = false
                }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course()
                {
                    Id = 1,
                    Name = "History"
                },
                new Course()
                {
                    Id = 2,
                    Name = "Math"
                },
                new Course()
                {
                    Id = 3,
                    Name = "War"
                }
            );

        }
    }
}
