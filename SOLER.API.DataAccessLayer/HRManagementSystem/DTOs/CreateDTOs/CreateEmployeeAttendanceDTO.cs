namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs.CreateDTOs
{
    public class CreateEmployeeAttendanceDTO
    {
        [Required]
        public int? EmployeeID { get; set; }
        [Required]
        public DateTime? CheckInTime { get; set; }
        [Required]
        public DateTime? CheckOutTime { get; set; }
    }
}
