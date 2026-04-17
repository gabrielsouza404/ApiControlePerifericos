using ApiControlePerifericos.Context;
using ApiControlePerifericos.Interfaces;

namespace ApiControlePerifericos.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private IProdutoRepository? _produtoRepo;
        private IColaboradorRepository? _colaboradorRepo;
        private IMovimentacaoRepository? _movimentacaoRepo; 

        public AppDbContext _context;

        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }

        //Lazy loading
        public IColaboradorRepository ColaboradorRepository
        {
            get
            {
                return _colaboradorRepo ??= new ColaboradorRepository(_context);
                //Mesma coisa que 
                // return _colaboradorRepo = _colaboradorRepo ?? new ColaboradorRepository(_context);
            }
        }

        public IProdutoRepository ProdutoRepository
        {
            get 
            {
                return _produtoRepo ??= new ProdutoRepository(_context);
            }
        }

        public IMovimentacaoRepository MovimentacaoRepository
        {
            get
            {
                return _movimentacaoRepo ??= new MovimentacaoRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
