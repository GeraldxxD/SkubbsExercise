using Exercise3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Exercise3.Database
{
   public class Exercise3Context : DbContext
    {
        

        public Exercise3Context()
        {
        }

        public Exercise3Context(DbContextOptions<Exercise3Context> options)
            : base(options)
        {
        }
        public virtual DbSet<Employee> Employee { get; set; } = null!;

    }
}
