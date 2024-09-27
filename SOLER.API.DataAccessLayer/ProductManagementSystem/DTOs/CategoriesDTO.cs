namespace SOLER.API.DataAccessLayer.ProductManagementSystem.DTOs
{
    public class CategoriesDTO
    {
        public int? CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public CategoriesDTO(int? CategoryID, string? CategoryName, string? CategoryDescription,
        bool? IsActive, DateTime? CreatedAt, DateTime? UpdatedAt)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
            this.CategoryDescription = CategoryDescription;
            this.IsActive = IsActive;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }
        public CategoriesDTO()
        {
            this.CategoryID = null;
            this.CategoryName = null;
            this.CategoryDescription = null;
            this.IsActive = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;

        }
    }
}
