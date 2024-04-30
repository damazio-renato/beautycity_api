using Facens.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facens.Data.Mappings
{
    public class CidadaoMapping : IEntityTypeConfiguration<Cidadao>
    {
        public void Configure(EntityTypeBuilder<Cidadao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Sobrenome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Celular)
                .IsRequired()
                .HasColumnType("varchar(11)");

            // 1 : 1 => Cidadao : Endereco
            builder.HasOne(c => c.Endereco)
                .WithOne(e => e.Cidadao);

            // 1 : N => Cidadao : Solicitacoes
            builder.HasMany(c => c.Solicitacoes)
                .WithOne(s => s.Cidadao)
                .HasForeignKey(s => s.CidadaoId);

            builder.ToTable("Cidadaos");
        }
    }
}
