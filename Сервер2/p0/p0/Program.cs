using System;
using System.Text;
using System.ServiceModel;

namespace Server
{
    public class lab5//Сервер 1
    {

        [ServiceContract]
        public interface IMyService
        {
            [OperationContract]
            int GetInt(int Num);

        }
        public class MyService : IMyService
        {
            
            public int GetInt(int Num)
            {
                Console.WriteLine(Num);
                Uri tcpUri = new Uri("http://localhost:8001/MyService");
                EndpointAddress address = new EndpointAddress(tcpUri);
                BasicHttpBinding binding = new BasicHttpBinding();
                ChannelFactory<IMyService> factory = new ChannelFactory<IMyService>(binding, address);
                IMyService service = factory.CreateChannel();
                while (Num > 1)
                    Num = service.GetInt(Num-1);
                Console.WriteLine();
                if (Num == 1)
                    service.GetInt(Num - 1);
                    return 0;
                
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                ServiceHost host = new ServiceHost(typeof(MyService), new Uri("http://localhost:8000/MyService"));
                host.AddServiceEndpoint(typeof(IMyService), new BasicHttpBinding(), "");
                host.Open();
                Console.WriteLine("Сервер1 запущен");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}