namespace SOLER.API.BusinessLayer.ServiceProcurementManagementSystem
{
    public class ProcurementProductsService : IProcurementProductsService
    {
        private readonly IProcurementProductsRepository<ProcurementProductsDTO> _procurementProductsRepository;
        private readonly ILogger<ProcurementProductsService> _logger;

        public ProcurementProductsService(
            IProcurementProductsRepository<ProcurementProductsDTO> procurementProductsRepository,
            ILogger<ProcurementProductsService> logger)
        {
            _procurementProductsRepository = procurementProductsRepository ?? throw new ArgumentNullException(nameof(procurementProductsRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int ProcurementProductId, string Message)> CreateProcurementProductAsync(ProcurementProductsDTO ObjDTO)
        {
            try
            {
                return await _procurementProductsRepository.CreateProcurementProductAsync(ObjDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating procurement product in service layer.");
                return (0, "An error occurred while creating the procurement product.");
            }
        }


        public async Task<(bool Success, string Message)> DeleteProcurementProductAsync(int Id)
        {
            try
            {
                return await _procurementProductsRepository.DeleteProcurementProductAsync(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting procurement product with ID {Id} in service layer.");
                return (false, "An error occurred while deleting the procurement product.");
            }
        }

        public async Task<(IEnumerable<ProcurementProductsDTO> ProcurementProducts, string Message)> GetAllProcurementProductsAsync()
        {
            try
            {
                return await _procurementProductsRepository.GetAllProcurementProductsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all procurement products in service layer.");
                return (null, "An error occurred while retrieving all procurement products.");
            }
        }

        public async Task<(ProcurementProductsDTO? ProcurementProduct, string Message)> GetProcurementProductByIDAsync(int Id)
        {
            try
            {
                return await _procurementProductsRepository.GetProcurementProductByIDAsync(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving procurement product with ID {Id} in service layer.");
                return (null, "An error occurred while retrieving the procurement product.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateProcurementProductAsync(ProcurementProductsDTO ObjDTO)
        {
            try
            {
                return await _procurementProductsRepository.UpdateProcurementProductAsync(ObjDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating procurement product in service layer.");
                return (false, "An error occurred while updating the procurement product.");
            }
        }
    }
}
