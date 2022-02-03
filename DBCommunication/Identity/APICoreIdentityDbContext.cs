using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DBCommunication.Identity
{
    public partial class APICoreIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public APICoreIdentityDbContext()
        {
        }

        public APICoreIdentityDbContext(DbContextOptions<APICoreIdentityDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-MNNOJHC\\SQLEXPRESS;Database=APICoreDB;Trusted_Connection=True;");
            }
        }
    }
}
