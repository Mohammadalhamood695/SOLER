namespace SOLER.API.BusinessLayer.IService.IServiceWorkshopManagementSystem
{
    public interface IWorkshopEmployeeScheduleService
    {
        Task<(IEnumerable<WorkshopEmployeeScheduleDTO> WorkshopEmployeeSchedules, string Message)> GetAllWorkshopEmployeeSchedulesAsync();
        Task<(WorkshopEmployeeScheduleDTO? WorkshopEmployeeSchedule, string Message)> GetWorkshopEmployeeScheduleByIDAsync(int Id);
        Task<(int WorkshopEmployeeScheduleId, string Message)> CreateWorkshopEmployeeScheduleAsync(WorkshopEmployeeScheduleDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateWorkshopEmployeeScheduleAsync(WorkshopEmployeeScheduleDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteWorkshopEmployeeScheduleAsync(int Id);
    }
}
