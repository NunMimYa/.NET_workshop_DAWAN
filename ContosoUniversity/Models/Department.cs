using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        /*
         * The Column attribute:
         * Previously the Column attribute was used to change column name mapping. 
         * In the code for the Department entity, the Column attribute is used to change SQL data type mapping. 
         * The Budget column is defined using the SQL Server money type in the database.
         * 
         * Column mapping is generally not required. 
         * EF Core chooses the appropriate SQL Server data type based on the CLR type for the property. 
         * The CLR decimal type maps to a SQL Server decimal type. 
         * Budget is for currency, and the money data type is more appropriate for currency.
        */

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        /*
         * Foreign key and navigation properties:
         * The FK and navigation properties reflect the following relationships:
         * A department may or may not have an administrator.
         * An administrator is always an instructor. Therefore the InstructorID property is included as the FK to the Instructor entity.
         * The navigation property is named Administrator but holds an Instructor entity.
         * 
         * The ? in the preceding code specifies the property is nullable.
        */

        public int? InstructorID { get; set; }

        /*
         * Part 8 - Concurrency
         * The TimestampAttribute is what identifies the column as a concurrency tracking column. 
         * 
         * The fluent API is an alternative way to specify the tracking property:
         * modelBuilder.Entity<Department>().Property<byte[]>("ConcurrencyToken").IsRowVersion();
         */
        [Timestamp]
        public byte[] ConcurrencyToken { get; set; }

        public Instructor Administrator { get; set; }

        /*
         * A department may have many courses, so there's a Courses navigation property 
         */
        public ICollection<Course> Courses { get; set; }

        /*
         * By convention, EF Core enables cascade delete for non-nullable FKs and for many-to-many relationships. 
         * This default behavior can result in circular cascade delete rules. 
         * Circular cascade delete rules cause an exception when a migration is added.
         * For example, if the Department.InstructorID property was defined as non-nullable, EF Core would configure a cascade delete rule. 
         * In that case, the department would be deleted when the instructor assigned as its administrator is deleted. 
         * In this scenario, a restrict rule would make more sense. The following fluent API would set a restrict rule and disable cascade delete.
         * 
         * modelBuilder.Entity<Department>().HasOne(d => d.Administrator).WithMany().OnDelete(DeleteBehavior.Restrict)
         */
    }
}