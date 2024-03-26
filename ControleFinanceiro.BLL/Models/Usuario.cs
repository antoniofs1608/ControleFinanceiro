using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ControleFinanceiro.BLL.Models
{
    public class Usuario : IdentityUser<string>
    {
        public required string CPF { get; set; }

        public required string Profissao { get; set; }

        public required byte[] Foto { get; set; }

        public virtual ICollection<Cartao> Cartoes { get; set; }
        public virtual ICollection<Ganho> Ganhos { get; set; }
        public virtual ICollection<Despesa> Despesas { get; set; }
    }
}
