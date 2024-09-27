namespace SOLER.API.Controllers.ProcurementManagementSystem
{
    [Route("api/ProcurementProducts")]
    [ApiController]
    public class ProcurementProductsController : ControllerBase
    {
        private readonly IProcurementProductsService _procurementProductsService;
        private readonly ILogger<ProcurementProductsController> _logger;
        private readonly IMapper _mapper;

        public ProcurementProductsController(IProcurementProductsService procurementProductsService, ILogger<ProcurementProductsController> logger, IMapper mapper)
        {
            _procurementProductsService = procurementProductsService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProcurementProductsDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> GET()
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var result = await _procurementProductsService.GetAllProcurementProductsAsync();
                if (result.ProcurementProducts == null || !result.ProcurementProducts.Any())
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.ProcurementProducts;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Procurement Products.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching procurement products.");
            }
            return response;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProcurementProductsDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> GET(int id)
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var result = await _procurementProductsService.GetProcurementProductByIDAsync(id);
                if (result.ProcurementProduct == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.ProcurementProduct;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Procurement Product.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching the procurement product.");
            }
            return response;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> POST([FromBody] CreateProcurementProductsDTO procurementProduct)
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

                var procurementProductDTO = _mapper.Map<ProcurementProductsDTO>(procurementProduct);
                var result = await _procurementProductsService.CreateProcurementProductAsync(procurementProductDTO);
                if (result.ProcurementProductId <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.ProcurementProductId;
                response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Procurement Product.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while creating the procurement product.");
            }
            return response;
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> PUT([FromBody] UpdateProcurementProductsDTO procurementProduct)
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
                var procurementProductDTO = _mapper.Map<ProcurementProductsDTO>(procurementProduct);
                var result = await _procurementProductsService.UpdateProcurementProductAsync(procurementProductDTO);
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
                _logger.LogError(ex, "Error updating Procurement Product.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while updating the procurement product.");
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
                var result = await _procurementProductsService.DeleteProcurementProductAsync(id);
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
                _logger.LogError(ex, "Error deleting Procurement Product.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while deleting the procurement product.");
            }
            return response;
        }
    }
}
