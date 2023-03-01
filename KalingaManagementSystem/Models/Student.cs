using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KalingaManagementSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [DisplayName("Student Name ")]
        [Required(ErrorMessage = "Name is Required")]
        [RegularExpression(@"^[a-z A-Z]*$", ErrorMessage = "Please Enter valid Srudent Name")]
        public string StudentName { get; set; }

        [Required]
        public string DOJ { get; set; }
        [DisplayName("Mobile Number ")]
        [Required(ErrorMessage = "Phone number is Required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Please Enter Valid mobile number ")]
        //[Range()]
        public string ContactNumber { get; set; }
        [Required]
        public string Address { get; set; }
        public int LeadId { get; set; }
    }
}