using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcGreeter;

namespace GrpcGreeter.Services
{
    public class LogsService : Logs.LogsBase
    {
        private readonly ILogger<LogsService> _logger;
        public LogsService(ILogger<LogsService> logger)
        {
            _logger = logger;
        }

        public override Task<LogsReply> GetLogs(LogsRequest request, ServerCallContext context)
        {
            return Task.FromResult(new LogsReply
            {
                Message = $"Get logs for {request.Type} with status {request.Status} at {request.Timestamp.ToDateTime()}",
                Logs = { 
                    new LogEntry { Id = 1, Message = "Log 1", Timestamp = Timestamp.FromDateTime(DateTime.UtcNow) },
                    new LogEntry { Id = 2, Message = "Log 2", Timestamp = Timestamp.FromDateTime(DateTime.UtcNow) }
                }
            });
        }
    }
}
