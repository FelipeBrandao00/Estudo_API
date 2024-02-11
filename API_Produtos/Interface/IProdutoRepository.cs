using API_Produtos.Models;

namespace API_Produtos.Interface
{
    public interface IProdutoRepository
    {
        public List<Produto> GetProdutos();
        public Produto GetProdutoById(int id);
        public Produto AttProduto(ProdutoDTO produto, int cdProduto);
        public Produto DelProduto(int id);
        public Produto addProduto(ProdutoDTO produto);
    }
}
