namespace ControleFinanceiro.BLL.Models
{
    public class Despesa
    {
        public int DespesaId { get; set; }

        public int CartaoId { get; set; }
        public required Cartao Cartao { get; set; }

        public required string Descricao { get; set; }

        public int CategoriaId { get; set; }
        public required Categoria Categoria { get; set; }

        public double Valor { get; set; }

        public int Dia { get; set; }

        public int MesId { get; set; }
        public required Mes Mes { get; set; }
        public int Ano { get; set; }

        public required string UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }
    }
}