namespace SOLER.API.BusinessLayer.ServiceWorkshopManagementSystem
{
    public class WorkshopService : IWorkshopService
    {
        private readonly IWorkshopRepository<WorkshopDTO> _repository;
        private readonly ILogger<WorkshopService> _logger;

        public WorkshopService(
            IWorkshopRepository<WorkshopDTO> repository,
            ILogger<WorkshopService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int WorkshopId, string Message)> CreateWorkshopAsync(WorkshopDTO objDTO)
        {
            try
            {
                return await _repository.CreateWorkshopAsync(objDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating workshop in service layer.");
                return (0, "An error occurred while creating the workshop.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteWorkshopAsync(int id)
        {
            try
            {
                return await _repository.DeleteWorkshopAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting workshop with ID {id} in service layer.");
                return (false, "An error occurred while deleting the workshop.");
            }
        }

        public async Task<(IEnumerable<WorkshopDTO> Workshops, string Message)> GetAllWorkshopsAsync()
        {
            try
            {
                return await _repository.GetAllWorkshopsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all workshops in service layer.");
                return (null, "An error occurred while retrieving all workshops.");
            }
        }

        public async Task<(WorkshopDTO? Workshop, string Message)> GetWorkshopByIDAsync(int id)
        {
            try
            {
                return await _repository.GetWorkshopByIDAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving workshop with ID {id} in service layer.");
                return (null, "An error occurred while retrieving the workshop.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateWorkshopAsync(WorkshopDTO objDTO)
        {
            try
            {
                return await _repository.UpdateWorkshopAsync(objDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating workshop in service layer.");
                return (false, "An error occurred while updating the workshop.");
            }
        }
    }
}
