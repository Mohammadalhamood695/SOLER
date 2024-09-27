namespace SOLER.API.BusinessLayer.IService.IServiceMaintenanceManagementSystem
{
    public interface IMaintenanceOperationService
    {
        Task<(IEnumerable<MaintenanceOperationDTO> MaintenanceOperations, string Message)> GetAllMaintenanceOperationsAsync();
        Task<(MaintenanceOperationDTO? MaintenanceOperation, string Message)> GetMaintenanceOperationByIDAsync(int Id);
        Task<(int MaintenanceOperationId, string Message)> CreateMaintenanceOperationAsync(MaintenanceOperationDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateMaintenanceOperationAsync(MaintenanceOperationDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteMaintenanceOperationAsync(int Id);
    }
}
