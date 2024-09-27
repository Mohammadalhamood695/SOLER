namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs
{
    public class EmployeeDTO : PersonDTO // الوراثة من PersonDTO
    {
        public int? EmployeeID { get; set; }
        public DateTime? HireDate { get; set; }
        public string? JobTitle { get; set; }
        public decimal? Salary { get; set; }
        public string? Department { get; set; }
        public new DateTime? CreatedAt { get; set; } // استخدام كلمة "new" لتفادي الالتباس
        public new DateTime? UpdatedAt { get; set; }

        // Constructor يأخذ معاملات PersonDTO بالإضافة إلى معاملات EmployeeDTO
        public EmployeeDTO(int? PersonID, string? FirstName, string? LastName, string? Email,
            string? Phone, string? Address, DateTime? DateOfBirth,
            bool? Gender, DateTime? PersonCreatedAt, DateTime? PersonUpdatedAt,
            int? EmployeeID, DateTime? HireDate, string? JobTitle,
            decimal? Salary, string? Department, DateTime? EmployeeCreatedAt, DateTime? EmployeeUpdatedAt)
            : base(PersonID, FirstName, LastName, Email, Phone, Address, DateOfBirth, Gender, PersonCreatedAt, PersonUpdatedAt)
        {
            this.EmployeeID = EmployeeID;
            this.HireDate = HireDate;
            this.JobTitle = JobTitle;
            this.Salary = Salary;
            this.Department = Department;
            this.CreatedAt = EmployeeCreatedAt; // تخصيص CreatedAt لـ Employee
            this.UpdatedAt = EmployeeUpdatedAt; // تخصيص UpdatedAt لـ Employee
        }

        // Constructor افتراضي
        public EmployeeDTO() : base()
        {
            this.EmployeeID = null;
            this.HireDate = null;
            this.JobTitle = null;
            this.Salary = null;
            this.Department = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }
    }
}
