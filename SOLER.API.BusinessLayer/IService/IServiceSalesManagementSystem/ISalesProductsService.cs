namespace SOLER.API.BusinessLayer.IService.IServiceSalesManagementSystem
{
    public interface ISalesProductsService
    {
        Task<(IEnumerable<SalesProductsDTO> SalesProducts, string Message)> GetAllSalesProductsAsync();
        Task<(SalesProductsDTO? SalesProduct, string Message)> GetSalesProductByIDAsync(int Id);
        Task<(int SalesProductId, string Message)> CreateSalesProductAsync(SalesProductsDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateSalesProductAsync(SalesProductsDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteSalesProductAsync(int Id);
    }
}
