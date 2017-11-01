using EstoqueClientV2.StockService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueClientV2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();



            ServicoEstoqueV2Client proxy = new ServicoEstoqueV2Client("WS2007HttpBinding_IServicoEstoque");

            //1 - Verificar o estoque atual do Produto 1
            Console.WriteLine("Verificar o estoque atual do Produto 3");
            Console.WriteLine("");

            int stockQty = proxy.CheckStock("3000");
            Console.WriteLine("Id produto: 3000");
            Console.WriteLine("Quantidade produto: " + stockQty);
            Console.WriteLine("");

            
            //2) Adicionar 30 unidades para este produto
            Console.WriteLine("Adicionar 30 unidades para este produto");
            Console.WriteLine("");
            bool addStock = proxy.AddStock("3000", 30);
            if (addStock)
            {
                Console.WriteLine("Estoque adicionado!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Erro ao adicionar estoque!");
                Console.WriteLine("");

            }
            
            //3 - Verificar o estoque do Produto 3 novamente
            Console.WriteLine("Verificar o estoque do Produto 3 novamente");
            Console.WriteLine("");
            stockQty = proxy.CheckStock("3000");
            Console.WriteLine("Id produto: 3000");
            Console.WriteLine("Quantidade produto: " + stockQty);
            Console.WriteLine("");

            
            //4 - Verificar o estoque atual do Produto 4
            Console.WriteLine("Verificar o estoque atual do Produto 4");
            Console.WriteLine("");
            stockQty = proxy.CheckStock("4000");
            Console.WriteLine("Id produto: 4000");
            Console.WriteLine("Quantidade produto: " + stockQty);
            Console.WriteLine("");
            
            //5) Remover 15 unidades para este produto
            Console.WriteLine("Remover 15 unidades para este produto");
            Console.WriteLine("");
            addStock = proxy.RemoveStock("4000", 15);
            if (addStock)
            {
                Console.WriteLine("Estoque removido!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Erro ao remover estoque!");
                Console.WriteLine("");

            }
            
            //6) Verificar o estoque do Produto 4 novamente
            Console.WriteLine("Verificar o estoque do Produto 4 novamente");
            Console.WriteLine("");

            stockQty = proxy.CheckStock("4000");
            Console.WriteLine("Id produto: 4000");
            Console.WriteLine("Quantidade produto: " + stockQty);
            Console.WriteLine("");
            


            proxy.Close();
            Console.WriteLine("Press ENTER to finish"); Console.ReadLine();


        }
    }
}
