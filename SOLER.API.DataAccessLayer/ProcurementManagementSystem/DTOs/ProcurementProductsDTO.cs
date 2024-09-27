namespace SOLER.API.DataAccessLayer.ProcurementManagementSystem.DTOs
{
    public class ProcurementProductsDTO
    {
        public int? ProcurementProductID { get; set; }
        public int? ProcurementID { get; set; }
        public int? ProductID { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ProcurementProductsDTO(int? ProcurementProductID,
        int? ProcurementID, int? ProductID, int? Quantity,
        decimal? UnitPrice, DateTime? CreatedAt, DateTime? UpdatedAt)
        {
            this.ProcurementProductID = ProcurementProductID;
            this.ProcurementID = ProcurementID;
            this.ProductID = ProductID;
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }
        public ProcurementProductsDTO()
        {
            this.ProcurementProductID = null;
            this.ProcurementID = null;
            this.ProductID = null;
            this.Quantity = null;
            this.UnitPrice = null;
            this.UnitPrice = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }
    }
}
