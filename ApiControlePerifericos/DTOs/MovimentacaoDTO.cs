using System.ComponentModel.DataAnnotations;

namespace ApiControlePerifericos.DTOs
{
    public class MovimentacaoDTO
    {
        public int MovimentacaoId { get; set; }

        [Required]
        public char Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime? DataMovimentacao { get; set; }
        public int ProdutoId { get; set; }
        public int ColaboradorId { get; set; }
    }
}
