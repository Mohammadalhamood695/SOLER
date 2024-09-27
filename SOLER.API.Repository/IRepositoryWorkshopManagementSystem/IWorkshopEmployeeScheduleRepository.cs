namespace SOLER.API.Repository.IRepositoryWorkshopManagementSystem
{
    public interface IWorkshopEmployeeScheduleRepository<T>
    {
        Task<(IEnumerable<T> WorkshopEmployeeSchedules, string Message)> GetAllWorkshopEmployeeSchedulesAsync();
        Task<(T? WorkshopEmployeeSchedule, string Message)> GetWorkshopEmployeeScheduleByIDAsync(int Id);
        Task<(int WorkshopEmployeeScheduleId, string Message)> CreateWorkshopEmployeeScheduleAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateWorkshopEmployeeScheduleAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteWorkshopEmployeeScheduleAsync(int Id);
    }
}
