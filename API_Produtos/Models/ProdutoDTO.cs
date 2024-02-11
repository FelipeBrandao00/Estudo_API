using System.ComponentModel.DataAnnotations;

namespace API_Produtos.Models
{
    public class ProdutoDTO
    {
        public string Nome { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; }
        public string? Descricao { get; set; }
    }
}
