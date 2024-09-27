namespace SOLER.API.DataAccessLayer.InvoiceManagementSystem.DTOs.UpdateDTOs
{
    public class UpdateInvoicesDTO
    {
        [Required]
        public int InvoiceID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public DateTime InvoiceDate { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public string PaymentStatus { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
