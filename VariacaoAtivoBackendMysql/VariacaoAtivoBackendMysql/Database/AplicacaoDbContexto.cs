using Microsoft.EntityFrameworkCore;
using VariacaoAtivoBackendMysql.Modelos;

namespace VariacaoAtivoBackendMysql.Database
{
    public class AplicacaoDbContexto : DbContext
    {
        public AplicacaoDbContexto(DbContextOptions<AplicacaoDbContexto> opcoes) : base(opcoes)
        {
        }

        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Historico> Historico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Historico>().HasOne<Acao>(h => h.Acao).WithMany(a => a.Historico);
        }
    }
}
