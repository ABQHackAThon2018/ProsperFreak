using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class ApplicantModel : Person
    {
     
        
        public bool Landscaping { get; set; }

        public bool Housework { get; set; }

        public bool Construction { get; set; }

        [Display(Name = "Food Prep")]
        public bool Foodprep { get; set; }

        [Display(Name = "Auto Mechanic")]
        public bool AutoMechanic { get; set; }

        [Display(Name = "Customer Service")]
        public bool CustomerService { get; set; }

        public bool Administrative { get; set; }

        [Display(Name = "Available Now")]
        public bool AvailableNow { get; set; }

        [Display(Name = "Available Start Time Each Day")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Available End Time Each Day")]
        public DateTime EndTime { get; set; }

    }
}
