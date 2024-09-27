namespace SOLER.API.Controllers.MaintenanceManagementSystem
{
    [Route("api/MaintenanceOperation")]
    [ApiController]
    public class MaintenanceOperationController : ControllerBase
    {
        private readonly IMaintenanceOperationService _maintenanceOperationService;
        private readonly ILogger<MaintenanceOperationController> _logger;
        private readonly IMapper _mapper;

        public MaintenanceOperationController(IMaintenanceOperationService maintenanceOperationService, ILogger<MaintenanceOperationController> logger, IMapper mapper)
        {
            _maintenanceOperationService = maintenanceOperationService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MaintenanceOperationDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> GET()
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var result = await _maintenanceOperationService.GetAllMaintenanceOperationsAsync();
                if (result.MaintenanceOperations == null || !result.MaintenanceOperations.Any())
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.MaintenanceOperations;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Maintenance Operations.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching maintenance operations.");
            }
            return response;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(MaintenanceOperationDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> GET(int id)
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var result = await _maintenanceOperationService.GetMaintenanceOperationByIDAsync(id);
                if (result.MaintenanceOperation == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.MaintenanceOperation;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Maintenance Operation.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching maintenance operation.");
            }
            return response;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> POST([FromBody] CreateMaintenanceOperationDTO maintenanceOperation)
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

                var maintenanceOperationDTO = _mapper.Map<MaintenanceOperationDTO>(maintenanceOperation);
                var result = await _maintenanceOperationService.CreateMaintenanceOperationAsync(maintenanceOperationDTO);
                if (result.MaintenanceOperationId <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.MaintenanceOperationId;
                response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Maintenance Operation.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while creating the maintenance operation.");
            }
            return response;
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> PUT([FromBody] UpdateMaintenanceOperationDTO maintenanceOperation)
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

                var maintenanceOperationDTO = _mapper.Map<MaintenanceOperationDTO>(maintenanceOperation);
                var result = await _maintenanceOperationService.UpdateMaintenanceOperationAsync(maintenanceOperationDTO);
                if (!result.Success)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.Success;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Maintenance Operation.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while updating the maintenance operation.");
            }
            return response;
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> DELETE(int id)
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var result = await _maintenanceOperationService.DeleteMaintenanceOperationAsync(id);
                if (!result.Success)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }

                response.Result = result.Success;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting Maintenance Operation.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while deleting the maintenance operation.");
            }
            return response;
        }
    }
}
