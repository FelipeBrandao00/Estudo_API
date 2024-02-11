using API_Produtos.Interface;
using API_Produtos.Models;

namespace API_Produtos.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Produto addProduto(ProdutoDTO produto)
        {
            return _produtoRepository.addProduto(produto);
        }

        public Produto AttProduto(ProdutoDTO produto, int cdProduto)
        {
            return _produtoRepository.AttProduto(produto, cdProduto);
        }

        public Produto DelProduto(int id)
        {
            return _produtoRepository.DelProduto(id);
        }

        public Produto GetProdutoById(int id)
        {
            return _produtoRepository.GetProdutoById(id);
        }

        public List<Produto> GetProdutos()
        {
            return _produtoRepository.GetProdutos();
        }
    }
}
