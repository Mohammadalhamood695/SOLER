namespace SOLER.API.Repository.IRepositoryWorkshopManagementSystem
{
    public interface IWorkshopRepository<T>
    {
        Task<(IEnumerable<T> Workshops, string Message)> GetAllWorkshopsAsync();
        Task<(T? Workshop, string Message)> GetWorkshopByIDAsync(int Id);
        Task<(int WorkshopId, string Message)> CreateWorkshopAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateWorkshopAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteWorkshopAsync(int Id);
    }
}
