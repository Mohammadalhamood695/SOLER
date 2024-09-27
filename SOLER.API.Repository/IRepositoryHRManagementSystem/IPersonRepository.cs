namespace SOLER.API.Repository.IRepositoryHRManagementSystem
{
    public interface IPersonRepository<T>
    {
        Task<(IEnumerable<T> Persons, string Message)> GetAllPersonsAsync();
        Task<(T? Person, string Message)> GetPersonByIDAsync(int Id);
        Task<(int PersonId, string Message)> CreatePersonAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdatePersonAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeletePersonAsync(int Id);
    }
}
