using ApiControlePerifericos.Context;
using ApiControlePerifericos.Interfaces;
using ApiControlePerifericos.Models;

namespace ApiControlePerifericos.Repositories
{
    public class MovimentacaoRepository: Repository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(AppDbContext context) : base(context)
        {
        }
        public IEnumerable<Movimentacao> GetMovimentacoesPorProduto(int produtoId)
        {
            return _context.Movimentacoes.Where(m => m.ProdutoId == produtoId).ToList();
        }
        public IEnumerable<Movimentacao> GetMovimentacoesPorColaborador(int colaboradorId)
        {
            return _context.Movimentacoes.Where(m => m.ColaboradorId == colaboradorId).ToList();
        }
    }
}
