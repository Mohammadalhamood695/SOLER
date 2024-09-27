namespace SOLER.API.BusinessLayer.IService.IServiceProcurementManagementSystem
{
    public interface IProcurementProductsService
    {
        Task<(IEnumerable<ProcurementProductsDTO> ProcurementProducts, string Message)> GetAllProcurementProductsAsync();
        Task<(ProcurementProductsDTO? ProcurementProduct, string Message)> GetProcurementProductByIDAsync(int Id);
        Task<(int ProcurementProductId, string Message)> CreateProcurementProductAsync(ProcurementProductsDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateProcurementProductAsync(ProcurementProductsDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteProcurementProductAsync(int Id);
    }
}
