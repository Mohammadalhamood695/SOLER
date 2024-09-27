

namespace SOLER.API.DataAccessLayer.SalesManagementSystem
{
    public class SalesProductsData : BaseRepository, ISalesProductsRepository<SalesProductsDTO>
    {
        public SalesProductsData(IConfiguration configuration, ILogger logger) : base(configuration, logger) 
        {
            
        }

        public Task<(int SalesProductId, string Message)> CreateSalesProductAsync(SalesProductsDTO ObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> DeleteSalesProductAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<SalesProductsDTO> SalesProducts, string Message)> GetAllSalesProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(SalesProductsDTO? SalesProduct, string Message)> GetSalesProductByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> UpdateSalesProductAsync(SalesProductsDTO ObjDTO)
        {
            throw new NotImplementedException();
        }
    }
}

/*
 

CREATE PROCEDURE [dbo].[SP_CreateSalesProduct]
    @SaleID INT,
    @ProductID INT,
    @Quantity INT,
    @UnitPrice DECIMAL(18,2),
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME,
    @SaleProductID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- إضافة منتج مبيع جديد
        INSERT INTO [dbo].[SalesProducts]
           ([SaleID], [ProductID], [Quantity], [UnitPrice], [CreatedAt], [UpdatedAt])
        VALUES
           (@SaleID, @ProductID, @Quantity, @UnitPrice, @CreatedAt, @UpdatedAt);

        -- الحصول على ID المنتج المبيع الجديد
        SET @SaleProductID = SCOPE_IDENTITY();

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

CREATE PROCEDURE [dbo].[SP_GetAllSalesProducts]
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        -- استرجاع جميع منتجات المبيعات
        SELECT [SaleProductID], [SaleID], [ProductID], [Quantity], [UnitPrice], [LineTotal], [CreatedAt], [UpdatedAt]
        FROM [dbo].[SalesProducts];
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

CREATE PROCEDURE [dbo].[SP_UpdateSalesProduct]
    @SaleProductID INT,
    @SaleID INT,
    @ProductID INT,
    @Quantity INT,
    @UnitPrice DECIMAL(18,2),
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- تحديث المنتج المبيع المحدد
        UPDATE [dbo].[SalesProducts]
        SET [SaleID] = @SaleID,
            [ProductID] = @ProductID,
            [Quantity] = @Quantity,
            [UnitPrice] = @UnitPrice,
            [CreatedAt] = @CreatedAt,
            [UpdatedAt] = @UpdatedAt
        WHERE [SaleProductID] = @SaleProductID;

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

CREATE PROCEDURE [dbo].[SP_DeleteSalesProduct]
    @SaleProductID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- حذف المنتج المبيع المحدد
        DELETE FROM [dbo].[SalesProducts]
        WHERE [SaleProductID] = @SaleProductID;

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