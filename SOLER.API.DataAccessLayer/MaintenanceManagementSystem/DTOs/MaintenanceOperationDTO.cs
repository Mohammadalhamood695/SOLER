namespace SOLER.API.DataAccessLayer.MaintenanceManagementSystem.DTOs
{
    public class MaintenanceOperationDTO
    {
        public int? MaintenanceID { get; set; }
        public int? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public string? ItemDescription { get; set; }
        public string? MaintenanceDetails { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public MaintenanceOperationDTO(int? MaintenanceID, int? CustomerID, int? EmployeeID,
        DateTime? ReceivedDate, DateTime? ExpectedDeliveryDate, DateTime? ActualDeliveryDate, string? ItemDescription,
        string? MaintenanceDetails, string? Status, DateTime? CreatedAt, DateTime? UpdatedAt)
        {
            this.CustomerID = CustomerID;
            this.EmployeeID = EmployeeID;
            this.ReceivedDate = ReceivedDate;
            this.ExpectedDeliveryDate = ExpectedDeliveryDate;
            this.ActualDeliveryDate = ActualDeliveryDate;
            this.ItemDescription = ItemDescription;
            this.MaintenanceDetails = MaintenanceDetails;
            this.Status = Status;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }
        public MaintenanceOperationDTO()
        {
            this.CustomerID = null;
            this.EmployeeID = null;
            this.ReceivedDate = null;
            this.ExpectedDeliveryDate = null;
            this.ActualDeliveryDate = null;
            this.ItemDescription = null;
            this.MaintenanceDetails = null;
            this.Status = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }
    }
}
