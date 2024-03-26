using System.Collections.Generic;

namespace ControleFinanceiro.BLL.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public required string Nome { get; set; }
        public required string Icone { get; set; }

        public int TipoId { get; set; } // pra fazer a chave estrangeira
        public Tipo? Tipo { get; set; } // pra fazer a chave estrangeira

        public virtual ICollection<Despesa>? Despesas { get; set; } // Categoria pode ter várias Despesas

        public virtual ICollection<Ganho>? Ganhos { get; set; } // Categoria pode ter várias Ganhos
    }
}