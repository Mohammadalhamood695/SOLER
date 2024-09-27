namespace SOLER.API.BusinessLayer.IService.IServiceHRManagementSystem
{
    public interface ISupplierService
    {
        Task<(IEnumerable<SupplierDTO> Suppliers, string Message)> GetAllSuppliersAsync();
        Task<(SupplierDTO? Supplier, string Message)> GetSupplierByIDAsync(int Id);
        Task<(int SupplierId, string Message)> CreateSupplierAsync(SupplierDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateSupplierAsync(SupplierDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteSupplierAsync(int Id);
    }
}
