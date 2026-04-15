using ApiControlePerifericos.Models;

namespace ApiControlePerifericos.Interfaces
{
    public interface IMovimentacaoRepository: IRepository<Movimentacao>
    {
        IEnumerable<Movimentacao> GetMovimentacoesPorProduto(int produtoId);
        IEnumerable<Movimentacao> GetMovimentacoesPorColaborador(int colaboradorId);
    }
}
