namespace SOLER.API.DataAccessLayer.SalesManagementSystem.DTOs
{
    public class SalesDTO
    {
        public int? SaleID { get; set; }
        public int? CustomerID { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? SaleStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public SalesDTO(int? SaleID, int? CustomerID,
        DateTime? SaleDate, decimal? TotalAmount, string? PaymentMethod,
        string? SaleStatus, DateTime? CreatedAt, DateTime? UpdatedAt)
        {
            this.SaleID = SaleID;
            this.CustomerID = CustomerID;
            this.SaleDate = SaleDate;
            this.TotalAmount = TotalAmount;
            this.PaymentMethod = PaymentMethod;
            this.SaleStatus = SaleStatus;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }
        public SalesDTO()
        {
            this.SaleID = null;
            this.CustomerID = null;
            this.SaleDate = null;
            this.TotalAmount = null;
            this.PaymentMethod = null;
            this.SaleStatus = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }
    }
}
