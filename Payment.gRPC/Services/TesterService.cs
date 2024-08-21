using Grpc.Core;

namespace Payment.gRPC.Services;

public class TesterService : Tester.TesterBase
{
    private readonly ILogger<TesterService> _logger;

    public TesterService (ILogger<TesterService> logger)
    {
        _logger = logger;
    }

    public override Task<TestReply> SayHello (TestRequest request, ServerCallContext context)
    {
        return Task.FromResult(
            new TestReply
            {
                Message = "Hello " + request.Name
            });
    }
}