namespace SOLER.API.Repository.IRepositoryProcurementManagementSystem
{
    public interface IProcurementProductsRepository<T>
    {
        Task<(IEnumerable<T> ProcurementProducts, string Message)> GetAllProcurementProductsAsync();
        Task<(T? ProcurementProduct, string Message)> GetProcurementProductByIDAsync(int Id);
        Task<(int ProcurementProductId, string Message)> CreateProcurementProductAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateProcurementProductAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteProcurementProductAsync(int Id);
    }
}
