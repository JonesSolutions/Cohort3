using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContosoUniversity.Validation;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public Student()
        {

        }
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="Get a shorter last name please. Maximum 50 characters.")]
        [RegularExpression(@"^[A-Z].*$", ErrorMessage ="Last name must with a capital letter.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Get a shorter first name please. Maximum 50 characters.")]
        [RegularExpression(@"^[A-Z].*$", ErrorMessage = "First name must with a capital letter.")]
        [Display(Name = "First Mid Name")]
        public string FirstMidName { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage ="Please enter a valid date (yyyy/MM/DD)")]
        [Display(Name ="Enrollment Date")]
        //[Range(typeof(DateTime),"01/01/1900", "01/01/2016")]
        [ValidateDateRange(FirstDate = "01/10/2008", SecondDate = "01/01/2010", ErrorMessage ="Please enter a date in the valid range.")]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
