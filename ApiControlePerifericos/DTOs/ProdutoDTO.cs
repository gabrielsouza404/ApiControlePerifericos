using System.ComponentModel.DataAnnotations;

namespace ApiControlePerifericos.DTOs
{
    public class ProdutoDTO
    {
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }

        public int SaldoAtual { get; set; }     
        public int EstoqueMinimo { get; set; }          
    }
}
