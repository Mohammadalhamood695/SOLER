
namespace SOLER.API.DataAccessLayer.HRManagementSystem
{
    public class PayrollData : BaseRepository, IPayrollRepository<PayrollDTO>
    {
        public PayrollData(IConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
            
        }

        public Task<(int PayrollId, string Message)> CreatePayrollAsync(PayrollDTO ObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> DeletePayrollAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<PayrollDTO> Payrolls, string Message)> GetAllPayrollsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(PayrollDTO? Payroll, string Message)> GetPayrollByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Success, string Message)> UpdatePayrollAsync(PayrollDTO ObjDTO)
        {
            throw new NotImplementedException();
        }
    }
}
/*
 
 

CREATE PROCEDURE [dbo].[SP_GetAllPayrollRecords]
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        -- استرجاع جميع سجلات الرواتب
        SELECT 
            PayrollID,
            EmployeeID,
            PayPeriodStart,
            PayPeriodEnd,
            TotalHoursWorked,
            RegularHours,
            OvertimeHours,
            DoubleOvertimeHours,
            RegularPay,
            OvertimePay,
            DoubleOvertimePay,
            TotalPay,
            CreatedAt,
            UpdatedAt
        FROM 
            Payroll
        ORDER BY 
            PayPeriodEnd DESC; -- الترتيب بناءً على آخر فترة دفع
    END TRY
    BEGIN CATCH
        -- في حالة وجود خطأ، إظهار رسالة الخطأ
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
CREATE PROCEDURE [dbo].[SP_GetPayrollByEmployee]
    @EmployeeID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        -- استرجاع جميع سجلات الرواتب لموظف معين
        SELECT 
            PayrollID,
            EmployeeID,
            PayPeriodStart,
            PayPeriodEnd,
            TotalHoursWorked,
            RegularHours,
            OvertimeHours,
            DoubleOvertimeHours,
            RegularPay,
            OvertimePay,
            DoubleOvertimePay,
            TotalPay,
            CreatedAt,
            UpdatedAt
        FROM 
            Payroll
        WHERE 
            EmployeeID = @EmployeeID
        ORDER BY 
            PayPeriodEnd DESC; -- الترتيب بناءً على آخر فترة دفع
    END TRY
    BEGIN CATCH
        -- في حالة وجود خطأ، إظهار رسالة الخطأ
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
-- ستورد بروسيجر لإنشاء سجل جديد في جدول Payroll
CREATE PROCEDURE [dbo].[SP_CreatePayrollRecord]
    @EmployeeID INT,
    @PayPeriodStart DATE = NULL,  -- يمكن أن يكون NULL وسيتم حسابه إذا لم يتم توفيره
    @PayPeriodEnd DATE = NULL,    -- يمكن أن يكون NULL وسيتم حسابه إذا لم يتم توفيره
    @PayrollID INT OUTPUT         -- للحصول على PayrollID الجديد
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- التحقق من وجود EmployeeID صالح
        IF NOT EXISTS (SELECT 1 FROM Employee WHERE EmployeeID = @EmployeeID)
        BEGIN
            RAISERROR('Invalid EmployeeID', 16, 1);
            RETURN;
        END;

        -- إذا لم يتم تحديد فترة الدفع، نقوم بحسابها بناءً على آخر فترة دفع أو تاريخ اليوم
        IF @PayPeriodStart IS NULL OR @PayPeriodEnd IS NULL
        BEGIN
            -- جلب تاريخ نهاية آخر فترة دفع لهذا الموظف
            SELECT @PayPeriodEnd = MAX(PayPeriodEnd)
            FROM Payroll
            WHERE EmployeeID = @EmployeeID;

            -- إذا كانت هذه أول فترة دفع، نبدأ من اليوم الحالي
            IF @PayPeriodEnd IS NULL
            BEGIN
                SET @PayPeriodStart = GETDATE();
                SET @PayPeriodEnd = DATEADD(DAY, 6, @PayPeriodStart);  -- افتراض فترة دفع أسبوعية
            END
            ELSE
            BEGIN
                -- إذا كان هناك فترة دفع سابقة، نبدأ الفترة الجديدة من اليوم التالي لنهاية الفترة السابقة
                SET @PayPeriodStart = DATEADD(DAY, 1, @PayPeriodEnd);
                SET @PayPeriodEnd = DATEADD(DAY, 6, @PayPeriodStart);
            END
        END;

        -- المتغيرات المؤقتة لتخزين الأجور والحسابات
        DECLARE @BaseSalary DECIMAL(18, 2);
        DECLARE @TotalHoursWorked DECIMAL(5, 2);
        DECLARE @RegularHours DECIMAL(5, 2);
        DECLARE @OvertimeHours DECIMAL(5, 2);
        DECLARE @DoubleOvertimeHours DECIMAL(5, 2);
        DECLARE @RegularPay DECIMAL(18, 2);
        DECLARE @OvertimePay DECIMAL(18, 2);
        DECLARE @DoubleOvertimePay DECIMAL(18, 2);
        DECLARE @TotalPay DECIMAL(18, 2);

        -- جلب الراتب الأساسي
        SET @BaseSalary = dbo.GetBaseSalary(@EmployeeID);

        -- جلب ملخص الساعات من GetHoursSummary
        SELECT 
            @RegularHours = RegularHours,
            @OvertimeHours = OvertimeHours,
            @DoubleOvertimeHours = DoubleOvertimeHours
        FROM dbo.GetHoursSummary(@EmployeeID);

        -- حساب إجمالي ساعات العمل
        SET @TotalHoursWorked = @RegularHours + @OvertimeHours + @DoubleOvertimeHours;

        -- حساب الأجر العادي
        SET @RegularPay = @RegularHours * dbo.GetRegularHourlyRate(@EmployeeID);

        -- حساب أجر ساعات العمل الإضافية
        SET @OvertimePay = @OvertimeHours * dbo.GetOvertimeHourlyRate(@EmployeeID);

        -- حساب أجر ساعات العمل الإضافية المضاعفة
        SET @DoubleOvertimePay = @DoubleOvertimeHours * dbo.GetDoubleOvertimeHourlyRate(@EmployeeID);

        -- حساب المجموع الكلي للأجر
        SET @TotalPay = @RegularPay + @OvertimePay + @DoubleOvertimePay;

        -- إدخال السجل الجديد في جدول Payroll
        INSERT INTO Payroll 
        (
            EmployeeID, 
            PayPeriodStart, 
            PayPeriodEnd, 
            TotalHoursWorked, 
            RegularHours, 
            OvertimeHours, 
            DoubleOvertimeHours, 
            RegularPay, 
            OvertimePay, 
            DoubleOvertimePay, 
            TotalPay, 
            CreatedAt, 
            UpdatedAt
        )
        VALUES 
        (
            @EmployeeID, 
            @PayPeriodStart, 
            @PayPeriodEnd, 
            @TotalHoursWorked, 
            @RegularHours, 
            @OvertimeHours, 
            @DoubleOvertimeHours, 
            @RegularPay, 
            @OvertimePay, 
            @DoubleOvertimePay, 
            @TotalPay, 
            GETDATE(), 
            GETDATE()
        );

        -- الحصول على PayrollID الجديد
        SET @PayrollID = SCOPE_IDENTITY();

        -- تأكيد التغييرات
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- في حالة الخطأ، إلغاء التغييرات
        ROLLBACK TRANSACTION;

        -- رفع رسالة الخطأ
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
CREATE PROCEDURE [dbo].[SP_UpdatePayrollRecord]
    @PayrollID INT,
    @RegularHours DECIMAL(5,2),
    @OvertimeHours DECIMAL(5,2),
    @DoubleOvertimeHours DECIMAL(5,2),
    @TotalPay DECIMAL(18,2),
    @UpdatedAt DATETIME2(7)
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- تحديث سجل الرواتب
        UPDATE Payroll
        SET 
            RegularHours = @RegularHours,
            OvertimeHours = @OvertimeHours,
            DoubleOvertimeHours = @DoubleOvertimeHours,
            TotalPay = @TotalPay,
            UpdatedAt = @UpdatedAt
        WHERE 
            PayrollID = @PayrollID;

        -- تأكيد التحديث
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- في حالة وجود خطأ، إلغاء التغييرات
        ROLLBACK TRANSACTION;

        -- رفع رسالة الخطأ
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
CREATE PROCEDURE [dbo].[SP_DeletePayrollRecord]
    @PayrollID INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;

        -- حذف سجل الرواتب
        DELETE FROM Payroll
        WHERE PayrollID = @PayrollID;

        -- تأكيد الحذف
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- في حالة وجود خطأ، إلغاء التغييرات
        ROLLBACK TRANSACTION;

        -- رفع رسالة الخطأ
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

 */