namespace SOLER.API.Repository.IRepositoryHRManagementSystem
{
    public interface IEmployeeRepository<T>
    {
        Task<(IEnumerable<T> Employees, string Message)> GetAllEmployeesAsync();
        Task<(T? Employee, string Message)> GetEmployeeByIDAsync(int Id);
        Task<(int EmployeeId, string Message)> CreateEmployeeAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateEmployeeAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteEmployeeAsync(int Id);
    }
}
