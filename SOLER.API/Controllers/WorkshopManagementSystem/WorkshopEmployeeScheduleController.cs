using Microsoft.AspNetCore.Mvc;
using SOLER.API.Controllers.WorkshopManagementSystem;

namespace SOLER.API.Controllers.WorkshopManagementSystem
{
    [Route("api/WorkshopEmployeeSchedule")]
    [ApiController]
    public class WorkshopEmployeeScheduleController : ControllerBase
    {
        private readonly IWorkshopEmployeeScheduleService _workshopEmployeeScheduleService;
        private readonly ILogger<WorkshopEmployeeScheduleController> _logger;
        private readonly IMapper _mapper;

        public WorkshopEmployeeScheduleController(IWorkshopEmployeeScheduleService workshopEmployeeScheduleService, ILogger<WorkshopEmployeeScheduleController> logger, IMapper mapper)
        {
            _workshopEmployeeScheduleService = workshopEmployeeScheduleService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WorkshopEmployeeScheduleDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> Get()
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var (schedules, errorMessage) = await _workshopEmployeeScheduleService.GetAllWorkshopEmployeeSchedulesAsync();
                if (schedules == null || !schedules.Any())
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(errorMessage);
                    return response;
                }
                response.Result = schedules;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching WorkshopEmployeeSchedule/loss reports.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching WorkshopEmployeeSchedule/loss reports.");
            }
            return response;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(WorkshopEmployeeScheduleDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> Get(int id)
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var (schedule, errorMessage) = await _workshopEmployeeScheduleService.GetWorkshopEmployeeScheduleByIDAsync(id);
                if (schedule == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(errorMessage);
                    return response;
                }
                response.Result = schedule;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching WorkshopEmployeeSchedule/loss reports.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching WorkshopEmployeeSchedule/loss reports.");
            }
            return response;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> Post([FromBody] CreateWorkshopEmployeeScheduleDTO workshopEmployeeSchedule)
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                if (!ModelState.IsValid)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Invalid model.");
                    return response;
                }

                var workshopEmployeeScheduleDTO = _mapper.Map<WorkshopEmployeeScheduleDTO>(workshopEmployeeSchedule);
                var (createdId, errorMessage) = await _workshopEmployeeScheduleService.CreateWorkshopEmployeeScheduleAsync(workshopEmployeeScheduleDTO);
                if (createdId <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(errorMessage);
                    return response;
                }

                response.Result = createdId;
                response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating WorkshopEmployeeSchedule/loss report.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while creating the WorkshopEmployeeSchedule/loss report.");
            }
            return response;
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> Put([FromBody] UpdateWorkshopEmployeeScheduleDTO workshopEmployeeSchedule)
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                if (!ModelState.IsValid)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Invalid model.");
                    return response;
                }

                var workshopEmployeeScheduleDTO = _mapper.Map<WorkshopEmployeeScheduleDTO>(workshopEmployeeSchedule);
                var (success, errorMessage) = await _workshopEmployeeScheduleService.UpdateWorkshopEmployeeScheduleAsync(workshopEmployeeScheduleDTO);
                if (!success)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(errorMessage);
                    return response;
                }

                response.Result = success;
                response.StatusCode = HttpStatusCode.OK; // Updated to OK instead of Created
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating WorkshopEmployeeSchedule/loss report.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while updating the WorkshopEmployeeSchedule/loss report.");
            }
            return response;
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> Delete(int id)
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var (success, errorMessage) = await _workshopEmployeeScheduleService.DeleteWorkshopEmployeeScheduleAsync(id);
                if (!success)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(errorMessage);
                    return response;
                }

                response.Result = success;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting WorkshopEmployeeSchedule/loss report.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while deleting the WorkshopEmployeeSchedule/loss report.");
            }
            return response;
        }
    }
}
