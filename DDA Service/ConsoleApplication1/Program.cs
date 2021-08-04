using System;
using System.ServiceModel;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost host = new ServiceHost(typeof(Service.Service));
            host.Open();            

            Console.WriteLine("Service Open");
            Console.ReadLine();

            host.Close();
        }
    }
}
