using API.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.DataContext
{
   public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
