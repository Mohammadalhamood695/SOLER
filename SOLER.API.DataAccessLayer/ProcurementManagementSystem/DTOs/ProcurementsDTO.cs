namespace SOLER.API.DataAccessLayer.ProcurementManagementSystem.DTOs
{
    public class ProcurementsDTO
    {
        public int? ProcurementID { get; set; }
        public int? SupplierID { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? ProcurementStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ProcurementsDTO(int? ProcurementID, int? SupplierID,
        DateTime? PurchaseDat, decimal? TotalAmount, string? PaymentMethod,
        string? ProcurementStatus, DateTime? CreatedAt, DateTime? UpdatedAt)
        {
            this.ProcurementID = ProcurementID;
            this.SupplierID = SupplierID;
            this.PurchaseDate = PurchaseDat;
            this.TotalAmount = TotalAmount;
            this.PaymentMethod = PaymentMethod;
            this.ProcurementStatus = ProcurementStatus;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }
        public ProcurementsDTO()
        {
            this.ProcurementID = null;
            this.SupplierID = null;
            this.PurchaseDate = null;
            this.TotalAmount = null;
            this.PaymentMethod = null;
            this.ProcurementStatus = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }

    }
}
