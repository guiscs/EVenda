using EVenda.Estoque.Data.Models;
using EVenda.Estoque.Utils;
using Microsoft.EntityFrameworkCore;

namespace EVenda.Estoque.Data.Context
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string stringConexao = ParametersUtils.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(stringConexao);
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
