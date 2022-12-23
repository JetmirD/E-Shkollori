using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ligjerata_7___xhelali2.Models;

namespace Ligjerata_7___xhelali2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Models.Student> Students { get; set; }
        public DbSet<Ligjerata_7___xhelali2.Models.Mesuesi> Mesuesi { get; set; }
    }
}