namespace SOLER.API.BusinessLayer.ServiceProcurementManagementSystem
{
    public class ProcurementsService : IProcurementsService
    {
        private readonly IProcurementsRepository<ProcurementsDTO> _procurementsRepository;
        private readonly ILogger<ProcurementsService> _logger;

        public ProcurementsService(
            IProcurementsRepository<ProcurementsDTO> procurementsRepository,
            ILogger<ProcurementsService> logger)
        {
            _procurementsRepository = procurementsRepository ?? throw new ArgumentNullException(nameof(procurementsRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int ProcurementId, string Message)> CreateProcurementAsync(ProcurementsDTO ObjDTO)
        {
            try
            {
                return await _procurementsRepository.CreateProcurementAsync(ObjDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating procurement in service layer.");
                return (0, "An error occurred while creating the procurement.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteProcurementAsync(int Id)
        {
            try
            {
                return await _procurementsRepository.DeleteProcurementAsync(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting procurement with ID {Id} in service layer.");
                return (false, "An error occurred while deleting the procurement.");
            }
        }

        public async Task<(IEnumerable<ProcurementsDTO> Procurements, string Message)> GetAllProcurementsAsync()
        {
            try
            {
                return await _procurementsRepository.GetAllProcurementsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all procurements in service layer.");
                return (null, "An error occurred while retrieving all procurements.");
            }
        }

        public async Task<(ProcurementsDTO? Procurement, string Message)> GetProcurementByIDAsync(int Id)
        {
            try
            {
                return await _procurementsRepository.GetProcurementByIDAsync(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving procurement with ID {Id} in service layer.");
                return (null, "An error occurred while retrieving the procurement.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateProcurementAsync(ProcurementsDTO ObjDTO)
        {
            try
            {
                return await _procurementsRepository.UpdateProcurementAsync(ObjDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating procurement in service layer.");
                return (false, "An error occurred while updating the procurement.");
            }
        }
    }
}
