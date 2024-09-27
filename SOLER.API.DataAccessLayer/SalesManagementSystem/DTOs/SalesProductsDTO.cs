namespace SOLER.API.DataAccessLayer.SalesManagementSystem.DTOs
{
    public class SalesProductsDTO
    {
        public int? SaleProductID { get; set; }
        public int? SaleID { get; set; }
        public int? ProductID { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public SalesProductsDTO(int? SaleProductID, int? SaleID, int? ProductID, int? Quantity,
        decimal? UnitPrice, DateTime? CreatedAt, DateTime? UpdatedAt)
        {
            this.SaleProductID = SaleProductID;
            this.SaleID = SaleID;
            this.ProductID = ProductID;
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }
        public SalesProductsDTO()
        {
            this.SaleProductID = null;
            this.SaleID = null;
            this.ProductID = null;
            this.Quantity = null;
            this.UnitPrice = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }
    }
}
