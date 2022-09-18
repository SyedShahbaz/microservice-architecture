using System.Text;
using CoordinatorService.Dto;
using CoordinatorService.Enum;
using Newtonsoft.Json;
using ProcessorService.Abstraction;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ProcessorService.Implementation;

public class MessageConsumer : IMessageConsumer, IDisposable
{
    private readonly EventingBasicConsumer _consumer;
    private readonly IModel _channel;
    private readonly IDataBasePublisher _dataBasePublisher;
    
    public MessageConsumer(IDataBasePublisher dataBasePublisher)
    {
        _dataBasePublisher = dataBasePublisher;
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();
        _channel.QueueDeclare("orders", exclusive: false);
        _consumer = new EventingBasicConsumer(_channel);
    }
    
    public void Consume()
    {
        _consumer.Received += (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine($"Message received: {message}"); 
            _dataBasePublisher.Publish(ProcessorOrder(message));
        };

        _channel.BasicConsume(queue: "orders", autoAck: true, consumer: _consumer);
        Console.ReadKey();
    }

    private static OrderDto ProcessorOrder(string message)
    {
        var order = JsonConvert.DeserializeObject<OrderDto>(message);
        order!.Status =  order.Quantity > 1 ? StatusEnum.Approved.ToString() : StatusEnum.Declined.ToString();

        return order;
    }

    public void Dispose() => _channel.Dispose();
}