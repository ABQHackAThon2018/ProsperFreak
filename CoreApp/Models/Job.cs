using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class Job
    {
        public int Id { get; set; }

        public string PositionTitle { get; set; }

        public string Task { get; set; }

        public DateTime DateTime { get; set; }

        public int Payment { get; set; }

        public bool Food { get; set; }
    }
}
