using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class EnrollmentMetaData
    {
        [Display(Name = "Student Grade")]
        public Nullable<decimal> Grade { get; set; }
        
        [Display(Name = "Course")]
        public int CourseID { get; set; }
        [Display(Name = "Course")]
        public Course Course { get; set; }
        
        [Display(Name = "Student")]
        public int StudentID { get; set; }
        [Display(Name = "Student")]
        public Student Student { get; set; }

        [Display(Name = "Leacturer")]
        public Nullable<int> LecturerId { get; set; }
        [Display(Name = "Leacturer")]
        public Lecturer Lecturer { get; set; }
    }

    [MetadataType(typeof(EnrollmentMetaData))]
    public partial class Enrollment
    { 

    }
}