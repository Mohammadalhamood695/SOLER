namespace SOLER.API.DataAccessLayer.InvoiceManagementSystem.DTOs
{
    public class InvoicesDTO
    {
        public int? InvoiceID { get; set; }
        public int? CustomerID { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? PaymentStatus { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public InvoicesDTO(int? InvoiceID, int? CustomerID,
        DateTime? InvoiceDate, decimal? TotalAmount, string? PaymentStatus,
        string? Description, DateTime? CreatedAt, DateTime? UpdatedAt)
        {
            this.InvoiceID = InvoiceID;
            this.CustomerID = CustomerID;
            this.InvoiceDate = InvoiceDate;
            this.TotalAmount = TotalAmount;
            this.PaymentStatus = PaymentStatus;
            this.Description = Description;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;

        }
        public InvoicesDTO()
        {
            this.InvoiceID = null;
            this.CustomerID = null;
            this.InvoiceDate = null;
            this.TotalAmount = null;
            this.PaymentStatus = null;
            this.Description = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }
    }
}
