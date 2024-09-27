namespace SOLER.API.BusinessLayer.ServiceFinancialManagementSystem
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository<BudgetDTO> _budgetRepository;
        private readonly ILogger<BudgetService> _logger;

        public BudgetService(
            IBudgetRepository<BudgetDTO> budgetRepository,
            ILogger<BudgetService> logger)
        {
            _budgetRepository = budgetRepository ?? throw new ArgumentNullException(nameof(budgetRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int BudgetId, string Message)> CreateBudgetAsync(BudgetDTO budgetDTO)
        {
            try
            {
                return await _budgetRepository.CreateBudgetAsync(budgetDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating budget in service layer.");
                return (0, "An error occurred while creating the budget.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteBudgetAsync(int budgetID)
        {
            try
            {
                return await _budgetRepository.DeleteBudgetAsync(budgetID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting budget with ID {budgetID} in service layer.");
                return (false, "An error occurred while deleting the budget.");
            }
        }

        public async Task<(IEnumerable<BudgetDTO> Budgets, string Message)> GetAllBudgetsAsync()
        {
            try
            {
                return await _budgetRepository.GetAllBudgetsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all budgets in service layer.");
                return (null, "An error occurred while retrieving all budgets.");
            }
        }

        public async Task<(BudgetDTO? Budget, string Message)> GetBudgetByIDAsync(int budgetID)
        {
            try
            {
                return await _budgetRepository.GetBudgetByIDAsync(budgetID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving budget with ID {budgetID} in service layer.");
                return (null, "An error occurred while retrieving the budget.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateBudgetAsync(BudgetDTO budgetDTO)
        {
            try
            {
                return await _budgetRepository.UpdateBudgetAsync(budgetDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating budget in service layer.");
                return (false, "An error occurred while updating the budget.");
            }
        }
    }
}
