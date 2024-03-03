using System.ComponentModel.DataAnnotations;

namespace API_Produtos.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [MinLength(0)]
        public float Preco { get; set; }
        [Required]
        [MinLength(0)]
        public int Quantidade { get; set; }
        public string? Descricao { get; set; }


        public static implicit operator ProdutoDTO(Produto produto)
        {
            return new ProdutoDTO()
            {
                Descricao = produto.Descricao,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade
            };
        }

        public static implicit operator Produto(ProdutoDTO produtoDto)
        {
            return new Produto()
            {
                Descricao = produtoDto.Descricao,
                Nome = produtoDto.Nome,
                Preco = produtoDto.Preco,
                Quantidade = produtoDto.Quantidade
            };
        }
    }
}
