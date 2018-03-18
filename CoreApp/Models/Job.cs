using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class Job
    {
        public int JobID { get; set; }

        public string PositionTitle { get; set; }

        public string Task { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        [DataType(DataType.Currency)]
        public double PaymentAmount { get; set; }

        public bool FreeFood { get; set; }
    }
}
