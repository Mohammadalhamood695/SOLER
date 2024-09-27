namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs
{
    public class SupplierDTO : PersonDTO // الوراثة من PersonDTO
    {
        public int? SupplierID { get; set; }
        public string? CompanyName { get; set; }
        public string? SupplyType { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public new DateTime? CreatedAt { get; set; } // استخدام "new" لتفادي الالتباس مع الخاصية الموروثة
        public new DateTime? UpdatedAt { get; set; }

        // Constructor يأخذ معاملات PersonDTO بالإضافة إلى معاملات SupplierDTO
        public SupplierDTO(int? PersonID, string? FirstName, string? LastName, string? Email,
            string? Phone, string? Address, DateTime? DateOfBirth,
            bool? Gender, DateTime? PersonCreatedAt, DateTime? PersonUpdatedAt,
            int? SupplierID, string? CompanyName, string? SupplyType,
            DateTime? ContractStartDate, DateTime? SupplierCreatedAt, DateTime? SupplierUpdatedAt)
            : base(PersonID, FirstName, LastName, Email, Phone, Address, DateOfBirth, Gender, PersonCreatedAt, PersonUpdatedAt)
        {
            this.SupplierID = SupplierID;
            this.CompanyName = CompanyName;
            this.SupplyType = SupplyType;
            this.ContractStartDate = ContractStartDate;
            this.CreatedAt = SupplierCreatedAt; // تخصيص CreatedAt لـ Supplier
            this.UpdatedAt = SupplierUpdatedAt; // تخصيص UpdatedAt لـ Supplier
        }

        // Constructor افتراضي
        public SupplierDTO() : base()
        {
            this.SupplierID = null;
            this.CompanyName = null;
            this.SupplyType = null;
            this.ContractStartDate = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }
    }
}
