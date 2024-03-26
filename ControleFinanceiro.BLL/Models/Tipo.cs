using System.Collections.Generic;

namespace ControleFinanceiro.BLL.Models
{
    public class Tipo
    {
        public int TipoId { get; set; }

        public required string Nome { get; set; }

        // Evitar desperdiço de memória
        // Tipo pode ter várias Categorias
        public virtual ICollection<Categoria> Categorias { get; set; }
    }
}