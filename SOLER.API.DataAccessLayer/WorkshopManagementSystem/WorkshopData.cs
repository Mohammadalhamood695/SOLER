
namespace SOLER.API.DataAccessLayer.WorkshopManagementSystem
{
    public class WorkshopData : BaseRepository, IWorkshopRepository<WorkshopDTO>
    {
        public WorkshopData(IConfiguration configuration ,ILogger logger ) : base(configuration, logger)
        {
        }

        public Task<(int WorkshopId, string Message)> CreateWorkshopAsync(WorkshopDTO ObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> DeleteWorkshopAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<WorkshopDTO> Workshops, string Message)> GetAllWorkshopsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(WorkshopDTO? Workshop, string Message)> GetWorkshopByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> UpdateWorkshopAsync(WorkshopDTO ObjDTO)
        {
            throw new NotImplementedException();
        }
    }
}

/*
 
 CREATE PROCEDURE [dbo].[SP_CreateWorkshop]
    @CustomerID INT,
    @WorkshopName NVARCHAR(255),
    @Location NVARCHAR(255),
    @Description NVARCHAR(1000),
    @StartDate DATE,
    @EndDate DATE,
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME,
    @WorkshopID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- إضافة ورشة عمل جديدة
        INSERT INTO [dbo].[Workshop]
           ([CustomerID], [WorkshopName], [Location], [Description], [StartDate], [EndDate], [CreatedAt], [UpdatedAt])
        VALUES
           (@CustomerID, @WorkshopName, @Location, @Description, @StartDate, @EndDate, @CreatedAt, @UpdatedAt);

        -- الحصول على ID الورشة الجديدة
        SET @WorkshopID = SCOPE_IDENTITY();

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

CREATE PROCEDURE [dbo].[SP_GetAllWorkshops]
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        -- استرجاع جميع ورش العمل
        SELECT [WorkshopID], [CustomerID], [WorkshopName], [Location], [Description], [StartDate], [EndDate], [CreatedAt], [UpdatedAt]
        FROM [dbo].[Workshop];
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

CREATE PROCEDURE [dbo].[SP_UpdateWorkshop]
    @WorkshopID INT,
    @CustomerID INT,
    @WorkshopName NVARCHAR(255),
    @Location NVARCHAR(255),
    @Description NVARCHAR(1000),
    @StartDate DATE,
    @EndDate DATE,
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- تحديث الورشة المحددة
        UPDATE [dbo].[Workshop]
        SET [CustomerID] = @CustomerID,
            [WorkshopName] = @WorkshopName,
            [Location] = @Location,
            [Description] = @Description,
            [StartDate] = @StartDate,
            [EndDate] = @EndDate,
            [CreatedAt] = @CreatedAt,
            [UpdatedAt] = @UpdatedAt
        WHERE [WorkshopID] = @WorkshopID;

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

CREATE PROCEDURE [dbo].[SP_DeleteWorkshop]
    @WorkshopID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- حذف الورشة المحددة
        DELETE FROM [dbo].[Workshop]
        WHERE [WorkshopID] = @WorkshopID;

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