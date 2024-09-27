namespace SOLER.API.BusinessLayer.ServiceHRManagementSystem
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository<PersonDTO> _personRepository;
        private readonly ILogger<PersonService> _logger;
        public PersonService(
            IPersonRepository<PersonDTO> personRepository,
            ILogger<PersonService> logger)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<(int PersonId, string Message)> CreatePersonAsync(PersonDTO personDTO)
        {
            try
            {
                return await _personRepository.CreatePersonAsync(personDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating person in service layer.");
                return (0, "An error occurred while creating the person.");
            }
        }
        public async Task<(bool Success, string Message)> DeletePersonAsync(int personID)
        {
            try
            {
                return await _personRepository.DeletePersonAsync(personID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting person with ID {personID} in service layer.");
                return (false, "An error occurred while deleting the person.");
            }
        }
        public async Task<(IEnumerable<PersonDTO> Persons, string Message)> GetAllPersonsAsync()
        {
            try
            {
                return await _personRepository.GetAllPersonsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all persons in service layer.");
                return (null, "An error occurred while retrieving all persons.");
            }
        }
        public async Task<(PersonDTO? Person, string Message)> GetPersonByIDAsync(int personID)
        {
            try
            {
                return await _personRepository.GetPersonByIDAsync(personID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving person with ID {personID} in service layer.");
                return (null, "An error occurred while retrieving the person.");
            }
        }
        public async Task<(bool Success, string Message)> UpdatePersonAsync(PersonDTO personDTO)
        {
            try
            {
                return await _personRepository.UpdatePersonAsync(personDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating person in service layer.");
                return (false, "An error occurred while updating the person.");
            }
        }
    }
}
