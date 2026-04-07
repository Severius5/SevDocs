namespace SevDocs.Features
{
    public class TestEndpoint : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Get("test");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await Task.Delay(10);
        }
    }
}
