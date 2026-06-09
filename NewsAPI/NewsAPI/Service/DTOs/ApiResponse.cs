namespace NewsAPI.Service.DTOs
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
        public PaginationDTO Pagination { get; set; }

        public static ApiResponse<T> Ok(T data, PaginationDTO pagination = null)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Pagination = pagination
            };
        }

        public static ApiResponse<T> Fail(string message)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message
            };
        }
    }
}
