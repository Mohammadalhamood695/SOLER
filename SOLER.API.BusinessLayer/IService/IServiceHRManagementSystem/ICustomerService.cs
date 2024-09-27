namespace SOLER.API.BusinessLayer.IService.IServiceHRManagementSystem
{
    public interface ICustomerService
    {
        Task<(IEnumerable<CustomerDTO> Customers, string Message)> GetAllCustomersAsync();
        Task<(CustomerDTO? Customer, string Message)> GetCustomerByIDAsync(int Id);
        Task<(int CustomerId, string Message)> CreateCustomerAsync(CustomerDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateCustomerAsync(CustomerDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteCustomerAsync(int Id);
    }
}
