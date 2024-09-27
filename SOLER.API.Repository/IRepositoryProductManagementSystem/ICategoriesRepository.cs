namespace SOLER.API.Repository.IRepositoryProductManagementSystem
{
    public interface ICategoriesRepository<T>
    {
        Task<(IEnumerable<T> Categories, string Message)> GetAllCategoriesAsync();
        Task<(T? Category, string Message)> GetCategoryByIDAsync(int Id);
        Task<(int CategoryId, string Message)> CreateCategoryAsync(T ObjDTO);
        Task<(bool Success, string Message)> UpdateCategoryAsync(T ObjDTO);
        Task<(bool Success, string Message)> DeleteCategoryAsync(int Id);
    }
}
