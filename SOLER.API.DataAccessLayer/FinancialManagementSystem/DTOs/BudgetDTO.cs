namespace SOLER.API.DataAccessLayer.FinancialManagementSystem.DTOs
{
    public class BudgetDTO
    {
        public int? BudgetID { get; set; }
        public decimal? Balance { get; set; }
        public string? TransactionType { get; set; }
        public decimal? Amount { get; set; }
        public string? Description { get; set; }
        public DateTime? TransactionDate { get; set; }
        public BudgetDTO()
        {
            this.BudgetID = null;
            this.Balance = null;
            this.TransactionType = null;
            this.Amount = null;
            this.Description = null;
            this.TransactionDate = null;
        }
        public BudgetDTO(int BudgetID,decimal Balance,string TransactionType,
        decimal Amount,string Description,DateTime? TransactionDate)
        {
            this.BudgetID = BudgetID;
            this.Balance = Balance;
            this.TransactionType = TransactionType;
            this.Amount = Amount;
            this.Description = Description;
            this.TransactionDate = TransactionDate;
        }
    }
}