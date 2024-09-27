
namespace SOLER.API.DataAccessLayer.HRManagementSystem
{
    public class EmployeeAttendanceData : BaseRepository, IEmployeeAttendanceRepository<EmployeeAttendanceDTO>
    {
        public EmployeeAttendanceData(IConfiguration configuration, ILogger logger) : base(configuration, logger)
        {

        }

        public Task<(int AttendanceId, string Message)> CreateEmployeeAttendanceAsync(EmployeeAttendanceDTO ObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> DeleteEmployeeAttendanceAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<EmployeeAttendanceDTO> EmployeeAttendances, string Message)> GetAllEmployeeAttendancesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(EmployeeAttendanceDTO? EmployeeAttendance, string Message)> GetEmployeeAttendanceByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> UpdateEmployeeAttendanceAsync(EmployeeAttendanceDTO ObjDTO)
        {
            throw new NotImplementedException();
        }
    }
}
/*
 
 CREATE PROCEDURE [dbo].[SP_GetAllEmployeeAttendance]
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        -- استرجاع جميع سجلات الحضور
        SELECT [AttendanceID], [EmployeeID], [CheckInTime], [CheckOutTime], [WorkDuration], [CreatedAt], [UpdatedAt]
        FROM [dbo].[EmployeeAttendance];
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
CREATE PROCEDURE [dbo].[SP_CreateEmployeeAttendance]
    @EmployeeID INT,
    @CheckInTime DATETIME,
    @CheckOutTime DATETIME,
    @AttendanceID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- إضافة سجل حضور جديد
        INSERT INTO [dbo].[EmployeeAttendance] ([EmployeeID], [CheckInTime], [CheckOutTime], [CreatedAt], [UpdatedAt])
        VALUES (@EmployeeID, @CheckInTime, @CheckOutTime, GETDATE(), GETDATE());

        -- الحصول على ID السجل الجديد
        SET @AttendanceID = SCOPE_IDENTITY();

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
CREATE PROCEDURE [dbo].[SP_UpdateEmployeeAttendance]
    @AttendanceID INT,
    @EmployeeID INT,
    @CheckInTime DATETIME,
    @CheckOutTime DATETIME
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- تحديث سجل الحضور المحدد
        UPDATE [dbo].[EmployeeAttendance]
        SET [EmployeeID] = @EmployeeID,
            [CheckInTime] = @CheckInTime,
            [CheckOutTime] = @CheckOutTime,
            [UpdatedAt] = GETDATE()
        WHERE [AttendanceID] = @AttendanceID;

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
CREATE PROCEDURE [dbo].[SP_DeleteEmployeeAttendance]
    @AttendanceID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- حذف سجل الحضور المحدد
        DELETE FROM [dbo].[EmployeeAttendance]
        WHERE [AttendanceID] = @AttendanceID;

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