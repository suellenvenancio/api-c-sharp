namespace LibraryApi.Errors
{
    public class ApiError
    {
       
        public string Message { get; set; }
        public string Details { get; set; }

         public string StatusCode { get; set; }

        public ApiError(string message, string statusCode, string? details)
        {
            Message = message;
            StatusCode = statusCode;
            Details = details;
        
        }
    }
}