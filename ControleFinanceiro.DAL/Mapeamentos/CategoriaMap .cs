using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.CategoriaId);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Icone).IsRequired().HasMaxLength(15);

            // Várias Categorias (WithMany) pode estar relaciona a um Tipo (Assone)
            // Configura a chave estrangeira (HasForeignKey) TipoId conforme está na
            // Model Categoria.cs (public int TipoId { get; set; })
            builder.HasOne(c => c.Tipo).WithMany(c => c.Categorias).HasForeignKey(c => c.TipoId).IsRequired();

            // Uma Categoria (WithOne) pode estar relacionado a vários Ganho (HasMany)
            builder.HasMany(c => c.Ganhos).WithOne(c => c.Categoria);

            // Uma Categoria (WithOne) pode estar relacionado a vários Despesas (HasMany)
            builder.HasMany(c => c.Despesas).WithOne(c => c.Categoria);

            builder.ToTable("Categorias");
        }
    }
}
