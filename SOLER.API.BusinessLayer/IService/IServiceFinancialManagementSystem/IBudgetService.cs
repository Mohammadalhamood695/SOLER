namespace SOLER.API.BusinessLayer.IService.IServiceFinancialManagementSystem
{
    public interface IBudgetService
    {
        Task<(IEnumerable<BudgetDTO> Budgets, string Message)> GetAllBudgetsAsync();
        Task<(BudgetDTO? Budget, string Message)> GetBudgetByIDAsync(int Id);
        Task<(int BudgetId, string Message)> CreateBudgetAsync(BudgetDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateBudgetAsync(BudgetDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteBudgetAsync(int Id);
    }
}
