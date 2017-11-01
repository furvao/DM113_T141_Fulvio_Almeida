using EstoqueLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProvedorEstoqueHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost productsServiceHost = new ServiceHost(typeof(ServicoEstoque));
            productsServiceHost.Open();
            Console.WriteLine("Service Running");
            Console.ReadLine();
            Console.WriteLine("Service Stopping");
            productsServiceHost.Close();
        }
    }
}
