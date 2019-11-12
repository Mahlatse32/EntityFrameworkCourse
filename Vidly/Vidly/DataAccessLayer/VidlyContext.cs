using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DataAccessLayer
{
    public class VidlyContext : DbContext 
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public VidlyContext()
            : base("name=DeafaultConnection")
        {

        }
    }
}