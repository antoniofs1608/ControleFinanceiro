﻿using Microsoft.AspNetCore.Identity;

namespace ControleFinanceiro.BLL.Models
{
    public class Funcao : IdentityRole<string>
    {
        public required string Descricao { get; set; }
    }
}
