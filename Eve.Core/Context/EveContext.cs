using Eve.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eve.Core.Models.Context
{
    public class EveContext : DbContext
    {
        public DbSet<UserLogin> Users { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Media> Media { get; set; }

        public EveContext(DbContextOptions<EveContext> options) : base(options) { }
    }
}
