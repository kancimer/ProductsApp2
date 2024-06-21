using ProductsApp2.Models.Domains;

namespace ProductsApp2.Models.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Products>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAsc = true,
            int pageNumber = 1, int pageSize = 20);

        Task<Products?> GetByIdAsync(Guid id);
        Task<Products> CreateAsync(Products product);

        Task<Products?> UpdateAsync(Guid id, Products product);

        Task<Products?> DeleteAsync(Guid id);
    }
}
