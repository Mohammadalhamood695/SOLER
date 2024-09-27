
namespace SOLER.API.Repository
{
    public abstract class BaseRepository
    {
        protected readonly string _connectionString;
        protected readonly ILogger _logger;

        protected BaseRepository(IConfiguration configuration, ILogger logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected async Task<(T? Result, string Message)> ExecuteStoredProcedureAsync<T>(string storedProcedure, DynamicParameters parameters, bool expectMultipleResults = false)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                await sqlConnection.OpenAsync();
                try
                {
                    if (expectMultipleResults)
                    {
                        // إذا كنا نتوقع قائمة من النتائج
                        var result = await sqlConnection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                        return ((T)(object)result, "Operation completed successfully.");
                    }
                    else
                    {
                        // إذا كنا نتوقع نتيجة واحدة فقط
                        T? result = await sqlConnection.QuerySingleOrDefaultAsync<T?>(storedProcedure, parameters, commandType: CommandType.StoredProcedure, commandTimeout: 30);
                        return (result, "Operation completed successfully.");
                    }
                }
                catch (SqlException sqlException)
                {
                    _logger.LogError(sqlException, $"Database error occurred while executing {storedProcedure}.");
                    return (default!, "Database error: Unable to complete the operation. Please try again later.");
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    _logger.LogError(invalidOperationException, $"Invalid operation error occurred while executing {storedProcedure}.");
                    return (default!, "Operation error: Unable to complete the operation. Please try again later.");
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception, "An unexpected error occurred.");
                    return (default!, "Unexpected error: Please try again later.");
                }
            }
        }
    }
}
