using CoordinatorService.Dto;

namespace ProcessorService.Abstraction;

public interface IDataBasePublisher
{
    void Publish(OrderDto? order);
}