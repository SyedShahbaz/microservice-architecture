using Microsoft.Extensions.DependencyInjection;
using ProcessorService.Abstraction;
using ProcessorService.Implementation;

namespace ProcessorService;

public class ContainerBuilder
{
    public IServiceProvider Build()
    {
        var container = new ServiceCollection();

        container.AddSingleton<IProcessor, Processor>();
        container.AddSingleton<IMessageConsumer, MessageConsumer>();
        container.AddSingleton<IDataBasePublisher, DataBasePublisher>();
        
        return container.BuildServiceProvider();
    }
}