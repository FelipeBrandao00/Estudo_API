using API_Produtos.Interface;
using API_Produtos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService service)
        {
            _produtoService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_produtoService.GetProdutos());
        }

        [HttpGet("id:int")]
        public IActionResult GetById(int id)
        {
            var produto = _produtoService.GetProdutoById(id);

            if (produto == null) return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult AddProduto(ProdutoDTO produtoDTO)
        {
            return Ok(_produtoService.addProduto(produtoDTO));
        }


        [HttpDelete("id:int")]
        public IActionResult Delete(int id)
        {
            var produto = _produtoService.DelProduto(id);

            if (produto == null) return NotFound();

            return Ok(produto);
        }

        [HttpPut]
        public IActionResult Update(int id, ProdutoDTO produtoDTO)
        {
            var produto = _produtoService.AttProduto(produtoDTO, id);

            if (produto == null) return NotFound();

            return Ok(produto);
        }
    }
}
