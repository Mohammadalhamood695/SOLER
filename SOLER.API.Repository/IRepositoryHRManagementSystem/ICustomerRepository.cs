namespace SOLER.API.Repository.IRepositoryHRManagementSystem
{
    public interface ICustomerRepository<T>
    {
        Task<(IEnumerable<T> Customers, string Message)> GetAllCustomersAsync();
        Task<(T? Customer, string Message)> GetCustomerByIDAsync(int Id);
        Task<(int CustomerId, string Message)> CreateCustomerAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateCustomerAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteCustomerAsync(int Id);
    }
}
