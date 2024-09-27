namespace SOLER.API.BusinessLayer.IService.IServiceInvoiceManagementSystem
{
    public interface IInvoicesService
    {
        Task<(IEnumerable<InvoicesDTO> Invoices, string Message)> GetAllInvoicesAsync();
        Task<(InvoicesDTO? Invoice, string Message)> GetInvoiceByIDAsync(int Id);
        Task<(int InvoiceId, string Message)> CreateInvoiceAsync(InvoicesDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateInvoiceAsync(InvoicesDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteInvoiceAsync(int Id);
    }
}
