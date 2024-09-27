namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs.UpdateDTOs
{
    public class UpdateEmployeeDTO
    {
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public string Department { get; set; }
    }
}
