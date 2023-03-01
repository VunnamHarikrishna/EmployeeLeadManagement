using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KalingaManagementSystem.Models
{
    public class Lead
    {
        //@Name,@ContactNumber,@CatogeryId
        public int LeadID { get; set; }
        [DisplayName("Lead Name ")]
        [Required(ErrorMessage = "Name is Required")]
        [RegularExpression(@"^[a-z A-Z]*$", ErrorMessage = "Please Enter valid Lead Name")]
        public string Name { get; set; }

        [DisplayName("Mobile Number ")]
        [Required(ErrorMessage = "Phone number is Required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Please Enter Valid mobile number ")]
        public string ContactNumber { get; set; }
        public int CatogeryId { get; set; }
    }
}