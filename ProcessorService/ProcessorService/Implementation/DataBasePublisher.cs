using CoordinatorService.Dto;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using ProcessorService.Abstraction;

namespace ProcessorService.Implementation;

public class DataBasePublisher : IDataBasePublisher
{
    private const string AuthSecret = "";
    private const string BasePath = "";
    private readonly FirebaseClient _firebaseClient;
    
    public DataBasePublisher()
    {
        IFirebaseConfig firebaseConfig = new FirebaseConfig()
        {
            AuthSecret = AuthSecret,
            BasePath = BasePath
        };
        
        _firebaseClient = new FirebaseClient(firebaseConfig);
    }

    public void Publish(OrderDto? order)
    {
        _firebaseClient.SetAsync("Test/" + order!.Id , order);
    }
}