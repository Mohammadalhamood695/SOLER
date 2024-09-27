namespace SOLER.API.BusinessLayer.ServiceSalesManagementSystem
{
    public class SalesProductsService : ISalesProductsService
    {
        private readonly ISalesProductsRepository<SalesProductsDTO> _salesProductsRepository;
        private readonly ILogger<SalesProductsService> _logger;

        public SalesProductsService(
            ISalesProductsRepository<SalesProductsDTO> salesProductsRepository,
            ILogger<SalesProductsService> logger)
        {
            _salesProductsRepository = salesProductsRepository ?? throw new ArgumentNullException(nameof(salesProductsRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int SalesProductId, string Message)> CreateSalesProductAsync(SalesProductsDTO salesProductsDTO)
        {
            try
            {
                return await _salesProductsRepository.CreateSalesProductAsync(salesProductsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating sales product in service layer.");
                return (0, "An error occurred while creating the sales product.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteSalesProductAsync(int salesProductId)
        {
            try
            {
                return await _salesProductsRepository.DeleteSalesProductAsync(salesProductId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting sales product with ID {salesProductId} in service layer.");
                return (false, "An error occurred while deleting the sales product.");
            }
        }

        public async Task<(IEnumerable<SalesProductsDTO> SalesProducts, string Message)> GetAllSalesProductsAsync()
        {
            try
            {
                return await _salesProductsRepository.GetAllSalesProductsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all sales products in service layer.");
                return (null, "An error occurred while retrieving all sales products.");
            }
        }

        public async Task<(SalesProductsDTO? SalesProduct, string Message)> GetSalesProductByIDAsync(int salesProductId)
        {
            try
            {
                return await _salesProductsRepository.GetSalesProductByIDAsync(salesProductId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving sales product with ID {salesProductId} in service layer.");
                return (null, "An error occurred while retrieving the sales product.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateSalesProductAsync(SalesProductsDTO salesProductsDTO)
        {
            try
            {
                return await _salesProductsRepository.UpdateSalesProductAsync(salesProductsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating sales product in service layer.");
                return (false, "An error occurred while updating the sales product.");
            }
        }
    }
}
