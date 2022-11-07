using Confitec.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Confitec.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<User> Users { get; set; }
    }
}
