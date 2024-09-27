namespace SOLER.API.BusinessLayer.ServiceMaintenanceManagementSystem
{
    public class MaintenanceOperationService : IMaintenanceOperationService
    {
        private readonly IMaintenanceOperationRepository<MaintenanceOperationDTO> _maintenanceOperationRepository;
        private readonly ILogger<MaintenanceOperationService> _logger;

        public MaintenanceOperationService(
            IMaintenanceOperationRepository<MaintenanceOperationDTO> maintenanceOperationRepository,
            ILogger<MaintenanceOperationService> logger)
        {
            _maintenanceOperationRepository = maintenanceOperationRepository ?? throw new ArgumentNullException(nameof(maintenanceOperationRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<(int MaintenanceOperationId, string Message)> CreateMaintenanceOperationAsync(MaintenanceOperationDTO maintenanceOperationDTO)
        {
            try
            {
                return await _maintenanceOperationRepository.CreateMaintenanceOperationAsync(maintenanceOperationDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating maintenance operation in service layer.");
                return (0, "An error occurred while creating the maintenance operation.");
            }
        }
        public async Task<(bool Success, string Message)> DeleteMaintenanceOperationAsync(int maintenanceOperationID)
        {
            try
            {
                return await _maintenanceOperationRepository.DeleteMaintenanceOperationAsync(maintenanceOperationID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting maintenance operation with ID {maintenanceOperationID} in service layer.");
                return (false, "An error occurred while deleting the maintenance operation.");
            }
        }
        public async Task<(IEnumerable<MaintenanceOperationDTO> MaintenanceOperations, string Message)> GetAllMaintenanceOperationsAsync()
        {

            try
            {
                return await _maintenanceOperationRepository.GetAllMaintenanceOperationsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all maintenance operations in service layer.");
                return (null, "An error occurred while retrieving all maintenance operations.");
            }
        }
        public async Task<(MaintenanceOperationDTO? MaintenanceOperation, string Message)> GetMaintenanceOperationByIDAsync(int maintenanceOperationID)
        {
            try
            {
                return await _maintenanceOperationRepository.GetMaintenanceOperationByIDAsync(maintenanceOperationID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving maintenance operation with ID {maintenanceOperationID} in service layer.");
                return (null, "An error occurred while retrieving the maintenance operation.");
            }
        }
        public async Task<(bool Success, string Message)> UpdateMaintenanceOperationAsync(MaintenanceOperationDTO maintenanceOperationDTO)
        {
            try
            {
                return await _maintenanceOperationRepository.UpdateMaintenanceOperationAsync(maintenanceOperationDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating maintenance operation in service layer.");
                return (false, "An error occurred while updating the maintenance operation.");
            }
        }
    }
}
