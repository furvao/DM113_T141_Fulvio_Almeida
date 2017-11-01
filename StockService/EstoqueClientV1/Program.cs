using EstoqueClientV1.StockService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueClientV1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");
            
            //1 - Adicionar um produto 20
            Console.WriteLine("Add Product");
            Console.WriteLine("");
            Stock product = new Stock();
            product.ProductId = "20000";
            product.ProductName = "Product 20";
            product.ProdcutDesc = "Este é o produto 20";
            product.Quantity = 0;
            Console.WriteLine("ProductId: " + product.ProductId);
            Console.WriteLine("ProductName: " + product.ProductName);
            Console.WriteLine("ProductDesc: " + product.ProdcutDesc);
            bool addProduct = proxy.AddProduct(product);

            if (addProduct)
            {
                Console.WriteLine("Product Added!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Error to Add Product!");
                Console.WriteLine("");

            }

        
            //2 - Remover o produto 20
            Console.WriteLine("Remove product 20");
            Console.WriteLine("");
            bool removeProd = proxy.RemoveProducts("20000");
            if (removeProd)
            {
                Console.WriteLine("Product deleted!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Error to delete product!");
                Console.WriteLine("");

            }

            
            //3 - Listar todos os produtos
            Console.WriteLine("List Products");
            Console.WriteLine("");

            List<string> products = proxy.ListProducts().ToList();
            foreach (string p in products)
            {
                Console.WriteLine("Product: {0}", p);
            }
            Console.WriteLine();


            //4 -  Verificar todas as informações do Produto 1
            Console.WriteLine("Verify Product 1 Info");
            Console.WriteLine("");
            StockData stock = proxy.getProduct("1000");
            if (stock != null)
            {
                Console.WriteLine("ProductId: 1000");
                Console.WriteLine("ProductName: " + stock.ProductName);
                Console.WriteLine("ProductDesc: " + stock.ProductDesc);
                Console.WriteLine("Quantity: " + stock.Quantity);
                Console.WriteLine("");
            }

            else
            {
                Console.WriteLine("Error to find product!");
                Console.WriteLine("");
            }
            
            //5 - Add 20 units on product
            Console.WriteLine("Add 20 units on product");
            Console.WriteLine("");

            bool addStock = proxy.AddStock("2000", 20);
            if (addStock)
            {
                Console.WriteLine("Stock added!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Error to add stock!");
                Console.WriteLine("");

            }
            
            //6 - Verify stock of product 2
            Console.WriteLine(" Verify stock of product 2");
            Console.WriteLine("");

            int stockQty = proxy.CheckStock("2000");
            Console.WriteLine("ProductId: 2000");
            Console.WriteLine("Quantity: " + stockQty);
            Console.WriteLine("");


            //7 - Verify stock of product 1
            Console.WriteLine("Verify stock of product 1");
            Console.WriteLine("");

            stockQty = proxy.CheckStock("1000");
            Console.WriteLine("ProductId: 1000");
            Console.WriteLine("Quantity: " + stockQty);
            Console.WriteLine("");

            
            //8 - Remove 10 units
            Console.WriteLine("Remove 10 units");
            Console.WriteLine("");
            addStock = proxy.RemoveStock("1000", 10);
            if (addStock)
            {
                Console.WriteLine("Stock removed!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Error to remove stock!");
                Console.WriteLine("");

            }

            //9 - Verify stock of product 1 again
            Console.WriteLine("Verify stock of product 1 again");
            Console.WriteLine("");

            stockQty = proxy.CheckStock("1000");
            Console.WriteLine("ProductId: 1000");
            Console.WriteLine("Quantity: " + stockQty);
            Console.WriteLine("");

            //10 - Verify stock of product 1
            Console.WriteLine("Verify stock of product 1");
            Console.WriteLine("");

            stock = proxy.getProduct("1000");
            if (stock != null)
            {
                Console.WriteLine("ProductId: 1000");
                Console.WriteLine("ProductName: " + stock.ProductName);
                Console.WriteLine("ProductDesc: " + stock.ProductDesc);
                Console.WriteLine("Quantity: " + stock.Quantity);
                Console.WriteLine("");
            }

            proxy.Close();
            Console.WriteLine("Press ENTER to finish"); Console.ReadLine();
        }
    }
}
