using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FoodAroundTheGlobe.Models;

namespace FoodAroundTheGlobe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FoodStand> FoodStands { get; set; }

        public DbSet<Workshop> Workshops { get; set; }

    }
}
