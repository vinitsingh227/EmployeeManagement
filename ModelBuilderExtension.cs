﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(

                new Employee
                {
                    Id = 101,
                    Name = "Amit",
                    Email = "Amit@gmail.com",
                    Department = Dept.IT
                },
                new Employee
                {
                    Id = 102,
                    Name = "Riya",
                    Email = "Riya@gmail.com",
                    Department = Dept.HR
                }
                );
        }
    }
}
