//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APTA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class STUDENT
    {
        public int STUDENT_ID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LAST_NAME { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FIRST_NAME { get; set; }
        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        public string PHONE { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EMAIL { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> REGISTRATION_DATE { get; set; }
        public int EVENT_ID { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual EVENT EVENT { get; set; }
    }
}
