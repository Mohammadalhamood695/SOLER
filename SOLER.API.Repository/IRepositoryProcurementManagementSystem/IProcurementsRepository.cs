namespace SOLER.API.Repository.IRepositoryProcurementManagementSystem
{
    public interface IProcurementsRepository<T>
    {
        Task<(IEnumerable<T> Procurements, string Message)> GetAllProcurementsAsync();
        Task<(T? Procurement, string Message)> GetProcurementByIDAsync(int Id);
        Task<(int ProcurementId, string Message)> CreateProcurementAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateProcurementAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteProcurementAsync(int Id);
    }
}
