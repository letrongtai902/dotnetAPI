using dotnetAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAPI.Data
{
    public class DotnetAPIDbContext: DbContext
    {
        public DotnetAPIDbContext() : base("DbdotnetDemoAPI")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Error> Errors { get; set; }
        
       
    }
}
