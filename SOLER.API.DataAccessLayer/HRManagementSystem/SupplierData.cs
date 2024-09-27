
namespace SOLER.API.DataAccessLayer.HRManagementSystem
{
    public class SupplierData : BaseRepository, ISupplierRepository<SupplierDTO>
    {
        public SupplierData(IConfiguration configuration, ILogger logger) : base(configuration, logger)
        {

        }

        public Task<(int SupplierId, string Message)> CreateSupplierAsync(SupplierDTO ObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> DeleteSupplierAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<SupplierDTO> Suppliers, string Message)> GetAllSuppliersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(SupplierDTO? Supplier, string Message)> GetSupplierByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> UpdateSupplierAsync(SupplierDTO ObjDTO)
        {
            throw new NotImplementedException();
        }
    }
}

/*
 CREATE PROCEDURE [dbo].[SP_GetAllSupplierWithPerson]
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- استرجاع بيانات الموردين مع بيانات الأشخاص المرتبطة
        SELECT s.[SupplierID], s.[CompanyName], s.[SupplyType], s.[ContractStartDate], s.[CreatedAt], s.[UpdatedAt],
               p.[PersonID], p.[FirstName], p.[LastName], p.[Email], p.[Phone], p.[Address], p.[DateOfBirth], p.[Gender], p.[CreatedAt] AS PersonCreatedAt, p.[UpdatedAt] AS PersonUpdatedAt
        FROM [dbo].[Supplier] s
        INNER JOIN [dbo].[Person] p ON s.[SupplierID] = p.[PersonID];

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
CREATE PROCEDURE [dbo].[SP_UpdateSupplierWithPerson]
    @SupplierID INT,
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Phone NVARCHAR(15),
    @Address NVARCHAR(255),
    @DateOfBirth DATE,
    @Gender BIT,
    @CompanyName NVARCHAR(255),
    @SupplyType NVARCHAR(100),
    @ContractStartDate DATE
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- تحديث بيانات الشخص
        UPDATE [dbo].[Person]
        SET [FirstName] = @FirstName,
            [LastName] = @LastName,
            [Email] = @Email,
            [Phone] = @Phone,
            [Address] = @Address,
            [DateOfBirth] = @DateOfBirth,
            [Gender] = @Gender,
            [UpdatedAt] = GETDATE()
        WHERE [PersonID] = @SupplierID;

        -- تحديث بيانات المورد
        UPDATE [dbo].[Supplier]
        SET [CompanyName] = @CompanyName,
            [SupplyType] = @SupplyType,
            [ContractStartDate] = @ContractStartDate,
            [UpdatedAt] = GETDATE()
        WHERE [SupplierID] = @SupplierID;

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
CREATE PROCEDURE [dbo].[SP_DeleteSupplierWithPerson]
    @SupplierID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- حذف المورد
        DELETE FROM [dbo].[Supplier]
        WHERE [SupplierID] = @SupplierID;

        -- حذف الشخص المرتبط به
        DELETE FROM [dbo].[Person]
        WHERE [PersonID] = @SupplierID;

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
CREATE PROCEDURE [dbo].[SP_CreateSupplierWithPerson]
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Phone NVARCHAR(15),
    @Address NVARCHAR(255),
    @DateOfBirth DATE,
    @Gender BIT,
    @CompanyName NVARCHAR(255),
    @SupplyType NVARCHAR(100),
    @ContractStartDate DATE,
    @SupplierID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- إدخال بيانات الشخص
        INSERT INTO [dbo].[Person] ([FirstName], [LastName], [Email], [Phone], [Address], [DateOfBirth], [Gender], [CreatedAt], [UpdatedAt])
        VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @Gender, GETDATE(), GETDATE());

        -- الحصول على الـ PersonID الذي تم توليده
        SET @SupplierID = SCOPE_IDENTITY();

        -- إدخال بيانات المورد
        INSERT INTO [dbo].[Supplier] ([SupplierID], [CompanyName], [SupplyType], [ContractStartDate], [CreatedAt], [UpdatedAt])
        VALUES (@SupplierID, @CompanyName, @SupplyType, @ContractStartDate, GETDATE(), GETDATE());

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