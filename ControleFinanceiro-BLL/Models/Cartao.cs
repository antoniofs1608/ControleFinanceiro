using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro_BLL.Models
{
    public class Cartao
    {
        public int CartaoId { get; set; }
        public string Nome { get; set; }
        public string Bandeira { get; set; }
        public string Numero { get; set; }
        public double Limite { get; set; }
        // A FK UsuarioId é do tipo string porque para gerenciamento de usuários vamos
        // utilizar o Identity que já vem com classes prontas e seus atributos pré 
        // definidos e lá a chave primária do usuário é uma string, então aqui tem que
        // ser string também
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Essa linha abaixo evita desperdiço de memória
        public virtual ICollection<Despesa> Despesas { get; set; }
    }
}
