namespace SOLER.API.BusinessLayer.ServiceWorkshopManagementSystem
{
    public class WorkshopEmployeeScheduleService : IWorkshopEmployeeScheduleService
    {
        private readonly IWorkshopEmployeeScheduleRepository<WorkshopEmployeeScheduleDTO> _repository;
        private readonly ILogger<WorkshopEmployeeScheduleService> _logger;

        public WorkshopEmployeeScheduleService(
            IWorkshopEmployeeScheduleRepository<WorkshopEmployeeScheduleDTO> repository,
            ILogger<WorkshopEmployeeScheduleService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int WorkshopEmployeeScheduleId, string Message)> CreateWorkshopEmployeeScheduleAsync(WorkshopEmployeeScheduleDTO ObjDTO)
        {
            try
            {
                return await _repository.CreateWorkshopEmployeeScheduleAsync(ObjDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating workshop employee schedule in service layer.");
                return (0, "An error occurred while creating the workshop employee schedule.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteWorkshopEmployeeScheduleAsync(int id)
        {
            try
            {
                return await _repository.DeleteWorkshopEmployeeScheduleAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting workshop employee schedule with ID {id} in service layer.");
                return (false, "An error occurred while deleting the workshop employee schedule.");
            }
        }

        public async Task<(IEnumerable<WorkshopEmployeeScheduleDTO> WorkshopEmployeeSchedules, string Message)> GetAllWorkshopEmployeeSchedulesAsync()
        {
            try
            {
                return await _repository.GetAllWorkshopEmployeeSchedulesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all workshop employee schedules in service layer.");
                return (null, "An error occurred while retrieving all workshop employee schedules.");
            }
        }

        public async Task<(WorkshopEmployeeScheduleDTO? WorkshopEmployeeSchedule, string Message)> GetWorkshopEmployeeScheduleByIDAsync(int Id)
        {
            try
            {
                return await _repository.GetWorkshopEmployeeScheduleByIDAsync(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving workshop employee schedule with ID {Id} in service layer.");
                return (null, "An error occurred while retrieving the workshop employee schedule.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateWorkshopEmployeeScheduleAsync(WorkshopEmployeeScheduleDTO objDTO)
        {
            try
            {
                return await _repository.UpdateWorkshopEmployeeScheduleAsync(objDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating workshop employee schedule in service layer.");
                return (false, "An error occurred while updating the workshop employee schedule.");
            }
        }
    }
}
