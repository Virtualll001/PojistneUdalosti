using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PojistneUdalosti.Models;

namespace PojistneUdalosti.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pojisteni> Pojisteni { get; set; }
        public DbSet<Pojistnik> Pojistnik { get; set; }
        public DbSet<Udalost> Udalost { get; set; }     
    }
}
