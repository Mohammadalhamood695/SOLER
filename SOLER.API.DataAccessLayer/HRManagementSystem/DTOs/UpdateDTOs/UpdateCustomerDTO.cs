using System.ComponentModel.DataAnnotations;
namespace SOLER.API.DataAccessLayer.HRManagementSystem.DTOs.UpdateDTOs
{
    public class UpdateCustomerDTO
    {
        [Required]
        public int? CustomerID { get; set; }
        [Required]
        public DateTime? RegistrationDate { get; set; }
        [Required]
        public string? PreferredContactMethod { get; set; }
        [Required]
        public bool? IsVIP { get; set; }
    }
}
