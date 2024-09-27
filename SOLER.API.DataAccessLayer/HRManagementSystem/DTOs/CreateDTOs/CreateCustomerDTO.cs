using System.ComponentModel.DataAnnotations;

namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs.CreateDTOs
{
    public class CreateCustomerDTO
    {

        [Required]
        public DateTime? RegistrationDate { get; set; }
        [Required]
        public string? PreferredContactMethod { get; set; }
        [Required]
        public bool? IsVIP { get; set; }
    }
}
