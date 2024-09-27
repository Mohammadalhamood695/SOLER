namespace SOLER.API.Repository.IRepositoryHRManagementSystem
{
    public interface ISupplierRepository<T>
    {
        Task<(IEnumerable<T> Suppliers, string Message)> GetAllSuppliersAsync();
        Task<(T? Supplier, string Message)> GetSupplierByIDAsync(int Id);
        Task<(int SupplierId, string Message)> CreateSupplierAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateSupplierAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteSupplierAsync(int Id);
    }
}
