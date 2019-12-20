using System.Configuration;

namespace lab4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var storage = ConfigurationManager.AppSettings.Get("storage");
            Client client = new Client(storage == "database");
            client.addStores();
            client.addProducts();
            client.DeliverShipment();
            client.BuyingOportunity();
            client.buyShipment();

            Client client1 = new Client(true);
            client1.addStores();
            client1.addProducts();
            client1.DeliverShipment();
            client1.FindCheapestStoreForProduct();
            client1.BuyingOportunity();
            client1.cheapestStore();
        }
    }
}