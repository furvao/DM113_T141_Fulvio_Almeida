using EstoqueEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace EstoqueLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01", Name = "IServicoEstoque")]
    public interface IServicoEstoque
    {
        
        [OperationContract]
        List<string> ListProducts();
        
        [OperationContract]
        bool AddProduct(Stock stock);
        
        [OperationContract]
        bool RemoveProducts(string productCode);
        
        [OperationContract]
        int CheckStock(string productCode);
        
        [OperationContract]
        bool AddStock(string productCode, int quantity);
        
        [OperationContract]
        bool RemoveStock(string productCode, int quantity);
        
        [OperationContract]
        StockData getProduct(string productCode);

    }

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02", Name = "IServicoEstoqueV2")]
    public interface IServicoEstoqueV2
    {
 
        [OperationContract]
        int CheckStock(string productCode);
       
        [OperationContract]
        bool AddStock(string productCode, int quantity);
        
        [OperationContract]
        bool RemoveStock(string productCode, int quantity);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "EstoqueLibrary.ContractType".
    [DataContract]
    public class StockData
    {
        [DataMember]
        public string ProductId { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string ProductDesc { get; set; }
        [DataMember]
        public decimal Quantity { get; set; }

    }
}
