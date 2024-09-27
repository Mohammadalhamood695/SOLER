namespace SOLER.API.BusinessLayer.IService.IServiceSalesManagementSystem
{
    public interface ISalesService
    {
        Task<(IEnumerable<SalesDTO> Sales, string Message)> GetAllSalesAsync();
        Task<(SalesDTO? Sale, string Message)> GetSalesByIDAsync(int Id);
        Task<(int SaleId, string Message)> CreateSalesAsync(SalesDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateSalesAsync(SalesDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteSalesAsync(int Id);
    }
}
