using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        /* UPDATES */
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Course>().ToTable("Course");
            //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            //modelBuilder.Entity<Student>().ToTable("Student");

            modelBuilder.Entity<Course>().ToTable(nameof(Course))
                .HasMany(c => c.Instructors)
                .WithMany(i => i.Courses);
            modelBuilder.Entity<Student>().ToTable(nameof(Student));
            modelBuilder.Entity<Instructor>().ToTable(nameof(Instructor));
        }
    }
}

/*
 * Update adds the new entities and configures the many-to-many relationship between the Instructor and Course entities.
 * 
 * Fluent API alternative to attributes:
 * The OnModelCreating method in the preceding code uses the fluent API to configure EF Core behavior. 
 * The API is called "fluent" because it's often used by stringing a series of method calls together into a single statement.
 * 
 * 
 * In this tutorial, the fluent API is used only for database mapping that can't be done with attributes. 
 * However, the fluent API can specify most of the formatting, validation, and mapping rules that can be done with attributes.
 * Some attributes such as MinimumLength can't be applied with the fluent API. 
 * MinimumLength doesn't change the schema, it only applies a minimum length validation rule.
 * Some developers prefer to use the fluent API exclusively so that they can keep their entity classes clean. 
 * Attributes and the fluent API can be mixed. There are some configurations that can only be done with the fluent API, for example, specifying a composite PK. 
 * There are some configurations that can only be done with attributes (MinimumLength). The recommended practice for using fluent API or attributes:
 * Choose one of these two approaches.
 * Use the chosen approach consistently as much as possible.
 * Some of the attributes used in this tutorial are used for:
 * Validation only (for example, MinimumLength).
 * EF Core configuration only (for example, HasKey).
 * Validation and EF Core configuration (for example, [StringLength(50)]).
 */