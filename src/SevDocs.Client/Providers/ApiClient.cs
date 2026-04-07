using MudBlazor;
using System.Net.Http.Json;

namespace SevDocs.Client.Providers
{
    internal class ApiClient(HttpClient httpClient, ISnackbar snackbar)
    {
        public async Task<ApiResponse> GetAsync(string endpoint)
        {
            using var response = await httpClient.GetAsync(endpoint);
            return await GetResult(response);
        }

        public async Task<ApiResponse<TResult>> PostAsync<TResult>(string endpoint, object request, CancellationToken ct = default)
        {
            using var response = await httpClient.PostAsJsonAsync(endpoint, request, ct);
            return await GetResult<TResult>(response);
        }

        private async Task<ApiResponse<TResult>> GetResult<TResult>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return new ApiResponse<TResult>
                {
                    Result = await response.Content.ReadFromJsonAsync<TResult>()
                };
            }

            return new ApiResponse<TResult>
            {
                Errors = await GetApiErrors(response),
                IsError = true
            };
        }

        private async Task<ApiResponse> GetResult(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return new ApiResponse();

            return new ApiResponse
            {
                Errors = await GetApiErrors(response),
                IsError = true
            };
        }

        private async Task<ICollection<ApiError>> GetApiErrors(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new InvalidOperationException("Endpoint doesnt exists.");

            var problem = await response.Content.ReadFromJsonAsync<ProblemDetails>();
            if (problem.Status != 400)
                snackbar.Add(problem.Detail ?? problem.Title, Severity.Error);

            return problem.Errors ?? [];
        }

        private record ProblemDetails(string Type, string Title, int Status, string Instance, string TraceId, string Detail, List<ApiError> Errors);
    }
}
