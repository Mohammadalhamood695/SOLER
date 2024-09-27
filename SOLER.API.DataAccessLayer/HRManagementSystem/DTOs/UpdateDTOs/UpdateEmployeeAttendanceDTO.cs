namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs.UpdateDTOs
{
    public class UpdateEmployeeAttendanceDTO
    {
        [Required]
        public int? AttendanceID { get; set; }
        [Required]
        public int? EmployeeID { get; set; }
        [Required]
        public DateTime? CheckInTime { get; set; }
        [Required]
        public DateTime? CheckOutTime { get; set; }
    }
}
