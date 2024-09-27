namespace SOLER.API.Controllers.HRManagementSystem
{
    [Route("api/Supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly ILogger<SupplierController> _logger;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierService supplierService, ILogger<SupplierController> logger, IMapper mapper)
        {
            _supplierService = supplierService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SupplierDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> GET()
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var result = await _supplierService.GetAllSuppliersAsync();
                if (result.Suppliers == null || !result.Suppliers.Any())
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.Suppliers;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Supplier/loss reports.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching Supplier/loss reports.");
            }
            return response;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(SupplierDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> GET(int id)
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var result = await _supplierService.GetSupplierByIDAsync(id);
                if (result.Supplier == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.Supplier;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Supplier/loss reports.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching Supplier/loss reports.");
            }
            return response;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> POST([FromBody] CreateSupplierDTO supplier)
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

                var supplierDTO = _mapper.Map<SupplierDTO>(supplier);
                var result = await _supplierService.CreateSupplierAsync(supplierDTO);
                if (result.SupplierId <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.SupplierId;
                response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Supplier/loss report.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while creating the Supplier/loss report.");
            }
            return response;
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> PUT([FromBody] UpdateSupplierDTO supplier)
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

                var supplierDTO = _mapper.Map<SupplierDTO>(supplier);
                var result = await _supplierService.UpdateSupplierAsync(supplierDTO);
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
                _logger.LogError(ex, "Error updating Supplier/loss report.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while updating the Supplier/loss report.");
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
                var result = await _supplierService.DeleteSupplierAsync(id);
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
                _logger.LogError(ex, "Error deleting Supplier/loss report.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while deleting the Supplier/loss report.");
            }
            return response;
        }
    }
}
