namespace SOLER.API.BusinessLayer.ServiceProductManagementSystem
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository<ProductsDTO> _productsRepository;
        private readonly ILogger<ProductsService> _logger;

        public ProductsService(
            IProductsRepository<ProductsDTO> productsRepository,
            ILogger<ProductsService> logger)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(int ProductId, string Message)> CreateProductAsync(ProductsDTO productsDTO)
        {
            try
            {
                return await _productsRepository.CreateProductAsync(productsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating product in service layer.");
                return (0, "An error occurred while creating the product.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteProductAsync(int productId)
        {
            try
            {
                return await _productsRepository.DeleteProductAsync(productId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting product with ID {productId} in service layer.");
                return (false, "An error occurred while deleting the product.");
            }
        }

        public async Task<(IEnumerable<ProductsDTO> Products, string Message)> GetAllProductsAsync()
        {
            try
            {
                return await _productsRepository.GetAllProductsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all products in service layer.");
                return (null, "An error occurred while retrieving all products.");
            }
        }

        public async Task<(ProductsDTO? Product, string Message)> GetProductByIDAsync(int productId)
        {
            try
            {
                return await _productsRepository.GetProductByIDAsync(productId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving product with ID {productId} in service layer.");
                return (null, "An error occurred while retrieving the product.");
            }
        }

        public async Task<(bool Success, string Message)> UpdateProductAsync(ProductsDTO productsDTO)
        {
            try
            {
                return await _productsRepository.UpdateProductAsync(productsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating product in service layer.");
                return (false, "An error occurred while updating the product.");
            }
        }
    }
}
