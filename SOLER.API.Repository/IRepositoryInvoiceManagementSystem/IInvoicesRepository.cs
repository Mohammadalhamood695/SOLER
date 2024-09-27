namespace SOLER.API.Repository.IRepositoryInvoiceManagementSystem
{
    public interface IInvoicesRepository<T>
    {
        Task<(IEnumerable<T> Invoices, string Message)> GetAllInvoicesAsync();
        Task<(T? Invoice, string Message)> GetInvoiceByIDAsync(int Id);
        Task<(int InvoiceId, string Message)> CreateInvoiceAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateInvoiceAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteInvoiceAsync(int Id);
    }
}
