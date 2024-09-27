

namespace SOLER.API.DataAccessLayer.ProcurementManagementSystem
{
    public class ProcurementProductsData : BaseRepository, IProcurementProductsRepository<ProcurementProductsDTO>
    {
        public ProcurementProductsData(IConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
            
        }

        public Task<(int ProcurementProductId, string Message)> CreateProcurementProductAsync(ProcurementProductsDTO ObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> DeleteProcurementProductAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<ProcurementProductsDTO> ProcurementProducts, string Message)> GetAllProcurementProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(ProcurementProductsDTO? ProcurementProduct, string Message)> GetProcurementProductByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> UpdateProcurementProductAsync(ProcurementProductsDTO ObjDTO)
        {
            throw new NotImplementedException();
        }
    }
}

/*
 
 
 
CREATE PROCEDURE [dbo].[SP_CreateProcurementProduct]
    @ProcurementID INT,
    @ProductID INT,
    @Quantity INT,
    @UnitPrice DECIMAL(18,2),
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME,
    @ProcurementProductID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- إضافة منتج جديد إلى عملية الشراء
        INSERT INTO [dbo].[ProcurementProducts]
           ([ProcurementID], [ProductID], [Quantity], [UnitPrice], [CreatedAt], [UpdatedAt])
        VALUES
           (@ProcurementID, @ProductID, @Quantity, @UnitPrice, @CreatedAt, @UpdatedAt);

        -- الحصول على ID المنتج في عملية الشراء الجديدة
        SET @ProcurementProductID = SCOPE_IDENTITY();

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

CREATE PROCEDURE [dbo].[SP_GetAllProcurementProducts]
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        -- استرجاع جميع منتجات عمليات الشراء
        SELECT [ProcurementProductID], [ProcurementID], [ProductID], [Quantity], [UnitPrice], [LineTotal], [CreatedAt], [UpdatedAt]
        FROM [dbo].[ProcurementProducts];
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

CREATE PROCEDURE [dbo].[SP_UpdateProcurementProduct]
    @ProcurementProductID INT,
    @ProcurementID INT,
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

        -- تحديث منتج في عملية الشراء المحددة
        UPDATE [dbo].[ProcurementProducts]
        SET [ProcurementID] = @ProcurementID,
            [ProductID] = @ProductID,
            [Quantity] = @Quantity,
            [UnitPrice] = @UnitPrice,
            [CreatedAt] = @CreatedAt,
            [UpdatedAt] = @UpdatedAt
        WHERE [ProcurementProductID] = @ProcurementProductID;

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

CREATE PROCEDURE [dbo].[SP_DeleteProcurementProduct]
    @ProcurementProductID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- حذف المنتج من عملية الشراء المحددة
        DELETE FROM [dbo].[ProcurementProducts]
        WHERE [ProcurementProductID] = @ProcurementProductID;

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