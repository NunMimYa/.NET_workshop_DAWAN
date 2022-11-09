using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        /*
        The Key attribute
        The [Key] attribute is used to identify a property as the primary key (PK) when the property name is something other than classnameID or ID.
        There's a one-to-zero-or-one relationship between the Instructor and OfficeAssignment entities. An office assignment only exists in relation to the instructor it's assigned to. The OfficeAssignment PK is also its foreign key (FK) to the Instructor entity. A one-to-zero-or-one relationship occurs when a PK in one table is both a PK and a FK in another table.
        EF Core can't automatically recognize InstructorID as the PK of OfficeAssignment because InstructorID doesn't follow the ID or classnameID naming convention. Therefore, the Key attribute is used to identify InstructorID as the PK:
        */
        [Key]
        public int InstructorID { get; set; }
        /*
         * By default, EF Core treats the key as non-database-generated 
         * because the column is for an identifying relationship
         */
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }
        /*The Instructor navigation property
         * The Instructor.OfficeAssignment navigation property can be null 
         * because there might not be an OfficeAssignment row for a given instructor. 
         * An instructor might not have an office assignment.
         * The OfficeAssignment.Instructor navigation property will always have 
         * an instructor entity because the foreign key InstructorID type is int, 
         * a non-nullable value type. 
         * An office assignment can't exist without an instructor.
         * When an Instructor entity has a related OfficeAssignment entity, 
         * each entity has a reference to the other one in its navigation property.
         */
        public Instructor Instructor { get; set; }
    }
}