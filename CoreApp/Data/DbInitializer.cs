using CoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any jobs.
            if (context.Job.Any())
            {
                return;   // DB has been seeded
            }

            var jobs = new Job[]
            {
            new Job{
                JobID = 123,
                PaymentAmount = 50.00,
                FreeFood = true,
                Task = "Lawnmowing",
                PositionTitle ="Gardener",
                Date = DateTime.Parse("2018-09-01"),
                Time = DateTime.Parse("12:00"),
            },

            new Job
            {
                JobID = 123,
                PaymentAmount = 50.00,
                FreeFood = true,
                Task = "Lawnmowing",
                PositionTitle = "Gardener",
                Date = DateTime.Parse("2018-09-01"),
                Time = DateTime.Parse("12:00"),
            }
            };

            foreach (Job s in jobs)
            {
                context.Job.Add(s);
            }
            context.SaveChanges();
        }
    }
}
