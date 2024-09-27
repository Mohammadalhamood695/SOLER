namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs
{
    public class PersonDTO
    {
        public int? PersonID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public PersonDTO(int? PersonID, string? FirstName, string? LastName, string? Email,
        string? Phone, string? Address, DateTime? DateOfBirth,
        bool? Gender, DateTime? CreatedAt, DateTime? UpdatedAt)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.CreatedAt = DateOfBirth;
            this.UpdatedAt = UpdatedAt;
        }
        public PersonDTO()
        {
            this.PersonID = null;
            this.FirstName = null;
            this.LastName = null;
            this.Email = null;
            this.Phone = null;
            this.Address = null;
            this.DateOfBirth = null;
            this.Gender = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }
    }
}
