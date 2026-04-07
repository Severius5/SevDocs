namespace SevDocs.Client.Providers
{
    public class ApiResponse
    {
        public ICollection<ApiError> Errors { get; init; } = [];
        public bool IsError { get; init; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Result { get; init; }
    }
}
