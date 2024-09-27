
namespace SOLER.API.DataAccessLayer.InvoiceManagementSystem
{
    public class InvoicesData : BaseRepository, IInvoicesRepository<InvoicesDTO>
    {
        public InvoicesData(IConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
            
        }

        public Task<(int InvoiceId, string Message)> CreateInvoiceAsync(InvoicesDTO ObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> DeleteInvoiceAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<InvoicesDTO> Invoices, string Message)> GetAllInvoicesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(InvoicesDTO? Invoice, string Message)> GetInvoiceByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> UpdateInvoiceAsync(InvoicesDTO ObjDTO)
        {
            throw new NotImplementedException();
        }
    }
}


/*
 
 
 


CREATE PROCEDURE [dbo].[SP_CreateInvoice]
    @CustomerID INT,
    @InvoiceDate DATETIME,
    @TotalAmount DECIMAL(18,2),
    @PaymentStatus NVARCHAR(50),
    @Description NVARCHAR(2000),
    @InvoiceID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- إضافة فاتورة جديدة
        INSERT INTO [dbo].[Invoices]
           ([CustomerID], [InvoiceDate], [TotalAmount], [PaymentStatus], [Description], [CreatedAt], [UpdatedAt])
        VALUES
           (@CustomerID, @InvoiceDate, @TotalAmount, @PaymentStatus, @Description, GETDATE(), GETDATE());

        -- الحصول على ID الفاتورة الجديدة
        SET @InvoiceID = SCOPE_IDENTITY();

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
CREATE PROCEDURE [dbo].[SP_GetAllInvoices]
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        -- استرجاع جميع الفواتير
        SELECT [InvoiceID], [CustomerID], [InvoiceDate], [TotalAmount], [PaymentStatus], [Description], [CreatedAt], [UpdatedAt]
        FROM [dbo].[Invoices];
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
CREATE PROCEDURE [dbo].[SP_UpdateInvoice]
    @InvoiceID INT,
    @CustomerID INT,
    @InvoiceDate DATETIME,
    @TotalAmount DECIMAL(18,2),
    @PaymentStatus NVARCHAR(50),
    @Description NVARCHAR(2000)
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- تحديث الفاتورة المحددة
        UPDATE [dbo].[Invoices]
        SET [CustomerID] = @CustomerID,
            [InvoiceDate] = @InvoiceDate,
            [TotalAmount] = @TotalAmount,
            [PaymentStatus] = @PaymentStatus,
            [Description] = @Description,
            [UpdatedAt] = GETDATE()
        WHERE [InvoiceID] = @InvoiceID;

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
CREATE PROCEDURE [dbo].[SP_DeleteInvoice]
    @InvoiceID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- حذف الفاتورة المحددة
        DELETE FROM [dbo].[Invoices]
        WHERE [InvoiceID] = @InvoiceID;

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