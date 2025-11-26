using Microsoft.EntityFrameworkCore;

namespace RestWithASPNET10Erudio.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options)
            : base(options) { }
        public DbSet<Persons> Persons { get; set; }
    }
}
