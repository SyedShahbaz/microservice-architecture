using CoordinatorService.Abstraction;
using CoordinatorService.Dto;
using CoordinatorService.Enum;

namespace CoordinatorService.Implementation;

public class DataPublisher : IDataPublisher
{
    private readonly IMessageProducer _messagePublisher;

    public DataPublisher(IMessageProducer messagePublisher)
    {
        _messagePublisher = messagePublisher;
    }

    public Guid PublishData(RequestDto requestDto)
    {
        var order = new OrderDto()
        {
            Id = Guid.NewGuid(),
            Status = StatusEnum.Pending.ToString(),
            ProductName = requestDto.ProductName,
            Price = requestDto.Price,
            Quantity = requestDto.Quantity
        };
        
        _messagePublisher.SendMessage(order);

        return order.Id;
    }
}