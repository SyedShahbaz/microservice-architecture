namespace CoordinatorService.Abstraction;

public interface IMessageProducer
{
    void SendMessage<T> (T message);
}