namespace SOLER.API.Repository.IRepositoryHRManagementSystem
{
    public interface IPayrollRepository<T>
    {
        Task<(IEnumerable<T> Payrolls, string Message)> GetAllPayrollsAsync();
        Task<(T? Payroll, string Message)> GetPayrollByIDAsync(int Id);
        Task<(int PayrollId, string Message)> CreatePayrollAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdatePayrollAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeletePayrollAsync(int Id);
    }
}
