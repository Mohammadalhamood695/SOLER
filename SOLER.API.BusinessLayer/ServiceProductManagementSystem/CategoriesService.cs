namespace SOLER.API.BusinessLayer.ServiceProductManagementSystem
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository<CategoriesDTO> _categoriesRepository;
        private readonly ILogger<CategoriesService> _logger;

        public CategoriesService(
            ICategoriesRepository<CategoriesDTO> categoriesRepository,
            ILogger<CategoriesService> logger)
        {
            _categoriesRepository = categoriesRepository ?? throw new ArgumentNullException(nameof(categoriesRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int CategoryId, string Message)> CreateCategoryAsync(CategoriesDTO categoriesDTO)
        {
            try
            {
                return await _categoriesRepository.CreateCategoryAsync(categoriesDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating category in service layer.");
                return (0, "An error occurred while creating the category.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteCategoryAsync(int categoryId)
        {
            try
            {
                return await _categoriesRepository.DeleteCategoryAsync(categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting category with ID {categoryId} in service layer.");
                return (false, "An error occurred while deleting the category.");
            }
        }

        public async Task<(IEnumerable<CategoriesDTO> Categories, string Message)> GetAllCategoriesAsync()
        {
            try
            {
                return await _categoriesRepository.GetAllCategoriesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all categories in service layer.");
                return (null, "An error occurred while retrieving all categories.");
            }
        }

        public async Task<(CategoriesDTO? Category, string Message)> GetCategoryByIDAsync(int categoryId)
        {
            try
            {
                return await _categoriesRepository.GetCategoryByIDAsync(categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving category with ID {categoryId} in service layer.");
                return (null, "An error occurred while retrieving the category.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateCategoryAsync(CategoriesDTO categoriesDTO)
        {
            try
            {
                return await _categoriesRepository.UpdateCategoryAsync(categoriesDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating category in service layer.");
                return (false, "An error occurred while updating the category.");
            }
        }
    }
}
