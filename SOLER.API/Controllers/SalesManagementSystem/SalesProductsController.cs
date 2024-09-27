using Microsoft.AspNetCore.Mvc;
using SOLER.API.Controllers.FinancialManagementSystem;

namespace SOLER.API.Controllers.SalesManagementSystem
{
    [Route("api/SalesProducts")]
    [ApiController]
    public class SalesProductsController : ControllerBase
    {
        private readonly ISalesProductsService _salesProductsService;
        private readonly ILogger<SalesProductsController> _logger;
        private readonly IMapper _mapper;

        public SalesProductsController(ISalesProductsService salesProductsService, ILogger<SalesProductsController> logger, IMapper mapper)
        {
            _salesProductsService = salesProductsService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SalesProductsDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> Get()
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var (salesProducts, errorMessage) = await _salesProductsService.GetAllSalesProductsAsync();
                if (salesProducts == null || !salesProducts.Any())
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(errorMessage);
                    return response;
                }
                response.Result = salesProducts;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching sales products/loss reports.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching sales products/loss reports.");
            }
            return response;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(SalesProductsDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> Get(int id)
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var (salesProduct, errorMessage) = await _salesProductsService.GetSalesProductByIDAsync(id);
                if (salesProduct == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(errorMessage);
                    return response;
                }
                response.Result = salesProduct;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching sales products/loss reports.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching sales products/loss reports.");
            }
            return response;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> Post([FromBody] CreateSalesProductsDTO salesProducts)
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

                var salesProductsDTO = _mapper.Map<SalesProductsDTO>(salesProducts);
                var (createdId, errorMessage) = await _salesProductsService.CreateSalesProductAsync(salesProductsDTO);
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
                _logger.LogError(ex, "Error creating sales products/loss report.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while creating the sales products/loss report.");
            }
            return response;
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> Put([FromBody] UpdateSalesProductsDTO salesProducts)
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

                var salesProductsDTO = _mapper.Map<SalesProductsDTO>(salesProducts);
                var (success, errorMessage) = await _salesProductsService.UpdateSalesProductAsync(salesProductsDTO);
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
                _logger.LogError(ex, "Error updating sales products/loss report.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while updating the sales products/loss report.");
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
                var (success, errorMessage) = await _salesProductsService.DeleteSalesProductAsync(id);
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
                _logger.LogError(ex, "Error deleting sales products/loss report.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while deleting the sales products/loss report.");
            }
            return response;
        }
    }
}
