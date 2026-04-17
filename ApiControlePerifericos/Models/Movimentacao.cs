using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControlePerifericos.Models
{
    [Table("Movimentacoes")]
    public class Movimentacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public char Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime? DataMovimentacao { get; set; }
        public int ProdutoId { get; set; }
        public int ColaboradorId { get; set; }

        public Produto? Produto { get; set; }
        public Colaborador? Colaborador { get; set; }
        public int MovimentacaoId { get; internal set; }
    }
}
