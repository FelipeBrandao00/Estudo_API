using API_Produtos.Interface;
using API_Produtos.Models;
using API_Produtos.Service;
using Microsoft.EntityFrameworkCore;

namespace Teste
{
    [TestClass]
    public class Teste
    {
        private DatabaseContext _dbContext;
        private IProdutoService _produtoService;
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void Setup()
        {
            var testName = TestContext.TestName + "_database";

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: testName) 
                .Options;

            _dbContext = new DatabaseContext(options);
            _produtoService = new ProdutoService(_dbContext);
        }

        [TestMethod]
        public void AddProduto()
        {
            ProdutoDTO produto = new ProdutoDTO
            {
                Nome = "Produto Teste",
                Preco = 10.99f,
                Quantidade = 1,
                Descricao = "Descrição Teste"
            };

            Produto produtoAdicionado = _produtoService.addProduto(produto);

            // Assert
            Assert.IsNotNull(produtoAdicionado);
            Assert.AreEqual(produto.Nome, produtoAdicionado.Nome);
            Assert.AreEqual(produto.Preco, produtoAdicionado.Preco);
            Assert.AreEqual(produto.Descricao, produtoAdicionado.Descricao);
            Assert.AreEqual(produto.Quantidade, produtoAdicionado.Quantidade);

            // Verifica se o produto foi adicionado ao contexto em memória
            Assert.AreEqual(1, _dbContext.Produtos.Count());
        }

        [TestMethod]
        public void GetProdutos()
        {
            ProdutoDTO produto = new ProdutoDTO
            {
                Nome = "Produto Teste",
                Preco = 10.99f,
                Quantidade = 1,
                Descricao = "Descrição Teste"
            };
            _produtoService.addProduto(produto);

            List<Produto> produtos = _produtoService.GetProdutos();

            Assert.AreEqual(produtos.Count, _dbContext.Produtos.Count());
        }

        [TestMethod]
        public void GetProduto()
        {
            ProdutoDTO produto = new ProdutoDTO
            {
                Nome = "Produto Teste",
                Preco = 10.99f,
                Quantidade = 1,
                Descricao = "Descrição Teste"
            };
            _produtoService.addProduto(produto);

            int id = 1;

            Produto produtoBuscado = _produtoService.GetProdutoById(1);

            Assert.IsNotNull(produtoBuscado);
            Assert.AreEqual(id, produtoBuscado.Id);
        }

        [TestMethod]
        public void AttProduto()
        {
            ProdutoDTO produtoAdd = new ProdutoDTO
            {
                Nome = "Produto Teste",
                Preco = 10.99f,
                Quantidade = 1,
                Descricao = "Descrição Teste"
            };
            _produtoService.addProduto(produtoAdd);

            ProdutoDTO produto = new ProdutoDTO
            {
                Nome = "Produto Teste Atualizado",
                Preco = 0.99f,
                Quantidade = 10,
                Descricao = "Descrição Teste Atualizado"
            };

            Produto produtoAtualizado = _produtoService.AttProduto(produto,1);

            Assert.IsNotNull(produtoAtualizado);
            Assert.AreEqual(produto.Nome, produtoAtualizado.Nome);
            Assert.AreEqual(produto.Preco, produtoAtualizado.Preco);
            Assert.AreEqual(produto.Descricao, produtoAtualizado.Descricao);
            Assert.AreEqual(produto.Quantidade, produtoAtualizado.Quantidade);
        }

        [TestMethod]
        public void DelProduto()
        {
            ProdutoDTO produto = new ProdutoDTO
            {
                Nome = "Produto Teste",
                Preco = 10.99f,
                Quantidade = 1,
                Descricao = "Descrição Teste"
            };
            _produtoService.addProduto(produto);

            Produto produtoAtualizado = _produtoService.DelProduto(1);

            Assert.IsNotNull(produtoAtualizado);

            Assert.IsNull(_dbContext.Produtos.Find(1));
        }

        [TestCleanup]
        public void Teardown()
        {
            _dbContext.Dispose();
        }
    }
}
