using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API_Produtos.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            
        }
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
    }
}
