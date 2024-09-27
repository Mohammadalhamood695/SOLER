namespace SOLER.API.Repository.IRepositoryMaintenanceManagementSystem
{
    public interface IMaintenanceOperationRepository<T>
    {
        Task<(IEnumerable<T> MaintenanceOperations, string Message)> GetAllMaintenanceOperationsAsync();
        Task<(T? MaintenanceOperation, string Message)> GetMaintenanceOperationByIDAsync(int Id);
        Task<(int MaintenanceOperationId, string Message)> CreateMaintenanceOperationAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateMaintenanceOperationAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteMaintenanceOperationAsync(int Id);
    }
}
