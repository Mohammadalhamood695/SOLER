namespace SOLER.API.DataAccessLayer.WorkshopManagementSystem.DTOs
{
    public class WorkshopDTO
    {
        public int? WorkshopID { get; set; }
        public int? CustomerID { get; set; }
        public string? WorkshopName { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public WorkshopDTO(int? WorkshopID, int? CustomerID, string? WorkshopName,
        string? Location, string? Description, DateTime? StartDate,
        DateTime? EndDate, DateTime? CreatedAt, DateTime? UpdatedAt)
        {
            this.WorkshopID = WorkshopID;
            this.CustomerID = CustomerID;
            this.WorkshopName = WorkshopName;
            this.Location = Location;
            this.Description = Description;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }
        public WorkshopDTO()
        {
            this.WorkshopID = null;
            this.CustomerID = null;
            this.WorkshopName = null;
            this.Location = null;
            this.Description = null;
            this.StartDate = null;
            this.EndDate = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }
    }
}
