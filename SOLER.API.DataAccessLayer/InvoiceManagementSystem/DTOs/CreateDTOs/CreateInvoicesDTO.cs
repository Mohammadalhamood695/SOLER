namespace SOLER.API.DataAccessLayer.InvoiceManagementSystem.DTOs.CreateDTOs
{
    public class CreateInvoicesDTO
    {
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
