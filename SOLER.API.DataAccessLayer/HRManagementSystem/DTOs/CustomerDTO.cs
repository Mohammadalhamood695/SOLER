namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs
{
    public class CustomerDTO : PersonDTO // الوراثة من PersonDTO
    {
        public int? CustomerID { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? PreferredContactMethod { get; set; }
        public bool? IsVIP { get; set; }
        public new DateTime? CreatedAt { get; set; } // استخدام "new" لتفادي الالتباس مع الخاصية الموروثة
        public new DateTime? UpdatedAt { get; set; }

        // Constructor يأخذ معاملات PersonDTO بالإضافة إلى معاملات CustomerDTO
        public CustomerDTO(int? PersonID, string? FirstName, string? LastName, string? Email,
            string? Phone, string? Address, DateTime? DateOfBirth,
            bool? Gender, DateTime? PersonCreatedAt, DateTime? PersonUpdatedAt,
            int? CustomerID, DateTime? RegistrationDate, string? PreferredContactMethod,
            bool? IsVIP, DateTime? CustomerCreatedAt, DateTime? CustomerUpdatedAt)
            : base(PersonID, FirstName, LastName, Email, Phone, Address, DateOfBirth, Gender, PersonCreatedAt, PersonUpdatedAt)
        {
            this.CustomerID = CustomerID;
            this.RegistrationDate = RegistrationDate;
            this.PreferredContactMethod = PreferredContactMethod;
            this.IsVIP = IsVIP;
            this.CreatedAt = CustomerCreatedAt; // تخصيص CreatedAt لـ Customer
            this.UpdatedAt = CustomerUpdatedAt; // تخصيص UpdatedAt لـ Customer
        }

        // Constructor افتراضي
        public CustomerDTO() : base()
        {
            this.CustomerID = null;
            this.RegistrationDate = null;
            this.PreferredContactMethod = null;
            this.IsVIP = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }
    }
}
