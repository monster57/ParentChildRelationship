using System.Data.Entity;

namespace CreateTree.Model
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("CreateTree")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}