using System.Collections.Generic;

namespace lab4
{
    public abstract class Resource
    {
        public abstract void CreateStore(string name);

        public abstract void CreateProduct(string productName, string store, float price);

        public abstract void DeliverShipment(List<Shipment> shipments, string store);

        public abstract List<string> FindCheapestProductStore(string productName);

        public abstract List<string> GetProductsInfo(string store);

        public abstract void DecreaseCount(string product, string store, int count);

        public abstract List<string> GetStoresList();
    }

    public abstract class Connector
    {
        public abstract Resource Create();
    }
    
    public class DBConnector: Connector
    {
        public override Resource Create()
        {
            return new MySQLDAO("localhost", 3306, "storeinfo", "root", "password");
        }
    }
    
    public class FileConnector: Connector
    {
        public override Resource Create()
        {
            return new FileDAO(@"/Users/anastasia/Desktop/ООП/lab4/lab4/stores.txt", @"/Users/anastasia/Desktop/ООП/lab4/lab4/products.txt");
        }
    }
}