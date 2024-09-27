namespace SOLER.API.BusinessLayer.ServiceSalesManagementSystem
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository<SalesDTO> _salesRepository;
        private readonly ILogger<SalesService> _logger;

        public SalesService(
            ISalesRepository<SalesDTO> salesRepository,
            ILogger<SalesService> logger)
        {
            _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int SaleId, string Message)> CreateSalesAsync(SalesDTO ObjDTO)
        {
            try
            {
                return await _salesRepository.CreateSalesAsync(ObjDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating sales in service layer.");
                return (0, "An error occurred while creating the sales record.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteSalesAsync(int Id)
        {
            try
            {
                return await _salesRepository.DeleteSalesAsync(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting sales with ID {Id} in service layer.");
                return (false, "An error occurred while deleting the sales record.");
            }
        }

        public async Task<(IEnumerable<SalesDTO> Sales, string Message)> GetAllSalesAsync()
        {
            try
            {
                return await _salesRepository.GetAllSalesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all sales in service layer.");
                return (null, "An error occurred while retrieving all sales records.");
            }
        }

        public async Task<(SalesDTO? Sale, string Message)> GetSalesByIDAsync(int Id)
        {
            try
            {
                return await _salesRepository.GetSalesByIDAsync(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving sales with ID {Id} in service layer.");
                return (null, "An error occurred while retrieving the sales record.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateSalesAsync(SalesDTO ObjDTO)
        {
            try
            {
                return await _salesRepository.UpdateSalesAsync(ObjDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating sales in service layer.");
                return (false, "An error occurred while updating the sales record.");
            }
        }
    }
}
