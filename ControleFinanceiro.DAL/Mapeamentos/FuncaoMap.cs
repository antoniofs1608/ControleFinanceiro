using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class FuncaoMap : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            // quem vai cuidar dos usuários e funções é o Identity e ele já vem com conjunto
            // pré pronto de classes, então vamos precisar modificar poucas coisas
            //1ª ao criar uma função o valor da chave primária não é gerada automaticamente, a PK da função é o Id
            builder.Property(f => f.Id).ValueGeneratedOnAdd();

            // atributo da class model
            builder.Property(f => f.Descricao).IsRequired().HasMaxLength(50);

            // relacionamento já vem configurado

            // adicionar dados na tabela
            // NormalizeName é justamente onde a função usa para comparar valores
            builder.HasData(
                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR",
                    Descricao = "Administrador do sistema"
                },


                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Usuario",
                    NormalizedName = "USUARIO",
                    Descricao = "Usuário do sistema"
                });

            // nome da tabela
            builder.ToTable("Funcoes");
        }
    }
}
