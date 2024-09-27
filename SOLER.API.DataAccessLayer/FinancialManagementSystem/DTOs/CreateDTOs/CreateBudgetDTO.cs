using System.ComponentModel.DataAnnotations;
namespace SOLER.API.DataAccessLayer.FinancialManagementSystem.DTOs.CreateDTOs
{
    public class CreateBudgetDTO
    {
        [Required]
        public decimal? Balance { get; set; }
        [Required]
        public string? TransactionType { get; set; }
        [Required]
        public decimal? Amount { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
