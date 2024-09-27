namespace SOLER.API.Repository.IRepositoryFinancialManagementSystem
{
    public interface IBudgetRepository<T>
    {
        Task<(IEnumerable<T> Budgets, string Message)> GetAllBudgetsAsync();
        Task<(T? Budget, string Message)> GetBudgetByIDAsync(int Id);
        Task<(int BudgetId, string Message)> CreateBudgetAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateBudgetAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteBudgetAsync(int Id);
    }
}
