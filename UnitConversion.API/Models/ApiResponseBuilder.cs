namespace UnitConversion.API.Models;

public static class ApiResponseBuilder
{
    public static ApiResponse<T> CreateSuccessResponse<T>(T data, string message = "Operation successful")
    {
        return new ApiResponse<T>
        {
            Success = true,
            Data = data,
            Message = message
        };
    }

    public static ApiResponse<T> CreateErrorResponse<T>(string message, string errorCode)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Data = default,
            Message = message,
            ErrorCode = errorCode
        };
    }
}
