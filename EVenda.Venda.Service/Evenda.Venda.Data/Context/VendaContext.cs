using EVenda.Venda.Data.Models;
using EVenda.Venda.Utils;
using Microsoft.EntityFrameworkCore;

namespace EVenda.Venda.Data.Context
{
    public class VendaContext : DbContext
    {
        public VendaContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string stringConexao = ParametersUtils.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(stringConexao);
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
