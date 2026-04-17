namespace ApiControlePerifericos.Interfaces
{
    public interface IUnityOfWork
    {
        IColaboradorRepository ColaboradorRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        IMovimentacaoRepository MovimentacaoRepository { get; }

        void Commit();
    }
}
