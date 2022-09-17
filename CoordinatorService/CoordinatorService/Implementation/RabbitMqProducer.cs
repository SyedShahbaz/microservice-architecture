using System.Text;
using CoordinatorService.Abstraction;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace CoordinatorService.Implementation;

public class RabbitMqProducer : IMessageProducer, IDisposable
{
    private readonly IModel? _channel;
    
    public RabbitMqProducer()
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        var connection = factory.CreateConnection();
        
        _channel = connection.CreateModel();
        _channel.QueueDeclare("orders", exclusive: false);
    }
    
    public void SendMessage<T>(T message)
    {
        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        _channel.BasicPublish(exchange: "", routingKey: "orders", body: body);
    }

    public void Dispose()
    {
        _channel?.Dispose();
    }
}