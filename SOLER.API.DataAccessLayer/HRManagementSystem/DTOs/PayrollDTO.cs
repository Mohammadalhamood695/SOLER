namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs
{
    public class PayrollDTO
    {
        public int? PayrollID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? PayPeriodStart { get; set; }
        public DateTime? PayPeriodEnd { get; set; }
        public decimal? TotalHoursWorked { get; set; }
        public decimal? RegularHours { get; set; }
        public decimal? OvertimeHours { get; set; }
        public decimal? DoubleOvertimeHours { get; set; }
        public decimal? RegularPay { get; set; }
        public decimal? OvertimePay { get; set; }
        public decimal? DoubleOvertimePay { get; set; }
        public decimal? TotalPay { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public PayrollDTO(int? PayrollID,int? EmployeeID,DateTime? PayPeriodStart,
        DateTime? PayPeriodEnd,decimal? TotalHoursWorked,decimal? RegularHours,
        decimal? OvertimeHours,decimal? DoubleOvertimeHours,decimal? RegularPay,
        decimal? OvertimePay,decimal? DoubleOvertimePay,decimal? TotalPay,
        DateTime? CreatedAt,DateTime? UpdatedAt)
        {
            this.TotalPay = TotalPay;
            this.PayPeriodStart = PayPeriodStart;
            this.PayPeriodEnd = PayPeriodEnd;
            this.TotalHoursWorked = TotalHoursWorked;
            this.RegularHours = RegularHours;
            this.OvertimeHours = OvertimeHours;
            this.DoubleOvertimeHours= DoubleOvertimeHours;
            this.RegularPay = RegularPay;
            this.OvertimePay = RegularPay;
            this.DoubleOvertimePay = DoubleOvertimePay;
            this.TotalPay = TotalPay;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }
        public PayrollDTO()
        {
            this.TotalPay = null;
            this.PayPeriodStart = null;
            this.PayPeriodEnd = null;
            this.TotalHoursWorked = null;
            this.RegularHours = null;
            this.OvertimeHours = null;
            this.DoubleOvertimeHours = null;
            this.RegularPay = null;
            this.OvertimePay = null;
            this.DoubleOvertimePay = null;
            this.TotalPay = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }
    }
}
