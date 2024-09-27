namespace SOLER.API.DataAccessLayer.ProductManagementSystem.DTOs
{
    public class ProductsDTO
    {
        public int? ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int? CategoryID { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityAvailable { get; set; }
        public string? SKU { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? QuantityInStock { get; set; }
        public ProductsDTO(int? ProductID, string? ProductName,
        string? ProductDescription, int? CategoryID, decimal? Price,
        int? QuantityAvailable, string? SKU, bool? IsActive,
        DateTime? CreatedAt, DateTime? UpdatedAt, int? QuantityInStock)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.ProductDescription = ProductDescription;
            this.CategoryID = CategoryID;
            this.Price = Price;
            this.QuantityAvailable = QuantityAvailable;
            this.SKU = SKU;
            this.IsActive = IsActive;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.QuantityInStock = QuantityInStock;
        }
        public ProductsDTO()
        {
            this.ProductID = null;
            this.ProductName = null;
            this.ProductDescription = null;
            this.CategoryID = null;
            this.Price = null;
            this.QuantityAvailable = null;
            this.SKU = null;
            this.IsActive = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
            this.QuantityInStock = null;
        }
    }
}
