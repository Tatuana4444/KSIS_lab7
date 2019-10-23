using System;
using System.Text;
// Обратите внимание, данную библиотеку нужно будет подключить
using System.ServiceModel;

namespace Server
{
    public class lab5//Сервер 2
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
                Uri tcpUri = new Uri("http://localhost:8000/MyService");
                EndpointAddress address = new EndpointAddress(tcpUri);
                BasicHttpBinding binding = new BasicHttpBinding();
                ChannelFactory<IMyService> factory = new ChannelFactory<IMyService>(binding, address);
                IMyService service = factory.CreateChannel();
                while (Num > 0)
                    Num = service.GetInt(Num - 1);
                Console.WriteLine();
                return 0;
                
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                ServiceHost host = new ServiceHost(typeof(MyService), new Uri("http://localhost:8001/MyService"));
                host.AddServiceEndpoint(typeof(IMyService), new BasicHttpBinding(), "");
                host.Open();
                Console.WriteLine("Сервер2 запущен");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}