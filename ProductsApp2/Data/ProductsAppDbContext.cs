using Microsoft.EntityFrameworkCore;
using ProductsApp2.Models.Domains;

namespace ProductsApp2.Data
{
    public class ProductsAppDbContext : DbContext
    {
        public ProductsAppDbContext(DbContextOptions<ProductsAppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Products>().HasData(
                new Products { Id = Guid.NewGuid(), ProductName = "Apple", ProductPrice = 1.2, ProductDescription = "Fresh red apples", ProductImageUrl = "https://example.com/apple.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Banana", ProductPrice = 0.8, ProductDescription = "Ripe bananas", ProductImageUrl = "https://example.com/banana.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Orange", ProductPrice = 1.5, ProductDescription = "Juicy oranges", ProductImageUrl = "https://example.com/orange.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Milk", ProductPrice = 1.0, ProductDescription = "1 litre of whole milk", ProductImageUrl = "https://example.com/milk.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Bread", ProductPrice = 1.1, ProductDescription = "Whole grain bread", ProductImageUrl = "https://example.com/bread.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Cheese", ProductPrice = 2.5, ProductDescription = "Cheddar cheese", ProductImageUrl = "https://example.com/cheese.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Butter", ProductPrice = 1.8, ProductDescription = "Salted butter", ProductImageUrl = "https://example.com/butter.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Eggs", ProductPrice = 2.0, ProductDescription = "A dozen eggs", ProductImageUrl = "https://example.com/eggs.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Yogurt", ProductPrice = 0.9, ProductDescription = "Natural yogurt", ProductImageUrl = "https://example.com/yogurt.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Tomato", ProductPrice = 1.3, ProductDescription = "Fresh tomatoes", ProductImageUrl = "https://example.com/tomato.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Carrot", ProductPrice = 1.0, ProductDescription = "Organic carrots", ProductImageUrl = "https://example.com/carrot.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Potato", ProductPrice = 0.7, ProductDescription = "Fresh potatoes", ProductImageUrl = "https://example.com/potato.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Lettuce", ProductPrice = 1.2, ProductDescription = "Green lettuce", ProductImageUrl = "https://example.com/lettuce.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Chicken Breast", ProductPrice = 5.0, ProductDescription = "Boneless chicken breast", ProductImageUrl = "https://example.com/chicken.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Salmon", ProductPrice = 10.0, ProductDescription = "Fresh salmon fillets", ProductImageUrl = "https://example.com/salmon.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Pasta", ProductPrice = 1.5, ProductDescription = "Italian pasta", ProductImageUrl = "https://example.com/pasta.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Rice", ProductPrice = 1.3, ProductDescription = "Basmati rice", ProductImageUrl = "https://example.com/rice.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Olive Oil", ProductPrice = 4.0, ProductDescription = "Extra virgin olive oil", ProductImageUrl = "https://example.com/oliveoil.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Salt", ProductPrice = 0.5, ProductDescription = "Sea salt", ProductImageUrl = "https://example.com/salt.jpg" },
                new Products { Id = Guid.NewGuid(), ProductName = "Pepper", ProductPrice = 0.7, ProductDescription = "Black pepper", ProductImageUrl = "https://example.com/pepper.jpg" }
            );
        }
    }
}
