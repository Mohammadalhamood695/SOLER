namespace SOLER.API.DataAccessLayer.FinancialManagementSystem
{
    public class BudgetData : BaseRepository, IBudgetRepository<BudgetDTO>
    {
        public BudgetData(IConfiguration configuration, ILogger<BudgetData> logger)
            : base(configuration, logger)
        {
        }
        public async Task<(int BudgetId, string Message)> CreateBudgetAsync(BudgetDTO objDTO)
        {
            DynamicParameters parameters = new ();
            parameters.Add("@Balance", objDTO.Balance);
            parameters.Add("@TransactionType", objDTO.TransactionType);
            parameters.Add("@Amount", objDTO.Amount);
            parameters.Add("@Description", objDTO.Description);
            parameters.Add("@TransactionDate", objDTO.TransactionDate);
            parameters.Add("@BudgetID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            // هنا لا نتوقع قائمة من النتائج، نستخدم expectMultipleResults = false
            await ExecuteStoredProcedureAsync<object>("dbo.SP_CreateBudget", parameters, expectMultipleResults: false);
            int budgetId = parameters.Get<int>("@BudgetID");
            return (budgetId, "Budget created successfully.");
        }
        public async Task<(bool Success, string Message)> DeleteBudgetAsync(int id)
        {
            DynamicParameters parameters = new ();
            parameters.Add("@BudgetID", id);
            // تنفيذ الإجراء المخزن، لا نتوقع قائمة من النتائج
            var (result, message) = await ExecuteStoredProcedureAsync<object>("dbo.SP_DeleteBudget", parameters, expectMultipleResults: false);
            return (result != null, message);
        }
        public async Task<(IEnumerable<BudgetDTO> Budgets, string Message)> GetAllBudgetsAsync()
        {
            var parameters = new DynamicParameters();

            // هنا نتوقع قائمة من النتائج لذا نستخدم expectMultipleResults = true
            var (result, message) = await ExecuteStoredProcedureAsync<IEnumerable<BudgetDTO>>("dbo.SP_GetAllBudgets", parameters, expectMultipleResults: true);
            return (result, message);
        }
        public async Task<(BudgetDTO? Budget, string Message)> GetBudgetByIDAsync(int id)
        {
            DynamicParameters parameters = new ();
            parameters.Add("@BudgetID", id);

            // استرجاع نتيجة فردية لذا نستخدم expectMultipleResults = false
            var (result, message) = await ExecuteStoredProcedureAsync<BudgetDTO>("dbo.SP_GetBudgetByID", parameters, expectMultipleResults: false);
            return (result, message);
        }
        public async Task<(bool Success, string Message)> UpdateBudgetAsync(BudgetDTO objDTO)
        {
            DynamicParameters parameters = new ();
            parameters.Add("@BudgetID", objDTO.BudgetID);
            parameters.Add("@Balance", objDTO.Balance);
            parameters.Add("@TransactionType", objDTO.TransactionType);
            parameters.Add("@Amount", objDTO.Amount);
            parameters.Add("@Description", objDTO.Description);
            parameters.Add("@TransactionDate", objDTO.TransactionDate);
            // لا نتوقع قائمة من النتائج هنا
            var (result, message) = await ExecuteStoredProcedureAsync<object>("dbo.SP_UpdateBudget", parameters, expectMultipleResults: false);
            return (result != null, message);
        }
    }
}
