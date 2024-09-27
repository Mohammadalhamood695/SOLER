namespace SOLER.API.BusinessLayer.IService.IServiceHRManagementSystem
{
    public interface IPayrollService
    {
        Task<(IEnumerable<PayrollDTO> Payrolls, string Message)> GetAllPayrollsAsync();
        Task<(PayrollDTO? Payroll, string Message)> GetPayrollByIDAsync(int Id);
        Task<(int PayrollId, string Message)> CreatePayrollAsync(PayrollDTO ObjDTO);
        Task<(bool Success, string Message)> UpdatePayrollAsync(PayrollDTO ObjDTO);
        Task<(bool Success, string Message)> DeletePayrollAsync(int Id);
    }
}

