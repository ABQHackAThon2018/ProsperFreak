using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class Employer : Person
    {
        public string Industry { get; set; }
        public string Title { get; set; }

        [Display(Name = "Jobs Available?")]
        public bool JobsAvailable { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
