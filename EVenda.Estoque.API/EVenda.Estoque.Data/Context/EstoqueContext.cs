using EVenda.Estoque.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EVenda.Estoque.Data.Context
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
