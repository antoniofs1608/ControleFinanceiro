using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class TipoMap : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            // chave primária
            builder.HasKey(t => t.TipoId);
            // nome obrigatório, caso não queira colocar IsRequired(false)
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(20);

            builder.HasMany(t => t.Categorias).WithOne(t => t.Tipo);

            // adicionar dados na tabela
            builder.HasData(
                new Tipo
                {
                    TipoId = 1,
                    Nome = "Despesa"
                },
                new Tipo
                {
                    TipoId = 2,
                    Nome = "Ganho"
                });

            // nome da tabela
            builder.ToTable("Tipos");
        }
    }
}
