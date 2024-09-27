namespace SOLER.API.Repository.IRepositorySalesManagementSystem
{
    public interface ISalesProductsRepository<T>
    {
        Task<(IEnumerable<T> SalesProducts, string Message)> GetAllSalesProductsAsync();
        Task<(T? SalesProduct, string Message)> GetSalesProductByIDAsync(int Id);
        Task<(int SalesProductId, string Message)> CreateSalesProductAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateSalesProductAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteSalesProductAsync(int Id);
    }
}
