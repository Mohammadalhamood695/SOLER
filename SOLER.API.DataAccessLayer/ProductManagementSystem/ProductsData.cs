

namespace SOLER.API.DataAccessLayer.ProductManagementSystem
{
    public class ProductsData : BaseRepository, IProductsRepository<ProductsDTO>
    {
        public ProductsData(IConfiguration configuration, ILogger logger) : base(configuration, logger)
        {

        }

        public Task<(int ProductId, string Message)> CreateProductAsync(ProductsDTO ObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> DeleteProductAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<ProductsDTO> Products, string Message)> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(ProductsDTO? Product, string Message)> GetProductByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> UpdateProductAsync(ProductsDTO ObjDTO)
        {
            throw new NotImplementedException();
        }
    }
}
/*
 
 CREATE PROCEDURE [dbo].[SP_CreateProduct]
    @ProductName NVARCHAR(255),
    @ProductDescription NVARCHAR(1000),
    @CategoryID INT,
    @Price DECIMAL(18,2),
    @QuantityAvailable INT,
    @SKU NVARCHAR(100),
    @IsActive BIT,
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME,
    @QuantityInStock INT,
    @ProductID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- إضافة منتج جديد
        INSERT INTO [dbo].[Products]
           ([ProductName], [ProductDescription], [CategoryID], [Price], [QuantityAvailable], [SKU], [IsActive], [CreatedAt], [UpdatedAt], [QuantityInStock])
        VALUES
           (@ProductName, @ProductDescription, @CategoryID, @Price, @QuantityAvailable, @SKU, @IsActive, @CreatedAt, @UpdatedAt, @QuantityInStock);

        -- الحصول على ID المنتج الجديد
        SET @ProductID = SCOPE_IDENTITY();

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

CREATE PROCEDURE [dbo].[SP_GetAllProducts]
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        -- استرجاع جميع المنتجات
        SELECT [ProductID], [ProductName], [ProductDescription], [CategoryID], [Price], [QuantityAvailable], [SKU], [IsActive], [CreatedAt], [UpdatedAt], [QuantityInStock]
        FROM [dbo].[Products];
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

CREATE PROCEDURE [dbo].[SP_UpdateProduct]
    @ProductID INT,
    @ProductName NVARCHAR(255),
    @ProductDescription NVARCHAR(1000),
    @CategoryID INT,
    @Price DECIMAL(18,2),
    @QuantityAvailable INT,
    @SKU NVARCHAR(100),
    @IsActive BIT,
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME,
    @QuantityInStock INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- تحديث المنتج المحدد
        UPDATE [dbo].[Products]
        SET [ProductName] = @ProductName,
            [ProductDescription] = @ProductDescription,
            [CategoryID] = @CategoryID,
            [Price] = @Price,
            [QuantityAvailable] = @QuantityAvailable,
            [SKU] = @SKU,
            [IsActive] = @IsActive,
            [CreatedAt] = @CreatedAt,
            [UpdatedAt] = @UpdatedAt,
            [QuantityInStock] = @QuantityInStock
        WHERE [ProductID] = @ProductID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

CREATE PROCEDURE [dbo].[SP_DeleteProduct]
    @ProductID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- حذف المنتج المحدد
        DELETE FROM [dbo].[Products]
        WHERE [ProductID] = @ProductID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

 */