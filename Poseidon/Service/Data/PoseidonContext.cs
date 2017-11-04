using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Service.Data
{
    public class PoseidonContext : DbContext
    {
        public PoseidonContext(DbContextOptions<PoseidonContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create tables with singular names (defaults are plural)
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<StudentSubject>()
                .ToTable("StudentSubject")
                .HasKey(s => new { s.StudentID, s.SubjectID, s.EnrollmentSemenster });   // Sets composite primary key
            modelBuilder.Entity<Subject>().ToTable("Subject");
        }
    }
}
