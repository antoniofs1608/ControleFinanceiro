using System.Collections.Generic;

namespace ControleFinanceiro.BLL.Models
{
    public class Cartao
    {
        public int CartaoId { get; set; }

        public required string Nome { get; set; }

        public required string Bandeira { get; set; }

        public required string Numero { get; set; }

        public double Limite { get; set; }

        // A FK UsuarioId é do tipo string porque para gerenciamento de usuários vamos
        // utilizar o Identity que já vem com classes prontas e seus atributos pré 
        // definidos e lá a chave primária do usuário é uma string, então aqui tem que
        // ser string também
        public required string UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }

        // Essa linha abaixo evita desperdiço de memória
        public virtual ICollection<Despesa> Despesas { get; set; }
    }
}