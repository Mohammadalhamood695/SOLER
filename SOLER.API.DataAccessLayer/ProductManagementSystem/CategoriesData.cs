
namespace SOLER.API.DataAccessLayer.ProductManagementSystem
{
    public class CategoriesData : BaseRepository, ICategoriesRepository<CategoriesDTO>
    {
        public CategoriesData(IConfiguration configuration, ILogger logger) : base(configuration, logger) 
        {
        }

        public Task<(int CategoryId, string Message)> CreateCategoryAsync(CategoriesDTO ObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> DeleteCategoryAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<CategoriesDTO> Categories, string Message)> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(CategoriesDTO? Category, string Message)> GetCategoryByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> UpdateCategoryAsync(CategoriesDTO ObjDTO)
        {
            throw new NotImplementedException();
        }
    }
}
/*
 
 
CREATE PROCEDURE [dbo].[SP_GetAllCategories]
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        -- استرجاع جميع الفئات
        SELECT [CategoryID], [CategoryName], [CategoryDescription], [IsActive], [CreatedAt], [UpdatedAt]
        FROM [dbo].[Categories];
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
CREATE PROCEDURE [dbo].[SP_CreateCategory]
    @CategoryName NVARCHAR(255),
    @CategoryDescription NVARCHAR(1000),
    @IsActive BIT,
    @CategoryID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- إضافة فئة جديدة
        INSERT INTO [dbo].[Categories] ([CategoryName], [CategoryDescription], [IsActive], [CreatedAt], [UpdatedAt])
        VALUES (@CategoryName, @CategoryDescription, @IsActive, GETDATE(), GETDATE());

        -- الحصول على ID الفئة الجديدة
        SET @CategoryID = SCOPE_IDENTITY();

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
CREATE PROCEDURE [dbo].[SP_UpdateCategory]
    @CategoryID INT,
    @CategoryName NVARCHAR(255),
    @CategoryDescription NVARCHAR(1000),
    @IsActive BIT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- تحديث الفئة المحددة
        UPDATE [dbo].[Categories]
        SET [CategoryName] = @CategoryName,
            [CategoryDescription] = @CategoryDescription,
            [IsActive] = @IsActive,
            [UpdatedAt] = GETDATE()
        WHERE [CategoryID] = @CategoryID;

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
CREATE PROCEDURE [dbo].[SP_DeleteCategory]
    @CategoryID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- حذف الفئة المحددة
        DELETE FROM [dbo].[Categories]
        WHERE [CategoryID] = @CategoryID;

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