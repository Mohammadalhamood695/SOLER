namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs.UpdateDTOs
{
    public class UpdateSupplierDTO
    {
        [Required]
        public int? SupplierID { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        [Required]
        public string? SupplyType { get; set; }
        public DateTime? ContractStartDate { get; set; }
    }
}
