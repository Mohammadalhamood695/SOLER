namespace SOLER.API.Controllers.InvoiceManagementSystem
{
    [Route("api/Invoices")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoicesService _invoicesService;
        private readonly ILogger<InvoicesController> _logger;
        private readonly IMapper _mapper;

        public InvoicesController(IInvoicesService invoicesService, ILogger<InvoicesController> logger, IMapper mapper)
        {
            _invoicesService = invoicesService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InvoicesDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> GET()
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var result = await _invoicesService.GetAllInvoicesAsync();
                if (result.Invoices == null || !result.Invoices.Any())
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.Invoices;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching invoices/loss reports.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching invoices/loss reports.");
            }
            return response;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(InvoicesDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> GET(int id)
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var result = await _invoicesService.GetInvoiceByIDAsync(id);
                if (result.Invoice == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.Invoice;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching invoices/loss reports.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching invoices/loss reports.");
            }
            return response;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> POST([FromBody] CreateInvoicesDTO invoices)
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

                var invoicesDTO = _mapper.Map<InvoicesDTO>(invoices);
                var result = await _invoicesService.CreateInvoiceAsync(invoicesDTO);
                if (result.InvoiceId <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.InvoiceId;
                response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating invoice/loss report.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while creating the invoice/loss report.");
            }
            return response;
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> PUT([FromBody] UpdateInvoicesDTO invoices)
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

                var invoicesDTO = _mapper.Map<InvoicesDTO>(invoices);
                var result = await _invoicesService.UpdateInvoiceAsync(invoicesDTO);
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
                _logger.LogError(ex, "Error updating invoice/loss report.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while updating the invoice/loss report.");
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
                var result = await _invoicesService.DeleteInvoiceAsync(id);
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
                _logger.LogError(ex, "Error deleting invoice/loss report.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while deleting the invoice/loss report.");
            }
            return response;
        }
    }
}
