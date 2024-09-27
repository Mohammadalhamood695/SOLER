namespace SOLER.API.BusinessLayer.IService.IServiceHRManagementSystem
{
    public interface IPersonService
    {
        Task<(IEnumerable<PersonDTO> Persons, string Message)> GetAllPersonsAsync();
        Task<(PersonDTO? Person, string Message)> GetPersonByIDAsync(int Id);
        Task<(int PersonId, string Message)> CreatePersonAsync(PersonDTO ObjDTO);
        Task<(bool Success, string Message)> UpdatePersonAsync(PersonDTO ObjDTO);
        Task<(bool Success, string Message)> DeletePersonAsync(int Id);
    }
}
