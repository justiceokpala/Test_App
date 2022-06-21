using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_App.Models;

namespace Test_App.Data_Seed
{
    public static class UserSeed
    {
        public static void SeedCustomerData( this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData
            (
                new User
                {
                    Id = 1,
                    FirstName = "Jonathan",
                    LastName = "Walters",
                    PhoneNumber = "07035765489",
                    Email = "jwalt09@gmail.com"

                },
                 new User
                 {
                     Id = 2,
                     FirstName = "Jonathan",
                     LastName = "Peters",
                     PhoneNumber = "07035765489",
                     Email = "justicecharles497@gmail.com"

                 },
                  new User
                  {
                      Id = 3,
                      FirstName = "Jonathan",
                      LastName = "Walters",
                      PhoneNumber = "07035765489",
                      Email = "justiceokpala9@gmail.com"

                  }


            );  
        }
    }
}
