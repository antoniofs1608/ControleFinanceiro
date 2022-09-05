using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // quem vai cuidar dos usuários e funções é o Identity e ele já vem com conjunto
            // pré pronto de classes, então vamos precisar modificar poucas coisas
            //1ª ao criar uma função o valor da chave primária não é gerada automaticamente, a PK da função é o Id
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            // atributo da class model
            builder.Property(u => u.CPF).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.CPF).IsUnique();

            builder.Property(u => u.Profissao).IsRequired().HasMaxLength(30);

            // relacionamento, caso exclusão do usuário OnDelete nada acontece
            builder.HasMany(u => u.Cartoes).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.Despesas).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.Ganhos).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.NoAction);

            // nome da tabela
            builder.ToTable("Usuarios");
        }
    }
}
