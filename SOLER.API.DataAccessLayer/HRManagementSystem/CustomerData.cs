
namespace SOLER.API.DataAccessLayer.HRManagementSystem
{
    public class CustomerData : BaseRepository, ICustomerRepository<CustomerDTO>
    {
        public CustomerData(IConfiguration configuration, ILogger logger) : base(configuration, logger)
        {

        }

        public Task<(int CustomerId, string Message)> CreateCustomerAsync(CustomerDTO ObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> DeleteCustomerAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<CustomerDTO> Customers, string Message)> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(CustomerDTO? Customer, string Message)> GetCustomerByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> UpdateCustomerAsync(CustomerDTO ObjDTO)
        {
            throw new NotImplementedException();
        }
    }
}


/*
 
 CREATE PROCEDURE [dbo].[SP_GetAllCustomerWithPerson]
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- استرجاع بيانات العملاء مع بيانات الأشخاص المرتبطة
        SELECT c.[CustomerID], c.[RegistrationDate], c.[PreferredContactMethod], c.[IsVIP], c.[CreatedAt], c.[UpdatedAt],
               p.[PersonID], p.[FirstName], p.[LastName], p.[Email], p.[Phone], p.[Address], p.[DateOfBirth], p.[Gender], p.[CreatedAt] AS PersonCreatedAt, p.[UpdatedAt] AS PersonUpdatedAt
        FROM [dbo].[Customer] c
        INNER JOIN [dbo].[Person] p ON c.[CustomerID] = p.[PersonID];

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
CREATE PROCEDURE [dbo].[SP_UpdateCustomerWithPerson]
    @CustomerID INT,
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Phone NVARCHAR(15),
    @Address NVARCHAR(255),
    @DateOfBirth DATE,
    @Gender BIT,
    @RegistrationDate DATE,
    @PreferredContactMethod NVARCHAR(50),
    @IsVIP BIT
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
        WHERE [PersonID] = @CustomerID;

        -- تحديث بيانات العميل
        UPDATE [dbo].[Customer]
        SET [RegistrationDate] = @RegistrationDate,
            [PreferredContactMethod] = @PreferredContactMethod,
            [IsVIP] = @IsVIP,
            [UpdatedAt] = GETDATE()
        WHERE [CustomerID] = @CustomerID;

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
CREATE PROCEDURE [dbo].[SP_DeleteCustomerWithPerson]
    @CustomerID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- حذف العميل
        DELETE FROM [dbo].[Customer]
        WHERE [CustomerID] = @CustomerID;

        -- حذف الشخص المرتبط به
        DELETE FROM [dbo].[Person]
        WHERE [PersonID] = @CustomerID;

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
CREATE PROCEDURE [dbo].[SP_CreateCustomerWithPerson]
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Phone NVARCHAR(15),
    @Address NVARCHAR(255),
    @DateOfBirth DATE,
    @Gender BIT,
    @RegistrationDate DATE,
    @PreferredContactMethod NVARCHAR(50),
    @IsVIP BIT,
    @CustomerID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- إدخال بيانات الشخص
        INSERT INTO [dbo].[Person] ([FirstName], [LastName], [Email], [Phone], [Address], [DateOfBirth], [Gender], [CreatedAt], [UpdatedAt])
        VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @Gender, GETDATE(), GETDATE());

        -- الحصول على الـ PersonID الذي تم توليده
        SET @CustomerID = SCOPE_IDENTITY();

        -- إدخال بيانات العميل
        INSERT INTO [dbo].[Customer] ([CustomerID], [RegistrationDate], [PreferredContactMethod], [IsVIP], [CreatedAt], [UpdatedAt])
        VALUES (@CustomerID, @RegistrationDate, @PreferredContactMethod, @IsVIP, GETDATE(), GETDATE());

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