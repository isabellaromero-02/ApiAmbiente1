using Microsoft.EntityFrameworkCore;
using ApiAmbiente1.Entities;
namespace ApiAmbiente1.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>
           options)
           : base(options)

        {
        }
        public DbSet<Ambiente> Ambiente { get; set; }
        public DbSet<Novedad> Novedad { get; set; }
    }
}
