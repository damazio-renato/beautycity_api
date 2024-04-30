using Facens.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facens.Data.Mappings
{
    public class SolicitacaoMapping : IEntityTypeConfiguration<Solicitacao>
    {
        public void Configure(EntityTypeBuilder<Solicitacao> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Latitude)
                .IsRequired()
                .HasColumnType("decimal(10,6)");

            builder.Property(s => s.Longitude)
                .IsRequired()
                .HasColumnType("decimal(10,6)");

            builder.Property(s => s.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(s => s.Imagem)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : 1 => Solicitacao : Categoria
            builder.HasOne(s => s.Categoria)
                .WithOne(c => c.Solicitacao)
                .HasForeignKey<Solicitacao>(s => s.CategoriaId);

            builder.ToTable("Solicitacoes");

        }
    }
}
