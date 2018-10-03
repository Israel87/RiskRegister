using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static RiskRegister.CustomEnum.Enum;

namespace RiskRegisterII.Models
{
    public class ComplaintRegister
    {
        public int Id { get; set; }
        [Display(Name ="Name of Client")]
        public string NameofClient { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Date Received")]
        public DateTime DateReceived { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }       
        public ProcessStatus Status { get; set; }

    }
}
