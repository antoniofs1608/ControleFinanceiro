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
            // Quem vai cuidar dos usuários e funções é o Identity e ele já vem com conjunto
            // pré-pronto de classes, então vamos precisar modificar poucas coisas
            // 1ª ao criar uma função o valor da chave primária não é gerado automaticamente,
            // (.ValueGenerateOnAdd()) a PK da função é o Id
            builder.Property(f => f.Id).ValueGeneratedOnAdd();

            builder.Property(f => f.Descricao).IsRequired().HasMaxLength(50);

            // Relacionamento já vem configurado

            // Adicionar dados na tabela
            // NormalizeName é justamente onde a função usa para comparar valores e tem
            // que ser tudo em maiúscula
            builder.HasData(
                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR",
                    Descricao = "Administrador do Sistema"
                },

                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Usuario",
                    NormalizedName = "USUARIO",
                    Descricao = "Usuário do Sistema"
                });

            builder.ToTable("Funcoes");
        }
    }
}