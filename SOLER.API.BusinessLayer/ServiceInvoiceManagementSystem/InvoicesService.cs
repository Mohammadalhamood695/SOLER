namespace SOLER.API.BusinessLayer.ServiceInvoiceManagementSystem
{
    public class InvoicesService : IInvoicesService
    {
        private readonly IInvoicesRepository<InvoicesDTO> _invoicesRepository;
        private readonly ILogger<InvoicesService> _logger;

        public InvoicesService(
            IInvoicesRepository<InvoicesDTO> invoicesRepository,
            ILogger<InvoicesService> logger)
        {
            _invoicesRepository = invoicesRepository ?? throw new ArgumentNullException(nameof(invoicesRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int InvoiceId, string Message)> CreateInvoiceAsync(InvoicesDTO invoicesDTO)
        {
            try
            {
                return await _invoicesRepository.CreateInvoiceAsync(invoicesDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating invoice in service layer.");
                return (0, "An error occurred while creating the invoice.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteInvoiceAsync(int invoiceID)
        {
            try
            {
                return await _invoicesRepository.DeleteInvoiceAsync(invoiceID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting invoice with ID {invoiceID} in service layer.");
                return (false, "An error occurred while deleting the invoice.");
            }
        }

        public async Task<(IEnumerable<InvoicesDTO> Invoices, string Message)> GetAllInvoicesAsync()
        {
            try
            {
                return await _invoicesRepository.GetAllInvoicesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all invoices in service layer.");
                return (null, "An error occurred while retrieving all invoices.");
            }
        }

        public async Task<(InvoicesDTO? Invoice, string Message)> GetInvoiceByIDAsync(int invoiceID)
        {
            try
            {
                return await _invoicesRepository.GetInvoiceByIDAsync(invoiceID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving invoice with ID {invoiceID} in service layer.");
                return (null, "An error occurred while retrieving the invoice.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateInvoiceAsync(InvoicesDTO invoicesDTO)
        {
            try
            {
                return await _invoicesRepository.UpdateInvoiceAsync(invoicesDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating invoice in service layer.");
                return (false, "An error occurred while updating the invoice.");
            }
        }
    }
}
