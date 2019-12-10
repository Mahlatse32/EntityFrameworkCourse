using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.DataAccessLayer
{
    public class VidlyContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MembershipType> membershipTypes { get; set; }

        public VidlyContext()
            : base("name=DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static VidlyContext Create()
        {
            return new VidlyContext();
        }
    }
}