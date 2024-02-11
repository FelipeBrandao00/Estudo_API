using API_Produtos.Interface;
using API_Produtos.Models;

namespace API_Produtos.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DatabaseContext _dbContext;

        public ProdutoRepository(DatabaseContext context)
        {
            this._dbContext = context;
        }
        public Produto addProduto(ProdutoDTO produtoDto)
        {
            Produto produto = produtoDto;
            _dbContext.Produtos.Add(produto);
            _dbContext.SaveChanges();
            return produto;
        }

        public Produto AttProduto(ProdutoDTO produtoDto, int id)
        {
            var produto = GetProdutoById(id);

            if (produto == null) return produto;

            if (produtoDto.Preco != 0) produto.Preco = produtoDto.Preco;
            if (produtoDto.Quantidade != 0) produto.Quantidade = produtoDto.Quantidade;
            if (!string.IsNullOrEmpty(produtoDto.Descricao)) produto.Descricao = produtoDto.Descricao;
            if (!string.IsNullOrEmpty(produtoDto.Nome)) produto.Nome = produtoDto.Nome;

            _dbContext.Produtos.Update(produto);
            _dbContext.SaveChanges();
            return produto;
        }

        public Produto DelProduto(int id)
        {
            var produto = GetProdutoById(id);

            if (produto == null) return produto;

            _dbContext.Produtos.Remove(produto);
            _dbContext.SaveChanges();
            return produto;

        }

        public Produto GetProdutoById(int id)
        {
            return _dbContext.Produtos.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Produto> GetProdutos()
        {
            return _dbContext.Produtos.ToList();
        }
    }
}
