namespace SOLER.API.BusinessLayer.IService.IServiceHRManagementSystem
{
    public interface IEmployeeService
    {
        Task<(IEnumerable<EmployeeDTO> Employees, string Message)> GetAllEmployeesAsync();
        Task<(EmployeeDTO? Employee, string Message)> GetEmployeeByIDAsync(int Id);
        Task<(int EmployeeId, string Message)> CreateEmployeeAsync(EmployeeDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateEmployeeAsync(EmployeeDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteEmployeeAsync(int Id);
    }
}
