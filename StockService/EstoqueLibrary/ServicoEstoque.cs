using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EstoqueEntityModel;

namespace EstoqueLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ServicoEstoque : IServicoEstoque, IServicoEstoqueV2
    {
        public bool AddProduct(Stock product)
        {
            try { 
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    if (ProductExists(product.ProductId, database))
                        return false;
                    else
                    {
                        database.Stocks.Add(product);
                        database.SaveChanges();
                    }
                }

            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool AddStock(string productCode, int quantity)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    if (!ProductExists(productCode, database))
                        return false;
                    else
                    { 
                        Stock stockOrigin = database.Stocks.First(pi => pi.ProductId == productCode);
                        Stock stockUpdated = stockOrigin;
                        stockUpdated.Quantity = stockOrigin.Quantity+quantity;
                        database.Entry(stockOrigin).CurrentValues.SetValues(stockUpdated);
                        database.SaveChanges();
                    }
                }

            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public int CheckStock(string productCode)
        {

            int quantityTotal = 0;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    if (ProductExists(productCode, database))
                    {
                        quantityTotal = (from p in database.Stocks
                                         where String.Compare(p.ProductId, productCode) == 0
                                         select (int)p.Quantity).Sum();
                    }
                    
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return quantityTotal;
        }

        public StockData getProduct(string productCode)
        {
            StockData product = null;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    if (ProductExists(productCode, database))
                    {
                        Stock matchingProduct = database.Stocks.First(p => String.Compare(p.ProductId, productCode) == 0);
                        product = new StockData()
                        {
                            ProductName = matchingProduct.ProductName,
                            ProductDesc = matchingProduct.ProdcutDesc,
                            Quantity = matchingProduct.Quantity

                        };
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return product;
        }

        public List<string> ListProducts()
        {
            List<string> products = new List<string>();
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                     products = (from product in database.Stocks select product.ProductName).ToList();
                   
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return products;
        }

        public bool RemoveProducts(string productCode)
        {

            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    if (!ProductExists(productCode, database))
                        return false;
                    else
                    {
                        Stock stock = database.Stocks.First(pi => pi.ProductId == productCode);
                        database.Stocks.Remove(stock);
                        database.SaveChanges();
                    }
                }

            }
            catch(Exception e)
            {
                return false;
            }
            return true;

        }

        public bool RemoveStock(string productCode, int quantity)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    if (!ProductExists(productCode, database))
                        return false;
                    else
                    {
                        Stock stockOrigin = database.Stocks.First(pi => pi.ProductId == productCode);
                        Stock stockUpdated = stockOrigin;


                        if (quantity > stockOrigin.Quantity)
                            return false;

                        stockUpdated.Quantity = stockOrigin.Quantity - quantity;
                        database.Entry(stockOrigin).CurrentValues.SetValues(stockUpdated);
                        database.SaveChanges();

                    }
                }

            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool ProductExists(string productCode, ProvedorEstoque database)
        {
            int numProducts = (from p in database.Stocks
                               where string.Equals(p.ProductId, productCode)
                               select p).Count();
            return numProducts > 0;
        }

    }
}
