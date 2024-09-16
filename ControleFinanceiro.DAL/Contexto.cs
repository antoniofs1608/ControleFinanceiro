using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Mapeamentos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL
{
    public class Contexto : IdentityDbContext<Usuario, Funcao, string>
    {
        // Um DbSet representa a coleção de todas as entidades no contexto ou que podem ser consultadas do banco de dados de um determinado tipo.
        // Os objetos DbSet são criados a partir de um DbContext usando o método DbContext.Set.

        // Vamos criar nossos DBSet onde teremos todas nossas ações (inclusão, exclusão, alteração, consulta, etc) a serem realizadas.
        // Por exemplo quando precisar usar Cartoes eu crio uma variável do tipo Contexto e basta colocar Contexto.Cartoes.
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<Ganho> Ganhos { get; set; }
        public DbSet<Mes> Meses { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // Passar as opções
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Passar as configurações das tabelas, precisamos sobrescrever a função que cria o Bando de Dados que é o OnModelCreating
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CartaoMap());
            builder.ApplyConfiguration(new CategoriaMap());
            builder.ApplyConfiguration(new DespesaMap());
            builder.ApplyConfiguration(new FuncaoMap());
            builder.ApplyConfiguration(new GanhoMap());
            builder.ApplyConfiguration(new MesMap());
            builder.ApplyConfiguration(new TipoMap());
            builder.ApplyConfiguration(new UsuarioMap());
        }
    }
}