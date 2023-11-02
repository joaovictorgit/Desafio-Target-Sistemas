using Microsoft.EntityFrameworkCore;
using Release_WebApi.Models;

namespace Release_WebApi.Data
{
    public class ReleaseContext : DbContext
    {
        public ReleaseContext(DbContextOptions<ReleaseContext> options) : base (options) {}
        public DbSet<Release> releases { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Release>().HasKey(r => r.Id);
            builder.Entity<Release>().Property(r => r.descricao).HasMaxLength(500).IsRequired();
            builder.Entity<Release>().Property(r => r.data).IsRequired();
            builder.Entity<Release>().Property(r => r.valor).HasPrecision(14, 2).IsRequired();
            builder.Entity<Release>().Property(r => r.avulso).IsRequired();
            builder.Entity<Release>().Property(r => r.status).IsRequired();

            builder.Entity<Release>().HasData(new List<Release>(){
                new (1, "Teste 1", DateTime.Now, 10, "Válido", "Válido"),
                new (2, "Teste 2", DateTime.Now, 20, "Não Avulso", "Cancelado")
            });
        }
    }
}