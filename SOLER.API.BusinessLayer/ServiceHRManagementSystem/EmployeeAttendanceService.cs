using SOLER.API.Repository.IRepositoryHRManagementSystem;

namespace SOLER.API.BusinessLayer.ServiceHRManagementSystem
{
    public class EmployeeAttendanceService : IEmployeeAttendanceService
    {
        private readonly IEmployeeAttendanceRepository<EmployeeAttendanceDTO> _employeeAttendanceRepository;
        private readonly ILogger<EmployeeAttendanceService> _logger;

        public EmployeeAttendanceService(
            IEmployeeAttendanceRepository<EmployeeAttendanceDTO> employeeAttendanceRepository,
            ILogger<EmployeeAttendanceService> logger)
        {
            _employeeAttendanceRepository = employeeAttendanceRepository ?? throw new ArgumentNullException(nameof(employeeAttendanceRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int AttendanceId, string Message)> CreateEmployeeAttendanceAsync(EmployeeAttendanceDTO employeeAttendanceDTO)
        {
            try
            {
                return await _employeeAttendanceRepository.CreateEmployeeAttendanceAsync(employeeAttendanceDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating employee attendance in service layer.");
                return (0, "An error occurred while creating the employee attendance.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteEmployeeAttendanceAsync(int employeeAttendanceID)
        {
            try
            {
                return await _employeeAttendanceRepository.DeleteEmployeeAttendanceAsync(employeeAttendanceID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting employee attendance with ID {employeeAttendanceID} in service layer.");
                return (false, "An error occurred while deleting the employee attendance.");
            }
        }

        public async Task<(IEnumerable<EmployeeAttendanceDTO> Attendances, string Message)> GetAllEmployeeAttendancesAsync()
        {
            try
            {
                return await _employeeAttendanceRepository.GetAllEmployeeAttendancesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all employee attendances in service layer.");
                return (null, "An error occurred while retrieving all employee attendances.");
            }
        }

        public async Task<(EmployeeAttendanceDTO? Attendance, string Message)> GetEmployeeAttendanceByIDAsync(int employeeAttendanceID)
        {
            try
            {
                return await _employeeAttendanceRepository.GetEmployeeAttendanceByIDAsync(employeeAttendanceID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving employee attendance with ID {employeeAttendanceID} in service layer.");
                return (null, "An error occurred while retrieving the employee attendance.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateEmployeeAttendanceAsync(EmployeeAttendanceDTO employeeAttendanceDTO)
        {
            try
            {
                return await _employeeAttendanceRepository.UpdateEmployeeAttendanceAsync(employeeAttendanceDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating employee attendance in service layer.");
                return (false, "An error occurred while updating the employee attendance.");
            }
        }
    }
}
