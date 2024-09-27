namespace SOLER.API.BusinessLayer.IService.IServiceHRManagementSystem
{
    public interface IEmployeeAttendanceService
    {
        Task<(IEnumerable<EmployeeAttendanceDTO> Attendances, string Message)> GetAllEmployeeAttendancesAsync();
        Task<(EmployeeAttendanceDTO? Attendance, string Message)> GetEmployeeAttendanceByIDAsync(int Id);
        Task<(int AttendanceId, string Message)> CreateEmployeeAttendanceAsync(EmployeeAttendanceDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateEmployeeAttendanceAsync(EmployeeAttendanceDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteEmployeeAttendanceAsync(int Id);
    }
}
