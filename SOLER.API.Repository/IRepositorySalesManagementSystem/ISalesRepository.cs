namespace SOLER.API.Repository.IRepositorySalesManagementSystem
{
    public interface ISalesRepository<T>
    {
        Task<(IEnumerable<T> Sales, string Message)> GetAllSalesAsync();
        Task<(T? Sale, string Message)> GetSalesByIDAsync(int Id);
        Task<(int SaleId, string Message)> CreateSalesAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateSalesAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteSalesAsync(int Id);
    }
}
