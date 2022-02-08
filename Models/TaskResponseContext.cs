using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission6.Models
{
    public class TaskResponseContext : DbContext
    {
        // Constructor
        public TaskResponseContext(DbContextOptions<TaskResponseContext> options) : base(options)
        {
            // Leaving this blank for now
        }

        public DbSet<TaskResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }
            );

            mb.Entity<TaskResponse>().HasData(
            
                new TaskResponse
                {
                    TaskID = 1,
                    TaskName = "Read Book of Mormon",
                    DueDate = "01/01/2022",
                    Quadrant = 2,
                    CategoryID = 4,
                    Completed = false
                },
                new TaskResponse
                {
                    TaskID = 2,
                    TaskName = "Watch Book of Boba Fett",
                    DueDate = "02/09/2022",
                    Quadrant = 4,
                    CategoryID = 1,
                    Completed = false
                }
            );
        }
    }
}
