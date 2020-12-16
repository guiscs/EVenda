using EVenda.Venda.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVenda.Venda.Data
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Sku)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.QtdEstoque)
                .IsRequired();

            builder.ToTable("Produtos");
        }
    }
}
