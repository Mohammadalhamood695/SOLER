using SOLER.API.Repository.IRepositoryHRManagementSystem;

namespace SOLER.API.BusinessLayer.ServiceHRManagementSystem
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository<CustomerDTO> _customerRepository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(
            ICustomerRepository<CustomerDTO> customerRepository,
            ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int CustomerId, string Message)> CreateCustomerAsync(CustomerDTO customerDTO)
        {
            try
            {
                return await _customerRepository.CreateCustomerAsync(customerDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating customer in service layer.");
                return (0, "An error occurred while creating the customer.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteCustomerAsync(int customerID)
        {
            try
            {
                return await _customerRepository.DeleteCustomerAsync(customerID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting customer with ID {customerID} in service layer.");
                return (false, "An error occurred while deleting the customer.");
            }
        }

        public async Task<(IEnumerable<CustomerDTO> Customers, string Message)> GetAllCustomersAsync()
        {
            try
            {
                return await _customerRepository.GetAllCustomersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all customers in service layer.");
                return (null, "An error occurred while retrieving all customers.");
            }
        }

        public async Task<(CustomerDTO? Customer, string Message)> GetCustomerByIDAsync(int customerID)
        {
            try
            {
                return await _customerRepository.GetCustomerByIDAsync(customerID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving customer with ID {customerID} in service layer.");
                return (null, "An error occurred while retrieving the customer.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateCustomerAsync(CustomerDTO customerDTO)
        {
            try
            {
                return await _customerRepository.UpdateCustomerAsync(customerDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating customer in service layer.");
                return (false, "An error occurred while updating the customer.");
            }
        }
    }
}
