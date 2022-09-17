using ProcessorService.Abstraction;

namespace ProcessorService.Implementation;

public class Processor : IProcessor
{
    private readonly IMessageConsumer _messageConsumer;

    public Processor(IMessageConsumer messageConsumer)
    {
        _messageConsumer = messageConsumer;
    }

    public void Process()
    {
        _messageConsumer.Consume();
    }
}