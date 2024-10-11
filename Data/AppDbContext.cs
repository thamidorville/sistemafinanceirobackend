using Microsoft.EntityFrameworkCore;
using GerenciamentoFinanceiroAPI.Models;

namespace GerenciamentoFinanceiroAPI.Data
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Receitas> Receitas { get; set; }
        public DbSet<Despesas> Despesas { get; set; }
    }
}
