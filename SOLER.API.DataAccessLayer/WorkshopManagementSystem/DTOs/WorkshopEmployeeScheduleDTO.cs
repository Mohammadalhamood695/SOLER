namespace SOLER.API.DataAccessLayer.WorkshopManagementSystem.DTOs
{
    public class WorkshopEmployeeScheduleDTO
    {
        public int? ScheduleID { get; set; }
        public int? WorkshopID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public TimeSpan? ScheduledStartTime { get; set; }
        public TimeSpan? ScheduledEndTime { get; set; }
        public TimeSpan? ActualStartTime { get; set; }
        public TimeSpan? ActualEndTime { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public WorkshopEmployeeScheduleDTO(int? ScheduleID, int? WorkshopID,
        int? EmployeeID, DateTime? ScheduledDate,
        TimeSpan? ScheduledStartTime, TimeSpan? ScheduledEndTime, TimeSpan? ActualStartTime,
        TimeSpan? ActualEndTime, DateTime? CreatedAt, DateTime? UpdatedAt)
        {
            this.ScheduleID = ScheduleID;
            this.WorkshopID = WorkshopID;
            this.EmployeeID = EmployeeID;
            this.ScheduledDate = ScheduledDate;
            this.ScheduledStartTime = ScheduledStartTime;
            this.ScheduledEndTime = ScheduledEndTime;
            this.ActualStartTime = ActualStartTime;
            this.ActualEndTime = ActualEndTime;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }


        public WorkshopEmployeeScheduleDTO()
        {
            this.ScheduleID = null;
            this.WorkshopID = null;
            this.EmployeeID = null;
            this.ScheduledDate = null;
            this.ScheduledStartTime = null;
            this.ScheduledEndTime = null;
            this.ActualStartTime = null;
            this.ActualEndTime = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }
    }
}

