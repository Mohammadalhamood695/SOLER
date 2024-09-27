namespace SOLER.API.BusinessLayer.IService.IServiceProductManagementSystem
{
    public interface ICategoriesService
    {
        Task<(IEnumerable<CategoriesDTO> Categories, string Message)> GetAllCategoriesAsync();
        Task<(CategoriesDTO? Category, string Message)> GetCategoryByIDAsync(int Id);
        Task<(int CategoryId, string Message)> CreateCategoryAsync(CategoriesDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateCategoryAsync(CategoriesDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteCategoryAsync(int Id);
    }
}
