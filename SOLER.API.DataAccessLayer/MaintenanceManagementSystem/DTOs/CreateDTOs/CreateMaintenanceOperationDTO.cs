namespace SOLER.API.DataAccessLayer.MaintenanceManagementSystem.DTOs.CreateDTOs
{
    public class CreateMaintenanceOperationDTO
    {
        public int? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public string? ItemDescription { get; set; }
        public string? MaintenanceDetails { get; set; }
        public string? Status { get; set; }
    }
}
