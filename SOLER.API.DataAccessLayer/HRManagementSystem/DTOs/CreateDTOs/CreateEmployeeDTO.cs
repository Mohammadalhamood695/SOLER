namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs.CreateDTOs
{
    public class CreateEmployeeDTO
    {
        public DateTime PayPeriodStart { get; set; }
        public DateTime PayPeriodEnd { get; set; }
        public decimal TotalHoursWorked { get; set; }
        public decimal RegularHours { get; set; }
        public decimal OvertimeHours { get; set; }
        public decimal DoubleOvertimeHours { get; set; }
        public decimal RegularPay { get; set; }
        public decimal OvertimePay { get; set; }
        public decimal DoubleOvertimePay { get; set; }
        public decimal TotalPay { get; set; }
    }
}
