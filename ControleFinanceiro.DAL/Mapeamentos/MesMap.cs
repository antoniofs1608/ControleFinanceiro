using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class MesMap : IEntityTypeConfiguration<Mes>
    {
        public void Configure(EntityTypeBuilder<Mes> builder)
        {
            // chave primária
            builder.HasKey(m => m.MesId);
            // nome obrigatório, caso não queira colocar IsRequired(false)
            builder.Property(m => m.Nome).IsRequired().HasMaxLength(20);
            // nome não pode repetir
            builder.HasIndex(m => m.Nome).IsUnique();

            // uma despesa esta relacionado a um mes, mas um mês pode estar relacionado a várias despesas
            builder.HasMany(m => m.Despesas).WithOne(m => m.Mes);
            // um ganho esta relacionado a um mes, mas um mês pode estar relacionado a vários ganhos
            builder.HasMany(m => m.Ganhos).WithOne(m => m.Mes);

            // adicionar dados na tabela
            builder.HasData(
                new Mes
                {
                    MesId = 1,
                    Nome = "Janeiro"
                },
                new Mes
                {
                    MesId = 2,
                    Nome = "Fevereiro"
                },

                new Mes
                {
                    MesId = 3,
                    Nome = "Março"
                },
                new Mes
                {
                    MesId = 4,
                    Nome = "Abril"
                },
                new Mes
                {
                    MesId = 5,
                    Nome = "Maio"
                },
                new Mes
                {
                    MesId = 6,
                    Nome = "Junho"
                },
                new Mes
                {
                    MesId = 7,
                    Nome = "Julho"
                },
                new Mes
                {
                    MesId = 8,
                    Nome = "Agosto"
                },
                new Mes
                {
                    MesId = 9,
                    Nome = "Setembro"
                },
                new Mes
                {
                    MesId = 10,
                    Nome = "Outubro"
                },
                new Mes
                {
                    MesId = 11,
                    Nome = "Novembro"
                },
                new Mes
                {
                    MesId = 12,
                    Nome = "Dezembro"
                });

            // nome da tabela
            builder.ToTable("Meses");
        }
    }
}
