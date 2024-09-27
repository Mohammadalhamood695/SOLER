
namespace SOLER.API.DataAccessLayer.WorkshopManagementSystem
{
    public class WorkshopEmployeeScheduleData : BaseRepository, IWorkshopEmployeeScheduleRepository<WorkshopEmployeeScheduleDTO>
    {
        public WorkshopEmployeeScheduleData(IConfiguration configuration, ILogger logger) : base(configuration, logger)
        {

        }

        public Task<(int WorkshopEmployeeScheduleId, string Message)> CreateWorkshopEmployeeScheduleAsync(WorkshopEmployeeScheduleDTO ObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> DeleteWorkshopEmployeeScheduleAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<WorkshopEmployeeScheduleDTO> WorkshopEmployeeSchedules, string Message)> GetAllWorkshopEmployeeSchedulesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(WorkshopEmployeeScheduleDTO? WorkshopEmployeeSchedule, string Message)> GetWorkshopEmployeeScheduleByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> UpdateWorkshopEmployeeScheduleAsync(WorkshopEmployeeScheduleDTO ObjDTO)
        {
            throw new NotImplementedException();
        }
    }
}
/*
 
CREATE PROCEDURE [dbo].[SP_CreateWorkshopEmployeeSchedule]
    @WorkshopID INT,
    @EmployeeID INT,
    @ScheduledDate DATE,
    @ScheduledStartTime TIME(7),
    @ScheduledEndTime TIME(7),
    @ActualStartTime TIME(7),
    @ActualEndTime TIME(7),
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME,
    @ScheduleID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- إضافة جدول جداول الموظفين في ورشة العمل
        INSERT INTO [dbo].[WorkshopEmployeeSchedule]
           ([WorkshopID], [EmployeeID], [ScheduledDate], [ScheduledStartTime], [ScheduledEndTime], [ActualStartTime], [ActualEndTime], [CreatedAt], [UpdatedAt])
        VALUES
           (@WorkshopID, @EmployeeID, @ScheduledDate, @ScheduledStartTime, @ScheduledEndTime, @ActualStartTime, @ActualEndTime, @CreatedAt, @UpdatedAt);

        -- الحصول على ID جدول الموظف في الورشة الجديد
        SET @ScheduleID = SCOPE_IDENTITY();

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

CREATE PROCEDURE [dbo].[SP_GetAllWorkshopEmployeeSchedules]
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        -- استرجاع جميع جداول الموظفين في ورشة العمل
        SELECT [ScheduleID], [WorkshopID], [EmployeeID], [ScheduledDate], [ScheduledStartTime], [ScheduledEndTime], [ActualStartTime], [ActualEndTime], [TotalScheduledHours], [TotalActualHours], [CreatedAt], [UpdatedAt]
        FROM [dbo].[WorkshopEmployeeSchedule];
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

CREATE PROCEDURE [dbo].[SP_UpdateWorkshopEmployeeSchedule]
    @ScheduleID INT,
    @WorkshopID INT,
    @EmployeeID INT,
    @ScheduledDate DATE,
    @ScheduledStartTime TIME(7),
    @ScheduledEndTime TIME(7),
    @ActualStartTime TIME(7),
    @ActualEndTime TIME(7),
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- تحديث جدول الموظف في الورشة المحدد
        UPDATE [dbo].[WorkshopEmployeeSchedule]
        SET [WorkshopID] = @WorkshopID,
            [EmployeeID] = @EmployeeID,
            [ScheduledDate] = @ScheduledDate,
            [ScheduledStartTime] = @ScheduledStartTime,
            [ScheduledEndTime] = @ScheduledEndTime,
            [ActualStartTime] = @ActualStartTime,
            [ActualEndTime] = @ActualEndTime,
            [CreatedAt] = @CreatedAt,
            [UpdatedAt] = @UpdatedAt
        WHERE [ScheduleID] = @ScheduleID;

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

CREATE PROCEDURE [dbo].[SP_DeleteWorkshopEmployeeSchedule]
    @ScheduleID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- حذف جدول الموظف في الورشة المحدد
        DELETE FROM [dbo].[WorkshopEmployeeSchedule]
        WHERE [ScheduleID] = @ScheduleID;

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