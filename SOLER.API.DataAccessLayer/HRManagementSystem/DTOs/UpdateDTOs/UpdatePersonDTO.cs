namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs.UpdateDTOs
{
    public class UpdatePersonDTO
    {
        [Required]
        public int PersonID { get; set; }
        [Required]
        public string  FirstName { get; set; }
        [Required]
        public string  LastName { get; set; }
        [Required]
        public string  Email { get; set; }
        [Required]
        public string  Phone { get; set; }
        [Required]
        public string  Address { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool  Gender { get; set; }
    }
}
