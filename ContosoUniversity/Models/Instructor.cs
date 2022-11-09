using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Security.Policy;

namespace ContosoUniversity.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstMidName; }
        }

        //Navigation properties
        //The Courses and OfficeAssignment properties are navigation properties.
        //An instructor can teach any number of courses, so Courses is defined as a collection.
        public ICollection<Course> Courses { get; set; }
        //An instructor can have at most one office,
        //so the OfficeAssignment property holds a single OfficeAssignment entity.
        //OfficeAssignment is null if no office is assigned.
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}