namespace SOLER.API.BusinessLayer.IService.IServiceProcurementManagementSystem
{
    public interface IProcurementsService
    {
        Task<(IEnumerable<ProcurementsDTO> Procurements, string Message)> GetAllProcurementsAsync();
        Task<(ProcurementsDTO? Procurement, string Message)> GetProcurementByIDAsync(int Id);
        Task<(int ProcurementId, string Message)> CreateProcurementAsync(ProcurementsDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateProcurementAsync(ProcurementsDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteProcurementAsync(int Id);
    }
}
