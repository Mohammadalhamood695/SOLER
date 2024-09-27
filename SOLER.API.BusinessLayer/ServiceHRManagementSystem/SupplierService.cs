namespace SOLER.API.BusinessLayer.ServiceHRManagementSystem
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository<SupplierDTO> _supplierRepository;
        private readonly ILogger<SupplierService> _logger;

        public SupplierService(
            ISupplierRepository<SupplierDTO> supplierRepository,
            ILogger<SupplierService> logger)
        {
            _supplierRepository = supplierRepository ?? throw new ArgumentNullException(nameof(supplierRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int SupplierId, string Message)> CreateSupplierAsync(SupplierDTO supplierDTO)
        {
            try
            {
                return await _supplierRepository.CreateSupplierAsync(supplierDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating supplier in service layer.");
                return (0, "An error occurred while creating the supplier.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteSupplierAsync(int supplierID)
        {
            try
            {
                return await _supplierRepository.DeleteSupplierAsync(supplierID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting supplier with ID {supplierID} in service layer.");
                return (false, "An error occurred while deleting the supplier.");
            }
        }

        public async Task<(IEnumerable<SupplierDTO> Suppliers, string Message)> GetAllSuppliersAsync()
        {
            try
            {
                return await _supplierRepository.GetAllSuppliersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all suppliers in service layer.");
                return (null, "An error occurred while retrieving all suppliers.");
            }
        }

        public async Task<(SupplierDTO? Supplier, string Message)> GetSupplierByIDAsync(int supplierID)
        {
            try
            {
                return await _supplierRepository.GetSupplierByIDAsync(supplierID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving supplier with ID {supplierID} in service layer.");
                return (null, "An error occurred while retrieving the supplier.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateSupplierAsync(SupplierDTO supplierDTO)
        {
            try
            {
                return await _supplierRepository.UpdateSupplierAsync(supplierDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating supplier in service layer.");
                return (false, "An error occurred while updating the supplier.");
            }
        }
    }
}
