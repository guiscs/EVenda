using EVenda.Venda.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EVenda.Venda.Data.Context
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Produto> Produtos { get; set; }
    }
}
