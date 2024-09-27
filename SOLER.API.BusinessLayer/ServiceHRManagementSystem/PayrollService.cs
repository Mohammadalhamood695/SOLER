using SOLER.API.Repository.IRepositoryHRManagementSystem;

namespace SOLER.API.BusinessLayer.ServiceHRManagementSystem
{
    public class PayrollService : IPayrollService
    {
        private readonly IPayrollRepository<PayrollDTO> _payrollRepository;
        private readonly ILogger<PayrollService> _logger;

        public PayrollService(
            IPayrollRepository<PayrollDTO> payrollRepository,
            ILogger<PayrollService> logger)
        {
            _payrollRepository = payrollRepository ?? throw new ArgumentNullException(nameof(payrollRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int PayrollId, string Message)> CreatePayrollAsync(PayrollDTO payrollDTO)
        {
            try
            {
                return await _payrollRepository.CreatePayrollAsync(payrollDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating payroll in service layer.");
                return (0, "An error occurred while creating the payroll.");
            }
        }

        public async Task<(bool Success, string Message)> DeletePayrollAsync(int payrollID)
        {
            try
            {
                return await _payrollRepository.DeletePayrollAsync(payrollID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting payroll with ID {payrollID} in service layer.");
                return (false, "An error occurred while deleting the payroll.");
            }
        }
        public async Task<(IEnumerable<PayrollDTO> Payrolls, string Message)> GetAllPayrollsAsync()
        {
     
            try
            {
                return await _payrollRepository.GetAllPayrollsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all payrolls in service layer.");
                return (null, "An error occurred while retrieving all payrolls.");
            }
        }

    

        public async Task<(PayrollDTO? Payroll, string Message)> GetPayrollByIDAsync(int payrollID)
        {
            try
            {
                return await _payrollRepository.GetPayrollByIDAsync(payrollID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving payroll with ID {payrollID} in service layer.");
                return (null, "An error occurred while retrieving the payroll.");
            }
        }

        public async Task<(bool Success, string Message)> UpdatePayrollAsync(PayrollDTO payrollDTO)
        {
            try
            {
                return await _payrollRepository.UpdatePayrollAsync(payrollDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating payroll in service layer.");
                return (false, "An error occurred while updating the payroll.");
            }
        }
    }
}
