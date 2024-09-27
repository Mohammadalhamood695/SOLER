using SOLER.API.Repository.IRepositoryHRManagementSystem;

namespace SOLER.API.BusinessLayer.ServiceHRManagementSystem
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository<EmployeeDTO> _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(
            IEmployeeRepository<EmployeeDTO> employeeRepository,
            ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int EmployeeId, string Message)> CreateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            try
            {
                return await _employeeRepository.CreateEmployeeAsync(employeeDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating employee in service layer.");
                return (0, "An error occurred while creating the employee.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteEmployeeAsync(int employeeID)
        {
            try
            {
                return await _employeeRepository.DeleteEmployeeAsync(employeeID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting employee with ID {employeeID} in service layer.");
                return (false, "An error occurred while deleting the employee.");
            }
        }

        public async Task<(IEnumerable<EmployeeDTO> Employees, string Message)> GetAllEmployeesAsync()
        {
            try
            {
                return await _employeeRepository.GetAllEmployeesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all employees in service layer.");
                return (null, "An error occurred while retrieving all employees.");
            }
        }

        public async Task<(EmployeeDTO? Employee, string Message)> GetEmployeeByIDAsync(int employeeID)
        {
            try
            {
                return await _employeeRepository.GetEmployeeByIDAsync(employeeID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving employee with ID {employeeID} in service layer.");
                return (null, "An error occurred while retrieving the employee.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            try
            {
                return await _employeeRepository.UpdateEmployeeAsync(employeeDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating employee in service layer.");
                return (false, "An error occurred while updating the employee.");
            }
        }
    }
}
