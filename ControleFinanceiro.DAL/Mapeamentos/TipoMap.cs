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
            // Chave primária
            builder.HasKey(t => t.TipoId);

            // Nome obrigatório, caso não queira colocar IsRequired(false)
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(20);

            // Um Tipo (WithOne) pode estar relacionado a várias Categorias (HasMany)
            builder.HasMany(t => t.Categorias).WithOne(t => t.Tipo);

            // Adicionar dados na tabela
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

            // Nome da tabela
            builder.ToTable("Tipos");
        }
    }
}