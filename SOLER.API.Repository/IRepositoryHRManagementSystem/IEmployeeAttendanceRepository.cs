namespace SOLER.API.Repository.IRepositoryHRManagementSystem
{
    public interface IEmployeeAttendanceRepository<T>
    {
        Task<(IEnumerable<T> EmployeeAttendances, string Message)> GetAllEmployeeAttendancesAsync();
        Task<(T? EmployeeAttendance, string Message)> GetEmployeeAttendanceByIDAsync(int Id);
        Task<(int AttendanceId, string Message)> CreateEmployeeAttendanceAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateEmployeeAttendanceAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteEmployeeAttendanceAsync(int Id);
    }
}
