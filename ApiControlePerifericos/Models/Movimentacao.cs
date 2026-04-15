using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public Produto? Produto { get; set; }
        [JsonIgnore]
        public Colaborador? Colaborador { get; set; }

    }
}
