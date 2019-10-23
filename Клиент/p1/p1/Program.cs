using System;
using System.ServiceModel;

namespace Client
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        int GetInt(int Num);
    }
    class Program
    {
        static void Main(string[] args)
        {
            Uri tcpUri = new Uri("http://localhost:8000/MyService");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IMyService> factory = new ChannelFactory<IMyService>(binding, address);
            IMyService service = factory.CreateChannel();
            Console.WriteLine(service.GetInt(int.Parse(Console.ReadLine())));           
            Console.ReadLine();
        }
    }
}
