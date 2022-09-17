// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using ProcessorService;
using ProcessorService.Abstraction;

public class Program
{
    private static readonly System.IServiceProvider Container = new ContainerBuilder().Build();
    
    static void Main(string[] args)
    {
        Container.GetServices<IProcessor>().ToList().ForEach(p => p.Process());
    }
}
