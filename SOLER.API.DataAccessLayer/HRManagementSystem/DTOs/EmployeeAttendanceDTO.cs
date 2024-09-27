namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs
{
    public class EmployeeAttendanceDTO
    {
        public int? AttendanceID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public EmployeeAttendanceDTO(int? AttendanceID, int? EmployeeID, DateTime? CheckInTime, DateTime? CheckOutTime, DateTime? CreatedAt, DateTime? UpdatedAt)
        {
            this.AttendanceID = AttendanceID;
            this.EmployeeID = EmployeeID;
            this.CheckInTime = CheckInTime;
            this.CheckOutTime = CheckOutTime;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }
        public EmployeeAttendanceDTO()
        {
            this.AttendanceID = null;
            this.EmployeeID = null;
            this.CheckInTime = null;
            this.CheckOutTime = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }
    }
}