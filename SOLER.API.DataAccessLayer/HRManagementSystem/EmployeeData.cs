

namespace SOLER.API.DataAccessLayer.HRManagementSystem
{
    public class EmployeeData : BaseRepository, IEmployeeRepository<EmployeeDTO>
    {
        public EmployeeData(IConfiguration configuration, ILogger logger) : base(configuration, logger) 
        {
            
        }

        public Task<(int EmployeeId, string Message)> CreateEmployeeAsync(EmployeeDTO ObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> DeleteEmployeeAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<EmployeeDTO> Employees, string Message)> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(EmployeeDTO? Employee, string Message)> GetEmployeeByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> UpdateEmployeeAsync(EmployeeDTO ObjDTO)
        {
            throw new NotImplementedException();
        }
    }
}


/*
 CREATE PROCEDURE [dbo].[SP_GetAllEmployeeWithPerson]
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- استرجاع بيانات الموظفين مع بيانات الأشخاص المرتبطة
        SELECT e.[EmployeeID], e.[HireDate], e.[JobTitle], e.[Salary], e.[Department], e.[CreatedAt], e.[UpdatedAt],
               p.[PersonID], p.[FirstName], p.[LastName], p.[Email], p.[Phone], p.[Address], p.[DateOfBirth], p.[Gender], p.[CreatedAt] AS PersonCreatedAt, p.[UpdatedAt] AS PersonUpdatedAt
        FROM [dbo].[Employee] e
        INNER JOIN [dbo].[Person] p ON e.[EmployeeID] = p.[PersonID];

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
CREATE PROCEDURE [dbo].[SP_UpdateEmployeeWithPerson]
    @EmployeeID INT,
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Phone NVARCHAR(15),
    @Address NVARCHAR(255),
    @DateOfBirth DATE,
    @Gender BIT,
    @HireDate DATE,
    @JobTitle NVARCHAR(100),
    @Salary DECIMAL(18, 2),
    @Department NVARCHAR(100)
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
        WHERE [PersonID] = @EmployeeID;

        -- تحديث بيانات الموظف
        UPDATE [dbo].[Employee]
        SET [HireDate] = @HireDate,
            [JobTitle] = @JobTitle,
            [Salary] = @Salary,
            [Department] = @Department,
            [UpdatedAt] = GETDATE()
        WHERE [EmployeeID] = @EmployeeID;

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
CREATE PROCEDURE [dbo].[SP_DeleteEmployeeWithPerson]
    @EmployeeID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- حذف الموظف
        DELETE FROM [dbo].[Employee]
        WHERE [EmployeeID] = @EmployeeID;

        -- حذف الشخص المرتبط به
        DELETE FROM [dbo].[Person]
        WHERE [PersonID] = @EmployeeID;

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
CREATE PROCEDURE [dbo].[SP_CreateEmployee]
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Phone NVARCHAR(15),
    @Address NVARCHAR(255),
    @DateOfBirth DATE,
    @Gender BIT,
    
    @HireDate DATE,
    @JobTitle NVARCHAR(100),
    @Salary DECIMAL(18, 2),
    @Department NVARCHAR(100),
    @EmployeeID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;
        
        -- إدراج الشخص أولاً
        INSERT INTO [dbo].[Person] ([FirstName], [LastName], [Email], [Phone], [Address], [DateOfBirth], [Gender], [CreatedAt], [UpdatedAt])
        VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @Gender, GETDATE(), GETDATE());

        -- استرجاع الـ PersonID الجديد
        SET @EmployeeID = SCOPE_IDENTITY();

        -- إدراج الموظف باستخدام PersonID
        INSERT INTO [dbo].[Employee] ([EmployeeID], [HireDate], [JobTitle], [Salary], [Department], [CreatedAt], [UpdatedAt])
        VALUES (@EmployeeID, @HireDate, @JobTitle, @Salary, @Department, GETDATE(), GETDATE());

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