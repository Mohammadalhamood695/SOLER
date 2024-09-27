namespace SOLER.API.Repository.IRepositoryProductManagementSystem
{
    public interface IProductsRepository<T>
    {
        Task<(IEnumerable<T> Products, string Message)> GetAllProductsAsync();
        Task<(T? Product, string Message)> GetProductByIDAsync(int Id);
        Task<(int ProductId, string Message)> CreateProductAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateProductAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteProductAsync(int Id);
    }
}
