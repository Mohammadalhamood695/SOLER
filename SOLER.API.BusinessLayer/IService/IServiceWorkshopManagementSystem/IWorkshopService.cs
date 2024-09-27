namespace SOLER.API.BusinessLayer.IService.IServiceWorkshopManagementSystem
{
    public interface IWorkshopService
    {
        Task<(IEnumerable<WorkshopDTO> Workshops, string Message)> GetAllWorkshopsAsync();
        Task<(WorkshopDTO? Workshop, string Message)> GetWorkshopByIDAsync(int Id);
        Task<(int WorkshopId, string Message)> CreateWorkshopAsync(WorkshopDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateWorkshopAsync(WorkshopDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteWorkshopAsync(int Id);
    }
}
