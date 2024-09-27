namespace SOLER.API.BusinessLayer.IService.IServiceProductManagementSystem
{
    public interface IProductsService
    {
        Task<(IEnumerable<ProductsDTO> Products, string Message)> GetAllProductsAsync();
        Task<(ProductsDTO? Product, string Message)> GetProductByIDAsync(int Id);
        Task<(int ProductId, string Message)> CreateProductAsync(ProductsDTO ObjDTO);
        Task<(bool Success, string Message)> UpdateProductAsync(ProductsDTO ObjDTO);
        Task<(bool Success, string Message)> DeleteProductAsync(int Id);
    }
}
