using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcGreeterClient;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7283");
var client = new Logs.LogsClient(channel);

var reply = await client.GetLogsAsync(
    new LogsRequest { Type = "GreeterClient", Timestamp = Timestamp.FromDateTime(DateTime.UtcNow), Status = 0 });

Console.WriteLine("Request: " + reply.Message);
Console.WriteLine("Reply: " + string.Join(", ", reply.Logs.Select(x => $"{x.Id} - {x.Message} - {x.Timestamp}")));
Console.WriteLine("Press any key to exit...");
Console.ReadKey();