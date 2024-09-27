


namespace SOLER.API.DataAccessLayer.ProcurementManagementSystem
{
    public class ProcurementsData : BaseRepository, IProcurementsRepository<ProcurementsDTO>
    {
        public ProcurementsData(IConfiguration configuration, ILogger logger) : base(configuration, logger)
        {

        }

        public Task<(int ProcurementId, string Message)> CreateProcurementAsync(ProcurementsDTO ObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> DeleteProcurementAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<ProcurementsDTO> Procurements, string Message)> GetAllProcurementsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(ProcurementsDTO? Procurement, string Message)> GetProcurementByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> UpdateProcurementAsync(ProcurementsDTO ObjDTO)
        {
            throw new NotImplementedException();
        }
    }
}
/*
 
 CREATE PROCEDURE [dbo].[SP_CreateProcurement]
    @SupplierID INT,
    @PurchaseDate DATETIME,
    @TotalAmount DECIMAL(18,2),
    @PaymentMethod NVARCHAR(50),
    @ProcurementStatus NVARCHAR(50),
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME,
    @ProcurementID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- إضافة عملية شراء جديدة
        INSERT INTO [dbo].[Procurements]
           ([SupplierID], [PurchaseDate], [TotalAmount], [PaymentMethod], [ProcurementStatus], [CreatedAt], [UpdatedAt])
        VALUES
           (@SupplierID, @PurchaseDate, @TotalAmount, @PaymentMethod, @ProcurementStatus, @CreatedAt, @UpdatedAt);

        -- الحصول على ID عملية الشراء الجديدة
        SET @ProcurementID = SCOPE_IDENTITY();

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

CREATE PROCEDURE [dbo].[SP_GetAllProcurements]
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        -- استرجاع جميع عمليات الشراء
        SELECT [ProcurementID], [SupplierID], [PurchaseDate], [TotalAmount], [PaymentMethod], [ProcurementStatus], [CreatedAt], [UpdatedAt]
        FROM [dbo].[Procurements];
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

CREATE PROCEDURE [dbo].[SP_UpdateProcurement]
    @ProcurementID INT,
    @SupplierID INT,
    @PurchaseDate DATETIME,
    @TotalAmount DECIMAL(18,2),
    @PaymentMethod NVARCHAR(50),
    @ProcurementStatus NVARCHAR(50),
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- تحديث عملية الشراء المحددة
        UPDATE [dbo].[Procurements]
        SET [SupplierID] = @SupplierID,
            [PurchaseDate] = @PurchaseDate,
            [TotalAmount] = @TotalAmount,
            [PaymentMethod] = @PaymentMethod,
            [ProcurementStatus] = @ProcurementStatus,
            [CreatedAt] = @CreatedAt,
            [UpdatedAt] = @UpdatedAt
        WHERE [ProcurementID] = @ProcurementID;

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

CREATE PROCEDURE [dbo].[SP_DeleteProcurement]
    @ProcurementID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- حذف عملية الشراء المحددة
        DELETE FROM [dbo].[Procurements]
        WHERE [ProcurementID] = @ProcurementID;

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