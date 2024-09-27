namespace SOLER.API.Controllers.ProductManagementSystem
{
    [Route("api/Categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesService categoriesService, ILogger<CategoriesController> logger, IMapper mapper)
        {
            _categoriesService = categoriesService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoriesDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> GET()
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var result = await _categoriesService.GetAllCategoriesAsync();
                if (result.Categories == null || !result.Categories.Any())
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.Categories;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching categories.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching categories.");
            }
            return response;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(CategoriesDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> GET(int id)
        {
            APIResponseDTO response = new APIResponseDTO();
            try
            {
                var result = await _categoriesService.GetCategoryByIDAsync(id);
                if (result.Category == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.Category;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching category.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while fetching the category.");
            }
            return response;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> POST([FromBody] CreateCategoriesDTO categories)
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

                var categoriesDTO = _mapper.Map<CategoriesDTO>(categories);
                var result = await _categoriesService.CreateCategoryAsync(categoriesDTO);
                if (result.CategoryId <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(result.Message);
                    return response;
                }
                response.Result = result.CategoryId;
                response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating category.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while creating the category.");
            }
            return response;
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<APIResponseDTO> PUT([FromBody] UpdateCategoriesDTO categories)
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

                var categoriesDTO = _mapper.Map<CategoriesDTO>(categories);
                var result = await _categoriesService.UpdateCategoryAsync(categoriesDTO);
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
                _logger.LogError(ex, "Error updating category.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while updating the category.");
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
                var result = await _categoriesService.DeleteCategoryAsync(id);
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
                _logger.LogError(ex, "Error deleting category.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while deleting the category.");
            }
            return response;
        }
    }
}
