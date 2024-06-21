using Microsoft.EntityFrameworkCore;
using ProductsApp2.Data;
using ProductsApp2.Models.Domains;

namespace ProductsApp2.Models.Repositories
{
    public class SQLProductRepository : IProductsRepository
    {
        private ProductsAppDbContext dbContext;

        public SQLProductRepository(ProductsAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Products> CreateAsync(Products product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Products?> DeleteAsync(Guid id)
        {
            var existingProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProduct == null)
            {
                return null;
            }
            dbContext.Products.Remove(existingProduct);
            await dbContext.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<List<Products>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAsc = true, int pageNumber = 1, int pageSize = 20)
        {
            
                var products = dbContext.Products.AsQueryable();
                //filtering
                if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
                {
                    if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    {
                    products = products.Where(x => x.ProductName.Contains(filterQuery));
                    }

                }
                //sorting:

                if (string.IsNullOrWhiteSpace(sortBy) == false)
                {
                    if (sortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                    {
                    products = isAsc ? products.OrderBy(x => x.ProductPrice) : products.OrderByDescending(x => x.ProductPrice);
                    }
                    if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    {
                    products = isAsc ? products.OrderBy(x => x.ProductName) : products.OrderByDescending(x => x.ProductName);
                    }
                }

                //pagination:
                var skipResults = (pageNumber - 1) * pageSize;


                return await products.Skip(skipResults).Take(pageSize).ToListAsync();
            }

        public async Task<Products?> GetByIdAsync(Guid id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Products?> UpdateAsync(Guid id, Products product)
        {
            var existingProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductDescription = product.ProductDescription;
            existingProduct.ProductPrice = product.ProductPrice;
            existingProduct.ProductImageUrl = product.ProductImageUrl;
           

            await dbContext.SaveChangesAsync();
            return existingProduct;
        }
        //public DbSet<Products> Employees { get; set; }
    }
}
